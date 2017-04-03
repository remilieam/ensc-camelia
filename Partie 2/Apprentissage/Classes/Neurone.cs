using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Neurone
    {
        public int Numero { get; private set; }
        public List<Neurone> Entrees;
        public List<Neurone> Sorties;
        public int NumeroCouche { get; private set; }
        public double Sortie { get; private set; }
        public double Somme { get; private set; }
        public double Delta { get; private set; }

        /// <summary>
        /// Constructeur d’un neurone
        /// </summary>
        /// <param name="Num">Numéro du neurone dans le réseau</param>
        /// <param name="NumCouche">Numéro de la couche à laquelle appartient le neurone</param>
        public Neurone(int Num, int NumCouche)
        {
            Numero = Num;
            NumeroCouche = NumCouche;
            Sortie = 0;
            Somme = 0;
            Entrees = new List<Neurone>();
            Sorties = new List<Neurone>();
        }

        /// <summary>
        /// Fonction d’activation du neurone
        /// </summary>
        /// <param name="S">Somme pondérée des neurones de la couche précédente</param>
        /// <returns>Valeur du neurone entre 0 et 1</returns>
        public double g(double S)
        {
            // Fonction sigmoïde
            return 1 / (1 + Math.Exp(-S));
        }

        /// <summary>
        /// Fonction dérivée du neurone
        /// </summary>
        /// <param name="S">Somme pondérée des neurones de la couche précédente</param>
        /// <returns>Valeur du neurone entre 0 et 1</returns>
        public double gprime(double S)
        {
            // Dérivée de la sigmoïde, on en a bseoin dans backprop
            return Math.Exp(-S) / Math.Pow(1 + Math.Exp(-S), 2);
        }

        /// <summary>
        /// Mise à zéro de la sortie du neurone
        /// </summary>
        public void ReinitialiserSortie()
        {
            Sortie = 0;
        }

        /// <summary>
        /// Calcule de la sortie, c’est-à-dire la somme pondérée des neurones de la 
        /// couche précédente
        /// </summary>
        /// <param name="MatricePoids">Matrice des poids entre les 2 couches</param>
        public void CalculerSortie(double[,] MatricePoids)
        {
            double Poids;
            Neurone NeuronePrecedent;

            Somme = 0;

            for (int i = 0; i < Entrees.Count; i++)
            {
                NeuronePrecedent = Entrees[i];
                Poids = MatricePoids[NeuronePrecedent.Numero, Numero];
                Somme += Poids * NeuronePrecedent.Sortie;
            }

            Sortie = g(Somme);
        }

        /// <summary>
        /// Actualisation du delta
        /// </summary>
        /// <param name="D">Nouvelle valeur pour delta</param>
        public void ActualiserDelta(double D)
        {
            Delta = D;
        }

        /// <summary>
        /// Imposition de la valeur à la sortie d’un neurone
        /// </summary>
        /// <param name="S">Valeur de sortie imposée</param>
        public void ImposerSortie(double S)
        {
            Sortie = S;
        }
    }
}
