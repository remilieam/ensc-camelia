using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CameliaClass;

namespace CameliaApp
{
    public partial class Chemin_Form : Form
    {
        private Chariot arrivee;
        private int[,] entrepot;
        private int type = 0;
        public bool fini = false;

        // Assesseurs
        public Chariot Arrivee { get { return arrivee; } }
        public int Type { get { return type; } }

        /// <summary>
        /// Permet de créer le formulaire initial
        /// </summary>
        public Chemin_Form(int[,] entrepot)
        {
            InitializeComponent();
            this.entrepot = entrepot;
        }

        /// <summary>
        /// Permet de revenir sur le formulaire de l’entrepôt après fermeture avec
        /// la croix rouge en haut à droite
        /// </summary>
        private void Chemin_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Valider_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int objet_x = Convert.ToInt32(objet_x_textbox.Text) - 1;
                int objet_y = Convert.ToInt32(objet_y_textbox.Text) - 1;
                string objet_k = objet_k_listbox.SelectedItem.ToString();
                int objet_z = Convert.ToInt32(objet_z_textbox.Text);

                if (distance_radiobutton.Checked)
                {
                    type = 1;
                }

                else if (temps_radiobutton.Checked)
                {
                    type = 2;
                }

                else if (realite_radiobutton.Checked)
                {
                    type = 3;
                }

                try
                {
                    if (entrepot[objet_x, objet_y] != -1)
                    {
                        string message = "Il ne peut pas y avoir d’objet à cet endroit.";
                        throw new Exception(message);
                    }

                    if (!distance_radiobutton.Checked && !temps_radiobutton.Checked)
                    {
                        string message = "Sélectionner “Distance” ou “Temps”.";
                        throw new Exception(message);
                    }
                }

                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception("Veuillez entrer de nouvelles coordonnées pour l’objet.");
                }

                List<int> destination = Trouver_Destination(objet_x, objet_y, objet_k);
                arrivee = new Chariot(destination[1], destination[2], destination[0]);

                this.DialogResult = DialogResult.OK;
                this.fini = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Permet de calculer la destination du chariot à partir des coordonnées
        /// de l’objet à récupérer
        /// </summary>
        /// <param name="x">Numéro de ligne de l’objet</param>
        /// <param name="y">Numéro de colonne de l’objet</param>
        /// <param name="k">Orientation de l’objet</param>
        /// <returns></returns>
        private List<int> Trouver_Destination(int x, int y, string k)
        {
            List<int> arrivee = new List<int>();

            if (k == "Nord")
            {
                arrivee.Add(2);
                arrivee.Add(x - 1);
            }

            else if (k == "Sud")
            {
                arrivee.Add(0);
                arrivee.Add(x + 1);
            }

            arrivee.Add(y);

            return arrivee;
        }
    }
}
