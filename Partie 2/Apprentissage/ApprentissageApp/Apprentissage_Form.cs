﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperviseApp;
using NonSuperviseApp;

namespace ApprentissageApp
{
    public partial class Apprentissage_Form : Form
    {
        public Apprentissage_Form()
        {
            InitializeComponent();
        }

        private void Supervise_Button_Click(object sender, EventArgs e)
        {
            Supervise_Form Supervise = new Supervise_Form();
            this.Hide();

            if (Supervise.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void Non_Supervise_Button_Click(object sender, EventArgs e)
        {
            NonSupervise_Form Non_Supervise = new NonSupervise_Form();
            this.Hide();

            if (Non_Supervise.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }
    }
}
