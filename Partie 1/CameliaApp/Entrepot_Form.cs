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

        // Liste contenant le dernier chemin et là on 
        private List<Noeud> dernier_chemin = new List<Noeud>();
        private int compteur = 0;

        /// <summary>
        /// Permet de créer le formulaire initial
        /// </summary>
        public Entrepot_Form()
        {
            InitializeComponent();
            Creer_Chariots_Defaut();
            Generer_Entrepot();
            Afficher_Entrepot();
            Ajouter_Chariots();

            rafraichir_button.Enabled = false;
            dynamique_button.Enabled = false;
        }

        /// <summary>
        /// Permet de rafraîchir l’affichage de l’entrepôt
        /// </summary>
        private void Rafraichir_Button_Click(object sender, EventArgs e)
        {
            // Récupération du point de départ
            int rang = Trouver_Rang(dernier_chemin[0].nom);

            // Le point de départ devient une case quelconque
            entrepot[chariots[rang].Ligne, chariots[rang].Colonne] = 0;

            // Récupération du point d’arrivée
            chariots[rang] = dernier_chemin[dernier_chemin.Count - 1].nom;

            // Le point d’arrivée devient un chariot
            entrepot[chariots[rang].Ligne, chariots[rang].Colonne] = -2;

            Afficher_Entrepot();
            Ajouter_Chariots();
            rafraichir_button.Enabled = false;
            dynamique_button.Enabled = false;
        }

        /// <summary>
        /// Permet de voir le déplacement du chariot dans l’entrepôt
        /// </summary>
        private void Dynamique_Button_Click(object sender, EventArgs e)
        {
            Afficher_Entrepot();
            Ajouter_Chariots();
            Changer_Position();
            dynamique_button.Enabled = false;
            rafraichir_button.Enabled = false;
        }

        /// <summary>
        /// Permet de cliquer sur une case de l’entrepôt pour faire certaines actions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chariot_PictureBox_Click(object sender, EventArgs e)
        {
            // Récupération des coordonnées du carré sur lequel on a cliqué
            int ligne = 0;
            int colonne = 0;

            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (entrepot_image[i, j] == sender)
                    {
                        ligne = i;
                        colonne = j;
                    }
                }
            }

            if (entrepot[ligne, colonne] == 0)
            {
                // On ajoute le chariot à la liste de chariots
                // Par défaut, il est orienté au nord
                this.chariots.Add(new Chariot(ligne, colonne, 0));

                // Ajout des chariots dans la grille de l’entrepôt
                this.Ajouter_Chariots();
            }

            else if (entrepot[ligne, colonne] == -2)
            {
                // Récupération du chariot de départ
                Chariot depart = new Chariot(ligne,colonne,0);
                int rang = Trouver_Rang(depart);
                depart = chariots[rang];

                // Génération du formulaire pour connaître l’arrivée et le type
                // de recherche (chemin le plus court en distance ou en temps)
                Chemin_Form chemin_form = new Chemin_Form(entrepot);

                if (chemin_form.ShowDialog() == DialogResult.OK)
                {
                    if (chemin_form.fini)
                    {
                        if (chemin_form.Type == 1)
                        {
                            Tracer_Chemin_Distance(depart, chemin_form.Arrivee);
                        }

                        else
                        {
                            Tracer_Chemin_Temps(depart, chemin_form.Arrivee);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///  Permet de compter le nombre de secondes écoulées
        /// </summary>
        private void Chrono_Timer_Tick(object sender, EventArgs e)
        {
            Afficher_Entrepot();
            Ajouter_Chariots();
            compteur += 1;
            chrono_timer.Stop();
            if (compteur < dernier_chemin.Count - 1)
            {
                Changer_Position();
            }
        }

        /// <summary>
        /// Permet de trouver dans la liste de chariots à un chariot en particulier
        /// </summary>
        /// <param name="chariot_a_trouver">Chariot à trouver</param>
        /// <returns>Rang du chariot trouvé</returns>
        private int Trouver_Rang(Chariot chariot_a_trouver)
        {
            // Récupération de la position actuelle
            int rang = 0;
            while (!this.chariots[rang].Egal(chariot_a_trouver))
            {
                rang++;
            }
            return rang;
        }

        /// <summary>
        /// Permet de calculer et de tracer le chemin le plus court en
        /// terme de distance pour atteindre l’objet à récupérer.
        /// </summary>
        /// <param name="depart">Point de départ</param>
        /// <param name="arrivee">Point d’arrivée</param>
        private void Tracer_Chemin_Distance(Chariot depart, Chariot arrivee)
        {
            // Calcul du plus court chemin
            Graphe g = new Graphe();
            NoeudDistance noeudInitial = new NoeudDistance(depart, arrivee, entrepot);
            List<Noeud> chemin = g.RechercherSolutionAEtoile(noeudInitial);

            try
            {
                if (g.noeudsOuverts.Count == 0)
                {
                    throw new Exception("Pas de solution !");
                }

                // Sauvegarde du chemin
                dernier_chemin = new List<Noeud>();
                this.dernier_chemin.AddRange(chemin);

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

                rafraichir_button.Enabled = true;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Permet de calculer et de tracer le chemin le plus court en
        /// terme de temps pour atteindre l’objet à récupérer.
        /// </summary>
        /// <param name="depart">Point de départ</param>
        /// <param name="arrivee">Point d’arrivée</param>
        private void Tracer_Chemin_Temps(Chariot depart, Chariot arrivee)
        {
            // Calcul du premier plus court chemin en temps jusqu’à l'objet
            Graphe g = new Graphe();
            NoeudTemps noeudInitial = new NoeudTemps(depart, arrivee, entrepot);
            List<Noeud> chemin = g.RechercherSolutionAEtoile(noeudInitial);

            // Calcul du retour jusqu’à la colonne 1
            Graphe g2 = new Graphe();
            NoeudLivraison noeudInitial2 = new NoeudLivraison(arrivee, entrepot);
            List<Noeud> chemin2 = g2.RechercherSolutionAEtoile(noeudInitial2);

            try
            {
                if (g.noeudsOuverts.Count == 0 && g2.noeudsOuverts.Count == 0)
                {
                    throw new Exception("Pas de solution !");
                }

                // Sauvegarde du chemin
                dernier_chemin = new List<Noeud>();
                this.dernier_chemin.AddRange(chemin);
                this.dernier_chemin.AddRange(chemin2);

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

                dynamique_button.Enabled = true;
                rafraichir_button.Enabled = true;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Permet de changer la position du chariot pour changer l’affichage 1, 2 ou 6 secondes plus tard
        /// </summary>
        private void Changer_Position()
        {
            // Récupération de la position actuelle
            int rang = Trouver_Rang(dernier_chemin[compteur].nom);

            // Modification du timer
            chrono_timer.Interval = 1000;
            if (dernier_chemin[compteur + 1].nom.Orientation != dernier_chemin[compteur].nom.Orientation)
            {
                chrono_timer.Interval += 3000;

                if (dernier_chemin[compteur + 1].nom.Orientation % 2 == dernier_chemin[compteur].nom.Orientation % 2)
                {
                    chrono_timer.Interval += 3000;
                }
            }

            // Modification de la position
            this.chariots[rang] = dernier_chemin[compteur + 1].nom;
            chrono_timer.Start();
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
        /// Permet de générer l’entrepôt initial dynamiquement
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

            // réation, positionnement et affichage de l’entrepôt
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
                    this.entrepot_image[i, j].Click += new EventHandler(Chariot_PictureBox_Click);

                    // S’il s’agit d’une étagère
                    if (i % 2 == 0 && i != 0 && i != 24 &&
                        ((j >= 2 && j < 11) || (j >= 14 && j < 23)))
                    {
                        entrepot[i, j] = -1;
                    }

                    else
                    {
                        entrepot[i, j] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Permet d’afficher l’entrepôt vide
        /// </summary>
        private void Afficher_Entrepot()
        {
            // On assigne au tableau les images
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    // S’il s’agit d’une étagère
                    if (i % 2 == 0 && i != 0 && i != 24 &&
                        ((j >= 2 && j < 11) || (j >= 14 && j < 23)))
                    {
                        // On gère le tableau d’images 
                        FileStream fs = new FileStream("../../../CameliaIcon/noir.png", FileMode.Open);
                        entrepot_image[i, j].Image = Image.FromStream(fs);
                        fs.Close();
                    }

                    else
                    {
                        // On gère le tableau d’images
                        FileStream fs = new FileStream("../../../CameliaIcon/blanc.png", FileMode.Open);
                        entrepot_image[i, j].Image = Image.FromStream(fs);
                        fs.Close();
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
                // Modification du carré en fonction de l’orientation
                if (chariots[i].Orientation == 0)
                {
                    FileStream fs = new FileStream("../../../CameliaIcon/nord.png", FileMode.Open);
                    entrepot_image[chariots[i].Ligne, chariots[i].Colonne].Image = Image.FromStream(fs);
                    fs.Close();
                }
                else if (chariots[i].Orientation == 1)
                {
                    FileStream fs = new FileStream("../../../CameliaIcon/est.png", FileMode.Open);
                    entrepot_image[chariots[i].Ligne, chariots[i].Colonne].Image = Image.FromStream(fs);
                    fs.Close();
                }
                else if (chariots[i].Orientation == 2)
                {
                    FileStream fs = new FileStream("../../../CameliaIcon/sud.png", FileMode.Open);
                    entrepot_image[chariots[i].Ligne, chariots[i].Colonne].Image = Image.FromStream(fs);
                    fs.Close();
                }
                else if (chariots[i].Orientation == 3)
                {
                    FileStream fs = new FileStream("../../../CameliaIcon/ouest.png", FileMode.Open);
                    entrepot_image[chariots[i].Ligne, chariots[i].Colonne].Image = Image.FromStream(fs);
                    fs.Close();
                }
                else
                {
                    FileStream fs = new FileStream("../../../CameliaIcon/chariot.png", FileMode.Open);
                    entrepot_image[chariots[i].Ligne, chariots[i].Colonne].Image = Image.FromStream(fs);
                    fs.Close();
                }

                // Chariots = obstacle
                entrepot[chariots[i].Ligne, chariots[i].Colonne] = -2;
            }
        }
    }
}
