using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;


class Covid19{
    private double _lvlMortality;
    private double _lvlSpread;
    public Covid19(){
        _lvlMortality = 0.02;
        _lvlSpread = 0.10;
    }
    public double getLvlMortality(){ return _lvlMortality;}
    public double getLvlSpread(){return _lvlSpread;}
}

class Ebola{
    public double _lvlMortality;
    public double _lvlSpread;
    public Ebola(){
        _lvlMortality = 0.02;
        _lvlSpread = 0.10;
    }
    public double getLvlMortality(){ return _lvlMortality;}
    public double getLvlSpread(){return _lvlSpread;}
}

class Dengue{
    public double _lvlMortality;
    public double _lvlSpread;
    public Dengue(){
        _lvlMortality = 0.02;
        _lvlSpread = 0.10;
    }
    public double getLvlMortality(){ return _lvlMortality;}
    public double getLvlSpread(){return _lvlSpread;}
}
class RegionControl{
    static object monitor = new object();
    private int _incrementForRegions = 0;
    List<string> regionsExecuted = new List<string>();


    public int getIncrementForRegions() { return this._incrementForRegions; }

    public void selectRandomRegion(Random random, String path, double mortality, double spread,string n){
        int randomRegion = random.Next(1, 7);
        switch (randomRegion){
            case 1:
                // NORTH AMERICA
                Console.WriteLine("Started NorthAmerica");
                // bool isRunningNA = Process.GetProcessesByName("NorthAmerica").Length > 0;
                if (!regionsExecuted.Contains("NorthAmerica")){
                    regionsExecuted.Add("NorthAmerica");
                    ProcessStartInfo startPipe_NorthAmerica = new ProcessStartInfo();
                    startPipe_NorthAmerica.FileName = "cmd.exe";
                    startPipe_NorthAmerica.Arguments = "/c NorthAmerica.exe " + mortality + " " + spread + " " + n;
                    startPipe_NorthAmerica.WorkingDirectory = path;
                    startPipe_NorthAmerica.UseShellExecute = true;
                    startPipe_NorthAmerica.CreateNoWindow = false;
                    Process process_NorthAmerica = new Process();
                    process_NorthAmerica.StartInfo = startPipe_NorthAmerica;
                    process_NorthAmerica.Start();
                    _incrementForRegions += 1;
                }
                break;
            case 2:
                // SOUTH AMERICA
                Console.WriteLine("Started SouthAmerica");
                // bool isRunningSA = Process.GetProcessesByName("SouthAmerica").Length > 0;
                if (!regionsExecuted.Contains("SouthAmerica")){
                    regionsExecuted.Add("SouthAmerica");
                    ProcessStartInfo startPipe_SouthAmerica = new ProcessStartInfo();
                    startPipe_SouthAmerica.FileName = "cmd.exe";
                    startPipe_SouthAmerica.Arguments = "/c SouthAmerica.exe " + mortality + " " + spread + " " + n;
                    startPipe_SouthAmerica.WorkingDirectory = path;
                    startPipe_SouthAmerica.UseShellExecute = true;
                    startPipe_SouthAmerica.CreateNoWindow = false;
                    Process process_SouthAmerica = new Process();
                    process_SouthAmerica.StartInfo = startPipe_SouthAmerica;
                    process_SouthAmerica.Start();
                    _incrementForRegions += 1;
                }
                break;
            case 3:
                // EUROPE
                Console.WriteLine("Started Europe");
                // bool isRunningEU = Process.GetProcessesByName("Europe").Length > 0;
                if (!regionsExecuted.Contains("Europe")){
                    regionsExecuted.Add("Europe");
                    ProcessStartInfo startPipe_Europe = new ProcessStartInfo();
                    startPipe_Europe.FileName = "cmd.exe";
                    startPipe_Europe.Arguments = "/c Europe.exe " + mortality + " " + spread + " " + n;
                    startPipe_Europe.WorkingDirectory = path;
                    startPipe_Europe.UseShellExecute = true;
                    startPipe_Europe.CreateNoWindow = false;
                    Process process_Europe = new Process();
                    process_Europe.StartInfo = startPipe_Europe;
                    process_Europe.Start();
                    _incrementForRegions += 1;
                }
                break;
            case 4:
                // ASIA
                Console.WriteLine("Started Asia");
                // bool isRunningAs = Process.GetProcessesByName("Asia").Length > 0;
                if (!regionsExecuted.Contains("Asia")){
                    regionsExecuted.Add("Asia");
                    ProcessStartInfo startPipe_Asia = new ProcessStartInfo();
                    startPipe_Asia.FileName = "cmd.exe";
                    startPipe_Asia.Arguments = "/c Asia.exe " + mortality + " " + spread + " " + n;
                    startPipe_Asia.WorkingDirectory = path;
                    startPipe_Asia.UseShellExecute = true;
                    startPipe_Asia.CreateNoWindow = false;
                    Process process_Asia = new Process();
                    process_Asia.StartInfo = startPipe_Asia;
                    process_Asia.Start();
                    _incrementForRegions += 1;
                }
                break;
            case 5:
                // AFRICA
                Console.WriteLine("Started Africa");
                // bool isRunningAf = Process.GetProcessesByName("Africa").Length > 0;
                if (!regionsExecuted.Contains("Africa")){
                    regionsExecuted.Add("Africa");
                    ProcessStartInfo startPipe_Africa = new ProcessStartInfo();
                    startPipe_Africa.FileName = "cmd.exe";
                    startPipe_Africa.Arguments = "/c Africa.exe " + mortality + " " + spread + " " + n;
                    startPipe_Africa.WorkingDirectory = path;
                    startPipe_Africa.UseShellExecute = true;
                    startPipe_Africa.CreateNoWindow = false;
                    Process process_Africa = new Process();
                    process_Africa.StartInfo = startPipe_Africa;
                    process_Africa.Start();
                    _incrementForRegions += 1;
                }
                break;
            case 6:
                // OCEANIA
                Console.WriteLine("Started Oceania");
                // bool isRunningOc = Process.GetProcessesByName("Oceania").Length > 0;
                if (!regionsExecuted.Contains("Oceania")){
                    regionsExecuted.Add("Oceania");
                    ProcessStartInfo startPipe_Oceania = new ProcessStartInfo();
                    startPipe_Oceania.FileName = "cmd.exe";
                    startPipe_Oceania.Arguments = "/c Oceania.exe " + mortality + " " + spread + " " + n;
                    startPipe_Oceania.WorkingDirectory = path;
                    startPipe_Oceania.UseShellExecute = true;
                    startPipe_Oceania.CreateNoWindow = false;
                    Process process_Oceania = new Process();
                    process_Oceania.StartInfo = startPipe_Oceania;
                    process_Oceania.Start();
                    _incrementForRegions += 1;
                }
                break;
            default:
                // MANEJO DE ERRORES
                Console.WriteLine("Something went wront in the random for region!");
                break;
        }
    }

