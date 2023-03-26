using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;

class Asia
{
    static object monitor = new object();

    //initialize variables
    public int _totalPopulation = 4000;
    public int _uninfected = 3990;
    public int _infected = 10;
    public int _dead = 0;

    //upgrade variables
    public int _points = 0;
    public int _upgPoints = 0; //este contador sirve para ir contando que cada 5% se le den puntos 
    public double _lvlmortality;//1.00 es el mx sea va subiendo de 0.01 en 0.01
    public bool _upgMortalityLvl = false; // !What is this for?
    public bool _upgSpreadLvl = false; // !What is this for?
    public int _pneededMort = 1;//cantidad de puntos que necesita para upgrade mortality lvl
    public int _pneededSpread = 1;//cantidad de puntos que necesita para upgrade spread lvl 

    //virus spread variables
    public double _lvltransmissionRate; //1.00 es el max se va subiendo de 0.01 en 0.01
    public int _durationOfInfectivity = 14; //representing the number of days an individual remains infectious
    public int _numContactsPerDay = 2; //representing the number of contacts an individual has per day.
    public double _Curefund = 0.34; //infected * _curedFund
    public int _contDays = 0; //To count days till vaccine goes into development 

    //climate variables
    public double HeatRate = 0.0;
    public double ColdRate = 0.0;
    public double lvlVirusHeatResistance = 0.0;
    public double lvlVirusColdResistance = 0.0;

    /**
    ** Level of heat resistance should be higher than the heat rate to be able to spread more efectively
    ** same for cold resistance
*/

    /**
    * Win
    * *_uninfected --> 0
    * *_infected --> 0
    * *_dead --> Total Population  
*/
    //Lose _infected > 0 && _uninfected == 0

    public int getTotalPopulation() { return this._totalPopulation; }
    public int getInfected() { return this._infected; }
    public int getUninfected() { return this._uninfected; }
    public int getDead() { return this._dead; }
    public int getPoints() { return this._points; }
    public int getUpgradePoints() { return this._upgPoints; }
    public double getLevelMortality() { return this._lvlmortality; }
    public bool getUpgradeMortalityLevel() { return this._upgMortalityLvl; }
    public int getPointsNeededMortality() { return this._pneededMort; }
    public double getLevelSpread() { return this._lvltransmissionRate; }
    public bool getUpgradeSpreadLevel() { return this._upgSpreadLvl; }
    public int getPointsNeededSpread() { return this._pneededSpread; }
    public double getCureFund() { return this._Curefund; }
    public int getContagionDays() { return this._contDays; }

    public void SetLvlTransmissionRate(double transmissionRate){_lvltransmissionRate = transmissionRate;}
    public void SetLvlMortality(double mortality){_lvlmortality = mortality;}

    public void simulation()
    {
        // Simulate the spread of the disease
        // formula for modeling a virus spread is R0 = (transmission rate per contact) x (duration of infectivity) x (number of contacts per unit time)
        if (this._uninfected > 0)
        {//Infected increment
         //int newlyInfected = (int)((this._infected * _lvlspread) + 1); // gotta fix this probability
            int newlyInfected = (int)((this._infected * this._lvltransmissionRate * this._durationOfInfectivity * this._numContactsPerDay));
            Console.WriteLine("newlyinfected: {0}", newlyInfected);
            if (newlyInfected > this._uninfected)
            {
                newlyInfected = this._uninfected;
            }
            this._uninfected -= newlyInfected;
            this._infected += newlyInfected;
            this._upgPoints += newlyInfected; // ! Why is this +newlyInfected
        }

        if (this._infected + this._dead > this._uninfected / 4)
        { //Dead increment, if more than 1/4 of the uninfected get infected
            int newlyDead = (int)Math.Ceiling((this._infected * _lvlmortality)); // ! Getting stuck if newlydead < 1
            Console.WriteLine("newlydead: {0}", newlyDead);
            if (newlyDead > this._infected)
            {
                newlyDead = this._infected;
            }
            //int n = Covid19.
            this._infected -= newlyDead;
            this._dead += newlyDead;
        }

        if (this._infected > this._totalPopulation / 4)
        {// aqui se van agregando los curados
            this._contDays++;
            if (this._contDays > 6)
            { //percentage _curedFund * variableX
                int cured = (int)(((this._infected / 2) * _Curefund) / 4); //amount of people cured
                this._uninfected += cured;
                this._infected -= cured;
            }
        }

        /**
            **esto iria dentro del boton cuando le de upg a mortality
            this._lvlspread += 0.01;
            this._points -= _pneededMort;
            this._pneededMort += 2;
            if(this._points >= _pneededMort)
                _upgMortalityLvl = true;
    
            **esto iria dentro del boton cuando le de upg a spread
            this._lvlmortality += 0.01;
            this._points -= _pneededSpread;
            this._pneededSpread += 2;
            if(this._points >= _pneededSpread)
                _upgSpreadLvl = true;// y aqui se enable el boton
    
            **esto si iria dentro de aca
            if ( this._cont4points > (this._totalPopulation / 10)/2 ) { //aqui se ve lo del 5%
                this._points += 1;
                this._cont4points = 0;
            }
            **lo siguiente es para que los botones se vuelvan enable
            if(this._points >= _pneededSpread)
                _upgSpreadLvl = true;// y aqui se enable el boton
            if(this._points >= _pneededMort)
                _upgMortalityLvl = true;
        */

        //this._totalPopulation -= ;
        Console.WriteLine("Total population: {0}", this._totalPopulation);
        Console.WriteLine("Uninfected: {0}", this._uninfected);
        Console.WriteLine("Infected: {0}", this._infected);
        Console.WriteLine("Dead: {0}", this._dead);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("The pipe name is: {0}", args[2]);
        string pipeName = args[2];
        var instanceId = args.Length > 0 ? args[0] : "1"; // Use the first argument as instance ID, or default to "1"
        Asia processAS = new Asia();
        processAS.SetLvlMortality(Double.Parse(args[0]));
        processAS.SetLvlTransmissionRate(Double.Parse(args[1]));
        Console.WriteLine("Asia mortalityrate: {0}", processAS.getLevelMortality());
        Console.WriteLine("Asia spreadrate: {0}", processAS.getLevelSpread());
        while (true)
        {
            try
            {
                using (var pipeWriter = new NamedPipeClientStream(".", pipeName, PipeDirection.Out))
                {
                    pipeWriter.Connect();
                    string filename_id = Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName);
                    // Console.WriteLine("Produced: {0}", data);
                    processAS.simulation();
                    var actualData = DateTime.Now.ToString() + "," + processAS.getTotalPopulation() + "," + processAS.getInfected() + "," + processAS.getUninfected() + "," + processAS.getDead() + "," + filename_id;
                    var buffer = Encoding.UTF8.GetBytes(actualData);

                    Monitor.Enter(monitor); // acquire the monitor lock
                    pipeWriter.Write(buffer, 0, buffer.Length);
                    Monitor.Pulse(monitor); // notify the consumer that data is available
                    Monitor.Exit(monitor); // release the monitor lock
                }
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Producer error: {0}", ex.Message);
            }
        }
    }
}
