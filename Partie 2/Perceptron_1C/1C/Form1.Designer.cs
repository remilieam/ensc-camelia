namespace _1C
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.Consigne_taille_label = new System.Windows.Forms.Label();
            this.Consigne_poids_label = new System.Windows.Forms.Label();
            this.Reponse_label = new System.Windows.Forms.Label();
            this.Chercher_button = new System.Windows.Forms.Button();
            this.erreur_label = new System.Windows.Forms.Label();
            this.Poids_label = new System.Windows.Forms.Label();
            this.w1_label = new System.Windows.Forms.Label();
            this.w2_label = new System.Windows.Forms.Label();
            this.w3_label = new System.Windows.Forms.Label();
            this.erreur_TextBox = new System.Windows.Forms.TextBox();
            this.Poids_textbox = new System.Windows.Forms.TextBox();
            this.w1_textbox = new System.Windows.Forms.TextBox();
            this.w2_textbox = new System.Windows.Forms.TextBox();
            this.w3_Textbox = new System.Windows.Forms.TextBox();
            this.Iteration_label = new System.Windows.Forms.Label();
            this.Iteration_Textbox = new System.Windows.Forms.TextBox();
            this.Graph_pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Graph_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Consigne_taille_label
            // 
            this.Consigne_taille_label.AutoSize = true;
            this.Consigne_taille_label.Location = new System.Drawing.Point(49, 40);
            this.Consigne_taille_label.Name = "Consigne_taille_label";
            this.Consigne_taille_label.Size = new System.Drawing.Size(0, 13);
            this.Consigne_taille_label.TabIndex = 0;
            // 
            // Consigne_poids_label
            // 
            this.Consigne_poids_label.AutoSize = true;
            this.Consigne_poids_label.Location = new System.Drawing.Point(461, 39);
            this.Consigne_poids_label.Name = "Consigne_poids_label";
            this.Consigne_poids_label.Size = new System.Drawing.Size(0, 13);
            this.Consigne_poids_label.TabIndex = 1;
            // 
            // Reponse_label
            // 
            this.Reponse_label.AutoSize = true;
            this.Reponse_label.Location = new System.Drawing.Point(41, 226);
            this.Reponse_label.Name = "Reponse_label";
            this.Reponse_label.Size = new System.Drawing.Size(0, 13);
            this.Reponse_label.TabIndex = 4;
            // 
            // Chercher_button
            // 
            this.Chercher_button.Location = new System.Drawing.Point(264, 12);
            this.Chercher_button.Name = "Chercher_button";
            this.Chercher_button.Size = new System.Drawing.Size(182, 23);
            this.Chercher_button.TabIndex = 6;
            this.Chercher_button.Text = "Faire une iteration";
            this.Chercher_button.UseVisualStyleBackColor = true;
            this.Chercher_button.Click += new System.EventHandler(this.Chercher_button_Click);
            // 
            // erreur_label
            // 
            this.erreur_label.AutoSize = true;
            this.erreur_label.Location = new System.Drawing.Point(44, 71);
            this.erreur_label.Name = "erreur_label";
            this.erreur_label.Size = new System.Drawing.Size(87, 13);
            this.erreur_label.TabIndex = 12;
            this.erreur_label.Text = "Nombres d\'erreur";
            // 
            // Poids_label
            // 
            this.Poids_label.AutoSize = true;
            this.Poids_label.Location = new System.Drawing.Point(44, 110);
            this.Poids_label.Name = "Poids_label";
            this.Poids_label.Size = new System.Drawing.Size(102, 13);
            this.Poids_label.TabIndex = 13;
            this.Poids_label.Text = "Valeur du poids final";
            // 
            // w1_label
            // 
            this.w1_label.AutoSize = true;
            this.w1_label.Location = new System.Drawing.Point(47, 142);
            this.w1_label.Name = "w1_label";
            this.w1_label.Size = new System.Drawing.Size(21, 13);
            this.w1_label.TabIndex = 14;
            this.w1_label.Text = "w1";
            // 
            // w2_label
            // 
            this.w2_label.AutoSize = true;
            this.w2_label.Location = new System.Drawing.Point(44, 170);
            this.w2_label.Name = "w2_label";
            this.w2_label.Size = new System.Drawing.Size(21, 13);
            this.w2_label.TabIndex = 15;
            this.w2_label.Text = "w2";
            // 
            // w3_label
            // 
            this.w3_label.AutoSize = true;
            this.w3_label.Location = new System.Drawing.Point(44, 200);
            this.w3_label.Name = "w3_label";
            this.w3_label.Size = new System.Drawing.Size(21, 13);
            this.w3_label.TabIndex = 16;
            this.w3_label.Text = "w3";
            // 
            // erreur_TextBox
            // 
            this.erreur_TextBox.Location = new System.Drawing.Point(152, 63);
            this.erreur_TextBox.Name = "erreur_TextBox";
            this.erreur_TextBox.Size = new System.Drawing.Size(100, 20);
            this.erreur_TextBox.TabIndex = 17;
            // 
            // Poids_textbox
            // 
            this.Poids_textbox.Location = new System.Drawing.Point(152, 107);
            this.Poids_textbox.Name = "Poids_textbox";
            this.Poids_textbox.Size = new System.Drawing.Size(100, 20);
            this.Poids_textbox.TabIndex = 18;
            // 
            // w1_textbox
            // 
            this.w1_textbox.Location = new System.Drawing.Point(152, 135);
            this.w1_textbox.Name = "w1_textbox";
            this.w1_textbox.Size = new System.Drawing.Size(100, 20);
            this.w1_textbox.TabIndex = 19;
            // 
            // w2_textbox
            // 
            this.w2_textbox.Location = new System.Drawing.Point(152, 170);
            this.w2_textbox.Name = "w2_textbox";
            this.w2_textbox.Size = new System.Drawing.Size(100, 20);
            this.w2_textbox.TabIndex = 20;
            // 
            // w3_Textbox
            // 
            this.w3_Textbox.Location = new System.Drawing.Point(152, 200);
            this.w3_Textbox.Name = "w3_Textbox";
            this.w3_Textbox.Size = new System.Drawing.Size(100, 20);
            this.w3_Textbox.TabIndex = 21;
            // 
            // Iteration_label
            // 
            this.Iteration_label.AutoSize = true;
            this.Iteration_label.Location = new System.Drawing.Point(416, 63);
            this.Iteration_label.Name = "Iteration_label";
            this.Iteration_label.Size = new System.Drawing.Size(92, 13);
            this.Iteration_label.TabIndex = 22;
            this.Iteration_label.Text = "Nombre d\'itération";
            // 
            // Iteration_Textbox
            // 
            this.Iteration_Textbox.Location = new System.Drawing.Point(514, 56);
            this.Iteration_Textbox.Name = "Iteration_Textbox";
            this.Iteration_Textbox.Size = new System.Drawing.Size(44, 20);
            this.Iteration_Textbox.TabIndex = 23;
            // 
            // Graph_pictureBox
            // 
            this.Graph_pictureBox.Location = new System.Drawing.Point(282, 107);
            this.Graph_pictureBox.Name = "Graph_pictureBox";
            this.Graph_pictureBox.Size = new System.Drawing.Size(486, 358);
            this.Graph_pictureBox.TabIndex = 24;
            this.Graph_pictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 524);
            this.Controls.Add(this.Graph_pictureBox);
            this.Controls.Add(this.Iteration_Textbox);
            this.Controls.Add(this.Iteration_label);
            this.Controls.Add(this.w3_Textbox);
            this.Controls.Add(this.w2_textbox);
            this.Controls.Add(this.w1_textbox);
            this.Controls.Add(this.Poids_textbox);
            this.Controls.Add(this.erreur_TextBox);
            this.Controls.Add(this.w3_label);
            this.Controls.Add(this.w2_label);
            this.Controls.Add(this.w1_label);
            this.Controls.Add(this.Poids_label);
            this.Controls.Add(this.erreur_label);
            this.Controls.Add(this.Chercher_button);
            this.Controls.Add(this.Reponse_label);
            this.Controls.Add(this.Consigne_poids_label);
            this.Controls.Add(this.Consigne_taille_label);
            this.Name = "Form1";
            this.Text = "Perceptron 1 Couche";
            ((System.ComponentModel.ISupportInitialize)(this.Graph_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Consigne_taille_label;
        private System.Windows.Forms.Label Consigne_poids_label;
        private System.Windows.Forms.Label Reponse_label;
        private System.Windows.Forms.Button Chercher_button;
        private System.Windows.Forms.Label erreur_label;
        private System.Windows.Forms.Label Poids_label;
        private System.Windows.Forms.Label w1_label;
        private System.Windows.Forms.Label w2_label;
        private System.Windows.Forms.Label w3_label;
        private System.Windows.Forms.TextBox erreur_TextBox;
        private System.Windows.Forms.TextBox Poids_textbox;
        private System.Windows.Forms.TextBox w1_textbox;
        private System.Windows.Forms.TextBox w2_textbox;
        private System.Windows.Forms.TextBox w3_Textbox;
        private System.Windows.Forms.Label Iteration_label;
        private System.Windows.Forms.TextBox Iteration_Textbox;
        private System.Windows.Forms.PictureBox Graph_pictureBox;
    }
}

