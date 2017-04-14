using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NonSuperviseClass;

namespace NonSuperviseApp
{
    public partial class NonSupervise_Form : Form
    {
        private static List<Observation> ObservationsTriees = new List<Observation>();
        private static List<Observation> Observations = new List<Observation>();
        private static Random Alea = new Random();
        private int NbIterations;

        private int NbLignes = 0;
        private int NbColonnes = 0;
        private double CoefApprentissage = 0;
        private int DistanceNeurones = 0;

        private Graphics Graphe; // Objet graphique placé en global
        private Bitmap Image;    // Image figurant la carte
        private Pen Crayon;      // Crayon placé en global

        private Carte Carte;
        private static List<Classe> Classes = new List<Classe>();

        /// <summary>
        /// Constructeur
        /// </summary>
        public NonSupervise_Form()
        {
            InitializeComponent();
            NbIterations = 0;
            Image = (Bitmap)Resultat_PictureBox.Image;
            Graphe = Graphics.FromImage(Resultat_PictureBox.Image);
            Crayon = new Pen(Color.White, 1);
            RecupererDonnees();
        }

        /// <summary>
        /// Création de la carte à la première itération, puis algorithme de Kohonen aux suivantes
        /// </summary>
        private void Carte_Button_Click(object sender, EventArgs e)
        {
            if (NbLignes_TextBox.Enabled)
            {
                try
                {
                    // Récupération du nombre de lignes et de colonnes de la carte
                    NbLignes = Convert.ToInt32(NbLignes_TextBox.Text);
                    NbColonnes = Convert.ToInt32(NbColonnes_TextBox.Text);
                    NbLignes_TextBox.Enabled = false;
                    NbColonnes_TextBox.Enabled = false;

                    // Création de la carte
                    Carte = new Carte(NbLignes, NbColonnes, 2, Image.Width);

                    // Affichage des observations (données du fichier « dataetclassif.txt »)
                    // et des neurones de la carte que l’on vient de construire
                    Crayon.Color = Color.White;
                    Graphe.FillRectangle(Crayon.Brush, 0, 0, Image.Width, Image.Height);
                    AfficherDonnees();
                    AfficherNeurones();
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

                    // Récupération du coefficient d’apprentissage et de la distance de voisinage entre 2 neurones
                    CoefApprentissage = Convert.ToDouble(CoefApprentissage_TextBox.Text);
                    DistanceNeurones = Convert.ToInt32(DistanceNeurones_TextBox.Text);
                    for (int i = 0; i < 500; i++)
                    {
                        // Effectuation d’un apprentissage
                        Carte.AlgoKohonen(Observations, CoefApprentissage, DistanceNeurones);
                    }

                    // Affichage du résultat
                    Crayon.Color = Color.White;
                    Graphe.FillRectangle(Crayon.Brush, 0, 0, Image.Width, Image.Height);
                    AfficherDonnees();
                    AfficherNeurones();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Regroupement des neurones les plus forts dans 6 classes distinctes
        /// </summary>
        private void Classes_Button_Click(object sender, EventArgs e)
        {
            // Affectation des neurones les plus forts dans 6 classes
            Classes.Clear();
            Classes = Carte.Regroupement(Observations, 6);

            // Affichage du résultat
            Crayon.Color = Color.White;
            Graphe.FillRectangle(Crayon.Brush, 0, 0, Image.Width, Image.Height);
            AfficherDonnees();
            AfficherClasses();

            Coloriage_Button.Enabled = true;

            MessageBox.Show("Résultat pour " + NbIterations + " itérations.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Coloriage de l’image suivant les appartenances des pixels aux 6 classes
        /// </summary>
        private void Coloriage_Button_Click(object sender, EventArgs e)
        {
            List<Color> Couleurs = new List<Color> { Color.Red, Color.Blue, Color.Green, Color.Brown, Color.Orange, Color.Purple };

            for (int i = 0; i < 800; i++)
            {
                for (int j = 0; j < 800; j++)
                {
                    // Définition du neurone (= pixel)
                    Neurone Pixel = new Neurone(2, 800);
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
                Neurone Observation = new Neurone(2, 800);
                Observation.ModifierPoids((int)Math.Floor(ObservationsTriees[i * 500].Ligne), (int)Math.Floor(ObservationsTriees[i * 500].Colonne));
                int NumeroClasse = RechercherClasse(Observation);

                for (int j = 0; j < 500; j++)
                {
                    Observation = new Neurone(2, 800);
                    Observation.ModifierPoids((int)Math.Floor(ObservationsTriees[i * 500 + j].Ligne), (int)Math.Floor(ObservationsTriees[i * 500 + j].Colonne));
                    if (NumeroClasse != RechercherClasse(Observation))
                    {
                        MauvaiseClassification++;
                    }
                    else { BonneClassification++; }
                }
            }

            // Affichage du résultat
            AfficherDonnees();
            Resultat_PictureBox.Refresh();

            MessageBox.Show("Pourcentage de bonne classification : " + Math.Round(BonneClassification / 3000.0, 2) +
                "\nPourcentage de mauvaise classification : " + Math.Round(MauvaiseClassification / 3000.0, 2), "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Possibilité de créer une nouvelle carte
        /// </summary>
        private void Nouveau_Button_Click(object sender, EventArgs e)
        {
            NbIterations = 0;
            NbLignes_TextBox.Enabled = true;
            NbColonnes_TextBox.Enabled = true;
            Classes_Button.Enabled = false;
            Nouveau_Button.Enabled = false;
            Coloriage_Button.Enabled = false;
        }

        /// <summary>
        /// Récupération des données du fichiers « dataetclassif.txt »
        /// </summary>
        private void RecupererDonnees()
        {
            try
            {
                // Ouverture du fichier
                System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
                StreamReader Lecteur = new StreamReader("../../../ApprentissageData/datasetclassif.txt", encoding);

                // Initialisation des variables
                Observations = new List<Observation>();
                string Donnee = Lecteur.ReadLine();
                int Item = 2;
                List<double> Coordonnees = new List<double> { 0, 0 };

                // Parcours de chaque ligne du fichier
                while (Donnee != null)
                {
                    // Conversion du texte de la ligne lue en double
                    double DonneeChiffree = Convert.ToDouble(Donnee);

                    // Cas où la donnée est intéressante
                    if (Item != 2)
                    {
                        Coordonnees[Item] = DonneeChiffree;
                        Item++;
                    }

                    // Cas où la donnée est inintéressante
                    else
                    {
                        Observations.Add(new Observation(Coordonnees[0], Coordonnees[1]));
                        Coordonnees[0] = 0;
                        Coordonnees[1] = 0;
                        Item = 0;
                    }

                    // Passage à la ligne suivante
                    Donnee = Lecteur.ReadLine();
                }

                // Fermeture du fichier
                Lecteur.Close();
                
                // Ajout de la dernière observation et retrait de la première
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

        /// <summary>
        /// Affichage des données du fichier « dataetclassif.txt »
        /// </summary>
        private void AfficherDonnees()
        {
            for (int i = 0; i < Observations.Count; i++)
            {
                Image.SetPixel(Convert.ToInt32(Observations[i].Ligne), Convert.ToInt32(Observations[i].Colonne), Color.Black);
            }
        }

        /// <summary>
        /// Affichage des neurones sur la carte
        /// </summary>
        private void AfficherNeurones()
        {
            Crayon.Color = Color.Blue;

            for (int i = 0; i < NbLignes; i++)
            {
                for (int j = 0; j < NbColonnes; j++)
                {
                    int x = Convert.ToInt32(Carte.RecupererNeurone(i, j).RecupererPoids(0));
                    int y = Convert.ToInt32(Carte.RecupererNeurone(i, j).RecupererPoids(1));
                    Graphe.DrawEllipse(Crayon, x - 2, y - 2, 4, 4);
                }
            }

            Resultat_PictureBox.Refresh();
        }

        /// <summary>
        /// Coloration des neurones suivant la classe à laquelle ils appartiennent
        /// </summary>
        private void AfficherClasses()
        {
            List<Color> Couleurs = new List<Color> { Color.Red, Color.Blue, Color.Green, Color.Brown, Color.Orange, Color.Purple };
            for (int i = 0; i < 6; i++)
            {
                Crayon.Color = Couleurs[i];

                foreach (Neurone neurone in Classes[i].ListeNeurones)
                {
                    int x = Convert.ToInt32(neurone.RecupererPoids(0));
                    int y = Convert.ToInt32(neurone.RecupererPoids(1));
                    Graphe.DrawEllipse(Crayon, x - 2, y - 2, 4, 4);
                }
            }

            Resultat_PictureBox.Refresh();
        }

        /// <summary>
        /// Recherche à quelle classe appartient un neurone donné
        /// </summary>
        /// <param name="Neurone">Neurone dont on cherche la classe</param>
        /// <returns>Numéro de la classe à laquelle appartient le neurone</returns>
        private int RechercherClasse(Neurone Neurone)
        {
            // Recherche de la classe gagnante
            int NumeroClasseGagnante = 0;
            double DistanceMin = Neurone.CalculerDistance(Classes[0].ListeNeurones[0]);

            // On recherche le neurone qui a la plus faible distance du pixel
            // dans chacune des 6 classes. La classe gagnante est celle à laquelle
            // appartient le neurone ayant la plus faible distance avec le pixel
            for (int k = 0; k < Classes.Count; k++)
            {
                for (int l = 0; l < Classes[k].ListeNeurones.Count; l++)
                {
                    if (DistanceMin > Neurone.CalculerDistance(Classes[k].ListeNeurones[l]))
                    {
                        DistanceMin = Neurone.CalculerDistance(Classes[k].ListeNeurones[l]);
                        NumeroClasseGagnante = k;
                    }
                }
            }

            // Renvoi du numéro de la classe gagnante
            return NumeroClasseGagnante;
        }

        /// <summary>
        /// Fermeture du formulaire
        /// </summary>
        private void Non_Supervise_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
