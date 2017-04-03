using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MC
{
    public partial class Affichage : Form
    {
        public Affichage()
        {
            InitializeComponent();
        }

        private void Affichage_Load(object sender, EventArgs e)
        {
            // On récupère les lignes du fichiers textes
            string[] lignes = System.IO.File.ReadAllLines("../../../datasetregression.txt");

            // On récupère les positions et les intensités
            double[,] position = new double[3000, 3];
            for (int i = 0; i < position.GetLength(0); i++)
            {
                position[i, 0] = int.Parse(lignes[(4 * i) + 1]);
                position[i, 1] = int.Parse(lignes[(4 * i) + 2]);
                position[i, 2] = Convert.ToDouble(lignes[(4 * i) + 3]);
            }



        }
    }
}
