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
        public MainMenu() {
            InitializeComponent();

        }

        private void btn_Singleplayer_Click(object sender, EventArgs e)
        {
            SinglePlayerMenu ventanaSP = new SinglePlayerMenu();
            this.Hide();
            ventanaSP.Show();
        }

        private void btn_Multiplayer_Click(object sender, EventArgs e)
        {
            MultiPlayerMenu ventanaMP = new MultiPlayerMenu();
            this.Hide();
            ventanaMP.Show();
        }
    }
}