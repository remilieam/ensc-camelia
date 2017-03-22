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
    public partial class chariots_form : Form
    {
        // Listes recensant les chariots
        List<Label> chariots_label = new List<Label>();
        List<TextBox> champ_chariots_x = new List<TextBox>();
        List<TextBox> champ_chariots_y = new List<TextBox>();
        public List<int> chariots_x = new List<int>();
        public List<int> chariots_y = new List<int>();

        // Nombre de chariots
        int nbc = 0;

        /// <summary>
        /// Permet de créer le formulaire initial
        /// </summary>
        public chariots_form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Permet de revenir sur le formulaire de l’entrepôt après fermeture avec
        /// la croix rouge en haut à droite
        /// </summary>
        private void chariots_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Permet de récupérer le nombre de chariots afin d’afficher le formulaire
        /// pour entrer les coordonnées de chariots (d’abord le numéro de ligne, puis
        /// le numéro de colonnes)
        /// </summary>
        private void nbc_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupération du nombre de chariots à ajouter
                nbc = Convert.ToInt32(nbc_textbox.Text);

                // Masquage des anciens éléments
                nbc_textbox.Hide();
                nbc_button.Hide();

                // Changement du texte dans le label
                nbc_label.Text = "Entrez les coordonnées des chariots (ligne, colonne) :";

                // Pour chaque chariots
                for (int i = 0; i < nbc; i++)
                {
                    // Affichage du numéro du chariot
                    chariots_label.Add(new Label());
                    chariots_label[i].Text = "Chariot " + (i + 1) + " :";
                    chariots_label[i].Top = (i * 30) + 40;
                    chariots_label[i].Left = 10;
                    chariots_label[i].Width = 60;
                    chariots_label[i].Height = 20;
                    chariots_label[i].TextAlign = ContentAlignment.MiddleLeft;
                    this.Controls.Add(chariots_label[i]);

                    // Affichage du champ pour la coordonnée en x
                    champ_chariots_x.Add(new TextBox());
                    champ_chariots_x[i].Top = (i * 30) + 40;
                    champ_chariots_x[i].Left = 120;
                    champ_chariots_x[i].Width = 60;
                    champ_chariots_x[i].Height = 20;
                    this.Controls.Add(champ_chariots_x[i]);

                    // Affichage du champ pour la coordonnée en y
                    champ_chariots_y.Add(new TextBox());
                    champ_chariots_y[i].Top = (i * 30) + 40;
                    champ_chariots_y[i].Left = 230;
                    champ_chariots_y[i].Width = 60;
                    champ_chariots_y[i].Height = 20;
                    this.Controls.Add(champ_chariots_y[i]);
                }

                // Affichage du bouton de validation
                chariots_button.Show();
                chariots_button.Location = new Point(110, 30 * (nbc + 1) + 10);

                // Changement de taille du formulaire
                this.ClientSize = new Size(300, 30 * (nbc + 2) + 20);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Permet de récupérer les coordonnées des chariots et de revenir
        /// sur le formulaire de l’entrepôt
        /// </summary>
        private void chariots_button_Click(object sender, EventArgs e)
        {
            try
            {
                // On récupère les coordonnées de chaque chariot
                for (int i = 0; i < nbc; i++)
                {
                    chariots_x.Add(0);
                    chariots_y.Add(0);
                    chariots_x[i] = Convert.ToInt32(champ_chariots_x[i].Text) - 1;
                    chariots_y[i] = Convert.ToInt32(champ_chariots_y[i].Text) - 1;

                    try
                    {
                        if (!verifierChariot(chariots_x[i], chariots_y[i]))
                        {
                            string message = "Les coordonnées que vous avez données pour ";
                            message += "le chariot " + (i + 1) + " ne sont pas possibles : ";
                            message += "elles correspondent à une étagère...";
                            throw new Exception(message);
                        }
                    }

                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new Exception("Veuillez entrer de nouvelles coordonnées pour le chariot " + (i + 1) + ".");
                    }
                }

                this.DialogResult = DialogResult.OK;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Permet de vérifier si les coordonnées du chariot sont possibles
        /// </summary>
        /// <param name="x">Numéro de ligne</param>
        /// <param name="y">Numéro de colonne</param>
        /// <returns></returns>
        private bool verifierChariot(int x, int y)
        {
            // Si les coordonnées du chariot corresponde à une étagère
            if (x % 2 == 0 && x != 0 && x != 24 &&
                ((y >= 2 && y < 11) || (y >= 14 && y < 23)))
            {
                return false;
            }

            return true;
        }
    }
}
