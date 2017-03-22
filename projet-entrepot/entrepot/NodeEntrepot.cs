using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot
{
    class NodeEntrepot : GenericNode
    {
        public NodeEntrepot(int x, int y) : base() 
        {
            nom[0] = x;
            nom[1] = y;
        }

        public override bool EstEgal(GenericNode noeudEvalue)
        {
            return (((NodeEntrepot)noeudEvalue).nom[0] == nom[0] && ((NodeEntrepot)noeudEvalue).nom[1] == nom[1]);
        }

        public override double ObtenirCout(GenericNode noeudEvalue)
        {
            return 1;
        }

        public override bool VerifierFin(int xFinal, int yFinal)
        {
            return (this.nom[0] == xFinal && this.nom[1] == yFinal);
        }

        public override List<GenericNode> ObtenirSuccesseurs(int[,] entrepot)
        {
            List<GenericNode> lsucc = new List<GenericNode>();

            // On teste si le successeur est possible (c’est-à-dire si la position est possible (égale à 0 dans l’entrepôt))
            if (this.nom[0] < 24 && entrepot[this.nom[0] + 1, this.nom[1]] == 0)
            {
                lsucc.Add(new NodeEntrepot(this.nom[0] + 1, this.nom[1]));
            }

            if (this.nom[1] < 24 && entrepot[this.nom[0], this.nom[1] + 1] == 0)
            {
                lsucc.Add(new NodeEntrepot(this.nom[0], this.nom[1] + 1));
            }

            if (this.nom[0] > 0 && entrepot[this.nom[0] - 1, this.nom[1]] == 0)
            {
                lsucc.Add(new NodeEntrepot(this.nom[0] - 1, this.nom[1]));
            }

            if (this.nom[1] > 0 && entrepot[this.nom[0], this.nom[1] - 1] == 0)
            {
                lsucc.Add(new NodeEntrepot(this.nom[0], this.nom[1] - 1));
            }

            return lsucc;
        }

        public override void CalculerHCout()
        {
        }

        public override string ToString()
        {
            return "Position du nœud :\n  - Ligne : " + nom[0] + "\n  - Colonne : " + nom[1]; 
        }
    }
}
