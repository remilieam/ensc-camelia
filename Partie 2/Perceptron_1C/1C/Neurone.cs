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
        public double[] w = { 1, 2, 3 };

        public Neurone()
        {
            entrees = new double[3];
            nombreiteration = 1;
            //sorties = new Neurone();
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



        public int RecalculeSortie(int sortiecorrecte)
        {
            if (sortiecorrecte == 0)
            {

                while (sortie == 1)
                {

                    for (int i = 0; i < 3; i++)
                    {
                        w[i] = w[i]-entrees[i];
                        CalculeSortie();
                    }
                    nombreiteration += 1;
                }

            }
            else
            {
                while (sortie == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        w[i] = w[i] + entrees[i];
                        CalculeSortie();
                    }
                }
                    nombreiteration += 1;



                } 
            return nombreiteration;
        }





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



     
    

