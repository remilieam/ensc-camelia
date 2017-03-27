using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot
{
    class NodeEntrepotTemps : GenericNode
    {
        static int xFinal;
        static int yFinal;
        static int[,] entrepot = new int[25, 25];

        public NodeEntrepotTemps(int x, int y, int k)
            : base()
        {
            this.nom = new int[3];
            this.nom[0] = x;
            this.nom[1] = y;
            this.nom[2] = k;
        }

        public NodeEntrepotTemps(int x, int y, int k, int xFinal, int yFinal, int[,] entrepot)
            : base()
        {
            this.nom = new int[3];
            this.nom[0] = x;
            this.nom[1] = y;
            this.nom[2] = k;
            NodeEntrepotTemps.xFinal = xFinal;
            NodeEntrepotTemps.yFinal = yFinal;
            NodeEntrepotTemps.entrepot = entrepot;
        }

        public override bool EstEgal(GenericNode noeudEvalue)
        {
            return (((NodeEntrepotTemps)noeudEvalue).nom[0] == this.nom[0] && ((NodeEntrepotTemps)noeudEvalue).nom[1] == this.nom[1]);
        }

        public override double ObtenirCout(GenericNode noeudEvalue)
        {
            // S’il s'agit d'un déplacement, on a 1s dans tous les cas
            int cout = 1;
            
            // Si le chariot va dans une direction différente
            if (this.nom[2] != noeudEvalue.Nom[2])
            {
                cout += 3;
                // S'il fait demi-tour
                if (this.nom[2] % 2 == noeudEvalue.Nom[2] % 2)
                {
                    cout += 3;
                }
            }
            return cout;
        }

        public override bool VerifierFin()
        {
            return (this.nom[0] == NodeEntrepotTemps.xFinal && this.nom[1] == NodeEntrepotTemps.yFinal);
        }

        public override List<GenericNode> ObtenirSuccesseurs()
        {
            List<GenericNode> lsucc = new List<GenericNode>();
            
            // On teste si le successeur est possible (c’est-à-dire si la position est possible (égale à 0 dans l’entrepôt))
            if (this.nom[0] < 24 && NodeEntrepotTemps.entrepot[this.nom[0] + 1, this.nom[1]] == 0)
            {
                lsucc.Add(new NodeEntrepotTemps(this.nom[0] + 1, this.nom[1], 2));
            }

            if (this.nom[1] < 24 && NodeEntrepotTemps.entrepot[this.nom[0], this.nom[1] + 1] == 0)
            {
                lsucc.Add(new NodeEntrepotTemps(this.nom[0], this.nom[1] + 1, 1));
            }

            if (this.nom[0] > 0 && NodeEntrepotTemps.entrepot[this.nom[0] - 1, this.nom[1]] == 0)
            {
                lsucc.Add(new NodeEntrepotTemps(this.nom[0] - 1, this.nom[1], 0));
            }

            if (this.nom[1] > 0 && NodeEntrepotTemps.entrepot[this.nom[0], this.nom[1] - 1] == 0)
            {
                lsucc.Add(new NodeEntrepotTemps(this.nom[0], this.nom[1] - 1, 3));
            }

            return lsucc;
        }

        public override void CalculerHCout()
        {
            this.HCout = Math.Sqrt((NodeEntrepotTemps.yFinal - this.nom[1]) ^ 2 + (NodeEntrepotTemps.xFinal - this.nom[0]) ^ 2);
        }

        public override string ToString()
        {
            return "Position du nœud :\n  - Ligne : " + this.nom[0] + "\n  - Colonne : " + this.nom[1] + "\n  - Orientation : " + this.nom[2];
        }
    }
}
