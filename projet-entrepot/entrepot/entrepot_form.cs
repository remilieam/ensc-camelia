using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace entrepot
{
    public partial class entrepot_form : Form
    {
        // Tableaux d’images et d’entiers représentant l’entrepôt
        PictureBox[,] entrepot_image = new PictureBox[25, 25];
        int[,] entrepot = new int[25, 25];

        // Tableaux pour afficher les numéros de lignes et colonnes
        Label[] lignes = new Label[25];
        Label[] colonnes = new Label[25];

        // Listes pour les chariots (3 chariots sont prédéfinis par défaut)
        List<int> chariots_x = new List<int> { 0, 13, 24 };
        List<int> chariots_y = new List<int> { 0, 12, 24 };

        /// <summary>
        /// Permet de créer le formulaire initial
        /// </summary>
        public entrepot_form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Permet d’entrepôt au chargement de la page avec les chariots par défaut
        /// </summary>
        private void entrepot_form_Load(object sender, EventArgs e)
        {
            genererEntrepot();
            ajouterChariots();
        }

        /// <summary>
        /// Permet d’afficher le formulaire pour ajouter des chariots
        /// </summary>
        private void chariots_button_Click(object sender, EventArgs e)
        {
            // Création du formulaire pour ajouter des chariots
            chariots_form chariots = new chariots_form();

            // Ouverture modale du formulaire
            if (chariots.ShowDialog() == DialogResult.OK)
            {
                // Récupération de la position des chariots à ajouter
                chariots_x.AddRange(chariots.chariots_x);
                chariots_y.AddRange(chariots.chariots_y);

                // Ajout des chariots
                ajouterChariots();
            }
        }

        /// <summary>
        /// Permet de générer un entrepôt sans chariot
        /// </summary>
        private void genererEntrepot()
        {
            // Création, positionnement et affichage des lignes et des colonnes
            for (int i = 0; i < 25; i++)
            {
                lignes[i] = new Label();
                lignes[i].TextAlign = ContentAlignment.MiddleCenter;
                lignes[i].Text = (i + 1).ToString();
                lignes[i].Top = 20 + i * 20;
                lignes[i].Left = 0;
                lignes[i].Width = 20;
                lignes[i].Height = 20;
                this.Controls.Add(lignes[i]);

                colonnes[i] = new Label();
                colonnes[i].TextAlign = ContentAlignment.MiddleCenter;
                colonnes[i].Text = (i + 1).ToString();
                colonnes[i].Top = 0;
                colonnes[i].Left = 20 + i * 20;
                colonnes[i].Width = 20;
                colonnes[i].Height = 20;
                this.Controls.Add(colonnes[i]);
            }

            // On assigne au tableau les images
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    // Création du carré
                    entrepot_image[i, j] = new PictureBox();

                    // Positionnement du carré dans le formulaire
                    entrepot_image[i, j].Top = 20 + i * 20;
                    entrepot_image[i, j].Left = 20 + j * 20;
                    entrepot_image[i, j].Width = 20;
                    entrepot_image[i, j].Height = 20;

                    // Affichage du carré dans le formulaire
                    this.Controls.Add(entrepot_image[i, j]);

                    // S’il s’agit d’une étagère
                    if (i % 2 == 0 && i != 0 && i != 24 &&
                        ((j >= 2 && j < 11) || (j >= 14 && j < 23)))
                    {
                        // On gère le tableau d’images 
                        FileStream fs = new FileStream("../../noir.png", FileMode.Open);
                        entrepot_image[i, j].Image = Image.FromStream(fs);
                        fs.Close();

                        // Puis le tableau d’entiers
                        entrepot[i, j] = -1;
                    }

                    else
                    {
                        // On gère le tableau d’images
                        FileStream fs = new FileStream("../../blanc.png", FileMode.Open);
                        entrepot_image[i, j].Image = Image.FromStream(fs);
                        fs.Close();

                        // Puis le tableau d’entiers
                        entrepot[i, j] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Permet d’ajouter des chariots dans l’entrepôt
        /// </summary>
        private void ajouterChariots()
        {
            for (int i = 0; i < chariots_x.Count; i++)
            {
                // Modification du carré
                FileStream fs = new FileStream("../../chariot.png", FileMode.Open);
                entrepot_image[chariots_x[i], chariots_y[i]].Image = Image.FromStream(fs);
                fs.Close();

                // Chariots = obstacle
                entrepot[chariots_x[i], chariots_y[i]] = -1;
            }
        }
    }
}
