using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entrepot
{
    class NodeEntrepotLivraison : GenericNode
    {
        static int[,] entrepot = new int[25, 25];

        public NodeEntrepotLivraison(int x, int y, int k)
            : base()
        {
            this.nom = new int[3];
            this.nom[0] = x;
            this.nom[1] = y;
            this.nom[2] = k;
        }

        public NodeEntrepotLivraison(int x, int y, int k, int[,] entrepot)
            : base()
        {
            this.nom = new int[3];
            this.nom[0] = x;
            this.nom[1] = y;
            this.nom[2] = k;
            NodeEntrepotLivraison.entrepot = entrepot;
        }

        public override bool EstEgal(GenericNode noeudEvalue)
        {
            return (((NodeEntrepotLivraison)noeudEvalue).nom[0] == this.nom[0] && ((NodeEntrepotLivraison)noeudEvalue).nom[1] == this.nom[1]);
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
            return (this.nom[1] == 0);
        }

        public override List<GenericNode> ObtenirSuccesseurs()
        {
            List<GenericNode> lsucc = new List<GenericNode>();

            // On teste si le successeur est possible (c’est-à-dire si la position est possible (égale à 0 dans l’entrepôt))
            if (this.nom[0] < 24 && NodeEntrepotLivraison.entrepot[this.nom[0] + 1, this.nom[1]] == 0)
            {
                lsucc.Add(new NodeEntrepotLivraison(this.nom[0] + 1, this.nom[1], 2));
            }

            if (this.nom[1] < 24 && NodeEntrepotLivraison.entrepot[this.nom[0], this.nom[1] + 1] == 0)
            {
                lsucc.Add(new NodeEntrepotLivraison(this.nom[0], this.nom[1] + 1, 1));
            }

            if (this.nom[0] > 0 && NodeEntrepotLivraison.entrepot[this.nom[0] - 1, this.nom[1]] == 0)
            {
                lsucc.Add(new NodeEntrepotLivraison(this.nom[0] - 1, this.nom[1], 0));
            }

            if (this.nom[1] > 0 && NodeEntrepotLivraison.entrepot[this.nom[0], this.nom[1] - 1] == 0)
            {
                lsucc.Add(new NodeEntrepotLivraison(this.nom[0], this.nom[1] - 1, 3));
            }

            return lsucc;
        }

        public override void CalculerHCout()
        {
            
        }

        public override string ToString()
        {
            return "Position du nœud :\n  - Ligne : " + this.nom[0] + "\n  - Colonne : " + this.nom[1] + "\n  - Orientation : " + this.nom[2];
        }
    }
}
