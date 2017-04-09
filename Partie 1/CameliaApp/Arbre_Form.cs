using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CameliaClass;

namespace CameliaApp
{
    public partial class Arbre_Form : Form
    {
        private Graphe graphe;

        public Arbre_Form(Graphe graphe)
        {
            InitializeComponent();
            this.graphe = graphe;
            chiffre_ouverts_label.Text = graphe.compterOuverts().ToString();
            chiffre_fermes_label.Text = graphe.compterFermes().ToString();
            AvoirArbreRecherche();
        }

        /// <summary>
        /// Permet de revenir sur le formulaire de l’entrepôt après fermeture avec
        /// la croix rouge en haut à droite
        /// </summary>
        private void Arbre_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Fin_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Permet d’afficher l’arbre de recherche grâce à un TreeView.
        /// Celui-ci est mis à jour avec les nœuds de la liste des fermés,
        /// on ne tient pas compte des ouverts
        /// </summary>
        private void AvoirArbreRecherche()
        {
            if (graphe.noeudsFermes == null) return;
            if (graphe.noeudsFermes.Count == 0) return;

            // On efface toutes les branches de l’arbre
            arbre_treeview.Nodes.Clear();

            // On ajoute à l’arbre sa première branche (son tronc)
            TreeNode branche = new TreeNode(graphe.noeudsFermes[0].ToString());
            arbre_treeview.Nodes.Add(branche);

            AjouterBranche(graphe.noeudsFermes[0], branche);
        }

        /// <summary>
        /// Permet d’ajouter une branche à l’arbre de recherche.
        /// AjouterBranche est exclusivement appelée par AvoirArbreRecherche.
        /// Les nœuds sont ajoutés de manière récursive
        /// </summary>
        /// <param name="noeud">Nœud à partir duquel on ajoute une branche</param>
        /// <param name="branche">Branche sur laquelle on ajoute une nouvelle branche</param>
        private void AjouterBranche(Noeud noeud, TreeNode branche)
        {
            // On ajoute chaque enfant du nœud initial à la branche initiale
            foreach (Noeud enfant in noeud.Enfants)
            {
                // On récupère la branche à ajouter et on l’ajoute à la branche initiale
                TreeNode branche_enfant = new TreeNode(enfant.ToString());
                branche.Nodes.Add(branche_enfant);

                // Si le nœud enfant à lui-même des enfants, on ajoute ses enfants
                if (enfant.Enfants.Count > 0) { AjouterBranche(enfant, branche_enfant); }
            }
        }
    }
}
