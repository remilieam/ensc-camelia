using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NonSuperviseClass
{
    public class Neurone
    {
        // Comme une observation a 2 composantes, chaque neurone
        // a 2 poids
        private List<double> poids;
        private static Random alea = new Random();

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nbPoids">Nombre de poids du neurone</param>
        /// <param name="valeurMax">Amplitude maximale des poids du neurone</param>
        public Neurone(int nbPoids, int valeurMax)
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
        /// Modification des poids
        /// </summary>
        /// <param name="ligne">Poids de la ligne</param>
        /// <param name="colonne">Poids de la colonne</param>
        public void ModifierPoids(int ligne, int colonne)
        {
            poids[0] = ligne;
            poids[1] = colonne;
        }

        /// <summary>
        /// Récupération du i° poids
        /// </summary>
        /// <param name="i">0 pour le poids lié à la ligne et 1 pour celui lié à la colonne</param>
        /// <returns>Poids associé au numéro passé en argument</returns>
        public double RecupererPoids(int i)
        {
            return poids[i];
        }

        /// <summary>
        /// Calcul de l’erreur (distance entre un neurone et une observation)
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
        /// Calcul la distance entre 2 neurones
        /// </summary>
        /// <param name="autreNeurone">Second neurone</param>
        /// <returns>Distance entre les 2 neurones</returns>
        public double CalculerDistance(Neurone autreNeurone)
        {
            double distance = 0;
            for (int i = 0; i < poids.Count; i++)
            {
                distance = distance + Math.Pow(poids[i] - autreNeurone.poids[i], 2);
            }
            return Math.Sqrt(distance);
        }
    }
}
