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
        private static Random alea = new Random();
        private int temps_timer = 0;
        private int compteur = 0;

        // Tableaux d’images et d’entiers représentant l’entrepôt
        private PictureBox[,] entrepot_image = new PictureBox[25, 25];
        private int[,] entrepot = new int[25, 25];

        // Tableaux pour afficher les numéros de lignes et colonnes
        private Label[] lignes = new Label[25];
        private Label[] colonnes = new Label[25];

        // Liens pour les images
        FileStream fd = new FileStream("../../../CameliaIcon/depart.png", FileMode.Open);
        FileStream fi = new FileStream("../../../CameliaIcon/intermediaire.png", FileMode.Open);
        FileStream fa = new FileStream("../../../CameliaIcon/arrivee.png", FileMode.Open);
        FileStream fc = new FileStream("../../../CameliaIcon/chemin.png", FileMode.Open);

        // Listes pour les chariots
        private List<Chariot> chariots = new List<Chariot>();

        // Listes contenant le dernier chemin, la dernière livraison et le dernier graphe
        private List<Noeud> dernier_chemin = new List<Noeud>();
        private Objet dernier_objet;
        private List<Graphe> dernier_graphe = new List<Graphe>();

        // Listes pour sauvegarder les chemins et les temps pour les déplacements de tous les chariots
        private List<List<Noeud>> chemins_realite = new List<List<Noeud>>();
        private List<int> temps_realite = new List<int>();

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
            detail_button.Enabled = false;
        }

        /// <summary>
        /// Permet d’afficher les détails de la recherche
        /// </summary>
        private void Detail_Button_Click(object sender, EventArgs e)
        {
            Arbre_Form arbre_form = new Arbre_Form(dernier_graphe[0]);

            if (arbre_form.ShowDialog() == DialogResult.OK)
            {
            }

            if (dernier_graphe.Count > 1)
            {
                Arbre_Form arbre_form_2 = new Arbre_Form(dernier_graphe[1]);

                if (arbre_form_2.ShowDialog() == DialogResult.OK)
                {
                }
            }
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
            detail_button.Enabled = false;
            realite_button.Enabled = true;
            reinitialiser_button.Enabled = true;

            MessageBox.Show("Déplacement terminé en " + Calculer_Temps() + " secondes et " + dernier_chemin.Count + " pas !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    entrepot_image[i, j].Enabled = true;
                }
            }
        }

        /// <summary>
        /// Permet de voir le déplacement du chariot dans l’entrepôt
        /// </summary>
        private void Dynamique_Button_Click(object sender, EventArgs e)
        {
            Changer_Position();
            dynamique_button.Enabled = false;
            rafraichir_button.Enabled = false;
            detail_button.Enabled = false;
        }

        /// <summary>
        /// Permet de positionner tous les chariots sur la zone de livraison
        /// </summary>
        private void Realite_Button_Click(object sender, EventArgs e)
        {
            // S’il y a plus de 25 chariots dans l’entrepôt, on supprime les chariots surnuméraires
            if (chariots.Count > 25)
            {
                int nb_chariots = chariots.Count;
                for (int i = nb_chariots - 1; i > 24; i--)
                {
                    chariots.RemoveAt(i);
                }
            }

            // On part de la première ligne
            int ligne_libre = 0;

            // Pour chaque chariot
            for (int i = 0; i < chariots.Count; i++)
            {
                // On l’oriente à l’est
                chariots[i].Orientation = 1;

                // S’il n’est pas déjà sur la première colonne
                if (chariots[i].Colonne != 0)
                {
                    // Tant qu’on n’a pas trouvé de ligne libre sur la première colonne,
                    // on continue à chercher
                    while (entrepot[ligne_libre, 0] != 0)
                    {
                        ligne_libre += 1;
                    }

                    // On met à jour la position du chariot et la configuration de l’entrepôt
                    entrepot[chariots[i].Ligne, chariots[i].Colonne] = 0;

                    chariots[i].Colonne = 0;
                    chariots[i].Ligne = ligne_libre;

                    entrepot[chariots[i].Ligne, chariots[i].Colonne] = -2;
                }
            }

            for (int i = 0; i < 25; i++)
            {
                for (int j = 1; j < 25; j++)
                {
                    entrepot_image[i, j].Enabled = false;
                }
            }

            // On rafraîchit l’affichage de l’entrepôt
            Afficher_Entrepot();
            Ajouter_Chariots();
        }

        /// <summary>
        /// Permet de retrouver l’entrepôt initial
        /// </summary>
        private void Reinitialiser_Button_Click(object sender, EventArgs e)
        {
            chariots.Clear();
            dernier_chemin.Clear();
            compteur = 0;

            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (i % 2 == 0 && i != 0 && i != 24 &&
                            ((j >= 2 && j < 11) || (j >= 14 && j < 23)))
                    { entrepot[i, j] = -1; }
                    else { entrepot[i, j] = 0; }
                    entrepot_image[i, j].Enabled = true;
                }
            }

            Creer_Chariots_Defaut();
            Afficher_Entrepot();
            Ajouter_Chariots();

            rafraichir_button.Enabled = false;
            dynamique_button.Enabled = false;
            realite_button.Enabled = true;

            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    entrepot_image[i, j].Enabled = true;
                }
            }
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
                this.chariots.Add(new Chariot(ligne, colonne, alea.Next(4)));

                // Ajout des chariots dans la grille de l’entrepôt
                this.Ajouter_Chariots();
            }

            else if (entrepot[ligne, colonne] == -2)
            {
                // Récupération du chariot de départ
                Chariot depart = new Chariot(ligne, colonne, 0);
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
                            Tracer_Chemin_Distance(depart, chemin_form.Objet);
                        }

                        else if (chemin_form.Type == 2)
                        {
                            Tracer_Chemin_Temps(depart, chemin_form.Objet);
                        }
                        else
                        {
                            Tracer_Chemin_Realite_2(depart, chemin_form.Objet);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Permet de modifier l’affichage du chariot lorsqu’il parcourt le chemin le plus rapide
        /// </summary>
        private void Chrono_Timer_Tick(object sender, EventArgs e)
        {
            compteur += 1;

            // Modification du carré de la position précédente
            FileStream fs = new FileStream("../../../CameliaIcon/blanc.png", FileMode.Open);
            entrepot_image[dernier_chemin[compteur - 1].nom.Ligne, dernier_chemin[compteur - 1].nom.Colonne].Image = Image.FromStream(fs);
            fs.Close();

            // Vérification que l’on n’est pas au point intermédaire
            if (dernier_chemin[compteur].nom.Egal(Trouver_Destination(dernier_objet)))
            {
                // Modification du carré de la position actuelle
                fs = new FileStream("../../../CameliaIcon/chariot.png", FileMode.Open);
            }

            else
            {
                // Modification du carré en fonction de l’orientation de la position actuelle
                if (dernier_chemin[compteur].nom.Orientation == 0) { fs = new FileStream("../../../CameliaIcon/nord.png", FileMode.Open); }
                else if (dernier_chemin[compteur].nom.Orientation == 1) { fs = new FileStream("../../../CameliaIcon/est.png", FileMode.Open); }
                else if (dernier_chemin[compteur].nom.Orientation == 2) { fs = new FileStream("../../../CameliaIcon/sud.png", FileMode.Open); }
                else if (dernier_chemin[compteur].nom.Orientation == 3) { fs = new FileStream("../../../CameliaIcon/ouest.png", FileMode.Open); }
            }

            entrepot_image[dernier_chemin[compteur].nom.Ligne, dernier_chemin[compteur].nom.Colonne].Image = Image.FromStream(fs);
            fs.Close();

            chrono_timer.Stop();

            if (compteur < dernier_chemin.Count - 1)
            {
                Changer_Position();
            }

            else
            {
                Afficher_Entrepot();
                Ajouter_Chariots();
                MessageBox.Show("Déplacement terminé en " + Calculer_Temps() + " secondes et " + dernier_chemin.Count + " pas !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        entrepot_image[i, j].Enabled = true;
                    }
                }

                realite_button.Enabled = true;
                reinitialiser_button.Enabled = true;
            }
        }

        /// <summary>
        /// Permet de modifier l’affichage des chariots lorsqu’ils se déplacent tous en même temps
        /// </summary>
        private void Realite_Timer_Tick(object sender, EventArgs e)
        {
            temps_timer += 1;

            int max = temps_realite[0];
            for (int i = 0; i < temps_realite.Count; i++)
            {
                max = (max < temps_realite[i]) ? temps_realite[i] : max;
            }

            if (temps_timer <= max)
            {
                Super_Affichage_Dynamique();
            }
            else
            {
                realite_timer.Stop();
                temps_timer = 0;

                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        entrepot_image[i, j].Enabled = true;
                    }
                }

                reinitialiser_button.Enabled = true;
                realite_button.Enabled = true;
            }
        }

        /// <summary>
        /// Permet de calculer et de tracer le chemin le plus court en
        /// terme de distance pour atteindre l’objet à récupérer.
        /// </summary>
        /// <param name="depart">Point de départ</param>
        /// <param name="arrivee">Point d’arrivée</param>
        private void Tracer_Chemin_Distance(Chariot depart, Objet objet)
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    entrepot_image[i, j].Enabled = false;
                }
            }

            realite_button.Enabled = false;
            reinitialiser_button.Enabled = false;

            // Calcul du plus court chemin
            Graphe g = new Graphe();
            Chariot arrivee = Trouver_Destination(objet);
            NoeudDistance noeudInitial = new NoeudDistance(depart, arrivee, entrepot);
            List<Noeud> chemin = g.RechercherSolutionAEtoile(noeudInitial);

            try
            {
                if (chemin.Count == 0)
                {
                    throw new Exception("Pas de solution !");
                }

                // Sauvegarde du chemin, de l’objet à récupérer et du graphe
                this.dernier_chemin = chemin;
                this.dernier_objet = objet;
                this.dernier_graphe.Add(g);

                // Cas de la case de départ
                entrepot_image[chemin[0].nom.Ligne, chemin[0].nom.Colonne].Image = Image.FromStream(fd);

                // Cas de la case d’arrivée
                entrepot_image[chemin[chemin.Count - 1].nom.Ligne, chemin[chemin.Count - 1].nom.Colonne].Image = Image.FromStream(fa);

                // Cas du milieu
                for (int i = 1; i < chemin.Count - 1; i++)
                {
                    // Modification du carré
                    entrepot_image[chemin[i].nom.Ligne, chemin[i].nom.Colonne].Image = Image.FromStream(fc);
                }

                rafraichir_button.Enabled = true;
                detail_button.Enabled = true;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        entrepot_image[i, j].Enabled = true;
                    }
                }

                reinitialiser_button.Enabled = true;
                realite_button.Enabled = true;
            }
        }

        /// <summary>
        /// Permet de calculer et de tracer le chemin le plus court en
        /// terme de temps pour atteindre l’objet à récupérer.
        /// </summary>
        /// <param name="depart">Point de départ</param>
        /// <param name="arrivee">Point d’arrivée</param>
        private void Tracer_Chemin_Temps(Chariot depart, Objet objet)
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    entrepot_image[i, j].Enabled = false;
                }
            }

            realite_button.Enabled = false;
            reinitialiser_button.Enabled = false;

            // Calcul du chemin pour la récupération de l’objet
            Graphe g = new Graphe();
            Chariot arrivee = Trouver_Destination(objet);
            NoeudTemps noeudInitial = new NoeudTemps(depart, arrivee, entrepot);
            List<Noeud> chemin = g.RechercherSolutionAEtoile(noeudInitial);

            try
            {
                if (chemin.Count == 0)
                {
                    throw new Exception("Pas de solution !");
                }

                // Mise à jour de l’entrepôt après le premier déplacement
                int rang = Trouver_Rang(depart);
                entrepot[chariots[rang].Ligne, chariots[rang].Colonne] = 0;
                chariots[rang] = chemin[chemin.Count - 1].nom;
                entrepot[chariots[rang].Ligne, chariots[rang].Colonne] = -2;

                // Calcul du chemin pour la livraison de l’objet
                Graphe g2 = new Graphe();
                NoeudLivraison noeudInitial2 = new NoeudLivraison(chemin[chemin.Count - 1].nom, entrepot);
                List<Noeud> chemin2 = g2.RechercherSolutionAEtoile(noeudInitial2);
                chemin2.RemoveAt(0);

                // Dé-mise à jour de l’entrepôt après le second déplacement
                entrepot[chariots[rang].Ligne, chariots[rang].Colonne] = 0;
                chariots[rang] = chemin[0].nom;
                entrepot[chariots[rang].Ligne, chariots[rang].Colonne] = -2;

                if (chemin2.Count == 0)
                {
                    throw new Exception("Pas de solution !");
                }

                // Sauvegarde du chemin, de l’objet à récupérer et le graphe
                this.dernier_chemin = chemin;
                this.dernier_chemin.AddRange(chemin2);
                this.dernier_objet = objet;
                this.dernier_graphe.Add(g);
                this.dernier_graphe.Add(g2);

                // Cas du milieu
                for (int i = 1; i < dernier_chemin.Count - 1; i++)
                {
                    // Modification du carré
                    entrepot_image[dernier_chemin[i].nom.Ligne, dernier_chemin[i].nom.Colonne].Image = Image.FromStream(fc);
                }

                // Cas de la case de départ
                entrepot_image[dernier_chemin[0].nom.Ligne, dernier_chemin[0].nom.Colonne].Image = Image.FromStream(fd);

                // Cas de la case intermédiaire
                entrepot_image[Trouver_Destination(dernier_objet).Ligne, Trouver_Destination(dernier_objet).Colonne].Image = Image.FromStream(fi);

                // Cas de la case d’arrivée
                entrepot_image[dernier_chemin[dernier_chemin.Count - 1].nom.Ligne, dernier_chemin[dernier_chemin.Count - 1].nom.Colonne].Image = Image.FromStream(fa);

                dynamique_button.Enabled = true;
                rafraichir_button.Enabled = true;
                detail_button.Enabled = true;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        entrepot_image[i, j].Enabled = true;
                    }
                }

                reinitialiser_button.Enabled = true;
                realite_button.Enabled = true;
            }
        }

        /// <summary>
        /// Permet de calculer et de tracer le chemin le plus court en
        /// terme de temps pour atteindre l’objet à récupérer avec mouvement des autres chariots
        /// </summary>
        /// <param name="depart">Point de départ</param>
        /// <param name="arrivee">Point d’arrivée</param>
        private void Tracer_Chemin_Realite(Chariot depart, Objet objet)
        {
            // On crée une liste de chariots, une liste d'objets et une liste de graphes
            List<List<Noeud>> chemins_1 = new List<List<Noeud>>();
            List<List<Noeud>> chemins_2 = new List<List<Noeud>>();
            List<List<Noeud>> chemins = new List<List<Noeud>>();
            List<Objet> objets = new List<Objet>();
            List<int> temps = new List<int>();
            Graphe g, g2;

            // Placement du chariot sur lequel on a cliqué à la fin de la liste
            int rang = Trouver_Rang(depart);
            chariots.Add(chariots[rang]);
            chariots.RemoveAt(rang);

            // Attribution des objets à aller chercher aux chariots
            for (int i = 0; i < chariots.Count - 1; i++)
            {
                Objet objetAjoute = Generer_Objet();
                bool existeDeja = true;

                while (existeDeja)
                {
                    objetAjoute = Generer_Objet();

                    int j = 0;
                    existeDeja = objetAjoute.Egal(objet);

                    while (existeDeja && j < objets.Count)
                    {
                        existeDeja = objetAjoute.Egal(objets[j]);
                        j++;
                    }
                }

                objets.Add(objetAjoute);
            }

            objets.Add(objet);

            // Calcul des chemins de chaque chariot
            for (int i = 0; i < chariots.Count; i++)
            {
                // Cas où il n'y a qu'un seul chariot qui bouge
                if (i == 0)
                {
                    // Calcul du premier trajet du premier chariot
                    g = new Graphe();
                    NoeudTemps noeudInitial = new NoeudTemps(chariots[i], Trouver_Destination(objets[i]), entrepot);

                    // Ajout du premier trajet du premier chariot la liste
                    chemins_1.Add(g.RechercherSolutionAEtoile(noeudInitial));

                    // Mise à jour de la position du premier chariot dans l'entrepôt
                    entrepot[chariots[i].Ligne, chariots[i].Colonne] = 0;
                    chariots[i] = chemins_1[i][chemins_1[i].Count - 1].nom;
                    entrepot[chariots[i].Ligne, chariots[i].Colonne] = -2;

                    // Calcul du second trajet du premier chariot
                    g2 = new Graphe();
                    NoeudLivraison noeudInitial2 = new NoeudLivraison(chemins_1[i][chemins_1[i].Count - 1].nom, entrepot);

                    // Ajout du deuxième trajet du premier chariot à la liste
                    chemins_2.Add(g2.RechercherSolutionAEtoile(noeudInitial2));
                    chemins_2[i].RemoveAt(0);

                    // Mise à jour de la position du premier chariot dans l'entrepôt
                    entrepot[chariots[i].Ligne, chariots[i].Colonne] = 0;
                    chariots[i] = chemins_2[i][chemins_2[i].Count - 1].nom;
                    entrepot[chariots[i].Ligne, chariots[i].Colonne] = -2;

                    // Récupération du dernier chemin et objet
                    dernier_chemin = chemins_1[i];
                    dernier_chemin.AddRange(chemins_2[i]);
                    dernier_objet = objets[i];

                    // Calcul du temps de parcours du premier chariot
                    temps.Add(Calculer_Temps());

                    // Ajout du trajet du premier chariot à la liste
                    chemins.Add(dernier_chemin);
                }

                else
                {
                    // Calcul du premier trajet du i° chariot
                    g = new Graphe();
                    NoeudRealite noeudInitial = new NoeudRealite(chariots[i], Trouver_Destination(objets[i]), entrepot, chemins, chariots, false);

                    // Ajout du premier trajet du i° chariot la liste
                    chemins_1.Add(g.RechercherSolutionAEtoile(noeudInitial));

                    // Mise à jour de la position du i° chariot dans l'entrepôt
                    entrepot[chariots[i].Ligne, chariots[i].Colonne] = 0;
                    chariots[i] = chemins_1[i][chemins_1[i].Count - 1].nom;
                    entrepot[chariots[i].Ligne, chariots[i].Colonne] = -2;

                    // Calcul du second trajet du i° chariot
                    g2 = new Graphe();
                    NoeudRealite noeudInitial2 = new NoeudRealite(chemins_1[i][chemins_1[i].Count - 1].nom, Trouver_Destination(objets[i]), entrepot, chemins, chariots, true);

                    // Ajout du deuxième trajet du i° chariot à la liste
                    chemins_2.Add(g2.RechercherSolutionAEtoile(noeudInitial2));
                    chemins_2[i].RemoveAt(0);

                    // Mise à jour de la position du i° chariot dans l'entrepôt
                    entrepot[chariots[i].Ligne, chariots[i].Colonne] = 0;
                    chariots[i] = chemins_2[i][chemins_2[i].Count - 1].nom;
                    entrepot[chariots[i].Ligne, chariots[i].Colonne] = -2;

                    // Récupération du dernier chemin et objet
                    dernier_chemin = chemins_1[i];
                    dernier_chemin.AddRange(chemins_2[i]);
                    dernier_objet = objets[i];

                    // Calcul du temps de parcours du i° chariot
                    temps.Add(Calculer_Temps());

                    // Ajout du trajet du i° chariot à la liste
                    chemins.Add(dernier_chemin);
                }
            }

            this.chemins_realite = chemins;
            this.temps_realite = temps;
            Super_Affichage_Dynamique();
            realite_timer.Start();
        }

        /// <summary>
        /// Permet de calculer et de tracer le chemin le plus court en
        /// terme de temps pour tous les chariots
        /// </summary>
        /// <param name="depart">Point de départ</param>
        /// <param name="arrivee">Point d’arrivée</param>
        private void Tracer_Chemin_Realite_2(Chariot depart, Objet objet)
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    entrepot_image[i, j].Enabled = false;
                }
            }

            realite_button.Enabled = false;
            reinitialiser_button.Enabled = false;

            // On crée une liste de chariots, une liste d'objets et une liste de graphes
            List<List<Noeud>> chemins = new List<List<Noeud>>();
            List<bool> recuperation = new List<bool>();
            List<bool> livraison = new List<bool>();
            List<bool> montee = new List<bool>();
            List<Objet> objets = new List<Objet>();
            List<int> temps = new List<int>();
            Graphe g, g2;

            // Placement du chariot sur lequel on a cliqué à la fin de la liste
            int rang = Trouver_Rang(depart);
            chariots.Add(chariots[rang]);
            chariots.RemoveAt(rang);

            // Attribution des objets à aller chercher aux chariots
            for (int i = 0; i < chariots.Count - 1; i++)
            {
                Objet objetAjoute = Generer_Objet();
                bool existeDeja = true;

                while (existeDeja)
                {
                    objetAjoute = Generer_Objet();

                    int j = 0;
                    existeDeja = objetAjoute.Egal(objet);

                    while (existeDeja && j < objets.Count)
                    {
                        existeDeja = objetAjoute.Egal(objets[j]);
                        j++;
                    }
                }

                objets.Add(objetAjoute);
            }

            objets.Add(objet);

            for (int i = 0; i < chariots.Count; i++)
            {
                recuperation.Add(false);
                livraison.Add(false);
                montee.Add(false);
            }

            int temps_ecoule = 0;

            while (!Verifier_Fin(livraison))
            {
                for (int i = 0; i < chariots.Count; i++)
                {
                    if (!recuperation[i])
                    {
                        g = new Graphe();
                        NoeudTemps noeudInitial = new NoeudTemps(chariots[i], Trouver_Destination(objets[i]), entrepot);
                        List<Noeud> trajet = g.RechercherSolutionAEtoile(noeudInitial);

                        // Si on évalue au temps 0, on ajoute un chemin à la liste
                        // et on l’initialise avec la postion de départ et on itialise le temps
                        if (temps_ecoule == 0)
                        {
                            temps.Add(0);
                            chemins.Add(new List<Noeud>());
                            chemins[i].Add(trajet[0]);
                        }

                        // Si on trouve un chemin, on ajoute la prochaine position
                        if (trajet.Count > 1)
                        {
                            // Cas où la prochaine position implique un demi-tour
                            if (chemins[i][chemins[i].Count - 1].nom.Orientation != trajet[1].nom.Orientation && chemins[i][chemins[i].Count - 1].nom.Orientation % 2 == trajet[1].nom.Orientation % 2)
                            {
                                try
                                {
                                    bool arret_assez_long = true;
                                    int iter = 0;
                                    
                                    // On vérifie que les 7 derniers chariots ont la même orientation
                                    while (iter < 6 && arret_assez_long)
                                    {
                                        if (!chemins[i][chemins[i].Count - 1 - iter].nom.Egal(chemins[i][chemins[i].Count - 1 - iter - 1].nom))
                                        {
                                            arret_assez_long = false;
                                        }

                                        iter++;
                                    }

                                    // Si ce n’est pas le cas, on ajoute la position actuelle à la liste des positions
                                    if (!arret_assez_long)
                                    {
                                        chemins[i].Add(chemins[i][chemins[i].Count - 1]);
                                    }

                                    // Si c’est le cas, on ajoute la nouvelle position à la liste des positions
                                    else
                                    {
                                        chemins[i].Add(trajet[1]);
                                    }
                                }

                                catch
                                {
                                    // S’il ne peut pas remonter 7 fois en arrière, on ajoute la position actuelle à la liste des positions
                                    chemins[i].Add(chemins[i][chemins[i].Count - 1]);
                                }
                            }

                            // Cas où la prochaine position implique un virage
                            else if (chemins[i][chemins[i].Count - 1].nom.Orientation != trajet[1].nom.Orientation)
                            {
                                try
                                {
                                    bool arret_assez_long = true;
                                    int iter = 0;

                                    // On vérifie que les 4 derniers chariots ont la même orientation
                                    while (iter < 3 && arret_assez_long)
                                    {
                                        if (!chemins[i][chemins[i].Count - 1 - iter].nom.Egal(chemins[i][chemins[i].Count - 1 - iter - 1].nom))
                                        {
                                            arret_assez_long = false;
                                        }

                                        iter++;
                                    }

                                    // Si ce n’est pas le cas, on ajoute la position actuelle à la liste des positions
                                    if (!arret_assez_long)
                                    {
                                        chemins[i].Add(chemins[i][chemins[i].Count - 1]);
                                    }

                                    // Si c’est le cas, on ajoute la nouvelle position à la liste des positions
                                    else
                                    {
                                        chemins[i].Add(trajet[1]);
                                    }
                                }

                                catch
                                {
                                    // S’il ne peut pas remonter 4 fois en arrière, on ajoute la position actuelle à la liste des positions
                                    chemins[i].Add(chemins[i][chemins[i].Count - 1]);
                                }
                            }

                            else
                            {
                                chemins[i].Add(trajet[1]);
                            }
                        }

                        else
                        {
                            chemins[i].Add(chemins[i][chemins[i].Count - 1]);
                        }

                        entrepot[chariots[i].Ligne, chariots[i].Colonne] = 0;
                        chariots[i] = chemins[i][chemins[i].Count - 1].nom;
                        entrepot[chariots[i].Ligne, chariots[i].Colonne] = -2;

                        if (chariots[i].Egal(Trouver_Destination(objets[i])))
                        {
                            recuperation[i] = true;
                        }
                    }

                    else if (recuperation[i] && !montee[i])
                    {
                        try
                        {
                            bool montee_assez_longue = true;
                            int iter = 0;

                            while (iter < 2 * objets[i].Hauteur - 1 && montee_assez_longue)
                            {
                                if (!chemins[i][chemins[i].Count - 1 - iter].nom.Egal(chemins[i][chemins[i].Count - 1 - iter - 1].nom))
                                {
                                    montee_assez_longue = false;
                                }

                                iter++;
                            }

                            if (!montee_assez_longue)
                            {
                                chemins[i].Add(chemins[i][chemins[i].Count - 1]);
                            }

                            else
                            {
                                montee[i] = true;
                            }
                        }

                        catch
                        {
                            chemins[i].Add(chemins[i][chemins[i].Count - 1]);
                        }
                    }

                    else if (!livraison[i] && recuperation[i] && montee[i])
                    {
                        g = new Graphe();
                        NoeudLivraison noeudInitial = new NoeudLivraison(chariots[i], entrepot);
                        List<Noeud> trajet = g.RechercherSolutionAEtoile(noeudInitial);

                        // Si on trouve un chemin, on ajoute la prochaine position à la liste
                        if (trajet.Count > 1)
                        {
                            if (chemins[i][chemins[i].Count - 1].nom.Orientation != trajet[1].nom.Orientation && chemins[i][chemins[i].Count - 1].nom.Orientation % 2 == trajet[1].nom.Orientation % 2)
                            {
                                bool arret_assez_long = true;
                                int iter = 0;

                                while (iter < 6 && arret_assez_long)
                                {
                                    if (!chemins[i][chemins[i].Count - 1 - iter].nom.Egal(chemins[i][chemins[i].Count - 1 - iter - 1].nom))
                                    {
                                        arret_assez_long = false;
                                    }

                                    iter++;
                                }

                                if (!arret_assez_long)
                                {
                                    chemins[i].Add(chemins[i][chemins[i].Count - 1]);
                                }

                                else
                                {
                                    chemins[i].Add(trajet[1]);
                                }
                            }

                            else if (chemins[i][chemins[i].Count - 1].nom.Orientation != trajet[1].nom.Orientation)
                            {
                                bool arret_assez_long = true;
                                int iter = 0;

                                while (iter < 3 && arret_assez_long)
                                {
                                    if (!chemins[i][chemins[i].Count - 1 - iter].nom.Egal(chemins[i][chemins[i].Count - 1 - iter - 1].nom))
                                    {
                                        arret_assez_long = false;
                                    }

                                    iter++;
                                }

                                if (!arret_assez_long)
                                {
                                    chemins[i].Add(chemins[i][chemins[i].Count - 1]);
                                }

                                else
                                {
                                    chemins[i].Add(trajet[1]);
                                }
                            }

                            else
                            {
                                chemins[i].Add(trajet[1]);
                            }
                        }

                        else
                        {
                            chemins[i].Add(chemins[i][chemins[i].Count - 1]);
                        }

                        entrepot[chariots[i].Ligne, chariots[i].Colonne] = 0;
                        chariots[i] = chemins[i][chemins[i].Count - 1].nom;
                        entrepot[chariots[i].Ligne, chariots[i].Colonne] = -2;

                        if (chariots[i].Colonne == 0)
                        {
                            livraison[i] = true;
                            temps[i] = temps_ecoule;
                        }
                    }
                }

                temps_ecoule += 1;
            }

            this.chemins_realite = chemins;
            this.temps_realite = temps;
            Super_Affichage_Dynamique();
            realite_timer.Start();
        }

        /// <summary>
        /// Permet de vérifier si tous les chariots ont livrés leur objet
        /// </summary>
        /// <param name="livraison">Liste de booléens pour savoir si un chariot donné a livré ou non son objet</param>
        /// <returns>true si tous les chariots ont livré leur objet et false sinon</returns>
        private bool Verifier_Fin(List<bool> livraison)
        {
            bool fin = true;
            int i = 0;

            while (fin && i < livraison.Count)
            {
                if (!livraison[i])
                {
                    fin = false;
                }

                i++;
            }

            return fin;
        }

        /// <summary>
        /// Permet de changer la position du chariot pour changer l’affichage 1, 2 ou 6 secondes plus tard
        /// </summary>
        private void Changer_Position()
        {
            // Récupération de la position actuelle
            int rang = Trouver_Rang(dernier_chemin[compteur].nom);

            // Vérification que l’on n’est pas au point intermédaire
            if (dernier_chemin[compteur].nom.Egal(Trouver_Destination(dernier_objet)))
            {
                chrono_timer.Interval = 1000 * dernier_objet.Hauteur;
            }

            // Si ce n’est pas le cas, on regarde dans quel direction sera orienté le chariot au prochain mouvement
            else
            {
                // Initialisation du timer
                chrono_timer.Interval = 500;

                // Cas où il fera un virage
                if (dernier_chemin[compteur + 1].nom.Orientation != dernier_chemin[compteur].nom.Orientation)
                {
                    chrono_timer.Interval += 1500;

                    // Cas où il fera un demi-tour
                    if (dernier_chemin[compteur + 1].nom.Orientation % 2 == dernier_chemin[compteur].nom.Orientation % 2)
                    {
                        chrono_timer.Interval += 1500;
                    }
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

        /// <summary>
        /// Permet de générer l’emplacement d’un objet 
        /// </summary>
        private Objet Generer_Objet()
        {
            Objet objet;

            // Correspond à la position(ligne, colonne), orientation et hauteur de l'objet
            int x, y, k, z;

            // On génère l'orientation aléatoirement
            k = alea.Next(1);

            // On génère la hauteur aléatoirement
            z = alea.Next(0, 11);

            // On génère aléatoirement les positions
            x = alea.Next(0, 25);
            y = alea.Next(0, 25);
            bool etagere = true;
            while (etagere)
            {
                x = alea.Next(0, 25);
                y = alea.Next(0, 25);

                // Si ça tombe sur une étagère
                if (x % 2 == 0 && x != 0 && x != 24 &&
                        ((y >= 2 && y < 11) || (y >= 14 && y < 23)))
                {
                    etagere = false;
                }
            }

            objet = new Objet(x, y, k, z);

            return objet;
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
        /// Permet de calculer la destination du chariot à partir des coordonnées
        /// de l’objet à récupérer
        /// </summary>
        /// <param name="objet">Objet à récupérer</param>
        /// <returns></returns>
        private Chariot Trouver_Destination(Objet objet)
        {
            int x, y, k;

            if (objet.Orientation == 0)
            {
                k = 2;
                x = objet.Ligne - 1;
            }

            else
            {
                k = 0;
                x = objet.Ligne + 1;
            }

            y = objet.Colonne;

            return new Chariot(x, y, k);
        }

        /// <summary>
        /// Permet de calculer la durée du dernier trajet
        /// </summary>
        private int Calculer_Temps()
        {
            int temps = 0;

            for (int i = 0; i < dernier_chemin.Count - 1; i++)
            {
                // Vérification que l’on n’est pas au point intermédaire
                if (dernier_chemin[i].nom.Egal(Trouver_Destination(dernier_objet)))
                {
                    temps += 2 * dernier_objet.Hauteur;
                }

                // Si ce n’est pas le cas, on regarde dans quel direction sera orienté le chariot au prochain mouvement
                temps += 1;

                // Cas où il fera un virage
                if (dernier_chemin[i + 1].nom.Orientation != dernier_chemin[i].nom.Orientation)
                {
                    temps += 3;

                    // Cas où il fera un demi-tour
                    if (dernier_chemin[i + 1].nom.Orientation % 2 == dernier_chemin[i].nom.Orientation % 2)
                    {
                        temps += 3;
                    }
                }
            }

            return temps;
        }

        private void Super_Affichage_Dynamique()
        {
            for (int i = 0; i < chariots.Count; i++)
            {
                if (temps_timer <= temps_realite[i])
                {
                    entrepot[chariots[i].Ligne, chariots[i].Colonne] = 0;
                    chariots[i] = chemins_realite[i][temps_timer].nom;
                    entrepot[chariots[i].Ligne, chariots[i].Colonne] = -2;
                }
            }

            // Affichage des chariots
            Afficher_Entrepot();
            Ajouter_Chariots();
        }
    }
}