    public dynamic selectRandomVirus(Random random){
        int randomNumber = random.Next(1, 4);
        switch (randomNumber){
            case 1:
                Covid19 covid = new Covid19();
                Console.WriteLine("Covid19 LvlMortality: " + covid.getLvlMortality());
                Console.WriteLine("Covid19 LvlSpread: " + covid.getLvlSpread());
                return covid;
                break;
            case 2:
                Ebola ebola = new Ebola();
                Console.WriteLine("Ebola LvlMortality: " + ebola.getLvlMortality());
                Console.WriteLine("Ebola LvlSpread: " + ebola.getLvlSpread());
                return ebola;
                break;
            default:
                Dengue dengue = new Dengue();
                Console.WriteLine("Dengue LvlMortality: " + dengue.getLvlMortality());
                Console.WriteLine("Dengue LvlSpread: " + dengue.getLvlSpread());
                return dengue;
                break;
        }
        return null;
    }

    async Task MyLoop(RegionControl regionControl, double resultM, double resultS, Random random, string path,string n){
        while(regionControl.getIncrementForRegions() != 6){
            // Do something
            Console.WriteLine("Iteration: {0}", regionControl.getIncrementForRegions());
            regionControl.selectRandomRegion(random,path,resultM, resultS,n);
            // Add a delay
            await Task.Delay(25000);
        }
    }

    static void Main(string[] args){
        int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
        Random random = new Random(seed);
        int n = random.Next();
        string pipeName = n.ToString();
        string forwardPipeName = "forwardPipe";
        Console.WriteLine("Random number:  {0}", n); // 9

        // Random random = new Random();
        string path = Directory.GetCurrentDirectory();
        RegionControl regionControl = new RegionControl();
        dynamic myObject = regionControl.selectRandomVirus(random);
        double resultM = 0.0,resultS= 0.0;
        if(myObject != null){
            resultM = myObject.getLvlMortality();
            resultS = myObject.getLvlSpread();
        }
        Console.WriteLine("here is the mortality: {0} and the spread {1}",resultM,resultS);

        Task.Run(() => regionControl.MyLoop(regionControl, resultM, resultS, random, path,n.ToString()));

        /*
        TODO: add the thing to every so often ramdom select a random region
        */

        while (true){
            try{
                using (var pipeReader = new NamedPipeServerStream(pipeName, PipeDirection.In))
                {
                    pipeReader.WaitForConnection();
                    var buffer = new byte[1024];
                    Monitor.Enter(monitor); // acquire the monitor lock
                    pipeReader.Read(buffer, 0, buffer.Length);
                    var data = Encoding.UTF8.GetString(buffer).Trim('\0');
                    Console.WriteLine("Consumed: {0}", data);
                    Monitor.Exit(monitor); // release the monitor lock

                    // Forward data to server process
                    // using (var forwardPipe = new NamedPipeClientStream(".", forwardPipeName, PipeDirection.Out))
                    // {
                    //     forwardPipe.Connect();
                    //     var forwardBuffer = Encoding.UTF8.GetBytes(data);
                    //     forwardPipe.Write(forwardBuffer, 0, forwardBuffer.Length);
                    // }
                }
            }
            catch (Exception ex){
                Console.WriteLine("Consumer error: {0}", ex.Message);
            }
        }
    }
}
