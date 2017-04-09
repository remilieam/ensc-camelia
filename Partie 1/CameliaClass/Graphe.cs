using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameliaClass
{
    public class Graphe
    {
        public List<Noeud> noeudsOuverts;
        public List<Noeud> noeudsFermes;

        /// <summary>
        /// Permet de compter le nombre de nœuds ouverts
        /// </summary>
        /// <returns>Le nombre de nœuds ouverts</returns>
        public int compterOuverts()
        {
            return noeudsOuverts.Count;
        }

        /// <summary>
        /// Permet de compter le nombre de nœuds fermés
        /// </summary>
        /// <returns>Le nombre de nœuds fermés</returns>
        public int compterFermes()
        {
            return noeudsFermes.Count;
        }

        /// <summary>
        /// Permet de savoir si un nœud est parmi les nœuds fermés
        /// </summary>
        /// <param name="noeudEvalue">Nœud à rechercher parmi les nœuds fermés</param>
        /// <returns>Nœud s’il est dans les nœuds fermés</returns>
        private Noeud ChercherNoeudDansFermes(Noeud noeudEvalue)
        {
            int i = 0;
            while (i < noeudsFermes.Count)
            {
                if (noeudsFermes[i].EstEgal(noeudEvalue))
                    return noeudsFermes[i];
                i++;
            }
            return null;
        }

        /// <summary>
        /// Permet de savoir si un nœud est parmi les nœuds ouverts
        /// </summary>
        /// <param name="noeudEvalue">Nœud à rechercher parmi les nœuds ouverts</param>
        /// <returns>Nœud s’il est dans les nœuds ouverts</returns>
        private Noeud ChercherNoeudDansOuverts(Noeud noeudEvalue)
        {
            int i = 0;
            while (i < noeudsOuverts.Count)
            {
                if (noeudsOuverts[i].EstEgal(noeudEvalue))
                    return noeudsOuverts[i];
                i++;
            }
            return null;
        }

        /// <summary>
        /// Permet de rechercher le plus court chemin
        /// </summary>
        /// <param name="noeudInitial">Nœud de départ</param>
        /// <param name="xFinal">Ligne du nœud d’arrivée</param>
        /// <param name="yFinal">Colonne du nœud d’arrivée</param>
        /// <returns>Liste des nœuds pour aller du départ à l’arrivée</returns>
        public List<Noeud> RechercherSolutionAEtoile(Noeud noeudInitial)
        {
            noeudsOuverts = new List<Noeud>();
            noeudsFermes = new List<Noeud>();

            Noeud noeud = noeudInitial;

            // On ajoute le nœud de départ aux ouverts
            noeudsOuverts.Add(noeudInitial);

            // Tant que le nœud n’est pas terminal
            // et que la liste des ouverts n’est pas vide
            while (noeudsOuverts.Count != 0 && noeud.VerifierFin() == false)
            {
                // Le meilleur nœud des ouverts est supposé placé
                // en tête de liste des fermés
                noeudsOuverts.Remove(noeud);
                noeudsFermes.Add(noeud);

                // Il faut trouver les nœuds successeurs de N
                this.MettreAJourSuccesseurs(noeud);
                // Inutile de retrier car les insertions ont été faites en respectant l’ordre

                // On prend le meilleur, donc celui en position 0, pour continuer
                // à explorer les états, à condition qu’il existe bien sûr
                if (noeudsOuverts.Count > 0)
                {
                    noeud = noeudsOuverts[0];
                }

                else
                {
                    noeud = null;
                }
            }

            // A* terminé
            // On retourne le chemin qui va du nœud initial au nœud final sous forme de liste
            // Le chemin est retrouvé en partant du nœud final et en accédant aux parents de manière
            // itérative jusqu’à ce qu’on tombe sur le nœud initial
            List<Noeud> _LN = new List<Noeud>();
            if (noeud != null)
            {
                _LN.Add(noeud);

                while (noeud != noeudInitial)
                {
                    noeud = noeud.Parent();
                    _LN.Insert(0, noeud);  // On insère en position 1
                }
            }

            return _LN;
        }

        /// <summary>
        /// Permet de trouver les successeurs du dernier nœud fermé
        /// </summary>
        /// <param name="N">Nœud dont on cherche les successeurs</param>
        private void MettreAJourSuccesseurs(Noeud N)
        {
            // On fait appel à GetListSucc, méthode abstraite qu’on doit réécrire pour chaque
            // problème. Elle doit retourner la liste complète des nœuds successeurs de N.
            List<Noeud> listSucc = N.ObtenirSuccesseurs();

            // Pour chaque nœud de la liste des successeurs
            foreach (Noeud noeudEvalue in listSucc)
            {
                // On vérifie s’il n’est pas une copie d’un nœud déjà vu
                // et placé dans la liste des fermés
                Noeud noeudTrouve = ChercherNoeudDansFermes(noeudEvalue);

                if (noeudTrouve == null)
                {
                    // Si ce n’est pas le cas, on vérifie également s’il n’est pas
                    // une copie d’un nœud déjà vu et placé dans la liste des fermés
                    noeudTrouve = ChercherNoeudDansOuverts(noeudEvalue);

                    if (noeudTrouve != null)
                    {
                        // Il existe, donc on l’a déjà vu.
                        // Le nouveau chemin passant par N est-il meilleur ?
                        if (N.GCout + N.ObtenirCout(noeudEvalue) < noeudTrouve.GCout)
                        {
                            // Mise à jour du nœud trouvé
                            noeudTrouve.GCout = N.GCout + N.ObtenirCout(noeudEvalue);

                            // HCost pas recalculé car toujours bon
                            noeudTrouve.CalculerCoutTotal(); // somme de GCost et HCost

                            // Mise à jour de la famille...
                            noeudTrouve.SupprimerLiensParent();
                            noeudTrouve.Parent(N);

                            // Mise à jour des ouverts
                            noeudsOuverts.Remove(noeudTrouve);
                            this.InsererNoeudDansOuverts(noeudTrouve);
                        }

                        // else on ne fait rien, car le nouveau chemin est moins bon
                    }

                    else
                    {
                        // Le nœud est nouveau. Il faut donc le mettre à jour
                        // et l’insérer dans la liste des ouverts
                        noeudEvalue.GCout = N.GCout + N.ObtenirCout(noeudEvalue);
                        noeudEvalue.CalculerHCout();
                        noeudEvalue.Parent(N);
                        noeudEvalue.CalculerCoutTotal(); // somme de GCost et HCost
                        this.InsererNoeudDansOuverts(noeudEvalue);
                    }
                }

                // else il est dans les fermés donc on ne fait rien,
                // car on a déjà trouvé le plus court chemin pour aller vers le nœud évalué
            }
        }

        public void InsererNoeudDansOuverts(Noeud nouveauNoeud)
        {
            // Insertion pour respecter l’ordre du coût total le plus petit au plus grand
            if (this.noeudsOuverts.Count == 0)
            {
                noeudsOuverts.Add(nouveauNoeud);
            }

            else
            {
                Noeud N = noeudsOuverts[0];
                bool trouve = false;
                int i = 0;
                do
                {
                    if (nouveauNoeud.TotalCout < N.TotalCout)
                    {
                        noeudsOuverts.Insert(i, nouveauNoeud);
                        trouve = true;
                    }
                    else
                    {
                        i++;
                        if (noeudsOuverts.Count == i)
                        {
                            N = null;
                            noeudsOuverts.Insert(i, nouveauNoeud);
                        }
                        else
                        {
                            N = noeudsOuverts[i];
                        }
                    }
                }
                while ((N != null) && (trouve == false));
            }
        }
    }
}
