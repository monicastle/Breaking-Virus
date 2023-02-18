using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Breaking_Virus
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            // INICIO
            try
            {
                string SERVER_IP = "192.168.68.106";
                int PORT_NO = 8001;
                while (true)
                {
                    TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
                    Console.WriteLine("Connecting.....");
                    NetworkStream nwStream = client.GetStream();
                    Console.WriteLine("Connected");
                    Console.Write("Enter the string to be transmitted : ");
                    String textToSend = Console.ReadLine();
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
                    //---send the text---
                    Console.WriteLine("Sending : " + textToSend);
                    nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                    //---read back the text---
                    byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                    int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                    Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
                    Console.ReadLine();
                    client.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
            // FINAL
        }

        private void btn_Singleplayer_Click(object sender, EventArgs e)
        {
            SinglePlayerMenu ventanaSP = new SinglePlayerMenu();
            this.Hide();
            ventanaSP.Show();
        }
    }
}