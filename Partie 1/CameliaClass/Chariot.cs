using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameliaClass
{
    public class Chariot
    {
        public int Ligne { get; set; }
        public int Colonne { get; set; }
        public int Orientation { get; set; }

        public Chariot(int x, int y, int k)
        {
            this.Ligne = x;
            this.Colonne = y;
            this.Orientation = k;
        }

        public bool Egal(Chariot chariot)
        {
            if (this.Ligne == chariot.Ligne && this.Colonne == chariot.Colonne)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return "Ligne : " + (this.Ligne + 1) + " / Colonne : " + (this.Colonne + 1) + " / Orientation : " + this.Orientation;
        }
    }
}
