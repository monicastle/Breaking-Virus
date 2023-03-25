using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Replace "notepad.exe" with the path to the program you want to start
        ProcessStartInfo startInfoRegionControl = new ProcessStartInfo("PipeRegionControl.exe");
        ProcessStartInfo startInfoProducer_Europe = new ProcessStartInfo(@"C:\Users\tyler\Documents\UNITEC\2023\UNITEC PRIMER PERIODO 2022\Concurencia\NewProyecto\Breaking-Virus\RegionProcesses_Folder\PipeEurope.exe");

        // Start the program
        Process processRegionControl = Process.Start(startInfoRegionControl);
        Process processProducer_Europe = Process.Start(startInfoProducer_Europe);

        // Wait for the program to exit
        processRegionControl.WaitForExit();
        processProducer_Europe.WaitForExit();
    }
}