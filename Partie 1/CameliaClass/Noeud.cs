using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameliaClass
{
    /// <summary>
    /// Classe abstraite, il est donc impératif de créer une classe qui en hérite
    /// pour résoudre un problème particulier en y ajoutant des infos liées au contexte du problème
    /// </summary>
    abstract public class Noeud
    {
        public Chariot nom;
        protected double gCout;              // Coût du chemin du nœud initial jusqu’à ce nœud
        protected double hCout;              // Estimation heuristique du coût pour atteindre le nœud final
        protected double totalCout;          // Coût total (g + h)
        protected Noeud parent;              // Nœud Parent
        protected List<Noeud> enfants;       // Nœuds Enfants

        public Noeud()
        {
            parent = null;
            enfants = new List<Noeud>();
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

        public List<Noeud> Enfants
        {
            get { return enfants; }
        }

        public Noeud Parent()
        {
            return parent;
        }

        public void Parent(Noeud valeur)
        {
            parent = valeur;
            valeur.enfants.Add(this);
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
        public abstract bool EstEgal(Noeud noeudEvalue);
        public abstract double ObtenirCout(Noeud noeudEvalue);
        public abstract bool VerifierFin();
        public abstract List<Noeud> ObtenirSuccesseurs();
        public abstract void CalculerHCout();
    }
}
