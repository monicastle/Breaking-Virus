using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace Breaking_Virus
{
    public partial class Simulacion : Form
    {
        private IPAddress serverIpAddress;
        private int serverPort;
        private Socket clientSocket;

        public void Connect()
        {
            // Connect to the server
            clientSocket.Connect(new IPEndPoint(serverIpAddress, serverPort));
            Console.WriteLine("Connected to server {0}{1}{2}", serverIpAddress, ":", serverPort);

            // Receive data from the server and display it
            while (true)
            {
                byte[] buffer = new byte[1024];
                int numBytes = clientSocket.Receive(buffer);
                string data = Encoding.ASCII.GetString(buffer, 0, numBytes);
                string[] splitData = data.Split(','); // Split Data
                validateSendData(splitData);
                Console.WriteLine("Received data from server: {0}", data);
            }
        }

        public Simulacion()
        {
            InitializeComponent();
            this.serverIpAddress = IPAddress.Parse("192.168.1.12"); // Change this to the IP address of the server machine
            this.serverPort = 12345;
            this.clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Connect();
            Thread receiveThread = new Thread(Connect);
            receiveThread.Start();
        }

        private void UpdateLabelUninfected(string text)
        {
            if (uninfected_NorthAmerica.InvokeRequired)
            {
                uninfected_NorthAmerica.Invoke((Action)(() => uninfected_NorthAmerica.Text = text));
            }
            else
            {
                uninfected_NorthAmerica.Text = text;
            }
        }

        private void UpdateLabelInfected(string text)
        {
            if (infected_NorthAmerica.InvokeRequired)
            {
                infected_NorthAmerica.Invoke((Action)(() => infected_NorthAmerica.Text = text));
            }
            else
            {
                infected_NorthAmerica.Text = text;
            }
        }

        private void UpdateLabelDead(string text)
        {
            if (dead_NorthAmerica.InvokeRequired)
            {
                dead_NorthAmerica.Invoke((Action)(() => dead_NorthAmerica.Text = text));
            }
            else
            {
                dead_NorthAmerica.Text = text;
            }
        }


        // Se encarga de saber que proceso acaba de enviar la informacion
        private void validateSendData(string[] splitData)
        {
            //int lastItem = splitData.Length - 1;
            string totalPopulation = splitData[1];
            string uninfected = splitData[3];
            string infected = splitData[2];
            string dead = splitData[4];
            //string processId = splitData[lastItem]; //4

            // uninfected_NorthAmerica.Text = uninfected;
            UpdateLabelUninfected(uninfected);
            // infected_NorthAmerica.Text = infected;
            UpdateLabelInfected(infected);
            // dead_NorthAmerica.Text = dead;
            UpdateLabelDead(dead);

            //switch (processId)
            //{
            //    case "1":
            //        // North America
            //        uninfected_NorthAmerica.Text = uninfected;
            //        infected_NorthAmerica.Text = infected;
            //        dead_NorthAmerica.Text = dead;
            //        break;
            //    case "2":
            //        // South America
            //        uninfected_SouthAmerica.Text = uninfected;
            //        infected_SouthAmerica.Text = infected;
            //        dead_SouthAmerica.Text = dead;
            //        break;
            //    case "3":
            //        // Europe
            //        uninfected_Europe.Text = uninfected;
            //        infected_Europe.Text = infected;
            //        dead_Europe.Text = dead;
            //        break;
            //    case "4":
            //        // Asia
            //        uninfected_Asia.Text = uninfected;
            //        infected_Asia.Text = infected;
            //        dead_Asia.Text = dead;
            //        break;
            //    case "5":
            //        // Africa
            //        uninfected_Africa.Text = uninfected;
            //        infected_Africa.Text = infected;
            //        dead_Africa.Text = dead;
            //        break;
            //    case "6":
            //        // Oceania
            //        uninfected_Oceania.Text = uninfected;
            //        infected_Oceania.Text = infected;
            //        dead_Oceania.Text = dead;
            //        break;
            //    default:
            //        // Process id not valid
            //        break;
            //}
        }
    }
}
