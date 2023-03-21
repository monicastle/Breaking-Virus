using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using System.IO;
using System.IO.Pipes;

namespace Servers {
    class Program {

        static object monitor = new object();

        public static void connection_to_client() {
            try {
                IPAddress ipAd = IPAddress.Parse("192.168.5.185"); //Change IP moment to run program
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

        public static void receiveDataFromConsumer() {
            string pipeName = "forwardPipe";
            Console.WriteLine("Waiting for incoming data: ");
            while (true) {
                try {
                    using (var pipeReader = new NamedPipeServerStream(pipeName, PipeDirection.In)) {
                        pipeReader.WaitForConnection();
                        var buffer = new byte[1024];

                        Monitor.Enter(monitor); // acquire the monitor lock
                        pipeReader.Read(buffer, 0, buffer.Length);
                        var data = Encoding.UTF8.GetString(buffer).Trim('\0');
                        Console.WriteLine("Received data from consumer: {0}", data);
                        Monitor.Exit(monitor); // release the monitor lock
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine("Server error: {0}", ex.Message);
                }
            }
        }

        static void Main(string[] args) {
            //connection_to_client();
            receiveDataFromConsumer();
          
            //Console.ReadKey();
     
            Console.ReadLine();
        }
    }
}