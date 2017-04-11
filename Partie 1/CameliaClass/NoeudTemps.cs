using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameliaClass
{
    public class NoeudTemps : Noeud
    {
        private static Chariot arrivee;
        private static int[,] entrepot = new int[25, 25];

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="chariot">Chariot servant de nœud</param>
        public NoeudTemps(Chariot chariot) : base()
        {
            this.nom = chariot;
        }

        /// <summary>
        /// Constructeur du premier nœud
        /// </summary>
        /// <param name="depart">Nœud de départ</param>
        /// <param name="arrivee">Nœud d’arrivée</param>
        /// <param name="entrepot">Configuration de l’entrepôt au départ</param>
        public NoeudTemps(Chariot depart, Chariot arrivee, int[,] entrepot)
            : base()
        {
            this.nom = depart;
            NoeudTemps.arrivee = arrivee;
            NoeudTemps.entrepot = entrepot;
        }

        /// <summary>
        /// Permet de vérifier si 2 nœuds sont identiques
        /// </summary>
        /// <param name="noeudEvalue">Nœud que l’on compare</param>
        /// <returns>true si les nœuds sont les mêmes, false sinon</returns>
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
            // S’il s’agit d’un déplacement, on a 1 dans tous les cas
            int cout = 1;

            // Si le chariot va dans une direction différente
            if (this.nom.Orientation != noeudEvalue.nom.Orientation)
            {
                cout += 3;

                // S’il fait demi-tour
                if (this.nom.Orientation % 2 == noeudEvalue.nom.Orientation % 2)
                {
                    cout += 3;
                }
            }

            return cout;
        }

        /// <summary>
        /// Permet de vérifier si on est arrivé au nœud objectif
        /// </summary>
        /// <returns>Vrai si on a atteint l’objectif et faux sinon</returns>
        public override bool VerifierFin()
        {
            return (this.nom.Egal(NoeudTemps.arrivee));
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
            if (this.nom.Ligne < 24 && NoeudTemps.entrepot[this.nom.Ligne + 1, this.nom.Colonne] == 0)
            {
                listeSuccesseurs.Add(new NoeudTemps(new Chariot(this.nom.Ligne + 1, this.nom.Colonne, 2)));
            }

            if (this.nom.Colonne < 24 && NoeudTemps.entrepot[this.nom.Ligne, this.nom.Colonne + 1] == 0)
            {
                listeSuccesseurs.Add(new NoeudTemps(new Chariot(this.nom.Ligne, this.nom.Colonne + 1, 1)));
            }

            if (this.nom.Ligne > 0 && NoeudTemps.entrepot[this.nom.Ligne - 1, this.nom.Colonne] == 0)
            {
                listeSuccesseurs.Add(new NoeudTemps(new Chariot(this.nom.Ligne - 1, this.nom.Colonne, 0)));
            }

            if (this.nom.Colonne > 0 && NoeudTemps.entrepot[this.nom.Ligne, this.nom.Colonne - 1] == 0)
            {
                listeSuccesseurs.Add(new NoeudTemps(new Chariot(this.nom.Ligne, this.nom.Colonne - 1, 3)));
            }

            return listeSuccesseurs;
        }

        /// <summary>
        /// Permet de calculer le coût heuristique
        /// </summary>
        public override void CalculerHCout()
        {
            this.HCout = Math.Sqrt(Math.Pow(NoeudTemps.arrivee.Colonne - this.nom.Colonne, 2) + Math.Pow(NoeudTemps.arrivee.Ligne - this.nom.Ligne, 2));
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
