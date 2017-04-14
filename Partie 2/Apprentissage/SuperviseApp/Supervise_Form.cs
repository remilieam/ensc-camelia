using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperviseClass;

namespace SuperviseApp
{
    public partial class Supervise_Form : Form
    {
        private static Bitmap Image;
        private Reseau Reseau;
        private int Secondes;

        /// <summary>
        /// Constructeur
        /// </summary>
        public Supervise_Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Création, apprentissage et test du réseau en fonction des souhaits de l’utilisateur
        /// (nombre de couches du réseau et nombre de neurones par couches cachées, nombre d’itérations
        /// dans l’apprentissage et coefficient d’apprentissage) pour les données fournies dans
        /// « dataetclassif.txt »
        /// </summary>
        private void Reseau_Button_Click(object sender, EventArgs e)
        {
            // Initialisation des variables
            int NbCouches = 0;
            int NbNeurones = 0;
            int NbIterations = 0;
            double CoefApprentissage = 0;

            try
            {
                // Récupération des données inscrites dans les champs par l’utilisateur
                NbCouches = Convert.ToInt32(NbCouches_TextBox.Text);
                if (NbCouches <= 1) { throw new Exception("Le nombre de couches doit être au minimum de 2."); }
                NbNeurones = Convert.ToInt32(NbNeurones_TextBox.Text);
                if (NbNeurones <= 0) { throw new Exception("Le nombre de neurones par couches cachées doit être au minimum de 1."); }
                NbIterations = Convert.ToInt32(NbIterations_TextBox.Text);
                if (NbIterations <= 0) { throw new Exception("Le nombre d’itérations doit être au minimum de 1."); }
                CoefApprentissage = Convert.ToDouble(CoefApprentissage_TextBox.Text);
                if (CoefApprentissage <= 0 && CoefApprentissage >= 1) { throw new Exception("Le coefficient d’apprentissage doit être compris entre 0 et 1 exclus."); }

                // Création du réseau (3 entrées car un couple de données + le biais)
                Reseau = new Reseau(3, NbCouches, NbNeurones);

                // Récupération des valeurs d’entrées
                List<List<double>> Entrees = this.RecupererDonnees();

                // Récupération des sorties désirées
                List<double> Sorties = new List<double>();
                for (int i = 0; i < 3000; i++)
                {
                    if (i < 1500)
                        Sorties.Add(0.1);
                    else
                        Sorties.Add(0.9);
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

                // Apprentissage supervisé
                Secondes = 0;
                Chrono_Timer.Start();
                Reseau.Retropropagation(EntreesM, SortiesM, CoefApprentissage, NbIterations);
                Chrono_Timer.Stop();

                // Affichage de l’image de résultat
                Tests();

                // Affichage des valeurs du fichier
                for (int i = 0; i < 3000; i++)
                {
                    Entrees[i][0] = Math.Floor(Entrees[i][0]);
                    Entrees[i][1] = Math.Floor(Entrees[i][1]);
                    if (i < 1500)
                        Supervise_Form.Image.SetPixel((int)Entrees[i][0], (int)Entrees[i][1], Color.Black);
                    else
                        Supervise_Form.Image.SetPixel((int)Entrees[i][0], (int)Entrees[i][1], Color.White);
                }

                // Calcul du pourcentage de bonne et mauvaise classification et calcul de l’erreur résiduelle
                List<double> SortiesCalculees = Reseau.TesterReseau(EntreesM);
                double ErreurResiduelle = 0;
                int BonneClassification = 0;
                int MauvaiseClassification = 0;

                for (int i = 0; i < SortiesCalculees.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (SortiesCalculees[i] < 0.5) { BonneClassification++; }
                        else { MauvaiseClassification++; }
                        ErreurResiduelle += Math.Abs(SortiesCalculees[i] - 0.1);
                    }

                    else
                    {
                        if (SortiesCalculees[i] > 0.5) { BonneClassification++; }
                        else { MauvaiseClassification++; }
                        ErreurResiduelle += Math.Abs(SortiesCalculees[i] - 0.9);
                    }
                }

                // Rafraîchissement de l’image et affiche des performances dans une boîte de dialogue
                Resultat_PictureBox.Refresh();
                string Message = "Pourcentage de bonne classification : " + Math.Round(BonneClassification / 3000.0, 4) * 100 +
                    "\nPourcentage de mauvaise classification : " + Math.Round(MauvaiseClassification / 3000.0, 4) * 100 +
                    "\nErreur résiduelle : " + Math.Round(ErreurResiduelle / 3000.0, 2);
                MessageBox.Show(Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Récupération des données du fichier « dataetclassif.txt »
        /// </summary>
        /// <param name="fichier_source"></param>
        /// <returns></returns>
        private List<List<double>> RecupererDonnees()
        {
            try
            {
                // Ouverture du fichier
                System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
                StreamReader Lecteur = new StreamReader("../../../ApprentissageData/datasetclassif.txt", encoding);

                // Initialisation des variables
                List<List<double>> Entrees = new List<List<double>>();
                string Donnee = Lecteur.ReadLine();
                int Numero = -1;
                int Couple = 2;

                // Parcours des lignes du fichier une par une
                while (Donnee != null)
                {
                    // Conversion du texte récupéré en double
                    double DonneeChiffree = Convert.ToDouble(Donnee);

                    // Cas où on récupère une donnée exploitable
                    if (Couple != 2)
                    {
                        Entrees[Numero][Couple] = DonneeChiffree;
                        Couple++;
                    }

                    // Cas où on récupère le numéro d’un couple de données d’entrée
                    else
                    {
                        Entrees.Add(new List<double> { 0, 0 });
                        Numero++;
                        Couple = 0;
                    }

                    // Passage à la ligne suivante
                    Donnee = Lecteur.ReadLine();
                }

                // Fermeture du fichier
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

        /// <summary>
        /// Test le réseau avec pour données d’entrée les pixel d’une image 800 par 800
        /// </summary>
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
            Sorties = Reseau.TesterReseau(Entrees);

            // Affichage
            int Compteur = 0;
            for (int i = 0; i < 800; i++)
            {
                for (int j = 0; j < 800; j++)
                {
                    if (Sorties[Compteur] < 0.5)
                    {
                        Supervise_Form.Image.SetPixel(i, j, Color.Orange);
                    }
                    else
                    {
                        Supervise_Form.Image.SetPixel(i, j, Color.Blue);
                    }
                    Compteur++;
                }
            }
        }

        /// <summary>
        /// Ajout d’une seconde au temps de calcul
        /// </summary>
        private void Chrono_Timer_Tick(object sender, EventArgs e)
        {
            Secondes += 1;
        }

        /// <summary>
        /// Fermeture du formulaire
        /// </summary>
        private void Supervise_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
