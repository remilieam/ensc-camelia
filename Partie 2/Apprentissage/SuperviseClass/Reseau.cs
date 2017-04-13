using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperviseClass
{
    public class Reseau
    {
        Random Alea = new Random();
        List<Neurone> ListeNeurones;    // Liste des neurones du réseau
        List<Neurone>[] TableauCouches; // tableau des couches de neurones
        double[,] MatricePoids;         // Matrice d’adjacence des poids synaptiques

        /// <summary>
        /// Constructeur du réseau
        /// </summary>
        /// <param name="NbEntrees">Nombre de neurones dans la couche d’entrée (dont le biais)</param>
        /// <param name="NbCouches">Nombre de couches du réseau (dont les couches d’entrée et de sortie</param>
        /// <param name="NeuronesParCouche">Nombre de neurones dans les couches cachées</param>
        public Reseau(int NbEntrees, int NbCouches, int NeuronesParCouche)
        {
            int NumeroNeurone = -1;
            Neurone NeuroneAjoute;

            // Nombre de neurones du réseau = NbEntrees + (NbCouches - 2) * NeuronesParCouche + 1

            // Initialisation des listes avant de poursuivre
            ListeNeurones = new List<Neurone>();
            TableauCouches = new List<Neurone>[NbCouches];
            for (int i = 0; i < NbCouches; i++)
            {
                TableauCouches[i] = new List<Neurone>();
            }

            // Construction de la couche d’entrée
            for (int i = 0; i < NbEntrees; i++)
            {
                NumeroNeurone++;
                NeuroneAjoute = new Neurone(NumeroNeurone, 0);
                ListeNeurones.Add(NeuroneAjoute);
                TableauCouches[0].Add(NeuroneAjoute);
            }

            // Construction des couches cachées
            for (int i = 1; i < NbCouches - 1; i++)
            {
                for (int j = 0; j < NeuronesParCouche; j++)
                {
                    NumeroNeurone++;
                    NeuroneAjoute = new Neurone(NumeroNeurone, i);
                    ListeNeurones.Add(NeuroneAjoute);
                    TableauCouches[i].Add(NeuroneAjoute);

                    // Connexion des neurones de la couche cachée avec la couche précédente
                    for (int k = 0; k < TableauCouches[i - 1].Count; k++)
                    {
                        TableauCouches[i - 1][k].Sorties.Add(NeuroneAjoute);
                        NeuroneAjoute.Entrees.Add(TableauCouches[i - 1][k]);
                    }
                }
            }

            // Construction de la couche de sortie (ici il n’y a qu’un seul neurone de sortie)
            NumeroNeurone++;
            NeuroneAjoute = new Neurone(NumeroNeurone, NbCouches - 1);
            ListeNeurones.Add(NeuroneAjoute);
            TableauCouches[NbCouches - 1].Add(NeuroneAjoute);

            // Connexion du neurone de sortie avec la couche précédente
            for (int k = 0; k < TableauCouches[NbCouches - 2].Count; k++)
            {
                TableauCouches[NbCouches - 2][k].Sorties.Add(NeuroneAjoute);
                NeuroneAjoute.Entrees.Add(TableauCouches[NbCouches - 2][k]);
            }

            // Initialisation de la matrice des poids synaptiques
            int NbNeurones = ListeNeurones.Count;
            MatricePoids = new double[NbNeurones, NbNeurones];
            for (int i = 0; i < NbNeurones; i++)
            {
                for (int j = 0; j < NbNeurones; j++)
                {
                    MatricePoids[i, j] = Alea.NextDouble() * 2 - 1;
                }
            }
        }

        /// <summary>
        /// Réinitialisation du réseau afin que chaque neurone ait pour valeur 0
        /// </summary>
        public void ReinitialiserActivation()
        {
            for (int i = 0; i < this.ListeNeurones.Count; i++)
            {
                Neurone NeuroneLu = ListeNeurones[i];
                NeuroneLu.ReinitialiserSortie();
            }
        }

        /// <summary>
        /// Calcul de la sortie de tous les neurones d’une couche donnée
        /// 
        /// Cette méthode est appelée par la méthode 
        /// </summary>
        /// <param name="Couche">Numéro de la couche dont on calcule les sorties</param>
        public void CalculerSortieCouche(int Couche)
        {
            // Pour chaque neurone de la couche, on calcule la somme pondérées de ses entrées
            // par les poids synaptiques, puis on utilise la fonction d’activation (sigmoïde)
            // afin de connaître la valeur du neurone de sortie
            for (int i = 0; i < TableauCouches[Couche].Count; i++)
            {
                Neurone NeuroneLu = TableauCouches[Couche][i];
                NeuroneLu.CalculerSortie(MatricePoids);
            }
        }

        /// <summary>
        /// Affichage d’un neurone (sous forme de listes d’informations)
        /// </summary>
        /// <param name="Couche">Numéro de la couche sur laquelle se trouve le neurone</param>
        /// <param name="Numero">Numéro du neurone</param>
        /// <param name="Liste">Liste qui contiendra les informations</param>
        public void AfficheInfoNeurone(int Couche, int Numero, List<string> Liste)
        {
            // Récupération du neurone dont on veut connaître les caractéristiques
            Neurone Neurone = TableauCouches[Couche][Numero];

            // Ajout des informations à la liste
            Liste.Add("Neurone " + Convert.ToString(Neurone.Numero));
            Liste.Add("Somme :" + Convert.ToString(Neurone.Somme));
            Liste.Add("Sortie :" + Convert.ToString(Neurone.Sortie));

            // Neurones de la couche précédente
            Liste.Add(Convert.ToString(Neurone.Entrees.Count) + " entrées : ");
            for (int i = 0; i < Neurone.Entrees.Count; i++)
            {
                Neurone NeuronePrecedent = Neurone.Entrees[i];
                Liste.Add("Numéro : " + Convert.ToString(NeuronePrecedent.Numero)
                    + " Poids : " + Convert.ToString(MatricePoids[NeuronePrecedent.Numero, Neurone.Numero]));
            }

            // Neurones de la couche suivante
            Liste.Add(Convert.ToString(Neurone.Sorties.Count) + " sorties : ");
            for (int i = 0; i < Neurone.Sorties.Count; i++)
            {
                Neurone NeuroneSuivant = Neurone.Sorties[i];
                Liste.Add("Numéro : " + Convert.ToString(NeuroneSuivant.Numero)
                    + " Poids : " + Convert.ToString(MatricePoids[Neurone.Numero, NeuroneSuivant.Numero]));
            }
        }

        /// <summary>
        /// Récupération du dernier delta calculé
        /// </summary>
        /// <param name="Neurone">Neurone dont on veut le delta</param>
        /// <returns>Dernier delta calculé</returns>
        private double RecuperDelta(Neurone Neurone)
        {
            double Somme = 0;

            // Somme pondérée des deltas par les poids synaptiques
            for (int i = 0; i < Neurone.Sorties.Count; i++)
            {
                Neurone NeuroneSuivant = Neurone.Sorties[i];
                Somme += MatricePoids[Neurone.Numero, NeuroneSuivant.Numero]
                                * NeuroneSuivant.Delta;
            }
            return Somme;
        }

        /// <summary>
        /// Calcul des poids synaptiques à adopter de façon à obtenir les valeurs de sortie
        /// souhaitées
        /// </summary>
        /// <param name="Entrees">Vecteur contenant les valeurs des neurones d’entrée</param>
        /// <param name="Sorties">Vecteur contenant les valeurs des neurones de sortie</param>
        /// <param name="Alpha">Coefficient d’apprentissage</param>
        /// <param name="Interations">Nombre d’itérations pour l’apprentissage</param>
        public void Retropropagation(List<List<double>> Entrees, List<double> Sorties, double Alpha, int Interations)
        {
            double Sortie;
            Neurone Neurone, NeuroneSuivant;
            int NbCouches = TableauCouches.Length;

            // Pour chaque apprentissage
            for (int Iteration = 0; Iteration < Interations; Iteration++)
            {
                // Pour chaque échantillon
                for (int Echantillon = 0; Echantillon < Entrees.Count; Echantillon++)
                {
                    // Définition des entrées
                    for (int i = 0; i < Entrees[0].Count; i++)
                    {
                        TableauCouches[0][i].ImposerSortie(Entrees[Echantillon][i]);
                    }

                    // Ajout du biais
                    Neurone = TableauCouches[0][Entrees[0].Count];
                    Neurone.ImposerSortie(1);

                    // Définition de la sortie souhaitée
                    Sortie = Sorties[Echantillon];

                    // Calcul de la sortie véritable de chaque neurone, couche par couche
                    for (int Couche = 1; Couche < NbCouches; Couche++)
                    {
                        CalculerSortieCouche(Couche);
                    }

                    // Calcul du gradient pour le(s) neurone(s) de la couche de sortie
                    for (int i = 0; i < TableauCouches[NbCouches - 1].Count; i++)
                    {
                        Neurone = TableauCouches[NbCouches - 1][i];
                        Neurone.ActualiserDelta(Neurone.gprime(Neurone.Somme) * (Sortie - Neurone.Sortie));
                    }

                    // Calcul du gradient pour les neurones des couches cachées
                    for (int Couche = NbCouches - 2; Couche > -1; Couche--)
                    {
                        // Pour chaque neurone de cette couche, on met à jour les poids
                        for (int NumeroNeurone = 0; NumeroNeurone < TableauCouches[Couche].Count; NumeroNeurone++)
                        {
                            Neurone = TableauCouches[Couche][NumeroNeurone];
                            Neurone.ActualiserDelta(Neurone.gprime(Neurone.Somme) * RecuperDelta(Neurone));

                            // Mise à jour des poids entre les neurones de la couche et ceux de la couche suivante
                            for (int i = 0; i < TableauCouches[Couche + 1].Count; i++)
                            {
                                NeuroneSuivant = TableauCouches[Couche + 1][i];
                                MatricePoids[Neurone.Numero, NeuroneSuivant.Numero] +=
                                    Alpha * Neurone.Sortie * NeuroneSuivant.Delta;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calcul à partir des entrées fournies les sorties prédites par le réseau
        /// </summary>
        /// <param name="Entrees">Liste contenant les entrées du reseau</param>
        /// <returns>Listes des sorties prédites par le réseau</returns>
        public List<double> TesterReseau(List<List<double>> Entrees)
        {
            List<double> Sorties = new List<double>();

            for (int Echantillon = 0; Echantillon < Entrees.Count; Echantillon++)
            {
                // Définition des entrées
                for (int i = 0; i < Entrees[0].Count; i++)
                {
                    TableauCouches[0][i].ImposerSortie(Entrees[Echantillon][i]);
                }

                // Définition du biais
                Neurone Biais = TableauCouches[0][Entrees[0].Count];
                Biais.ImposerSortie(1);

                // Calcul de la sortie de chaque neurone avec le réseau actuel
                for (int i = 1; i < TableauCouches.Length; i++)
                {
                    CalculerSortieCouche(i);
                }

                // Récupération de la valeur du neurone de sortie
                Neurone Sortie = TableauCouches[TableauCouches.Length - 1][0];

                // Ajout du neurone de sortie à la liste des neurones de sortie
                Sorties.Add(Sortie.Sortie);
            }

            return Sorties;
        }
    }
}
