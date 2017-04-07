using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1C
{
    class Neurone
    {

        public double[] entrees;
        public double sortie;
        public int nombreiteration;
        public double somme;
        public double[] w=new double[3];
        public int nombreerreur;
        public Random rnd= new Random();



        public Neurone()
        {
            entrees = new double[3];
            nombreiteration = 1;
            nombreerreur = 0;
            

            // Génération des wi de manière aléatoire
            w[0] = rnd.Next(1, 5);
            w[1] = rnd.Next(1, 5);
            w[2] = rnd.Next(1, 5);


        }



        public double GetSortie()
        {
            return sortie;
        }

        public double GetNbIteration()
        {
            return nombreiteration;
        }

        public void SetNbIteration(int nb)
        {
            nombreiteration = nb;
        }

        public double GetNbErreur()
        {
            return nombreerreur;
        }

        public void SetNbErreur(int nb)
        {
            nombreerreur = nb;
        }


       
        /// <summary>
        /// Méthode qui calcule une première fois w1*E1+w2*E2+w3*E3
        /// </summary>
        public void CalculeSortie()
        {
            int i;
            somme = 0;
           



            for (i = 0; i < 3; i++)
            {
                double entree = entrees[i];

                somme = somme + w[i] * entrees[i];
            }
            sortie = g(somme);
            
        }






        /// <summary>
        /// Méthode qui recalcule la sortie si elle est différente de celle attendue 
        /// </summary>
        /// <param name="sortiecorrecte"></param>
        /// <returns name="nombreerreur"></returns>
        public int RecalculeSortie(int sortiecorrecte)
        {
            if (sortiecorrecte == 0 &&sortie==1)
            {

                
                    for (int i = 0; i < 3; i++)
                    {
                        w[i] = w[i]-entrees[i];
                    }
                    nombreerreur += 1;
                }

            
           if (sortiecorrecte==1&&sortie==0)
            {
               
                    for (int i = 0; i < 3; i++)
                    {
                        w[i] = w[i] + entrees[i];
                    }
                
                    nombreerreur+= 1;



                }
            return nombreerreur;
        }




        
        /// <summary>
        /// Déduit la sortie en fonction de la position de la somme par rapport au seuil
        /// </summary>
        /// <param name="s">somme calculée par CalculeSortie()</param>
        /// <returns></returns>
        public double g(double s)
        {
            int seuil = 1;
            if (s > seuil)
            {
                sortie = 1;
            }
            else
            {
                sortie = 0;

               
            }
            return sortie;
        }
    }
}



     
    

