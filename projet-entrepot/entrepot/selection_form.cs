using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace entrepot
{
    public partial class selection_form : Form
    {
        public int chariot_x;
        public int chariot_y;
        public int chariot_x_final;
        public int chariot_y_final;
        public int chariot_k_final;
        int objet_x;
        int objet_y;
        string objet_k;
        int objet_z;
        int[,] entrepot;

        public selection_form(int[,] entrepot)
        {
            InitializeComponent();
            this.entrepot = entrepot;
        }

        private void valider_button_Click(object sender, EventArgs e)
        {
            try
            {
                chariot_x = Convert.ToInt32(chariot_x_textbox.Text) - 1;
                chariot_y = Convert.ToInt32(chariot_y_textbox.Text) - 1;

                try
                {
                    if (entrepot[chariot_x, chariot_y] != -2)
                    {
                        string message = "Il n’y a pas de chariot à cet endroit.";
                        throw new Exception(message);
                    }
                }

                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception("Veuillez entrer de nouvelles coordonnées pour le chariot.");
                }

                objet_x = Convert.ToInt32(objet_x_textbox.Text) - 1;
                objet_y = Convert.ToInt32(objet_y_textbox.Text) - 1;
                objet_k = objet_k_listbox.SelectedItem.ToString();
                objet_z = Convert.ToInt32(objet_z_textbox.Text);

                try
                {
                    if (entrepot[objet_x, objet_y] != -1)
                    {
                        string message = "Il ne peut pas y avoir d’objet à cet endroit.";
                        throw new Exception(message);
                    }
                }

                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception("Veuillez entrer de nouvelles coordonnées pour l’objet.");
                }

                List<int> destination = trouver_destination(objet_x, objet_y, objet_k);
                chariot_k_final = destination[0];
                chariot_x_final = destination[1];
                chariot_y_final = destination[2];

                this.DialogResult = DialogResult.OK;
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
        private List<int> trouver_destination(int x, int y, string k)
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

        private void selection_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
