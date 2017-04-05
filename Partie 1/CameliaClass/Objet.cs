using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameliaClass
{
    public class Objet
    {
        public int Ligne { get; set; }
        public int Colonne { get; set; }
        public int Orientation { get; set; }
        public int Hauteur { get; set; }

        public Objet(int x, int y, int k, int z)
        {
            Ligne = x;
            Colonne = y;
            Orientation = k;
            Hauteur = z;
        }

        public override string ToString()
        {
            return "Objet :\n  - Ligne : " + this.Ligne + "\n  - Colonne : " + this.Colonne + "\n  - Orientation : " + this.Orientation + "\n  - Hauteur : " + this.Hauteur;
        }
    }
}
