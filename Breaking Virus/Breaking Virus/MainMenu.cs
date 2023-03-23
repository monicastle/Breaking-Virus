using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace Breaking_Virus
{
    public partial class MainMenu : Form
    {
        private IPAddress serverIpAddress;
        private int serverPort;
        private Socket clientSocket;

        public void Connect() {
            // Connect to the server
            clientSocket.Connect(new IPEndPoint(serverIpAddress, serverPort));
            Console.WriteLine("Connected to server {0}{1}{2}", serverIpAddress, ":", serverPort);

            // Receive data from the server and display it
            while (true) {
                byte[] buffer = new byte[1024];
                int numBytes = clientSocket.Receive(buffer);
                string data = Encoding.ASCII.GetString(buffer, 0, numBytes);
                Console.WriteLine("Received data from server: {0}", data);
            }
        }

        public MainMenu() {
            InitializeComponent();
            this.serverIpAddress = IPAddress.Parse("192.168.0.13"); // Change this to the IP address of the server machine
            this.serverPort = 12345;
            this.clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Connect();


        }

        private void btn_Singleplayer_Click(object sender, EventArgs e)
        {
            SinglePlayerMenu ventanaSP = new SinglePlayerMenu();
            this.Hide();
            ventanaSP.Show();
        }
    }
}