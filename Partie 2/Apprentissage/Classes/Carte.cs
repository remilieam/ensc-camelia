using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Carte
    {
        private Point[,] tableau;
        private int nbLignes, nbColonnes;
        private List<Classe> classes;

        public List<Classe> Classes { get { return classes; } }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nbColonnes">Nombre de colonnes de la carte</param>
        /// <param name="nbPoids">Nombre de poids par point</param>
        /// <param name="nbLignes">Nombre de lignes de la table</param>
        /// <param name="valeurMax">Amplitude maximale des points</param>
        public Carte(int nbLignes, int nbColonnes, int nbPoids, int valeurMax)
        {
            this.classes = new List<Classe>();
            this.nbColonnes = nbColonnes;
            this.nbLignes = nbLignes;
            this.tableau = new Point[nbLignes, nbColonnes];

            for (int i = 0; i < nbLignes; i++)
            {
                for (int j = 0; j < nbColonnes; j++)
                {
                    tableau[i, j] = new Point(nbPoids, valeurMax);
                }
            }
        }

        /// <summary>
        /// Récupération d’un point du tableau
        /// </summary>
        /// <param name="ligne">Numéro de ligne du point à récupérer</param>
        /// <param name="colonne">Numéro de colonne du point à récupérer</param>
        /// <returns>Point à récupérer</returns>
        public Point RecupererPoint(int ligne, int colonne)
        {
            return tableau[ligne, colonne];
        }

        /// <summary>
        /// Mise en place de l’algorithme de Kohonen
        /// </summary>
        /// <param name="observations">Liste des observations</param>
        /// <param name="alpha">Coefficient d’apprentissage</param>
        public void AlgoKohonen(List<Observation> observations, double alpha)
        {
            // Distance pour laquelle on considère que 2 points sont voisins
            int distanceMax = 1;

            // Pour chaque observation
            foreach (Observation observation in observations)
            {
                double erreurMin = 1000;
                alpha = alpha - 0.00001;

                // Recherche des coordonnées du point qui a la plus faible erreur
                int ligneMieux = 0;
                int colonneMieux = 0;

                for (int i = 0; i < nbLignes; i++)
                {
                    for (int j = 0; j < nbColonnes; j++)
                    {
                        if (tableau[i, j].CalculerErreur(observation) < erreurMin)
                        {
                            ligneMieux = i;
                            colonneMieux = j;
                            erreurMin = tableau[i, j].CalculerErreur(observation);
                        }
                    }
                }

                // Mise à jour des poids des points voisins du meilleur point
                for (int i = ligneMieux - distanceMax; i <= ligneMieux + distanceMax; i++)
                {
                    for (int j = colonneMieux - distanceMax; j <= colonneMieux + distanceMax; j++)
                    {
                        if (i >= 0 && i < nbLignes && j >= 0 && j < nbColonnes)
                        {
                            tableau[i, j].ModifierPoids(observation, alpha);
                        }
                    }
                }
            }
        }

        public void Regroupement(List<Observation> observations, int nbClasses)
        {
            // Recherche des points qui ne gagnent jamais ou presque jamais
            // Pour cela, on compte le nombre de fois où le point à l’erreur minimale

            // Tableau pour compter
            int[,] comptage = new int[nbLignes, nbColonnes];

            // Initialisation à 0 pour tous les points de la carte
            for (int i = 0; i < nbLignes; i++)
            {
                for (int j = 0; j < nbColonnes; j++)
                {
                    comptage[i, j] = 0;
                }
            }

            // Pour chaque observation, on cherche quel point à l’erreur la plus faible
            foreach (Observation observation in observations)
            {
                double erreurMin = 100000;
                int ligneMieux = 0;
                int colonneMieux = 0;

                for (int i = 0; i < nbLignes; i++)
                {
                    for (int j = 0; j < nbColonnes; j++)
                    {
                        if (tableau[i, j].CalculerErreur(observation) < erreurMin)
                        {
                            ligneMieux = i;
                            colonneMieux = j;
                            erreurMin = tableau[i, j].CalculerErreur(observation);
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
                    if (comptage[i, j] > 5)
                    {
                        classes.Add(new Classe(tableau[i, j]));
                    }
                }
            }

            // Fusion des classes : le critère le plus simple est la distance interclasse
            do
            {
                Classe classeMieux1 = classes[0];
                Classe classeMieux2 = classes[1];
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
                                classeMieux1 = classe1;
                                classeMieux2 = classe2;
                            }
                        }
                    }

                }

                // Fusion des 2 classes les plus proches
                classeMieux1.FusionnerAvec(classeMieux2);
                classes.Remove(classeMieux2);
            }
            while (classes.Count > nbClasses);
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

            // On calcule la distance entre chaque point de chaque classe
            foreach (Point point1 in classe1.ListePoints)
            {
                foreach (Point point2 in classe2.ListePoints)
                {
                    if (point2.CalculerDistance(point2) < distanceMin)
                    {
                        distanceMin = point2.CalculerDistance(point2);
                    }
                }
            }

            // On renvoie la distance la plus courte
            return distanceMin;
        }
    }
}
