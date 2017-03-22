using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot
{
    /// <summary>
    /// Classe abstraite, il est donc impératif de créer une classe qui en hérite
    /// pour résoudre un problème particulier en y ajoutant des infos liées au contexte du problème
    /// </summary>
    abstract public class GenericNode
    {
        protected int[] nom;                 // Nom du nœud
        protected double gCout;              // Coût du chemin du nœud initial jusqu’à ce nœud
        protected double hCout;              // Estimation heuristique du coût pour atteindre le nœud final
        protected double totalCout;          // Coût total (g + h)
        protected GenericNode parent;        // Nœud Parent
        protected List<GenericNode> enfants; // Nœuds Enfants

        public GenericNode()
        {
            parent = null;
            enfants = new List<GenericNode>();
        }

        public double GCout
        {
            get { return gCout; }
            set { gCout = value; }
        }

        public double HCout
        {
            get { return hCout; }
            set { hCout = value; }
        }

        public double TotalCout
        {
            get { return totalCout; }
            set { totalCout = value; }
        }

        public List<GenericNode> Enfants
        {
            get { return enfants; }
        }

        public GenericNode Parent
        {
            get { return parent; }
            set { parent = value; value.enfants.Add(this); }
        }

        public void SupprimerLiensParent()
        {
            if (parent == null) return;
            parent.enfants.Remove(this);
            parent = null;
        }

        public void CalculerCoutTotal()
        {
            totalCout = gCout + hCout;
        }

        // Méthodes abstrates, donc à surcharger obligatoirement avec override
        // dans une classe fille
        public abstract bool EstEgal(GenericNode noeudEvalue);
        public abstract double ObtenirCout(GenericNode noeudEvalue);
        public abstract bool VerifierFin();
        public abstract List<GenericNode> ObtenirSuccesseurs();
        public abstract void CalculerHCout();
    }
}
