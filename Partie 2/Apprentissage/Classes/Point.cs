using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Point
    {
        // Comme une observation a 2 composantes, chaque point
        // a 2 poids
        private List<double> poids;
        private static Random alea = new Random();

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nbPoids">Nombre de poids du point</param>
        /// <param name="valeurMax">Amplitude maximale des poids du point</param>
        public Point(int nbPoids, int valeurMax)
        {
            poids = new List<double>();

            // Ajout des poids dans la liste
            for (int i = 0; i < nbPoids; i++)
            {
                // Les poids seront compris dans [0, valeurMax[
                poids.Add(alea.NextDouble() * valeurMax);
            }
        }

        /// <summary>
        /// Récupération du ie poids
        /// </summary>
        /// <param name="i">0 pour le poids lié à la ligne et 1 pour celui lié à la colonne</param>
        /// <returns>Poids associé au numéro passé en argument</returns>
        public double RecupererPoids(int i)
        {
            return poids[i];
        }

        /// <summary>
        /// Calcul de l’erreur (distance entre un point et une observation)
        /// </summary>
        /// <param name="observation">Observation sur laquelle on calcule l’erreur</param>
        /// <returns>Erreur calculée</returns>
        public double CalculerErreur(Observation observation)
        {
            double somme = 0;
            for (int i = 0; i < poids.Count; i++)
            {
                somme = somme + Math.Pow(poids[i] - observation.Valeur(i), 2);
            }
            return Math.Sqrt(somme);
        }

        /// <summary>
        /// Modification des poids
        /// </summary>
        /// <param name="observation">Observation sur laquelle on se base pour modifier les poids</param>
        /// <param name="alpha">Coefficient d’apprentissage</param>
        public void ModifierPoids(Observation observation, double alpha)
        {
            for (int i = 0; i < poids.Count; i++)
            {
                poids[i] = poids[i] - alpha * (poids[i] - observation.Valeur(i));
            }
        }

        /// <summary>
        /// Calcul la distance entre 2 points
        /// </summary>
        /// <param name="autrePoint">Second point</param>
        /// <returns>Distance entre 2 points</returns>
        public double CalculerDistance(Point autrePoint)
        {
            double distance = 0;
            for (int i = 0; i < poids.Count; i++)
            {
                distance = distance + Math.Pow(poids[i] - autrePoint.poids[i], 2);
            }
            return Math.Sqrt(distance);
        }
    }
}
