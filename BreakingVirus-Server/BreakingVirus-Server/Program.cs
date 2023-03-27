using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Servers {

    class ProcessStarters {
        ProcessStartInfo startInfoRegionControl = new ProcessStartInfo();
        Process processRegionControl = new Process();
        public ProcessStarters(string path) {
            //this.startInfoRegionControl = startInfoRegionControl;
            this.startInfoRegionControl.FileName = "cmd.exe";
            this.startInfoRegionControl.Arguments = "/c PipeRegionControl.exe";
            this.startInfoRegionControl.WorkingDirectory = path;
            this.startInfoRegionControl.UseShellExecute = true;
            this.startInfoRegionControl.CreateNoWindow = false;
            processRegionControl.StartInfo = this.startInfoRegionControl;
        }

        public void startProcess() {
            this.processRegionControl.Start();
        }

        public void waitForExitProcess() {
            this.processRegionControl.WaitForExit();
        }

        public Process getProcess() {
            return this.processRegionControl;
        }

    }

    class Server {

        static object monitor = new object();
        private  IPAddress serverIpAddress;
        private  int serverPort;
        private  Socket serverSocket;
        private  List<Socket> clientSockets;
        private  static string _dataValue = "";
        private static string _virusName = "";


        public static void setDataValue(string value){
            _dataValue = value;
        }

        public static void setVirusName(string value) {
            _virusName = value;
        }

        public Server(IPAddress serverIpAddress, int serverPort) {
            this.serverIpAddress = serverIpAddress;
            this.serverPort = serverPort;
            this.serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.clientSockets = new List<Socket>();
        }
        public string RetrievePath() {
            string path = Directory.GetCurrentDirectory();
            for (int i = 0; i < 5; i++) {
                DirectoryInfo parent = Directory.GetParent(path);
                if (parent != null) {
                    path = parent.FullName;
                }
            }

            //Console.WriteLine("OLD: {0}", path);
            // Move into the subdirectory
            Directory.SetCurrentDirectory(path + @"\RegionProcesses_Folder");
            string newDirectory = Directory.GetCurrentDirectory();
            //Console.WriteLine("NEW: {0}", newDirectory);
            return newDirectory;
        }

        public void StartPrograms() {
            try {
                string path = RetrievePath();
                ProcessStarters pstart = new ProcessStarters(path);
                pstart.startProcess();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public void Start() {
            string VirusName = receiveVirusName();
            setVirusName(VirusName);
            Console.WriteLine("The virus named received in server: {0}", VirusName);
            // Bind the server socket to the specified IP address and port
            serverSocket.Bind(new IPEndPoint(serverIpAddress, serverPort));
            Console.WriteLine("Server started on {0}{1}{2}", serverIpAddress, ":", serverPort);

            // Listen for incoming connections
            serverSocket.Listen(10);

            // Accept client connections and start a new thread to handle each client
            while (true) {
                Socket clientSocket = serverSocket.Accept();
                Console.WriteLine("Accepted client connection from {0}", clientSocket.RemoteEndPoint);
                if (clientSocket != null && clientSocket.Connected) {
                    //Console.WriteLine("Client connected!");
                    // handle client communication here
                    sendVirusName(clientSocket);

                    Thread receiveThread = new Thread(receiveDataFromConsumer);
                    receiveThread.Start();
                }

                lock (clientSockets) {
                    // Add the client socket to the list of connected clients
                    clientSockets.Add(clientSocket);
                }

                // Start a new thread to handle the client
                Thread clientThread = new Thread(() => HandleClient(clientSocket));
                clientThread.Start();
            }
        }

        public void sendVirusName(Socket clientSocket) {
            //first send virus name:
            byte[] bufferVirus = Encoding.ASCII.GetBytes(_virusName); //Value from global variable
            clientSocket.Send(bufferVirus);
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
                Console.WriteLine("Client {0}{1}  ", clientSocket.RemoteEndPoint, "   disconnected");
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

                        if (!pipeReader.IsConnected) {
                            // Pipe is disconnected
                            Console.WriteLine("PipeDisconnected!");
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine("Server error: {0}", ex.Message);
                }
            }
        }

        public static string receiveVirusName() {
            string pipeName = "forwardPipe";
            Console.WriteLine("Waiting for incoming data: ");
            try {
                using (var pipeReader = new NamedPipeServerStream(pipeName, PipeDirection.In)) {
                    pipeReader.WaitForConnection();
                    var buffer = new byte[1024];

                    Monitor.Enter(monitor); // acquire the monitor lock
                    pipeReader.Read(buffer, 0, buffer.Length);
                    var data = Encoding.UTF8.GetString(buffer).Trim('\0');
                    // _dataValue =
                    string result = data.ToString();
                    Console.WriteLine("Received data from consumer: {0}", data);
                    Monitor.Exit(monitor); // release the monitor lock

                    pipeReader.Disconnect();
                    if (!pipeReader.IsConnected) {
                        // Pipe is disconnected
                        Console.WriteLine("PipeDisconnected!");
                    }
                    return result;
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Server error: {0}", ex.Message);
            }
            return "";
        }

        static void Main(string[] args) {
            //receiveDataFromConsumer();
                       
            // Start the server on a specific IP address and port
            IPAddress ipAddress = IPAddress.Parse("192.168.0.19"); // Change this to the IP address of the server machine
            Server server = new Server(ipAddress, 12345);
            server.StartPrograms();
            server.Start();

            //Console.ReadLine();
        }
    }
}