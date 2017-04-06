using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Observation
    {
        // Une observation a 2 coordonnées contenue dans une liste
        private List<double> e;

        // Récupération des coordonnées
        public double Abscisse { get { return e[0]; } }
        public double Ordonnee { get { return e[1]; } }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="abcsisse">Abscisse de l’observation</param>
        /// <param name="ordonnee">Ordonnée de l’observation</param>
        public Observation(double abcsisse, double ordonnee)
        {
            e = new List<double>();
            e.Add(abcsisse);
            e.Add(ordonnee);
        }

        /// <summary>
        /// Récupération soit de l’abscisse, soit de l’ordonnée
        /// </summary>
        /// <param name="i">0 si abscisse, 1 si ordonnée</param>
        /// <returns>Abscisse ou ordonnée de l’observation</returns>
        public double Valeur(int i)
        {
            return e[i];
        }
    }
}
