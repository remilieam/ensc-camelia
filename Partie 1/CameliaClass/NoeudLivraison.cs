using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameliaClass
{
    public class NoeudLivraison : Noeud
    {
        private static int[,] entrepot = new int[25, 25];

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="x">Ligne du nœud</param>
        /// <param name="y">Colonne du nœud</param>
        public NoeudLivraison(Chariot chariot) : base()
        {
            this.nom = chariot;
        }

        /// <summary>
        /// Constructeur du premier nœud
        /// </summary>
        /// <param name="x">Ligne du premier nœud</param>
        /// <param name="y">Colonne du premier nœud</param>
        /// <param name="xFinal">Ligne du nœud objectif</param>
        /// <param name="yFinal">Colonne du nœud objectif</param>
        /// <param name="entrepot">Entrepôt</param>
        public NoeudLivraison(Chariot depart, int[,] entrepot)
            : base()
        {
            this.nom = depart;
            NoeudLivraison.entrepot = entrepot;
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
            return (this.nom.Colonne == 0);
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
            if (this.nom.Ligne < 24 && NoeudLivraison.entrepot[this.nom.Ligne + 1, this.nom.Colonne] == 0)
            {
                listeSuccesseurs.Add(new NoeudLivraison(new Chariot(this.nom.Ligne + 1, this.nom.Colonne, 2)));
            }

            if (this.nom.Colonne < 24 && NoeudLivraison.entrepot[this.nom.Ligne, this.nom.Colonne + 1] == 0)
            {
                listeSuccesseurs.Add(new NoeudLivraison(new Chariot(this.nom.Ligne, this.nom.Colonne + 1, 1)));
            }

            if (this.nom.Ligne > 0 && NoeudLivraison.entrepot[this.nom.Ligne - 1, this.nom.Colonne] == 0)
            {
                listeSuccesseurs.Add(new NoeudLivraison(new Chariot(this.nom.Ligne - 1, this.nom.Colonne, 0)));
            }

            if (this.nom.Colonne > 0 && NoeudLivraison.entrepot[this.nom.Ligne, this.nom.Colonne - 1] == 0)
            {
                listeSuccesseurs.Add(new NoeudLivraison(new Chariot(this.nom.Ligne, this.nom.Colonne - 1, 3)));
            }

            return listeSuccesseurs;
        }

        /// <summary>
        /// Permet de calculer le coût heuristique
        /// </summary>
        public override void CalculerHCout()
        {
        }

        /// <summary>
        /// Permet d’obtenir les informations concernant le nœud sous forme de chaîne
        /// </summary>
        /// <returns>Nœud</returns>
        public override string ToString()
        {
            return "Position du nœud :\n  - Ligne : " + this.nom.Ligne + "\n  - Colonne : " + this.nom.Colonne + "\n  - Orientation : " + this.nom.Orientation; 
        }
    }
}
