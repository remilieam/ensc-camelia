using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot
{
    class NodeEntrepot : GenericNode
    {
        static int xFinal;
        static int yFinal;
        static int[,] entrepot = new int[25, 25];

        public NodeEntrepot(int x, int y) : base()
        {
            this.nom = new int[2];
            this.nom[0] = x;
            this.nom[1] = y;
        }

        public NodeEntrepot(int x, int y, int xFinal, int yFinal, int[,] entrepot)
            : base()
        {
            this.nom = new int[2];
            this.nom[0] = x;
            this.nom[1] = y;
            NodeEntrepot.xFinal = xFinal;
            NodeEntrepot.yFinal = yFinal;
            NodeEntrepot.entrepot = entrepot;
        }

        public override bool EstEgal(GenericNode noeudEvalue)
        {
            return (((NodeEntrepot)noeudEvalue).nom[0] == this.nom[0] && ((NodeEntrepot)noeudEvalue).nom[1] == this.nom[1]);
        }

        public override double ObtenirCout(GenericNode noeudEvalue)
        {
            return 1;
        }

        public override bool VerifierFin()
        {
            return (this.nom[0] == NodeEntrepot.xFinal && this.nom[1] == NodeEntrepot.yFinal);
        }

        public override List<GenericNode> ObtenirSuccesseurs()
        {
            List<GenericNode> lsucc = new List<GenericNode>();

            // On teste si le successeur est possible (c’est-à-dire si la position est possible (égale à 0 dans l’entrepôt))
            if (this.nom[0] < 24 && NodeEntrepot.entrepot[this.nom[0] + 1, this.nom[1]] == 0)
            {
                lsucc.Add(new NodeEntrepot(this.nom[0] + 1, this.nom[1]));
            }

            if (this.nom[1] < 24 && NodeEntrepot.entrepot[this.nom[0], this.nom[1] + 1] == 0)
            {
                lsucc.Add(new NodeEntrepot(this.nom[0], this.nom[1] + 1));
            }

            if (this.nom[0] > 0 && NodeEntrepot.entrepot[this.nom[0] - 1, this.nom[1]] == 0)
            {
                lsucc.Add(new NodeEntrepot(this.nom[0] - 1, this.nom[1]));
            }

            if (this.nom[1] > 0 && NodeEntrepot.entrepot[this.nom[0], this.nom[1] - 1] == 0)
            {
                lsucc.Add(new NodeEntrepot(this.nom[0], this.nom[1] - 1));
            }

            return lsucc;
        }

        public override void CalculerHCout()
        {
            this.HCout = Math.Sqrt((NodeEntrepot.yFinal - this.nom[1]) ^ 2 + (NodeEntrepot.xFinal - this.nom[0]) ^ 2);
        }

        public override string ToString()
        {
            return "Position du nœud :\n  - Ligne : " + this.nom[0] + "\n  - Colonne : " + this.nom[1]; 
        }
    }
}
