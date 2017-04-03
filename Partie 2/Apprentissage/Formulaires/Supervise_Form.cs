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
    public partial class Supervise_Form : Form
    {

        private static Graphics g;
        private static Bitmap bmp;
        private Random rnd = new Random();

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
                    Sorties.Add(1);
                }
                else
                {
                    Sorties.Add(0);
                }
            }

            // Apprentissage supervisé pour un coefficient d’apprentissage de 0.5 et 1000 itérations
            Reseau.backprop(Entrees, Sorties, 0.5, 1000);

            // Affichage de l’image de résultat
            Tests(g, bmp);

            MessageBox.Show("Fait !", "Fini", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private List<List<double>> RecupererDonnees(string fichier_source)
        {
            try
            {
                System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
                StreamReader Lecteur = new StreamReader(fichier_source, encoding);

                List<List<double>> Entrees = new List<List<double>>();
                string Donnee = Lecteur.ReadLine();
                int Numero = 0;
                int Couple = 0;
                Entrees.Add(new List<double> { 0, 0 });

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
                Entrees.RemoveAt(Entrees.Count - 1);

                return Entrees;
            }

            catch (Exception Ex)
            {
                string Erreur = "Une erreur est survenue au cours de l’opération :";
                MessageBox.Show(Erreur + "\n" + Ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return new List<List<double>>();
        }

        public void Tests(Graphics g, Bitmap bmp)
        {
            bmp = (Bitmap)Resultat_PictureBox.Image;
            List<List<double>> lvecteursentrees = new List<List<double>>();
            List<double> lsortiesobtenues;

            // Vecteurs des entrées
            for (int i = 0; i < 800; i++)
            {
                for (int j = 0; j < 800; j++)
                {
                    lvecteursentrees.Add(new List<double> { i, j });
                }
            }

            // Vecteurs des sorties
            lsortiesobtenues = Reseau.ResultatsEnSortie(lvecteursentrees);

            // Affichage
            int compteur = 0;
            for (int i = 0; i < 800; i++)
            {
                for (int j = 0; j < 800; j++)
                {
                    if (lsortiesobtenues[compteur] == 0)
                    {
                        bmp.SetPixel(i, j, Color.Yellow);
                    }
                    else
                    {
                        bmp.SetPixel(i, j, Color.Blue);
                    }
                    compteur++;
                }
            }
        }
    }
}
