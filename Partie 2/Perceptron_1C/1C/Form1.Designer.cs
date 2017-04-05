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
            this.Reponse_TextBox = new System.Windows.Forms.TextBox();
            this.Chercher_button = new System.Windows.Forms.Button();
            this.Poids_final_label = new System.Windows.Forms.Label();
            this.Poids_final_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.classe_TextBox = new System.Windows.Forms.TextBox();
            this.Graphique_PictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Graphique_PictureBox)).BeginInit();
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
            this.Reponse_label.Size = new System.Drawing.Size(130, 13);
            this.Reponse_label.TabIndex = 4;
            this.Reponse_label.Text = "Le nombre d\'erreur est de ";
            // 
            // Reponse_TextBox
            // 
            this.Reponse_TextBox.Location = new System.Drawing.Point(44, 242);
            this.Reponse_TextBox.Name = "Reponse_TextBox";
            this.Reponse_TextBox.Size = new System.Drawing.Size(59, 20);
            this.Reponse_TextBox.TabIndex = 5;
            // 
            // Chercher_button
            // 
            this.Chercher_button.Location = new System.Drawing.Point(558, 133);
            this.Chercher_button.Name = "Chercher_button";
            this.Chercher_button.Size = new System.Drawing.Size(182, 23);
            this.Chercher_button.TabIndex = 6;
            this.Chercher_button.Text = "Chercher la classe";
            this.Chercher_button.UseVisualStyleBackColor = true;
            this.Chercher_button.Click += new System.EventHandler(this.Chercher_button_Click);
            // 
            // Poids_final_label
            // 
            this.Poids_final_label.AutoSize = true;
            this.Poids_final_label.Location = new System.Drawing.Point(570, 242);
            this.Poids_final_label.Name = "Poids_final_label";
            this.Poids_final_label.Size = new System.Drawing.Size(151, 13);
            this.Poids_final_label.TabIndex = 7;
            this.Poids_final_label.Text = "La valeur du poids final est de ";
            // 
            // Poids_final_TextBox
            // 
            this.Poids_final_TextBox.Location = new System.Drawing.Point(569, 259);
            this.Poids_final_TextBox.Name = "Poids_final_TextBox";
            this.Poids_final_TextBox.Size = new System.Drawing.Size(60, 20);
            this.Poids_final_TextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "La classe de l\'espèce est :";
            // 
            // classe_TextBox
            // 
            this.classe_TextBox.Location = new System.Drawing.Point(287, 241);
            this.classe_TextBox.Name = "classe_TextBox";
            this.classe_TextBox.Size = new System.Drawing.Size(40, 20);
            this.classe_TextBox.TabIndex = 10;
            // 
            // Graphique_PictureBox
            // 
            this.Graphique_PictureBox.Location = new System.Drawing.Point(125, 285);
            this.Graphique_PictureBox.Name = "Graphique_PictureBox";
            this.Graphique_PictureBox.Size = new System.Drawing.Size(518, 204);
            this.Graphique_PictureBox.TabIndex = 11;
            this.Graphique_PictureBox.TabStop = false;
            this.Graphique_PictureBox.Click += new System.EventHandler(this.Graphique_PictureBox_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 524);
            this.Controls.Add(this.Graphique_PictureBox);
            this.Controls.Add(this.classe_TextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Poids_final_TextBox);
            this.Controls.Add(this.Poids_final_label);
            this.Controls.Add(this.Chercher_button);
            this.Controls.Add(this.Reponse_TextBox);
            this.Controls.Add(this.Reponse_label);
            this.Controls.Add(this.Consigne_poids_label);
            this.Controls.Add(this.Consigne_taille_label);
            this.Name = "Form1";
            this.Text = "Graphique";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Graphique_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Consigne_taille_label;
        private System.Windows.Forms.Label Consigne_poids_label;
        private System.Windows.Forms.Label Reponse_label;
        private System.Windows.Forms.TextBox Reponse_TextBox;
        private System.Windows.Forms.Button Chercher_button;
        private System.Windows.Forms.Label Poids_final_label;
        private System.Windows.Forms.TextBox Poids_final_TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox classe_TextBox;
        private System.Windows.Forms.PictureBox Graphique_PictureBox;
    }
}

