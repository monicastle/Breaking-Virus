using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;

class Covid19
{
    public double _lvlmortality;
    public double _lvlspread;

    public Covid19()
    {
        _lvlmortality = 0.02;
        _lvlspread = 0.10;
    }

    public double LvlMortality
    {
        get { return _lvlmortality; }
        set { _lvlmortality = value; }
    }

    public double LvlSpread
    {
        get { return _lvlspread; }
        set { _lvlspread = value; }
    }
}

class Ebola
{
    public double _lvlmortality;
    public double _lvlspread;

    public Ebola()
    {
        _lvlmortality = 0.02;
        _lvlspread = 0.10;
    }

    public double LvlMortality
    {
        get { return _lvlmortality; }
        set { _lvlmortality = value; }
    }

    public double LvlSpread
    {
        get { return _lvlspread; }
        set { _lvlspread = value; }
    }
}

class Dengue
{
    public double _lvlmortality;
    public double _lvlspread;

    public Dengue()
    {
        _lvlmortality = 0.02;
        _lvlspread = 0.10;
    }

    public double LvlMortality
    {
        get { return _lvlmortality; }
        set { _lvlmortality = value; }
    }

    public double LvlSpread
    {
        get { return _lvlspread; }
        set { _lvlspread = value; }
    }
}
class RegionControl
{
    static object monitor = new object();

    static void Main(string[] args)
    {
        string pipeName = "myPipe";
        string forwardPipeName = "forwardPipe";

        Random random = new Random();
        int randomNumber = random.Next(1, 4);
        if (randomNumber == 1)
        {
            Covid19 covid = new Covid19();
            Console.WriteLine("Covid19 LvlMortality: " + covid.LvlMortality);
            Console.WriteLine("Covid19 LvlSpread: " + covid.LvlSpread);

        }
        else if (randomNumber == 2)
        {
            Ebola ebola = new Ebola();
            Console.WriteLine("Ebola LvlMortality: " + ebola.LvlMortality);
            Console.WriteLine("Ebola LvlSpread: " + ebola.LvlSpread);
        }
        else
        {
            Dengue dengue = new Dengue();
            Console.WriteLine("Dengue LvlMortality: " + dengue.LvlMortality);
            Console.WriteLine("Dengue LvlSpread: " + dengue.LvlSpread);
        }

        // Selection of the Starting Region
        int randomRegion = random.Next(1, 7);
        switch (randomRegion)
        {
            case 1:
                // NORTH AMERICA
                break;
            case 2:
                // SOUTH AMERICA
                break;
            case 3:
                // EUROPE
                break;
            case 4:
                // ASIA
                break;
            case 5:
                // FRICA
                break;
            case 6:
                // OCEANIA
                break;
            default:
                // MANEJO DE ERRORES
                break;
        }

        while (true)
        {
            try
            {
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
                    using (var forwardPipe = new NamedPipeClientStream(".", forwardPipeName, PipeDirection.Out))
                    {
                        forwardPipe.Connect();
                        var forwardBuffer = Encoding.UTF8.GetBytes(data);
                        forwardPipe.Write(forwardBuffer, 0, forwardBuffer.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Consumer error: {0}", ex.Message);
            }
        }
    }
}
