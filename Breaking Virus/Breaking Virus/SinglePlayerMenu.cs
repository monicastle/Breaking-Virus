using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breaking_Virus
{
    public partial class SinglePlayerMenu : Form
    {
        public SinglePlayerMenu()
        {
            InitializeComponent();
        }

        private void btn_returnMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu ventanaMain = new MainMenu();
            this.Hide();
            ventanaMain.Show();
        }
    }
}
