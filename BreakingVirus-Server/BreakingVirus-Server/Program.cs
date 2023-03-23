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
    class Server {

        static object monitor = new object();
        private  IPAddress serverIpAddress;
        private  int serverPort;
        private  Socket serverSocket;
        private  List<Socket> clientSockets;
        private  static string _dataValue = "";

        // public string _dataValue{
        //     set { _dataValue = value; }
        // }

        public static void setDataValue(string value){
            _dataValue = value;
        }

        public Server(IPAddress serverIpAddress, int serverPort) {
            this.serverIpAddress = serverIpAddress;
            this.serverPort = serverPort;
            this.serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.clientSockets = new List<Socket>();
        }

        public void Start() {
            // Bind the server socket to the specified IP address and port
            serverSocket.Bind(new IPEndPoint(serverIpAddress, serverPort));
            Console.WriteLine("Server started on {0}{1}{2}", serverIpAddress, ":", serverPort);

            // Listen for incoming connections
            serverSocket.Listen(10);

            // Accept client connections and start a new thread to handle each client
            while (true) {
                Socket clientSocket = serverSocket.Accept();
                Console.WriteLine("Accepted client connection from {0}", clientSocket.RemoteEndPoint);

                lock (clientSockets) {
                    // Add the client socket to the list of connected clients
                    clientSockets.Add(clientSocket);
                }

                // Start a new thread to handle the client
                Thread clientThread = new Thread(() => HandleClient(clientSocket));
                clientThread.Start();
            }
        }

        private void HandleClient(Socket clientSocket) {
            try {
                // Send data to the client every second
                while (true) {
                    string data = DateTime.Now.ToString();
                    byte[] buffer = Encoding.ASCII.GetBytes(_dataValue); //Value from global variable
                    clientSocket.Send(buffer);
                    Thread.Sleep(1000);
                }
            }
            catch (SocketException) {
                // The client has disconnected, remove the socket from the list of connected clients
                Console.WriteLine("Client {0}{1}", clientSocket.RemoteEndPoint, "disconnected");
                lock (clientSockets) {
                    clientSockets.Remove(clientSocket);
                }
            }
        }

        public void Stop() {
            // Close all connected client sockets
            lock (clientSockets) {
                foreach (Socket clientSocket in clientSockets) {
                    clientSocket.Close();
                }
                clientSockets.Clear();
            }

            // Close the server socket
            serverSocket.Close();
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
                        // _dataValue =
                        setDataValue(data.ToString());
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
            //receiveDataFromConsumer();
            Thread receiveThread = new Thread(receiveDataFromConsumer);
            receiveThread.Start();

            // Start the server on a specific IP address and port
            IPAddress ipAddress = IPAddress.Parse("192.168.1.12"); // Change this to the IP address of the server machine
            Server server = new Server(ipAddress, 12345);
            server.Start();

            //Console.ReadLine();
        }
    }
}