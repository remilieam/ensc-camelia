using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CameliaClass;

namespace CameliaApp
{
    public partial class Entrepot_Form : Form
    {
        // Tableaux d’images et d’entiers représentant l’entrepôt
        private PictureBox[,] entrepot_image = new PictureBox[25, 25];
        private int[,] entrepot = new int[25, 25];

        // Tableaux pour afficher les numéros de lignes et colonnes
        private Label[] lignes = new Label[25];
        private Label[] colonnes = new Label[25];

        // Listes pour les chariots
        private List<Chariot> chariots = new List<Chariot>();

        /// <summary>
        /// Permet de créer le formulaire initial
        /// </summary>
        public Entrepot_Form()
        {
            InitializeComponent();
            Creer_Chariots_Defaut();
            Generer_Entrepot();
            Ajouter_Chariots();
        }

        /// <summary>
        /// Permet d’afficher le formulaire pour ajouter des chariots (choix du
        /// nombre de chariots à ajouter et position des chariots).
        /// 
        /// À la fermeture du formulaire, on ajoute dans l’entrepôt les chariots.
        /// </summary>
        private void Chariots_Button_Click(object sender, EventArgs e)
        {
            // Création du formulaire pour ajouter des chariots
            Chariots_Form chariots_form = new Chariots_Form();

            // Ouverture modale du formulaire
            if (chariots_form.ShowDialog() == DialogResult.OK)
            {
                int nb_chariots = this.chariots.Count;

                // Vérification que le chariot n’exite pas déjà
                foreach (Chariot chariot_ajoute in chariots_form.Chariots)
                {
                    for (int i = 0; i < nb_chariots; i++)
                    {
                        // Si ce n’est pas le cas, on l’ajoute à la liste
                        if (!chariot_ajoute.Egal(this.chariots[i]))
                        {
                            this.chariots.Add(chariot_ajoute);
                        }
                    }
                }

                // Ajout des chariots
                this.Ajouter_Chariots();
            }
        }

        /// <summary>
        /// Permet d’afficher le formulaire pour choisir le chariot à déplacer
        /// et l’emplacement de l’objet à aller récupérer.
        /// 
        /// À la fermeture du formulaire, on trace le chemin le plus court en
        /// terme de distance pour atteindre l’objet à récupérer.
        /// </summary>
        private void Distance_Button_Click(object sender, EventArgs e)
        {
            Chemin_Form chemin_form = new Chemin_Form(entrepot);

            if (chemin_form.ShowDialog() == DialogResult.OK)
            {
                // Récupération du point de départ
                Chariot depart = chariots[0];
                int rang = 0;
                foreach (Chariot c in this.chariots)
                {
                    rang++;
                    if (c.Egal(chemin_form.Depart))
                    {
                        rang--;
                        depart = c;
                    }
                }

                // Récupération du point d’arrivée
                Chariot arrivee = chemin_form.Arrivee;

                // Calcul du plus court chemin
                Graphe g = new Graphe();
                NoeudDistance noeudInitial = new NoeudDistance(depart, arrivee, entrepot);
                List<Noeud> chemin = g.RechercherSolutionAEtoile(noeudInitial);

                // Cas de la case de départ
                FileStream fs = new FileStream("../../../CameliaIcon/depart.png", FileMode.Open);
                entrepot_image[chemin[0].nom.Ligne, chemin[0].nom.Colonne].Image = Image.FromStream(fs);
                fs.Close();

                // Cas de la case d’arrivée
                fs = new FileStream("../../../CameliaIcon/arrivee.png", FileMode.Open);
                entrepot_image[chemin[chemin.Count - 1].nom.Ligne, chemin[chemin.Count - 1].nom.Colonne].Image = Image.FromStream(fs);
                fs.Close();

                // Cas du milieu
                for (int i = 1; i < chemin.Count - 1; i++)
                {
                    // Modification du carré
                    fs = new FileStream("../../../CameliaIcon/chemin.png", FileMode.Open);
                    entrepot_image[chemin[i].nom.Ligne, chemin[i].nom.Colonne].Image = Image.FromStream(fs);
                    fs.Close();
                }

                // Déplacement du chariot dans l’entrepôt
                entrepot[chariots[rang].Ligne, chariots[rang].Colonne] = 0;
                chariots[rang] = chemin[chemin.Count - 1].nom;
                entrepot[chariots[rang].Ligne, chariots[rang].Colonne] = -2;
            }
        }

