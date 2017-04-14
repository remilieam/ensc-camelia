using System;
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
        static Bitmap bmp2;
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
                // On récpère les positions en les normalisant
                position.Add(double.Parse(lignes[(4 * i) + 1]) / 500.0);
                position.Add(double.Parse(lignes[(4 * i) + 2]) / 500.0);

                lvecteursentrees.Add(position);

                // On récupère le niveau de gris
                lsortiesdesirees.Add(Convert.ToDouble(lignes[(4 * i) + 3]));
            }

            // On effectue l'apprentissage
            reseau.backprop(lvecteursentrees, lsortiesdesirees,
                               Convert.ToDouble(textBoxalpha.Text),
                               Convert.ToInt32(textBoxnbiter.Text));


            // On crée notre image
            bmp = new Bitmap(500, 500);
            pictureBox1.Image = bmp;

            // On remplit cette image de noir
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                    bmp.SetPixel(i, j, Color.Black);

           
            // Les tests sur des valeurs
            List<List<double>> lentreestests = new List<List<double>>();
            // On crée le vecteur test
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    List<double> vect = new List<double>();
                    // On normalise les positions de l'image
                    vect.Add(i / 500.0);
                    vect.Add(j / 500.0);
                    lentreestests.Add(vect);
                }
            }

            
            List<double> lsortiesobtenues;
            // On effectue le test
            lsortiesobtenues = reseau.ResultatsEnSortie(lentreestests);

            int z;
            int cmpt = 0;
            // On fait l'affichage de la première image
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    z = (int)(lsortiesobtenues[cmpt] * 255);

                    bmp.SetPixel(i, j, Color.FromArgb(z, z, z));
                    cmpt++;
                }
            }


            // On crée une autre image
            bmp2 = new Bitmap(500, 500);
            pictureBox2.Image = bmp2;

            // On remplit cette image de noir
            for (int i = 0; i < bmp2.Width; i++)
                for (int j = 0; j < bmp2.Height; j++)
                    bmp2.SetPixel(i, j, Color.Black);
            
            // On crée la liste qui contiendra toutes les erreurs
            List<double> erreurs = new List<double>();
            // Calcul de l'erreur pour chaque pixel et affichage
            for (int i = 0; i < lvecteursentrees.Count(); i++)
            {
                // On récupère les coordonnées du fichier
                int x = (int)(lvecteursentrees[i][0] * 500);
                int y = (int)(lvecteursentrees[i][1] * 500);

                // On determine la position dans l"image 500*500
                int indice = y * bmp.Width + x;

                // Calcul de l'erreur : | valeur approchée - valeur réelle |
                erreurs.Add(Math.Abs(lsortiesobtenues[indice] - lsortiesdesirees[i]));
                
            }

            // On cherche le max et le min dans la liste
            double erreur_max = erreurs.Max();
            double erreur_min = erreurs.Min();
  
            int valeur;
            for (int i = 0; i < erreurs.Count(); i++)
            {
                // On récupère les coordonnées du fichier
                int x = (int)(lvecteursentrees[i][0] * 500);
                int y = (int)(lvecteursentrees[i][1] * 500);

                // On ajuste le coefficient de la liste suivant la nouvelle échelle
                // erreur_min à erreur_max --> 0 à 255
                valeur = (int)((erreurs[i] - erreur_min) * 255 / (erreur_max - erreur_min));

                bmp2.SetPixel(x, y, Color.FromArgb(valeur, valeur, valeur));

            }

            // On calcule la valeur moyenne des erreurs
            double valeur_moyenne = erreurs.Sum() / (erreurs.Count * 1.0);
            valeur_taux_resi_label.Text = Convert.ToString(valeur_moyenne);

            // On affiche l'erreur max
            erreur_max_valeur.Text = Convert.ToString(erreur_max);

                        
            pictureBox1.Invalidate();
            pictureBox2.Invalidate();

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


    }
}
