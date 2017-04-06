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
        protected int W1 = 1;
        protected int W2 = 2;
        protected int W3 = 3;
        protected int nbiterations=0;
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
        private Graphics g;	// Objet graphique placé en global
        private Bitmap bmp;
        private Pen pen;


        public Form1()
        {
            InitializeComponent();
           Graph_pictureBox.Image = new Bitmap(Graph_pictureBox.Width, Graph_pictureBox.Height);
            g = Graphics.FromImage(Graph_pictureBox.Image);
        }

        private void Chercher_button_Click(object sender, EventArgs e)
        {
            nbiterations += 1;
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
                    n.entrees[0] = tailleA[i];
                    n.entrees[1] = poidsA[i];
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

                    n.entrees[0] = tailleB[i];
                    n.entrees[1] = poidsB[i];
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


            erreur_TextBox.Text = sommeerreur.ToString();
            w1_textbox.Text = n.w[0].ToString();
            w2_textbox.Text = n.w[1].ToString();
            w3_Textbox.Text = n.w[2].ToString();
            Iteration_Textbox.Text = nbiterations.ToString();
            Poids_textbox.Text = n.somme.ToString();
            bmp = (Bitmap)Graph_pictureBox.Image;
            pen = new Pen(Color.White, 1);
            g.FillRectangle(pen.Brush, 0, 0, bmp.Width, bmp.Height);
            for (int j = 0; j < 6; j++)
            {
                pen = new Pen(Color.Blue, 1);
                g.DrawEllipse(pen, (float)tailleA[j] * 6, (float)poidsA[j] * 10, 5, 5);
                pen = new Pen(Color.Red, 1);
                g.DrawEllipse(pen, (float)tailleB[j] * 6, (float)poidsB[j] * 10, 5, 5);
            }
            double y1 = 0;
            double x1 = -n.w[2] / n.w[0] * 6.0;
            double y2 = 100;
            double x2 = (-n.w[2] - n.w[1] * y2) / n.w[0];
            x2 = x2 * 6;
            y2 = y2 * 10;

            pen.Color = Color.Black;
            g.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
            Graph_pictureBox.Refresh();
        }



    }
        
        
    
        }

    

