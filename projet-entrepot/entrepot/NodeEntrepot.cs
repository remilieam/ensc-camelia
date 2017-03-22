using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot
{
    class NodeEntrepot : GenericNode
    {
        // Correspond à la position du chariot
        int[] Name;

        public NodeEntrepot(int x, int y) : base() 
        {
            Name[0] = x;
            Name[1] = y;
        }

        public override bool IsEqual(GenericNode noeudEvalue)
        {
            return (((NodeEntrepot)noeudEvalue).Name[0] == Name[0] && ((NodeEntrepot)noeudEvalue).Name[1] == Name[1]);
        }

        public override double GetArcCost(GenericNode noeudEvalue)
        {
            return 1;
        }

        public override bool EndState(int xFinal, int yFinal)
        {
            return (this.Name[0] == xFinal && this.Name[1] == yFinal);
        }

        public override List<GenericNode> GetListSucc(int[,] entrepot)
        {
            List<GenericNode> lsucc = new List<GenericNode>();

            // On teste si le successeur est possible (c’est-à-dire si la position est possible (égale à 0 dans l’entrepôt))
            if (this.Name[0] < 24 && entrepot[this.Name[0] + 1, this.Name[1]] == 0)
            {
                lsucc.Add(new NodeEntrepot(this.Name[0] + 1, this.Name[1]));
            }

            if (this.Name[1] < 24 && entrepot[this.Name[0], this.Name[1] + 1] == 0)
            {
                lsucc.Add(new NodeEntrepot(this.Name[0], this.Name[1] + 1));
            }

            if (this.Name[0] > 0 && entrepot[this.Name[0] - 1, this.Name[1]] == 0)
            {
                lsucc.Add(new NodeEntrepot(this.Name[0] - 1, this.Name[1]));
            }

            if (this.Name[1] > 0 && entrepot[this.Name[0], this.Name[1] - 1] == 0)
            {
                lsucc.Add(new NodeEntrepot(this.Name[0], this.Name[1] - 1));
            }

            return lsucc;
        }

        public override void CalculeHCost()
        {
        }

        public override string ToString()
        {
            return "Position du nœud :\n  - Ligne : " + Name[0] + "\n  - Colonne : " + Name[1]; 
        }
    }
}
