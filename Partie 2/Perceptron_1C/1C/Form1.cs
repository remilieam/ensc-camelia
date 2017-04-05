﻿using System;
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
        protected int W1 = 1;
        protected int W2 = 2;
        protected int W3 = 3;
        protected int nbiterations=1;
        protected int sommeerreur;
        protected double []tailleA = new double[]{36.1, 41.1, 47.9, 47, 49.8, 48.5};
        protected double[] tailleB = new double[] { 47.8, 55.5, 62.0, 64.1, 64.3, 65.3 };
        protected int sortiecorrecte;
        protected double[] poidsA = new double[] { 17,16.5,18,18.5,22,21};
        protected double[] poidsB = new double[] { 11.7, 16.4, 13, 22, 18.5, 21 };
        protected int erreurA;
        protected int erreurB;
        protected double[] point1=new double[]{-3/2,0}; // 0,-w3/w2
        protected double[] point2 = new double[] { -23/2,20}; //Deuxième point de la droite
        double coeff = 2.5; //Détermination du coefficient directeur yb-ya/xb-xa
        Neurone n = new Neurone();
  
 
        public Form1()
        {
            InitializeComponent();
        }

        private void Chercher_button_Click(object sender, EventArgs e)
        {   
          
            erreurA = 0;
            erreurB = 0;
            sommeerreur = 0;

            n.nombreerreur = 0;


            sortiecorrecte = 1;



            /*   if(taille>coeff*poids)

               {   
                   sortiecorrecte=0;
               }*/

            int i = 0;


            while (i < tailleA.Length)
            {
                if (sortiecorrecte == 1)
                {
                    n.entrees[0] = tailleA[i] ; //on normalise
                    n.entrees[1] = poidsA[i] ; //on normalise
                    n.entrees[2] = 1;

                    // On calcule la sortie avec les poids
                    n.CalculeSortie();
                    if (sortiecorrecte != n.sortie)
                    {
                        n.RecalculeSortie(sortiecorrecte);
                    }


                    erreurA += n.nombreerreur;
                    n.nombreerreur = 0;
                    sortiecorrecte = 0;
                

                }

                sommeerreur = erreurA;

                if (sortiecorrecte == 0)
                {

                    n.entrees[0] = tailleB[i]; //on normalise
                    n.entrees[1] = poidsB[i]; //on normalise
                    n.entrees[2] = 1;

                    n.CalculeSortie();
                    if (sortiecorrecte != n.sortie)
                    {
                        n.RecalculeSortie(sortiecorrecte);
                    }


                    erreurB += n.nombreerreur;
                    n.nombreerreur = 0;



                }


                sommeerreur += erreurB;
                i++;
                sortiecorrecte = 1;
            }


                Reponse_TextBox.Text = sommeerreur.ToString();
                classe_TextBox.Text = n.w[1].ToString();
                Poids_final_TextBox.Text = n.w[2].ToString();
              

            }
        
        

        private void taille_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Graphique_PictureBox_Click(object sender, EventArgs e)
        {
        
        }

       

      
    }
}
