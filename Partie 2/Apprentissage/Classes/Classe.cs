using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Classe
    {
        // Liste des points appartenant à la classe
        private List<Point> listePoints = new List<Point>();
        public List<Point> ListePoints { get { return listePoints; } }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="neurone">Point initial de la classe</param>
        public Classe(Point point)
        {
            listePoints.Add(point);
        }

        /// <summary>
        /// Fusion d’une classe avec une autre
        /// </summary>
        /// <param name="autreClasse">Classe qui fusionne avec notre classe actuelle</param>
        public void FusionnerAvec(Classe autreClasse)
        {
            foreach (Point point in autreClasse.ListePoints)
            {
                listePoints.Add(point);
            }
        }
    }
}
