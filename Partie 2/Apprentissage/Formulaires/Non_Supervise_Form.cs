using System;
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
        private static List<Observation> ObservationsTriees = new List<Observation>();
        private static List<Observation> Observations = new List<Observation>();
        private static Random Alea = new Random();
        private int NbIterations;

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
            NbIterations = 0;
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
                    NbIterations++;
                    Classes_Button.Enabled = true;
                    Nouveau_Button.Enabled = true;

                    CoefApprentissage = Convert.ToDouble(CoefApprentissage_TextBox.Text);

                    Carte.AlgoKohonen(Observations, CoefApprentissage, 2);

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

            Coloriage_Button.Enabled = true;

            MessageBox.Show("Résultat pour " + NbIterations + " itérations.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Coloriage_Button_Click(object sender, EventArgs e)
        {
            List<Color> Couleurs = new List<Color> { Color.Red, Color.Blue, Color.Green, Color.Brown, Color.Orange, Color.Purple };

            for (int i = 0; i < 800; i++)
            {
                for (int j = 0; j < 800; j++)
                {
                    // Définition du point (= neurone = pixel)
                    Classes.Point Pixel = new Classes.Point(2, 800);
                    Pixel.ModifierPoids(i, j);

                    // Modification du pixel en fonction du numéro de classe
                    Image.SetPixel(i, j, Couleurs[RechercherClasse(Pixel)]);
                }
            }

            // Calcul du pourcentage de bonne classification et de mauvaise
            int BonneClassification = 0;
            int MauvaiseClassification = 0;

            for (int i = 0; i < 6; i++)
            {
                Classes.Point Observation = new Classes.Point(2, 800);
                Observation.ModifierPoids((int)Math.Floor(ObservationsTriees[i * 500].Ligne), (int)Math.Floor(ObservationsTriees[i * 500].Colonne));
                int NumeroClasse = RechercherClasse(Observation);

                for (int j = 0; j < 500; j++)
                {
                    Observation = new Classes.Point(2, 800);
                    Observation.ModifierPoids((int)Math.Floor(ObservationsTriees[i * 500 + j].Ligne), (int)Math.Floor(ObservationsTriees[i * 500 + j].Colonne));
                    if (NumeroClasse != RechercherClasse(Observation))
                    {
                        MauvaiseClassification++;
                    }
                    else { BonneClassification++; }
                }
            }

            AfficherDonnees();

            MessageBox.Show("Pourcentage de bonne classification : " + Math.Round(BonneClassification / 3000.0, 2) +
                "\nPourcentage de mauvaise classification : " + Math.Round(MauvaiseClassification / 3000.0, 2), "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Nouveau_Button_Click(object sender, EventArgs e)
        {
            NbIterations = 0;
            NbLignes_TextBox.Enabled = true;
            NbColonnes_TextBox.Enabled = true;
            Classes_Button.Enabled = false;
            Nouveau_Button.Enabled = false;
            Coloriage_Button.Enabled = false;
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

                Lecteur.Close();
                
                Observations.Add(new Observation(Coordonnees[0], Coordonnees[1]));
                Observations.RemoveAt(0);

                // Mélange des observations
                int NbObservations = Observations.Count;
                ObservationsTriees.AddRange(Observations);
                List<Observation> ObservationsMelangees = new List<Observation>();

                for (int i = 0; i < NbObservations; i++)
                {
                    int Numero = Alea.Next(Observations.Count);
                    ObservationsMelangees.Add(Observations[Numero]);
                    Observations.RemoveAt(Numero);
                }

                Observations = ObservationsMelangees;
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

        private int RechercherClasse(Classes.Point Neurone)
        {
            // Recherche de la classe gagnante
            int NumeroClasseGagnante = 0;
            double DistanceMin = Neurone.CalculerDistance(Classes[0].ListePoints[0]);

            // On recherche le neurone qui a la plus faible distance du pixel
            // dans chacune des 6 classes. La classe gagnante est celle à laquelle
            // appartient le neurone ayant la plus faible distance avec le pixel
            for (int k = 0; k < Classes.Count; k++)
            {
                for (int l = 0; l < Classes[k].ListePoints.Count; l++)
                {
                    if (DistanceMin > Neurone.CalculerDistance(Classes[k].ListePoints[l]))
                    {
                        DistanceMin = Neurone.CalculerDistance(Classes[k].ListePoints[l]);
                        NumeroClasseGagnante = k;
                    }
                }
            }

            return NumeroClasseGagnante;
        }

        private void Non_Supervise_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
