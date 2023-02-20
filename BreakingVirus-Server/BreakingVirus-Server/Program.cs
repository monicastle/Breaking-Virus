using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Servers {
    class Program {
        public static void CallToChildThread() {
            Console.WriteLine("Lating Ametica thread starts");

            int population = 660000000; //660 million
            int healthy = 0, infected = 0, dead = 0;
            // the thread is paused for 5000 milliseconds
            int sleepfor = 5000;

            connection_to_client();

            Console.WriteLine("Child Thread Paused for {0} seconds", sleepfor / 1000);
            //Thread.Sleep(sleepfor);
            Console.WriteLine("Child thread resumes");
        }

        public static void connection_to_client() {
            try {
                IPAddress ipAd = IPAddress.Parse("192.168.5.185");
                TcpListener listener = new TcpListener(ipAd, 8001);
                listener.Start();
                Console.WriteLine("The server is running at port 8001...");
                Console.WriteLine("The local End point is :" + listener.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");
                TcpClient client = listener.AcceptTcpClient();

                //---get the incoming data through a network stream---
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];

                //---read incoming stream---
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                //---convert the data received into a string---
                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received : " + dataReceived);

                //---write back the text to the client---
                Console.WriteLine("Sending back : " + dataReceived);
                nwStream.Write(buffer, 0, bytesRead);
                client.Close();
                listener.Stop();
            }
            catch (Exception e) {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }

        static void Main(string[] args) {

            ThreadStart childref_LatinA = new ThreadStart(CallToChildThread);
            Thread LatinAmericaThread = new Thread(childref_LatinA);
            LatinAmericaThread.Start();
            Console.ReadKey();
            //try
            //{
            //    IPAddress ipAd = IPAddress.Parse("192.168.0.12");
            //    TcpListener listener = new TcpListener(ipAd, 8001);
            //    listener.Start();
            //    Console.WriteLine("The server is running at port 8001...");
            //    Console.WriteLine("The local End point is :" + listener.LocalEndpoint);
            //    Console.WriteLine("Waiting for a connection.....");
            //    while (true)
            //    {
            //        TcpClient client = listener.AcceptTcpClient();

            //        //---get the incoming data through a network stream---
            //        NetworkStream nwStream = client.GetStream();
            //        byte[] buffer = new byte[client.ReceiveBufferSize];

            //        //---read incoming stream---
            //        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

            //        //---convert the data received into a string---
            //        string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            //        Console.WriteLine("Received : " + dataReceived);

            //        //---write back the text to the client---
            //        Console.WriteLine("Sending back : " + dataReceived);
            //        nwStream.Write(buffer, 0, bytesRead);
            //        client.Close();
            //    }
            //    listener.Stop();
            //    Console.ReadLine();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Error..... " + e.StackTrace);
            //}
            Console.ReadLine();
        }
    }
}