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
        public int[,] entrepot = new int[25, 25];

        // Tableaux pour afficher les numéros de lignes et colonnes
        Label[] lignes = new Label[25];
        Label[] colonnes = new Label[25];

        // Listes pour les chariots (3 chariots sont prédéfinis par défaut)
        List<int> chariots_x = new List<int> { 0, 13, 24, 5, 16, 13, 23, 14, 18, 6, 17, 15, 23, 8, 5 };
        List<int> chariots_y = new List<int> { 0, 12, 24, 7, 12, 3, 0, 13, 23, 1, 19, 7, 23, 24, 20 };
        // Nord : 0, Est :1, Sud : 2, Ouest : 3
        List<int> chariots_k = new List<int> { 0, 2, 1, 2, 3, 1, 0, 0, 2, 1, 2, 3, 1, 0, 3 };

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
            generer_entrepot();
            ajouter_chariots();
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
                ajouter_chariots();
            }
        }

        /// <summary>
        /// Permet de générer un entrepôt sans chariot
        /// </summary>
        private void generer_entrepot()
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
        private void ajouter_chariots()
        {
            for (int i = 0; i < chariots_x.Count; i++)
            {
                // Modification du carré
                FileStream fs = new FileStream("../../chariot.png", FileMode.Open);
                entrepot_image[chariots_x[i], chariots_y[i]].Image = Image.FromStream(fs);
                fs.Close();

                // Chariots = obstacle
                entrepot[chariots_x[i], chariots_y[i]] = -2;
            }
        }

        private void selection_button_Click(object sender, EventArgs e)
        {
            selection_form selection = new selection_form(entrepot);

            if (selection.ShowDialog() == DialogResult.OK)
            {
                // Récupération Point Départ
                int depart_x = selection.chariot_x;
                int depart_y = selection.chariot_y;

                // Récupération Point Arrivée
                int arrivee_x = selection.chariot_x_final;
                int arrivee_y = selection.chariot_y_final;

                // Calcul du plus court chemin
                Graph g = new Graph();
                NodeEntrepot noeudInitial = new NodeEntrepot(depart_x, depart_y, arrivee_x, arrivee_y, entrepot);
                List<GenericNode> chemin = g.RechercherSolutionAEtoile(noeudInitial);

                // Cas de la case de départ
                FileStream fs = new FileStream("../../depart.png", FileMode.Open);
                entrepot_image[chemin[0].Nom[0], chemin[0].Nom[1]].Image = Image.FromStream(fs);
                fs.Close();

                // Cas de la case d’arrivée
                fs = new FileStream("../../arrivee.png", FileMode.Open);
                entrepot_image[chemin[chemin.Count - 1].Nom[0], chemin[chemin.Count - 1].Nom[1]].Image = Image.FromStream(fs);
                fs.Close();

                // Cas du milieu
                for (int i = 1; i < chemin.Count - 1; i++)
                {
                    // Modification du carré
                    fs = new FileStream("../../chemin.png", FileMode.Open);
                    entrepot_image[chemin[i].Nom[0], chemin[i].Nom[1]].Image = Image.FromStream(fs);
                    fs.Close();
                }
            }
        }

        private void selection_temps_button_Click(object sender, EventArgs e)
        {
            selection_form selection = new selection_form(entrepot);

            if (selection.ShowDialog() == DialogResult.OK)
            {
                // Récupération Point Départ
                int depart_x = selection.chariot_x;
                int depart_y = selection.chariot_y;
                int depart_k = this.recupererOrientation(depart_x,depart_y);

                // Récupération Point Intermédiaire
                int arrivee_x = selection.chariot_x_final;
                int arrivee_y = selection.chariot_y_final;
                int arrivee_k = selection.chariot_k_final;

                // Calcul du premier plus court chemin en temps jusqu’à l'objet
                Graph g = new Graph();
                NodeEntrepotTemps noeudInitial = new NodeEntrepotTemps(depart_x, depart_y, depart_k, arrivee_x, arrivee_y, entrepot);
                List<GenericNode> chemin = g.RechercherSolutionAEtoile(noeudInitial);

                // Calcul du retour jusqu’à la colonne 1
                Graph g2 = new Graph();
                NodeEntrepotLivraison noeudInitial2 = new NodeEntrepotLivraison(arrivee_x, arrivee_y, arrivee_k, entrepot);
                List<GenericNode> chemin2 = g2.RechercherSolutionAEtoile(noeudInitial2);

                // Cas de la case de départ
                FileStream fs = new FileStream("../../depart.png", FileMode.Open);
                entrepot_image[chemin[0].Nom[0], chemin[0].Nom[1]].Image = Image.FromStream(fs);
                fs.Close();

                // Cas de la case d’arrivée
                fs = new FileStream("../../arrivee.png", FileMode.Open);
                entrepot_image[chemin[chemin.Count - 1].Nom[0], chemin[chemin.Count - 1].Nom[1]].Image = Image.FromStream(fs);
                fs.Close();

                // Cas du milieu
                for (int i = 1; i < chemin.Count - 1; i++)
                {
                    // Modification du carré
                    fs = new FileStream("../../chemin.png", FileMode.Open);
                    entrepot_image[chemin[i].Nom[0], chemin[i].Nom[1]].Image = Image.FromStream(fs);
                    fs.Close();
                }

                // Cas de la case de départ
                fs = new FileStream("../../depart.png", FileMode.Open);
                entrepot_image[chemin2[0].Nom[0], chemin2[0].Nom[1]].Image = Image.FromStream(fs);
                fs.Close();

                // Cas de la case d’arrivée
                fs = new FileStream("../../arrivee.png", FileMode.Open);
                entrepot_image[chemin2[chemin2.Count - 1].Nom[0], chemin2[chemin2.Count - 1].Nom[1]].Image = Image.FromStream(fs);
                fs.Close();

                // Cas du milieu
                for (int i = 1; i < chemin2.Count - 1; i++)
                {
                    // Modification du carré
                    fs = new FileStream("../../chemin.png", FileMode.Open);
                    entrepot_image[chemin2[i].Nom[0], chemin2[i].Nom[1]].Image = Image.FromStream(fs);
                    fs.Close();
                }
            }
        }

        private int recupererOrientation(int x, int y)
        {
            int i = 0;
            while (x != chariots_x[i] && y != chariots_y[i])
            {
                i = i + 1;
            }
            return chariots_k[i];
        }
    }
}
