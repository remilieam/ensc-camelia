using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NonSuperviseClass
{
    public class Carte
    {
        private Neurone[,] carte;
        private int nbLignes, nbColonnes;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nbLignes">Nombre de lignes de la table</param>
        /// <param name="nbColonnes">Nombre de colonnes de la carte</param>
        /// <param name="nbPoids">Nombre de poids par neurone</param>
        /// <param name="valeurMax">Amplitude maximale des poids des neurones</param>
        public Carte(int nbLignes, int nbColonnes, int nbPoids, int valeurMax)
        {
            this.nbColonnes = nbColonnes;
            this.nbLignes = nbLignes;
            this.carte = new Neurone[nbLignes, nbColonnes];

            for (int i = 0; i < nbLignes; i++)
            {
                for (int j = 0; j < nbColonnes; j++)
                {
                    carte[i, j] = new Neurone(nbPoids, valeurMax);
                }
            }
        }

        /// <summary>
        /// Récupération d’un neurone du tableau
        /// </summary>
        /// <param name="ligne">Numéro de ligne du neurone à récupérer</param>
        /// <param name="colonne">Numéro de colonne du neurone à récupérer</param>
        /// <returns>Neurone à récupérer</returns>
        public Neurone RecupererNeurone(int ligne, int colonne)
        {
            return carte[ligne, colonne];
        }

        /// <summary>
        /// Mise en place de l’algorithme de Kohonen
        /// </summary>
        /// <param name="observations">Liste des observations</param>
        /// <param name="alpha">Coefficient d’apprentissage</param>
        public void AlgoKohonen(List<Observation> observations, double alpha, int distance)
        {
            // Distance pour laquelle on considère que 2 neurones sont voisins
            int distanceMax = distance;

            // Pour chaque observation
            foreach (Observation observation in observations)
            {
                double erreurMin = 1000;
                alpha = alpha - 0.00001;

                // Recherche des coordonnées du neurone qui a la plus faible erreur
                int ligneMieux = 0;
                int colonneMieux = 0;

                for (int i = 0; i < nbLignes; i++)
                {
                    for (int j = 0; j < nbColonnes; j++)
                    {
                        if (carte[i, j].CalculerErreur(observation) < erreurMin)
                        {
                            ligneMieux = i;
                            colonneMieux = j;
                            erreurMin = carte[i, j].CalculerErreur(observation);
                        }
                    }
                }

                // Mise à jour des poids des neurones voisins du meilleur neurone
                for (int i = ligneMieux - distanceMax; i <= ligneMieux + distanceMax; i++)
                {
                    for (int j = colonneMieux - distanceMax; j <= colonneMieux + distanceMax; j++)
                    {
                        if (i >= 0 && i < nbLignes && j >= 0 && j < nbColonnes)
                        {
                            carte[i, j].ModifierPoids(observation, alpha);
                        }
                    }
                }
            }
        }

        public List<Classe> Regroupement(List<Observation> observations, int nbClasses)
        {
            // Recherche des neurones qui ne gagnent jamais ou presque jamais
            // Pour cela, on compte le nombre de fois où le neurone à l’erreur minimale
            List<Classe> classes = new List<Classe>();

            // Tableau pour compter
            int[,] comptage = new int[nbLignes, nbColonnes];

            // Initialisation à 0 pour tous les neurones de la carte
            for (int i = 0; i < nbLignes; i++)
            {
                for (int j = 0; j < nbColonnes; j++)
                {
                    comptage[i, j] = 0;
                }
            }

            // Pour chaque observation, on cherche quel neurone à l’erreur la plus faible
            foreach (Observation observation in observations)
            {
                double erreurMin = 100000;
                int ligneMieux = 0;
                int colonneMieux = 0;

                for (int i = 0; i < nbLignes; i++)
                {
                    for (int j = 0; j < nbColonnes; j++)
                    {
                        if (carte[i, j].CalculerErreur(observation) < erreurMin)
                        {
                            ligneMieux = i;
                            colonneMieux = j;
                            erreurMin = carte[i, j].CalculerErreur(observation);
                        }
                    }
                }

                comptage[ligneMieux, colonneMieux]++;
            }

            // Initialisation des classes (en prenant les meilleures)
            for (int i = 0; i < nbLignes; i++)
            {
                for (int j = 0; j < nbColonnes; j++)
                {
                    if (comptage[i, j] > 10)
                    {
                        classes.Add(new Classe(carte[i, j]));
                    }
                }
            }

            // Fusion des classes : le critère le plus simple est la distance interclasse
            do
            {
                Classe classeFusionnee1 = classes[0];
                Classe classeFusionnee2 = classes[1];
                double distanceMin = 1000000;

                foreach (Classe classe1 in classes)
                {
                    foreach (Classe classe2 in classes)
                    {
                        if (classe1 != classe2)
                        {
                            if (CalculerDistanceClasses(classe1, classe2) < distanceMin)
                            {
                                distanceMin = CalculerDistanceClasses(classe1, classe2);
                                classeFusionnee1 = classe1;
                                classeFusionnee2 = classe2;
                            }
                        }
                    }
                }

                // Fusion des 2 classes les plus proches
                classeFusionnee1.FusionnerAvec(classeFusionnee2);
                classes.Remove(classeFusionnee2);
            }
            while (classes.Count > nbClasses);

            return classes;
        }

        /// <summary>
        /// Calcul de la distance entre 2 classes
        /// </summary>
        /// <param name="classe1">Classe 1</param>
        /// <param name="classe2">Classe 2</param>
        /// <returns>Distance entre les classes 1 et 2</returns>
        private double CalculerDistanceClasses(Classe classe1, Classe classe2)
        {
            double distanceMin = 1000;

            // On calcule la distance entre chaque neurone de chaque classe
            foreach (Neurone neurone1 in classe1.ListeNeurones)
            {
                foreach (Neurone neurone2 in classe2.ListeNeurones)
                {
                    if (neurone1.CalculerDistance(neurone2) < distanceMin)
                    {
                        distanceMin = neurone1.CalculerDistance(neurone2);
                    }
                }
            }

            // On renvoie la distance la plus courte
            return distanceMin;
        }
    }
}
