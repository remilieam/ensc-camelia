using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _1C
{
    public partial class Form1 : Form
    {


        protected double poids;
        protected double taille;
        protected int nberreurs = 0;
        protected int W1 = 20;
        protected int W2 = 10;
        protected int W3 = 2;
        protected int nbiterations=0;
        protected double []tailleA = new double[]{36.1, 41.1, 47.9, 47, 49.8, 48.5, 47.8, 55.5, 62.0, 64.1, 64.3, 65.3 };
        protected int sortiecorrecte;



  
 
        public Form1()
        {
            InitializeComponent();
        }

        private void Chercher_button_Click(object sender, EventArgs e)
        {

            Neurone n = new Neurone();
            poids = double.Parse(Poids_TextBox.Text);
            taille = double.Parse(taille_TextBox.Text);
            for (int i = 0; i < tailleA.Length; i++)
            { 
                
                
                // on cherche la sortie normalement correcte

                if (taille == tailleA[i])
                {
                    sortiecorrecte = 1;
                }


                else
                {

                    sortiecorrecte = 0;


                }
                n.entrees[0] = poids / 629.40; //on normalise
                n.entrees[1] = taille / 215.60; //on normalise
                n.entrees[2] = 1;

                // On calcule la sortie avec les poids
                n.CalculeSortie();
                if (sortiecorrecte != n.sortie)
                {
                    n.RecalculeSortie(sortiecorrecte);
                }
                



                Reponse_TextBox.Text = n.nombreiteration.ToString();

            }
        }

        private void taille_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
    }
}
