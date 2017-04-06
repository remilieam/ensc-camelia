using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Point
    {
        // Un point est connecté à d’autres points
        // Entre chacun de ses points, il y a un certain poids
        private List<double> poids;
        private Random alea = new Random();

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
        /// <param name="i">Numéro du poids</param>
        /// <returns>Poids associé au numéro passé en argument</returns>
        public double RecupererUnPoids(int i)
        {
            return poids[i];
        }

        /// <summary>
        /// Calcul de l’erreur
        /// </summary>
        /// <param name="obs">Observation sur laquelle on calcule l’erreur</param>
        /// <returns>Erreur calculée</returns>
        public double CalculerErreur(Observation obs)
        {
            double somme = 0;
            for (int i = 0; i < poids.Count; i++)
            {
                somme = somme + Math.Pow(poids[i] - obs.Valeur(i), 2);
            }
            return Math.Sqrt(somme);
        }

        /// <summary>
        /// Modification des poids
        /// </summary>
        /// <param name="obs">Observation sur laquelle on se base pour modifier les poids</param>
        /// <param name="alpha">Coefficient d’apprentissage</param>
        public void ModifierPoids(Observation obs, double alpha)
        {
            for (int i = 0; i < poids.Count; i++)
            {
                poids[i] = poids[i] - alpha * (poids[i] - obs.Valeur(i));
            }
        }

        /// <summary>
        /// Calcul la distance entre 2 points
        /// </summary>
        /// <param name="autrePoint">Second point</param>
        /// <returns>Distance entre 2 points</returns>
        public double CalculerDistance(Point autrePoint)
        {
            double dist = 0;
            for (int i = 0; i < poids.Count; i++)
            {
                dist = dist + Math.Pow(poids[i] - autrePoint.poids[i], 2);
            }
            return Math.Sqrt(dist);
        }
    }
}
