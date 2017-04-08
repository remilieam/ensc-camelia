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
    public partial class Non_Supervise_Form : Form
    {
        private static List<Observation> Observations = new List<Observation>();
        private static Random Alea = new Random();

        private int NbLignes;
        private int NbColonnes;
        private double CoefApprentissage;

        private Graphics Graphe; // Objet graphique placé en global
        private Bitmap Image;    // Image figurant la carte
        private Pen Crayon;      // Crayon placé en global

        private Carte Carte;
        private static List<Classe> Classes = new List<Classe>();

        public Non_Supervise_Form()
        {
            InitializeComponent();
            Image = (Bitmap)Resultat_PictureBox.Image;
            Graphe = Graphics.FromImage(Resultat_PictureBox.Image);
            Crayon = new Pen(Color.White, 1);
            RecupererDonnees("../../../Donnees/datasetclassif.txt");
        }

        private void Carte_Button_Click(object sender, EventArgs e)
        {
            if (NbLignes_TextBox.Enabled)
            {
                try
                {
                    NbLignes = Convert.ToInt32(NbLignes_TextBox.Text);
                    NbColonnes = Convert.ToInt32(NbColonnes_TextBox.Text);
                    NbLignes_TextBox.Enabled = false;
                    NbColonnes_TextBox.Enabled = false;

                    CoefApprentissage = Convert.ToDouble(CoefApprentissage_TextBox.Text);

                    Carte = new Carte(NbLignes, NbColonnes, 2, Image.Width);

                    Crayon.Color = Color.White;
                    Graphe.FillRectangle(Crayon.Brush, 0, 0, Image.Width, Image.Height);
                    AfficherDonnees();
                    AfficherPoints();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                try
                {
                    Classes_Button.Enabled = true;
                    Nouveau_Button.Enabled = true;

                    CoefApprentissage = Convert.ToDouble(CoefApprentissage_TextBox.Text);

                    Carte.AlgoKohonen(Observations, CoefApprentissage);

                    Crayon.Color = Color.White;
                    Graphe.FillRectangle(Crayon.Brush, 0, 0, Image.Width, Image.Height);
                    AfficherDonnees();
                    AfficherPoints();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Classes_Button_Click(object sender, EventArgs e)
        {
            Classes.Clear();
            Classes = Carte.Regroupement(Observations, 6);

            Crayon.Color = Color.White;
            Graphe.FillRectangle(Crayon.Brush, 0, 0, Image.Width, Image.Height);
            AfficherDonnees();
            AfficherClasses();
        }

        private void Nouveau_Button_Click(object sender, EventArgs e)
        {
            NbLignes_TextBox.Enabled = true;
            NbColonnes_TextBox.Enabled = true;
            Classes_Button.Enabled = false;
            Nouveau_Button.Enabled = false;
        }

        private void RecupererDonnees(string fichier_source)
        {
            try
            {
                System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
                StreamReader Lecteur = new StreamReader(fichier_source, encoding);

                Observations = new List<Observation>();
                string Donnee = Lecteur.ReadLine();
                int Item = 2;
                List<double> Coordonnees = new List<double> { 0, 0 };

                while (Donnee != null)
                {
                    double DonneeChiffree = Convert.ToDouble(Donnee);
                    if (Item != 2)
                    {
                        Coordonnees[Item] = DonneeChiffree;
                        Item++;
                    }
                    else
                    {
                        Observations.Add(new Observation(Coordonnees[0], Coordonnees[1]));
                        Coordonnees[0] = 0;
                        Coordonnees[1] = 0;
                        Item = 0;
                    }

                    Donnee = Lecteur.ReadLine();
                }

                Observations.RemoveAt(0);

                Lecteur.Close();
            }

            catch (Exception Ex)
            {
                string Erreur = "Une erreur est survenue au cours de l’opération :";
                MessageBox.Show(Erreur + "\n" + Ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherDonnees()
        {
            for (int i = 0; i < Observations.Count; i++)
            {
                Image.SetPixel(Convert.ToInt32(Observations[i].Ligne), Convert.ToInt32(Observations[i].Colonne), Color.Black);
            }
        }

        private void AfficherPoints()
        {
            Crayon.Color = Color.Blue;

            for (int i = 0; i < NbLignes; i++)
            {
                for (int j = 0; j < NbColonnes; j++)
                {
                    int x = Convert.ToInt32(Carte.RecupererPoint(i, j).RecupererPoids(0));
                    int y = Convert.ToInt32(Carte.RecupererPoint(i, j).RecupererPoids(1));
                    Graphe.DrawEllipse(Crayon, x - 2, y - 2, 4, 4);
                }
            }

            Resultat_PictureBox.Refresh();
        }

        private void AfficherClasses()
        {
            List<Color> Couleurs = new List<Color> { Color.Red, Color.Blue, Color.Green, Color.Brown, Color.Orange, Color.Purple };
            for (int i = 0; i < 6; i++)
            {
                Crayon.Color = Couleurs[i];

                foreach (Classes.Point point in Classes[i].ListePoints)
                {
                    int x = Convert.ToInt32(point.RecupererPoids(0));
                    int y = Convert.ToInt32(point.RecupererPoids(1));
                    Graphe.DrawEllipse(Crayon, x - 2, y - 2, 4, 4);
                }
            }

            Resultat_PictureBox.Refresh();
        }
    }
}
