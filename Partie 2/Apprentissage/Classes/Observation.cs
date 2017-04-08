using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Observation
    {
        // Une observation a 2 coordonnées contenue dans une liste
        private List<double> coordonnees;

        // Récupération des coordonnées
        public double Ligne { get { return coordonnees[0]; } }
        public double Colonne { get { return coordonnees[1]; } }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="ligne">Ligne de l’observation</param>
        /// <param name="colonne">Colonne de l’observation</param>
        public Observation(double ligne, double colonne)
        {
            coordonnees = new List<double>();
            coordonnees.Add(ligne);
            coordonnees.Add(colonne);
        }

        /// <summary>
        /// Récupération soit de l’abscisse, soit de l’ordonnée
        /// </summary>
        /// <param name="i">0 si lignee, 1 si colonne</param>
        /// <returns>Abscisse ou ordonnée de l’observation</returns>
        public double Valeur(int i)
        {
            return coordonnees[i];
        }
    }
}