        /// <summary>
        /// Permet d’afficher le formulaire pour choisir le chariot à déplacer
        /// et l’emplacement de l’objet à aller récupérer.
        /// 
        /// À la fermeture du formulaire, on trace le chemin le plus court en
        /// terme de temps pour atteindre l’objet à récupérer.
        /// </summary>
        private void Temps_Button_Click(object sender, EventArgs e)
        {
            Chemin_Form chemin_form = new Chemin_Form(entrepot);

            if (chemin_form.ShowDialog() == DialogResult.OK)
            {
                // Récupération du point de départ
                Chariot depart = chariots[0];
                int rang = 0;
                foreach (Chariot c in this.chariots)
                {
                    rang++;
                    if (c.Egal(chemin_form.Depart))
                    {
                        rang--;
                        depart = c;
                    }
                }

                // Récupération du point d’arrivée intermédiaire
                Chariot arrivee = chemin_form.Arrivee;

                // Calcul du premier plus court chemin en temps jusqu’à l'objet
                Graphe g = new Graphe();
                NoeudTemps noeudInitial = new NoeudTemps(depart, arrivee, entrepot);
                List<Noeud> chemin = g.RechercherSolutionAEtoile(noeudInitial);

                // Calcul du retour jusqu’à la colonne 1
                Graphe g2 = new Graphe();
                NoeudLivraison noeudInitial2 = new NoeudLivraison(arrivee, entrepot);
                List<Noeud> chemin2 = g2.RechercherSolutionAEtoile(noeudInitial2);

                // Cas de la case de départ
                FileStream fs = new FileStream("../../../CameliaIcon/depart.png", FileMode.Open);
                entrepot_image[chemin[0].nom.Ligne, chemin[0].nom.Colonne].Image = Image.FromStream(fs);
                fs.Close();

                // Cas de la case d’arrivée
                fs = new FileStream("../../../CameliaIcon/intermediaire.png", FileMode.Open);
                entrepot_image[chemin[chemin.Count - 1].nom.Ligne, chemin[chemin.Count - 1].nom.Colonne].Image = Image.FromStream(fs);
                fs.Close();

                // Cas du milieu
                for (int i = 1; i < chemin.Count - 1; i++)
                {
                    // Modification du carré
                    fs = new FileStream("../../../CameliaIcon/chemin.png", FileMode.Open);
                    entrepot_image[chemin[i].nom.Ligne, chemin[i].nom.Colonne].Image = Image.FromStream(fs);
                    fs.Close();
                }

                // Cas de la case de départ
                fs = new FileStream("../../../CameliaIcon/intermediaire.png", FileMode.Open);
                entrepot_image[chemin2[0].nom.Ligne, chemin2[0].nom.Colonne].Image = Image.FromStream(fs);
                fs.Close();

                // Cas de la case d’arrivée
                fs = new FileStream("../../../CameliaIcon/arrivee.png", FileMode.Open);
                entrepot_image[chemin2[chemin2.Count - 1].nom.Ligne, chemin2[chemin2.Count - 1].nom.Colonne].Image = Image.FromStream(fs);
                fs.Close();

                // Cas du milieu
                for (int i = 1; i < chemin2.Count - 1; i++)
                {
                    // Modification du carré
                    fs = new FileStream("../../../CameliaIcon/chemin.png", FileMode.Open);
                    entrepot_image[chemin2[i].nom.Ligne, chemin2[i].nom.Colonne].Image = Image.FromStream(fs);
                    fs.Close();
                }

                // Déplacement du chariot dans l’entrepôt
                entrepot[chariots[rang].Ligne, chariots[rang].Colonne] = 0;
                chariots[rang] = chemin2[chemin2.Count - 1].nom;
                entrepot[chariots[rang].Ligne, chariots[rang].Colonne] = -2;
            }
        }

        private void Rafraichir_Button_Click(object sender, EventArgs e)
        {
            Generer_Entrepot();
            Ajouter_Chariots();
        }

        /// <summary>
        /// Permet de créer 15 chariots par défaut dans l’entrepôt
        /// </summary>
        private void Creer_Chariots_Defaut()
        {
            List<int> chariots_x = new List<int> { 0, 13, 24, 5, 16, 13, 23, 14, 18, 6, 17, 15, 23, 8, 5 };
            List<int> chariots_y = new List<int> { 0, 12, 24, 7, 12, 3, 0, 13, 23, 1, 19, 7, 23, 24, 20 };
            List<int> chariots_k = new List<int> { 0, 2, 1, 2, 3, 1, 0, 0, 2, 1, 2, 3, 1, 0, 3 };

            for (int i = 0; i < chariots_x.Count; i++)
            {
                this.chariots.Add(new Chariot(chariots_x[i], chariots_y[i], chariots_k[i]));
            }
        }

        /// <summary>
        /// Permet de générer l’entrepôt
        /// </summary>
        private void Generer_Entrepot()
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
                        FileStream fs = new FileStream("../../../CameliaIcon/noir.png", FileMode.Open);
                        entrepot_image[i, j].Image = Image.FromStream(fs);
                        fs.Close();

                        // Puis le tableau d’entiers
                        entrepot[i, j] = -1;
                    }

                    else
                    {
                        // On gère le tableau d’images
                        FileStream fs = new FileStream("../../../CameliaIcon/blanc.png", FileMode.Open);
                        entrepot_image[i, j].Image = Image.FromStream(fs);
                        fs.Close();

                        // Puis le tableau d’entiers
                        entrepot[i, j] = 0;
                    }
                }

                FileStream fl = new FileStream("../../../CameliaIcon/livraison.png", FileMode.Open);
                entrepot_image[i, 0].Image = Image.FromStream(fl);
                fl.Close();
            }
        }

        /// <summary>
        /// Permet d’ajouter des chariots dans l’entrepôt
        /// </summary>
        private void Ajouter_Chariots()
        {
            for (int i = 0; i < chariots.Count; i++)
            {
                // Modification du carré
                FileStream fs = new FileStream("../../../CameliaIcon/chariot.png", FileMode.Open);
                entrepot_image[chariots[i].Ligne, chariots[i].Colonne].Image = Image.FromStream(fs);
                fs.Close();

                // Chariots = obstacle
                entrepot[chariots[i].Ligne, chariots[i].Colonne] = -2;
            }
        }

    }
}
