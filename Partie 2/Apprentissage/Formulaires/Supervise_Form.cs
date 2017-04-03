﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Classes;

namespace Formulaire
{
    public partial class Supervise_Form : Form
    {
        private static Bitmap Image;
        private Reseau Reseau;

        public Supervise_Form()
        {
            InitializeComponent();
        }

        private void Reseau_Button_Click(object sender, EventArgs e)
        {
            int NbCouches = 0;
            int NbNeurones = 0;

            // Vérification du nombre de couches et du nombre de neurones
            try
            {
                NbCouches = Convert.ToInt32(NbCouches_TextBox.Text);
                if (NbCouches <= 1)
                {
                    throw new Exception("Le nombre de couches est trop faible.");
                }

                NbNeurones = Convert.ToInt32(NbNeurones_TextBox.Text);
                if (NbNeurones <= 0)
                {
                    throw new Exception("Le nombre de neurones par couches cachées est trop faible.");
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Création du réseau (3 entrées car un couple de données + le biais)
            Reseau = new Reseau(3, NbCouches, NbNeurones);

            // Récupération des valeurs d’entrées
            List<List<double>> Entrees = this.RecupererDonnees("../../../Donnees/datasetclassif.txt");

            // Récupération des sorties désirées
            List<double> Sorties = new List<double>();
            for (int i = 0; i < 3000; i++)
            {
                if (i < 1500)
                {
                    Sorties.Add(0.1);
                }
                else
                {
                    Sorties.Add(0.9);
                }
            }

            // Mélange des listes
            List<List<double>> EntreesM = new List<List<double>>();
            List<double> SortiesM = new List<double>();
            for (int i = 0; i < 1500; i++)
            {
                EntreesM.Add(new List<double> { Entrees[i][0] / 800.0, Entrees[i][1] / 800.0 });
                SortiesM.Add(Sorties[i]);
                EntreesM.Add(new List<double> { Entrees[i + 1500][0] / 800.0, Entrees[i + 1500][1] / 800.0 });
                SortiesM.Add(Sorties[1500 + i]);
            }

            // Apprentissage supervisé pour un coefficient d’apprentissage de 0.5 et 1000 itérations
            Reseau.backprop(EntreesM, SortiesM, 0.5, 1000);

            // Affichage de l’image de résultat
            Tests();

            // Affichage des valeurs du fichier
            for (int i = 0; i < 3000; i++)
            {
                Entrees[i][0] = Math.Floor(Entrees[i][0]);
                Entrees[i][1] = Math.Floor(Entrees[i][1]);
                if (i < 1500)
                {
                    Supervise_Form.Image.SetPixel((int)Entrees[i][0], (int)Entrees[i][1], Color.Black);
                }
                else
                {
                    Supervise_Form.Image.SetPixel((int)Entrees[i][0], (int)Entrees[i][1], Color.White);
                }
            }
        }

        private List<List<double>> RecupererDonnees(string fichier_source)
        {
            try
            {
                System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
                StreamReader Lecteur = new StreamReader(fichier_source, encoding);

                List<List<double>> Entrees = new List<List<double>>();
                string Donnee = Lecteur.ReadLine();
                int Numero = -1;
                int Couple = 2;

                while (Donnee != null)
                {
                    double DonneeChiffree = Convert.ToDouble(Donnee);
                    if (Couple != 2)
                    {
                        Entrees[Numero][Couple] = DonneeChiffree;
                        Couple++;
                    }
                    else
                    {
                        Entrees.Add(new List<double> { 0, 0 });
                        Numero++;
                        Couple = 0;
                    }

                    Donnee = Lecteur.ReadLine();
                }

                Lecteur.Close();

                return Entrees;
            }

            catch (Exception Ex)
            {
                string Erreur = "Une erreur est survenue au cours de l’opération :";
                MessageBox.Show(Erreur + "\n" + Ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return new List<List<double>>();
        }

        public void Tests()
        {
            Supervise_Form.Image = (Bitmap)Resultat_PictureBox.Image;
            List<List<double>> Entrees = new List<List<double>>();
            List<double> Sorties;

            // Vecteurs des entrées
            for (int i = 0; i < 800; i++)
            {
                for (int j = 0; j < 800; j++)
                {
                    Entrees.Add(new List<double> { i / 800.0, j / 800.0 });
                }
            }

            // Vecteurs des sorties
            Sorties = Reseau.ResultatsEnSortie(Entrees);

            // Affichage
            int compteur = 0;
            for (int i = 0; i < 800; i++)
            {
                for (int j = 0; j < 800; j++)
                {
                    if (Sorties[compteur] < 0.5)
                    {
                        Supervise_Form.Image.SetPixel(i, j, Color.Yellow);
                    }
                    else
                    {
                        Supervise_Form.Image.SetPixel(i, j, Color.Blue);
                    }
                    compteur++;
                }
            }
        }
    }
}
