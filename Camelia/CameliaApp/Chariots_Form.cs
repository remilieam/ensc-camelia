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
    public partial class Chariots_Form : Form
    {
        // Listes contenant les labels et les champs
        private List<Label> chariots_label = new List<Label>();
        private List<TextBox> champ_chariots_x = new List<TextBox>();
        private List<TextBox> champ_chariots_y = new List<TextBox>();
        
        // Liste contenant les chariots à ajouter
        private List<Chariot> chariots;
        public List<Chariot> Chariots { get { return chariots; } }

        // Nombre de chariots
        private int nb_chariots = 0;
        public bool fini = false;

        /// <summary>
        /// Permet de créer le formulaire initial
        /// </summary>
        public Chariots_Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Permet de revenir sur le formulaire de l’entrepôt après fermeture avec
        /// la croix rouge en haut à droite
        /// </summary>
        private void Chariots_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Permet de récupérer le nombre de chariots afin d’afficher le formulaire
        /// pour entrer les coordonnées de chariots (d’abord le numéro de ligne, puis
        /// le numéro de colonnes)
        /// </summary>
        private void Valider_Button_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupération du nombre de chariots à ajouter
                this.nb_chariots = Convert.ToInt32(nombre_textbox.Text);

                // Masquage des anciens éléments
                this.nombre_textbox.Hide();
                this.valider_button.Hide();

                // Changement du texte dans le label
                this.consigne_Label.Text = "Entrez les coordonnées des chariots (ligne, colonne) :";

                // Pour chaque chariots
                for (int i = 0; i < nb_chariots; i++)
                {
                    // Affichage du numéro du chariot
                    this.chariots_label.Add(new Label());
                    this.chariots_label[i].Text = "Chariot " + (i + 1) + " :";
                    this.chariots_label[i].Top = (i * 30) + 40;
                    this.chariots_label[i].Left = 10;
                    this.chariots_label[i].Width = 60;
                    this.chariots_label[i].Height = 20;
                    this.chariots_label[i].TextAlign = ContentAlignment.MiddleLeft;
                    this.Controls.Add(chariots_label[i]);

                    // Affichage du champ pour la coordonnée en x
                    this.champ_chariots_x.Add(new TextBox());
                    this.champ_chariots_x[i].Top = (i * 30) + 40;
                    this.champ_chariots_x[i].Left = 120;
                    this.champ_chariots_x[i].Width = 60;
                    this.champ_chariots_x[i].Height = 20;
                    this.Controls.Add(champ_chariots_x[i]);

                    // Affichage du champ pour la coordonnée en y
                    this.champ_chariots_y.Add(new TextBox());
                    this.champ_chariots_y[i].Top = (i * 30) + 40;
                    this.champ_chariots_y[i].Left = 230;
                    this.champ_chariots_y[i].Width = 60;
                    this.champ_chariots_y[i].Height = 20;
                    this.Controls.Add(champ_chariots_y[i]);
                }

                // Affichage du bouton de validation
                this.ajouter_button.Show();
                this.ajouter_button.Location = new Point(110, 30 * (nb_chariots + 1) + 10);

                // Changement de taille du formulaire
                this.ClientSize = new Size(300, 30 * (nb_chariots + 2) + 20);
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
        private void Ajouter_Button_Click(object sender, EventArgs e)
        {
            try
            {
                chariots = new List<Chariot>();

                // On récupère les coordonnées de chaque chariot
                for (int i = 0; i < nb_chariots; i++)
                {
                    // Par défaut, les chariots sont orientés vers le nord
                    Chariot chariot = new Chariot(
                        (Convert.ToInt32(this.champ_chariots_x[i].Text) - 1),
                        (Convert.ToInt32(this.champ_chariots_y[i].Text) - 1), 0);

                    try
                    {
                        if (!this.Verifier_Chariot(chariot))
                        {
                            string message = "Les coordonnées que vous avez données pour ";
                            message += "le chariot " + (i + 1) + " ne sont pas possibles : ";
                            message += "elles correspondent à une étagère ou à un chariot...";
                            throw new Exception(message);
                        }

                        else
                        {
                            this.chariots.Add(chariot);
                        }
                    }

                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new Exception("Veuillez entrer de nouvelles coordonnées pour le chariot " + (i + 1) + ".");
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.fini = true;
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
        private bool Verifier_Chariot(Chariot chariot)
        {
            // Si les coordonnées du chariot corresponde à une étagère
            if (chariot.Ligne % 2 == 0 && chariot.Ligne != 0 && chariot.Ligne != 24 &&
                ((chariot.Colonne >= 2 && chariot.Colonne < 11) || (chariot.Colonne >= 14 && chariot.Colonne < 23)))
            {
                return false;
            }

            // Si l’utilisateur a entré 2 fois les mêmes coordonnées pour 2 chariots différents
            foreach (Chariot chariot_dans_liste in this.chariots)
            {
                if (chariot.Egal(chariot_dans_liste)) { return false; }
            }

            return true;
        }
    }
}
