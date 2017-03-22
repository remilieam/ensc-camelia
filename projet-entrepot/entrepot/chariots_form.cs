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
        // listes recensant les chariots
        List<Label> chariots_label = new List<Label>();
        List<TextBox> chariots_x = new List<TextBox>();
        List<TextBox> chariots_y = new List<TextBox>();

        public chariots_form()
        {
            InitializeComponent();
        }

        private void nbc_button_Click(object sender, EventArgs e)
        {
            // on cache/affiche les élements
            nbc_textbox.Hide();
            nbc_button.Hide();
            chariots_button.Show();

            // on change le texte
            nbc_label.Text = "Entrez les coordonnées de chaque chariot :";

            // on récupère le champs
            int nbc = Convert.ToInt32(nbc_textbox.Text);

            //
            for (int i = 0; i < nbc; i++)
            {
                // on affiche les champs
                chariots_label.Add(new Label());
                chariots_label[i].Text = "Chariot " + (i + 1);
                this.Controls.Add(chariots_label[i]);
                chariots_label[i].Left = 10;
                chariots_label[i].Top = (i * 50) + 70;
                chariots_label[i].Width = 50;
                chariots_label[i].Height = 20;

                chariots_x.Add(new TextBox());
                this.Controls.Add(chariots_x[i]);
                chariots_x[i].Left = 70;
                chariots_x[i].Top = (i * 50) + 70;
                chariots_x[i].Width = 50;
                chariots_x[i].Height = 20;

                chariots_y.Add(new TextBox());
                this.Controls.Add(chariots_y[i]);
                chariots_y[i].Left = 150;
                chariots_y[i].Top = (i * 50) + 70;
                chariots_y[i].Width = 50;
                chariots_y[i].Height = 20;


            }

        }

        private void chariots_button_Click(object sender, EventArgs e)
        {

        }

        private void chariots_form_Load(object sender, EventArgs e)
        {
            chariots_button.Hide();
        }
    }
}
