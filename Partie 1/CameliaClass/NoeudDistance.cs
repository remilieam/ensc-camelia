using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameliaClass
{
    public class NoeudDistance : Noeud
    {
        private static Chariot arrivee;
        private static int[,] entrepot = new int[25, 25];

        /// <summary>
        /// Constructeur
        /// </summary>
        public NoeudDistance(Chariot chariot) : base()
        {
            this.nom = chariot;
        }

        /// <summary>
        /// Constructeur du premier nœud
        /// </summary>
        /// <param name="entrepot">Entrepôt</param>
        public NoeudDistance(Chariot depart, Chariot arrivee, int[,] entrepot)
            : base()
        {
            this.nom = depart;
            NoeudDistance.arrivee = arrivee;
            NoeudDistance.entrepot = entrepot;
        }

        /// <summary>
        /// Permet de vérifier si 2 nœuds sont identiques
        /// </summary>
        /// <param name="noeudEvalue">Nœud que l’on compare</param>
        /// <returns></returns>
        public override bool EstEgal(Noeud noeudEvalue)
        {
            return (this.nom.Egal(noeudEvalue.nom));
        }

        /// <summary>
        /// Permet d’obtenir le coût d’un déplacement
        /// </summary>
        /// <param name="noeudEvalue">Nœud vers lequel on se déplace</param>
        /// <returns>Coût du déplacement</returns>
        public override double ObtenirCout(Noeud noeudEvalue)
        {
            return 1;
        }

        /// <summary>
        /// Permet de vérifier si on est arrivé au nœud objectif
        /// </summary>
        /// <returns>Vrai si on a atteint l’objectif et faux sinon</returns>
        public override bool VerifierFin()
        {
            return (this.nom.Egal(NoeudDistance.arrivee));
        }

        /// <summary>
        /// Permet d’obtenir les successeurs du nœud
        /// </summary>
        /// <returns>Liste des successeurs</returns>
        public override List<Noeud> ObtenirSuccesseurs()
        {
            List<Noeud> listeSuccesseurs = new List<Noeud>();

            // On teste si le successeur est possible
            // c’est-à-dire si la position est possible (égale à 0 dans l’entrepôt)
            if (this.nom.Ligne < 24 && NoeudDistance.entrepot[this.nom.Ligne + 1, this.nom.Colonne] == 0)
            {
                listeSuccesseurs.Add(new NoeudDistance(new Chariot(this.nom.Ligne + 1, this.nom.Colonne, 2)));
            }

            if (this.nom.Colonne < 24 && NoeudDistance.entrepot[this.nom.Ligne, this.nom.Colonne + 1] == 0)
            {
                listeSuccesseurs.Add(new NoeudDistance(new Chariot(this.nom.Ligne, this.nom.Colonne + 1, 1)));
            }

            if (this.nom.Ligne > 0 && NoeudDistance.entrepot[this.nom.Ligne - 1, this.nom.Colonne] == 0)
            {
                listeSuccesseurs.Add(new NoeudDistance(new Chariot(this.nom.Ligne - 1, this.nom.Colonne, 0)));
            }

            if (this.nom.Colonne > 0 && NoeudDistance.entrepot[this.nom.Ligne, this.nom.Colonne - 1] == 0)
            {
                listeSuccesseurs.Add(new NoeudDistance(new Chariot(this.nom.Ligne, this.nom.Colonne - 1, 3)));
            }

            return listeSuccesseurs;
        }

        /// <summary>
        /// Permet de calculer le coût heuristique
        /// </summary>
        public override void CalculerHCout()
        {
            this.HCout = Math.Sqrt(Math.Pow(NoeudDistance.arrivee.Colonne - this.nom.Colonne, 2) + Math.Pow(NoeudDistance.arrivee.Ligne - this.nom.Ligne, 2));
        }

        /// <summary>
        /// Permet d’obtenir les informations concernant le nœud sous forme de chaîne
        /// </summary>
        /// <returns>Nœud</returns>
        public override string ToString()
        {
            return "Ligne : " + (this.nom.Ligne + 1) + " / Colonne : " + (this.nom.Colonne + 1) + " / Orientation : " + this.nom.Orientation;
        }
    }
}
