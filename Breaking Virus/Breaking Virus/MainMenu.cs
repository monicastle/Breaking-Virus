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

        public static void CallToChildThread() {

            int population = 660000000; //660 million
            int healthy = 0, infected = 0, dead = 0;



            try {
            Console.WriteLine("Lating Ametica thread starts");

            //doing some work like
            connect_to_server();
            //the thread is paused for 5000 milliseconds
            //int sleepfor = 5000;
            //Console.WriteLine("Child Thread Paused for {0} seconds", sleepfor / 1000);
            //Thread.Sleep(sleepfor);
            Console.WriteLine("Task finished now closing thread");
            }
            catch (ThreadAbortException e) {
                Console.WriteLine("Thread Abort Exception");
            }
            finally {
                Console.WriteLine("Couldn't catch the Thread Exception");
            }

        }

        public static void connect_to_server() {
            try {
                string SERVER_IP = "192.168.0.12";
                int PORT_NO = 8001;
                //while (true)
                //{
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
                //}
            }
            catch (Exception e) {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }


        public MainMenu(){
            InitializeComponent();

            // INICIO

            ThreadStart childref_LatinA = new ThreadStart(CallToChildThread);
            Thread LatinAmericaThread = new Thread(childref_LatinA);

            //loop to keep starting a new task for client
            bool question = true;
            while (question) {

                LatinAmericaThread.Start();
                //stop the main thread for some time
                //Thread.Sleep(2000);
                //after doing task abort
                //LatinAmericaThread.Suspend();
                //LatinAmericaThread.Abort();
                Console.WriteLine("Wanna start another client: true or false");
                string answer = Console.ReadLine() + "";
                question = (answer.Equals("T")) ? true : false;
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