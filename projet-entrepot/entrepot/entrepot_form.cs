using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace entrepot
{
    public partial class entrepot_form : Form
    {
        // Tableau d'images représentant l'entrepot
        PictureBox[,] entrepot_image;
        int[,] entrepot;

        public entrepot_form()
        {
            InitializeComponent();
        }


        private void entrepot_form_Load(object sender, EventArgs e)
        {
            entrepot_image = new PictureBox[25, 25];
            entrepot = new int[25, 25];
            // on assigne au tableau les images
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    entrepot_image[i, j] = new PictureBox();

                    this.Controls.Add(entrepot_image[i, j]);
                    entrepot_image[i, j].Left = i * 20;
                    entrepot_image[i, j].Top = j * 20;
                    entrepot_image[i, j].Width = 20;
                    entrepot_image[i, j].Height = 20;

                    // S'il s'agit d'une étagère
                    if (j % 2 == 0 && j != 0 && j != 24 && ((i >= 2 && i < 11) || (i >= 14 && i < 23)))
                    {
                        // On gère le tableau d'images 
                        FileStream fs = new FileStream("robot.jpg", FileMode.Open);
                        entrepot_image[i, j].Image = Image.FromStream(fs);
                        fs.Close();

                        // Le tableau d'entiers
                        entrepot[i, j] = -1;
                    }
                    else
                    {
                        // On gère le tableau d'images
                        FileStream fs = new FileStream("logo.png", FileMode.Open);
                        entrepot_image[i, j].Image = Image.FromStream(fs);
                        fs.Close();

                        // Le tableau d'entiers
                        entrepot[i, j] = 0; // Par défaut
                    }
                }

            }
        }

        private void chariots_button_Click(object sender, EventArgs e)
        {
            Form chariots = new chariots_form();
            if (chariots.ShowDialog() == DialogResult.OK){}
        }
    }
}
