using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NonSuperviseClass
{
    public class Classe
    {
        // Liste des neurones appartenant à la classe
        private List<Neurone> listeNeurones = new List<Neurone>();
        public List<Neurone> ListeNeurones { get { return listeNeurones; } }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="neurone">Neurone initial de la classe</param>
        public Classe(Neurone neurone)
        {
            listeNeurones.Add(neurone);
        }

        /// <summary>
        /// Fusion d’une classe avec une autre
        /// </summary>
        /// <param name="autreClasse">Classe qui fusionne avec notre classe actuelle</param>
        public void FusionnerAvec(Classe autreClasse)
        {
            foreach (Neurone neurone in autreClasse.listeNeurones)
            {
                listeNeurones.Add(neurone);
            }
        }
    }
}
