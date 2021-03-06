﻿using System;
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

        public bool Egal(Objet objet)
        {
            if (this.Ligne == objet.Ligne && this.Colonne == objet.Colonne && this.Orientation == objet.Orientation)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return "Ligne : " + (this.Ligne + 1) + " / Colonne : " + (this.Colonne + 1) + " / Orientation : " + this.Orientation + " / Hauteur : " + this.Hauteur;
        }
    }
}
