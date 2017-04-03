﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Graphics g;
        static Bitmap bmp;
        Random rnd = new Random();

        Reseau reseau;

        private void button1_Click(object sender, EventArgs e)
        {
            // Initialisation d'un réseau de neurones avec le nombre d'entrées, 
            // le nombre de couches et le nbre de neurones par couches
            reseau = new Reseau(Convert.ToInt32(textBoxnbentrees.Text),
                                        Convert.ToInt32(textBoxnbcouches.Text),
                                        Convert.ToInt32(textBoxnbneurcouche.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // En entrée on a une liste de k valeurs réelles correspondant aux k neurones
            // de la 1ère couche dite couche des entrées ou entrées tout court
            // On dispose en général d'une base de données de vecteurs d'entrées
            // c'est pour cela qu'on a une liste de vecteurs, donc une liste de liste 
            List<List<double>> lvecteursentrees = new List<List<double>>();

            // On a 1 seule sortie associée à chaque vecteur d'entrée
            // donc on a seulement 1 liste de réels
            // Attention, on suppose ici que le nième élément de cette liste est
            // la sortie désirée du nième vecteur de levecteurentrees
            List<double> lsortiesdesirees = new List<double>();

            // On récupère les lignes du fichiers textes
            string[] lignes = System.IO.File.ReadAllLines("../../../datasetregression.txt");
            // On récupère les positions et les intensités
            List<double> position; ;
            for (int i = 0; i < lignes.GetLength(0) / 4; i++)
            {
                position = new List<double> { };
                position.Add(int.Parse(lignes[(4 * i) + 1]));
                position.Add(int.Parse(lignes[(4 * i) + 2]));

                lvecteursentrees.Add(position);

                lsortiesdesirees.Add(Convert.ToDouble(lignes[(4 * i) + 3]));
            }

            /*
             for (int i = 0; i < 1000; i++)
             {
                 List<double> vect = new List<double>();
                 double x = rnd.NextDouble();
                 vect.Add(x); // Une seule valeur ici pour ce vecteur 
                // EN général, un vecteur sera récupéré dans un fichier de données
                 lvecteursentrees.Add(vect);
                // Pour la sortie, idem, en général, on la récupère dans le fichier 
                // de données; ici on la crée de toute pièce à partir d'une fonction
                // modèle
                 lsortiesdesirees.Add(fonctionmodele(x));
             }
             */


            // Apprentissage
            reseau.backprop(lvecteursentrees, lsortiesdesirees,
                               Convert.ToDouble(textBoxalpha.Text),
                               Convert.ToInt32(textBoxnbiter.Text));


            int x, y;
            Int32 z;

            bmp = new Bitmap(500, 500);
            pictureBox1.Image = bmp;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                    bmp.SetPixel(i, j, Color.Black);



            // Les tests !!

            List<List<double>> lentreestests = new List<List<double>>();
            // On crée le vecteur test
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    List<double> vect = new List<double>();
                    vect.Add(i);
                    vect.Add(j);
                    lentreestests.Add(vect);
                }
            }


            List<double> lsortiesobtenues;
            lsortiesobtenues = reseau.ResultatsEnSortie(lentreestests);

            int cmpt = 0;
            // Affichage
            for (x = 0; x < bmp.Width; x++)
            {
                for (y = 0; y < bmp.Height; y++)
                {
                    z = (Int32)lsortiesobtenues[cmpt];

                    bmp.SetPixel(x, y, Color.FromArgb(z * 256 + z * 6536 + z));
                    cmpt++;
                }
            }



            // Tests( g, bmp);
            pictureBox1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = (Bitmap)pictureBox1.Image;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            reseau.AfficheInfoNeurone(Convert.ToInt32(textBoxnumcouche.Text),
                                       Convert.ToInt32(textBoxnumneur.Text),
                                       listBox1);

        }
        /*****************************************************************/
        // Attention, la fonction à apprendre doit fournir des valeurs entre 0 et 1 !!!
        double fonctionmodele(double x)
        {
            // return Math.Sin(x * 20) / 2.5 + 0.5;
            if (x < 0.2 || x > 0.8) return 0.8;
            else return 0.2;
        }

        /**********************************************************************/
        public void Tests(Graphics g, Bitmap bmp)
        {
            int x, z, zdesire;
            double x2, z2;
            for (x = 0; x < bmp.Width; x++)
                for (z = 0; z < bmp.Height; z++)
                    bmp.SetPixel(x, z, Color.Black);

            List<List<double>> lvecteursentrees = new List<List<double>>();
            List<double> lsortiesdesirees = new List<double>();
            List<double> lsortiesobtenues;

            // EN général, on reprend ici les données récupérées du fichier base de données
            // mais pour illustrer le fonctionnement, on se propose ici de tester 200 valeurs
            // de x (dimension 1 pour les entrées ici) entre 0 et 1, ramenées entre 0 et 200
            // idem pour la sortie, pour permettre l'affichage dans une image.
            for (x = 0; x < lvecteursentrees.Count; x++)
            {
                x2 = x / lvecteursentrees.Count;
                // Initialisation des activations  ai correspondant aux entrées xi
                // Le premier neurone est une constante égale à 1
                List<double> vect = new List<double>();
                vect.Add(x2); // Une seule valeur ici pour ce vecteur 
                lvecteursentrees.Add(vect);
                lsortiesdesirees.Add(fonctionmodele(x2));
            }

            lsortiesobtenues = reseau.ResultatsEnSortie(lvecteursentrees);

            // Affichage
            for (x = 0; x < 200; x++)
            {
                z2 = lsortiesobtenues[x];

                // z2 valeur attendu entre 0 et 1 ; conversion pour z qui est retenu pour l'affichage
                z = (int)(z2 * 200);
                zdesire = (int)(lsortiesdesirees[x] * 200);
                bmp.SetPixel(x, bmp.Height - z - 1, Color.Yellow);

                bmp.SetPixel(x, bmp.Height - zdesire - 1, Color.White);
            }

        }

    }
}
