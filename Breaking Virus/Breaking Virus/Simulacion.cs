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
    public partial class Simulacion : Form
    {
        public Simulacion()
        {
            InitializeComponent();
        }

        private void btn_pinNorthAmerica_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Are you sure you want to select North America to start your virus?", "Select Region", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                enableVisuals_Regions();
            }
        }

        private void btn_pinSouthAmerica_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Are you sure you want to select South America to start your virus?", "Select Region", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                enableVisuals_Regions();
            }

        }

        private void btn_pinEurope_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Are you sure you want to select Europe to start your virus?", "Select Region", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                enableVisuals_Regions();
            }
        }

        private void btn_pinAfrica_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Are you sure you want to select Africa to start your virus?", "Select Region", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                enableVisuals_Regions();
            }
        }

        private void btn_pinAsia_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Are you sure you want to select Asia to start your virus?", "Select Region", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                enableVisuals_Regions();
            }
        }

        private void btn_pinOceania_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Are you sure you want to select Oceania to start your virus?", "Select Region", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                enableVisuals_Regions();
            }
        }

        private void enableVisuals_Regions()
        {
            // Dejamos de mostrar los botones de Pins de cada region
            btn_pinNorthAmerica.Visible = false;
            btn_pinSouthAmerica.Visible = false;
            btn_pinEurope.Visible = false;
            btn_pinAfrica.Visible = false;
            btn_pinAsia.Visible = false;
            btn_pinOceania.Visible = false;
            // Mostramos los paneles con la simulacion por region
            panel_NorthAmerica.Visible = true;
            panel_SouthAmerica.Visible = true;
            panel_Europe.Visible = true;
            panel_Africa.Visible = true;
            panel_Asia.Visible = true;
            panel_Oceania.Visible = true;
        }
    }
}
