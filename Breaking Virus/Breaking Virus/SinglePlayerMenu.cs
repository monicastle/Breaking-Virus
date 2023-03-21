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

        private void btn_Covid19_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Are you sure you want to select Covid-19 as the virus?", "Virus Confirmation", MessageBoxButtons.YesNo);
            
            if (confirmResult == DialogResult.Yes)
            {
                Simulacion ventanaSimulacion = new Simulacion();
                this.Hide();
                ventanaSimulacion.Show();
            }
        }

        private void btn_Dengue_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Are you sure you want to select Dengue as the virus?", "Virus Confirmation", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                Simulacion ventanaSimulacion = new Simulacion();
                this.Hide();
                ventanaSimulacion.Show();
            }
        }

        private void btn_Ebola_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Are you sure you want to select Ebola as the virus?", "Virus Confirmation", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                Simulacion ventanaSimulacion = new Simulacion();
                this.Hide();
                ventanaSimulacion.Show();
            }
        }
    }
}
