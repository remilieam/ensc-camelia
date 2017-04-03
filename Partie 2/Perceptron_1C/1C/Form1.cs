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
        protected int nbiterations=1;
        protected double []tailleA = new double[]{36.1, 41.1, 47.9, 47, 49.8, 48.5};
        protected double[] tailleB = new double[] { 47.8, 55.5, 62.0, 64.1, 64.3, 65.3 };
        protected int sortiecorrecte;
        protected double[] poidsA = new double[] { 17,16.5,18,18.5,22,21};
        protected double[] poidsB = new double[] { 11.7, 16.4, 13, 22, 18.5, 21 };
         private Graphics g;	// Objet graphique placé en global
        private Bitmap bmp;
        private Pen pen;		// Crayon placé en global
        private int nbcol;      // nb de colonnes de la carte de Kohonen
        private int nblignes;   
        protected double[] point1=new double[]{-3/2,0}; // 0,-w3/w2
        protected double[] point2 = new double[] { -23/2,20}; //Deuxième point de la droite
        double coeff = 2.5; //Détermination du coefficient directeur yb-ya/xb-xa
        private Graphics g;	// Objet graphique placé en global
        private Bitmap bmp;
        private Pen pen;		// Crayon placé en global
        private int nbcol;      // nb de colonnes de la carte de Kohonen
        private int nblignes;
     
  
 
        public Form1()
        {
            InitializeComponent();
        }

        private void Chercher_button_Click(object sender, EventArgs e)
        {
            int X1 = 0;
            int X2 = 50;
            int Y1 = (3* X1) + 6;
            int Y2 = (2 * X2) + 6;
            Graphics dessin = this.CreateGraphics();
            dessin.DrawLine(new Pen(Color.Blue), X1, X2, Y1, Y2);
            
           
            

            Neurone n = new Neurone();
            poids = double.Parse(Poids_TextBox.Text);
            taille = double.Parse(taille_TextBox.Text);
            
               
                // on cherche la sortie normalement correcte
               sortiecorrecte = 1;
               
            
            
            if(taille>coeff*poids)

            {   
                sortiecorrecte=0;
            }



              
               

                
            


                n.entrees[0] = poids / 629.40; //on normalise
                n.entrees[1] = taille / 215.60; //on normalise
                n.entrees[2] = 1;

                // On calcule la sortie avec les poids
                n.CalculeSortie();
                if (sortiecorrecte != n.sortie)
                {
                    n.RecalculeSortie(sortiecorrecte);
                }





                Reponse_TextBox.Text = n.nombreiteration.ToString();
                Poids_final_TextBox.Text = n.somme.ToString();
                classe_TextBox.Text = sortiecorrecte.ToString();

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
