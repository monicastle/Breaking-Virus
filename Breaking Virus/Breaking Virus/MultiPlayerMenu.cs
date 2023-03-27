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
    public partial class MultiPlayerMenu : Form
    {
        public MultiPlayerMenu()
        {
            InitializeComponent();
        }

        private void btn_StartSimulationMP_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Are you sure you want to start the simulation?", "Start Confirmation", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                Simulacion ventanaSimulacion = new Simulacion();
                this.Hide();
                ventanaSimulacion.Show();
            }
        }

        private void btn_returnMainMenuMP_Click(object sender, EventArgs e)
        {
            MainMenu ventanaMain = new MainMenu();
            this.Hide();
            ventanaMain.Show();
        }
    }
}
