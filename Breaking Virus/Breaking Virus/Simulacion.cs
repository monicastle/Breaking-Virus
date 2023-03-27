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
            this.serverIpAddress = IPAddress.Parse("192.168.1.8"); // Change this to the IP address of the server machine
            this.serverPort = 12345;
            this.clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Connect();
            Thread receiveThread = new Thread(Connect);
            receiveThread.Start();
        }

        private void UpdateLabelUninfected_NorthAmerica(string text){
            if (uninfected_NorthAmerica.InvokeRequired){
                uninfected_NorthAmerica.Invoke((Action)(() => uninfected_NorthAmerica.Text = text));
            }
            else{
                uninfected_NorthAmerica.Text = text;
            }
        }

        private void UpdateLabelInfected_NorthAmerica(string text){
            if (infected_NorthAmerica.InvokeRequired){
                infected_NorthAmerica.Invoke((Action)(() => infected_NorthAmerica.Text = text));
            }
            else{
                infected_NorthAmerica.Text = text;
            }
        }

        private void UpdateLabelDead_NorthAmerica(string text){
            if (dead_NorthAmerica.InvokeRequired){
                dead_NorthAmerica.Invoke((Action)(() => dead_NorthAmerica.Text = text));
            }
            else{
                dead_NorthAmerica.Text = text;
            }
        }

        private void UpdateLabelUninfected_SouthAmerica(string text) {
            if (uninfected_SouthAmerica.InvokeRequired) {
                uninfected_SouthAmerica.Invoke((Action)(() => uninfected_SouthAmerica.Text = text));
            }
            else {
                uninfected_SouthAmerica.Text = text;
            }
        }

        private void UpdateLabelInfected_SouthAmerica(string text) {
            if (infected_SouthAmerica.InvokeRequired) {
                infected_SouthAmerica.Invoke((Action)(() => infected_SouthAmerica.Text = text));
            }
            else {
                infected_SouthAmerica.Text = text;
            }
        }

        private void UpdateLabelDead_SouthAmerica(string text) {
            if (dead_SouthAmerica.InvokeRequired) {
                dead_SouthAmerica.Invoke((Action)(() => dead_SouthAmerica.Text = text));
            }
            else {
                dead_SouthAmerica.Text = text;
            }
        }
        //--
        private void UpdateLabelUninfected_Europe(string text) {
            if (uninfected_Europe.InvokeRequired) {
                uninfected_Europe.Invoke((Action)(() => uninfected_Europe.Text = text));
            }
            else {
                uninfected_Europe.Text = text;
            }
        }

        private void UpdateLabelInfected_Europe(string text) {
            if (infected_Europe.InvokeRequired) {
                infected_Europe.Invoke((Action)(() => infected_Europe.Text = text));
            }
            else {
                infected_Europe.Text = text;
            }
        }

        private void UpdateLabelDead_Europe(string text) {
            if (dead_Europe.InvokeRequired) {
                dead_Europe.Invoke((Action)(() => dead_Europe.Text = text));
            }
            else {
                dead_Europe.Text = text;
            }
        }
        //---
        private void UpdateLabelUninfected_Asia(string text) {
            if (uninfected_Asia.InvokeRequired) {
                uninfected_Asia.Invoke((Action)(() => uninfected_Asia.Text = text));
            }
            else {
                uninfected_Asia.Text = text;
            }
        }

        private void UpdateLabelInfected_Asia(string text) {
            if (infected_Asia.InvokeRequired) {
                infected_Asia.Invoke((Action)(() => infected_Asia.Text = text));
            }
            else {
                infected_Asia.Text = text;
            }
        }

        private void UpdateLabelDead_Asia(string text) {
            if (dead_Asia.InvokeRequired) {
                dead_Asia.Invoke((Action)(() => dead_Asia.Text = text));
            }
            else {
                dead_Asia.Text = text;
            }
        }
        //--
        private void UpdateLabelUninfected_Africa(string text) {
            if (uninfected_Africa.InvokeRequired) {
                uninfected_Africa.Invoke((Action)(() => uninfected_Africa.Text = text));
            }
            else {
                uninfected_Africa.Text = text;
            }
        }

        private void UpdateLabelInfected_Africa(string text) {
            if (infected_Africa.InvokeRequired) {
                infected_Africa.Invoke((Action)(() => infected_Africa.Text = text));
            }
            else {
                infected_Africa.Text = text;
            }
        }

        private void UpdateLabelDead_Africa(string text) {
            if (dead_Africa.InvokeRequired) {
                dead_Africa.Invoke((Action)(() => dead_Africa.Text = text));
            }
            else {
                dead_Africa.Text = text;
            }
        }
        //--
        private void UpdateLabelUninfected_Oceania(string text) {
            if (uninfected_Oceania.InvokeRequired) {
                uninfected_Oceania.Invoke((Action)(() => uninfected_Oceania.Text = text));
            }
            else {
                uninfected_Oceania.Text = text;
            }
        }

        private void UpdateLabelInfected_Oceania(string text) {
            if (infected_Oceania.InvokeRequired) {
                infected_Oceania.Invoke((Action)(() => infected_Oceania.Text = text));
            }
            else {
                infected_Oceania.Text = text;
            }
        }

        private void UpdateLabelDead_Oceania(string text) {
            if (dead_Oceania.InvokeRequired) {
                dead_Oceania.Invoke((Action)(() => dead_Oceania.Text = text));
            }
            else {
                dead_Oceania.Text = text;
            }
        }

        // Se encarga de saber que proceso acaba de enviar la informacion
        private void validateSendData(string[] splitData)
        {
            int lastItem = splitData.Length - 1;
            string totalPopulation = splitData[1];
            string infected = splitData[2];
            string uninfected = splitData[3];
            string dead = splitData[4];
            string processId = splitData[lastItem]; //4

            switch (processId) {
                case "PipeNorthAmerica":
                    // North America
                    UpdateLabelUninfected_NorthAmerica(uninfected);
                    UpdateLabelInfected_NorthAmerica(infected);
                    UpdateLabelDead_NorthAmerica(dead);
                    break;
                case "PipeSouthAmerica":
                    // South America
                    UpdateLabelUninfected_SouthAmerica(uninfected);
                    UpdateLabelInfected_SouthAmerica(infected);
                    UpdateLabelDead_SouthAmerica(dead);
                    break;
                case "PipeEurope":
                    // Europe
                    UpdateLabelUninfected_Europe(uninfected);
                    UpdateLabelInfected_Europe(infected);
                    UpdateLabelDead_Europe(dead);
                    break;
                case "PipeAsia":
                    // Asia
                    UpdateLabelUninfected_Asia(uninfected);
                    UpdateLabelInfected_Asia(infected);
                    UpdateLabelDead_Asia(dead);
                    break;
                case "PipeAfrica":
                    // Africa
                    UpdateLabelUninfected_Africa(uninfected);
                    UpdateLabelInfected_Africa(infected);
                    UpdateLabelDead_Africa(dead);
                    break;
                case "PipeOceania":
                    // Oceania
                    UpdateLabelUninfected_Oceania(uninfected);
                    UpdateLabelInfected_Oceania(infected);
                    UpdateLabelDead_Oceania(dead);
                    break;
                default:
                    // Process id not valid
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
