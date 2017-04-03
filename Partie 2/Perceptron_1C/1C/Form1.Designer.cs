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
            this.taille_TextBox = new System.Windows.Forms.TextBox();
            this.Poids_TextBox = new System.Windows.Forms.TextBox();
            this.Reponse_label = new System.Windows.Forms.Label();
            this.Reponse_TextBox = new System.Windows.Forms.TextBox();
            this.Chercher_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Consigne_taille_label
            // 
            this.Consigne_taille_label.AutoSize = true;
            this.Consigne_taille_label.Location = new System.Drawing.Point(49, 40);
            this.Consigne_taille_label.Name = "Consigne_taille_label";
            this.Consigne_taille_label.Size = new System.Drawing.Size(141, 13);
            this.Consigne_taille_label.TabIndex = 0;
            this.Consigne_taille_label.Text = "Inscrivez la taille de l\'espèce";
            // 
            // Consigne_poids_label
            // 
            this.Consigne_poids_label.AutoSize = true;
            this.Consigne_poids_label.Location = new System.Drawing.Point(461, 39);
            this.Consigne_poids_label.Name = "Consigne_poids_label";
            this.Consigne_poids_label.Size = new System.Drawing.Size(145, 13);
            this.Consigne_poids_label.TabIndex = 1;
            this.Consigne_poids_label.Text = "Inscrivez le poids de l\'espèce";
            // 
            // taille_TextBox
            // 
            this.taille_TextBox.Location = new System.Drawing.Point(71, 73);
            this.taille_TextBox.Name = "taille_TextBox";
            this.taille_TextBox.Size = new System.Drawing.Size(100, 20);
            this.taille_TextBox.TabIndex = 2;
            this.taille_TextBox.TextChanged += new System.EventHandler(this.taille_TextBox_TextChanged);
            // 
            // Poids_TextBox
            // 
            this.Poids_TextBox.Location = new System.Drawing.Point(464, 73);
            this.Poids_TextBox.Name = "Poids_TextBox";
            this.Poids_TextBox.Size = new System.Drawing.Size(100, 20);
            this.Poids_TextBox.TabIndex = 3;
            // 
            // Reponse_label
            // 
            this.Reponse_label.AutoSize = true;
            this.Reponse_label.Location = new System.Drawing.Point(229, 248);
            this.Reponse_label.Name = "Reponse_label";
            this.Reponse_label.Size = new System.Drawing.Size(159, 13);
            this.Reponse_label.TabIndex = 4;
            this.Reponse_label.Text = "L\'espèce appartient à la classe :";
            // 
            // Reponse_TextBox
            // 
            this.Reponse_TextBox.Location = new System.Drawing.Point(263, 279);
            this.Reponse_TextBox.Name = "Reponse_TextBox";
            this.Reponse_TextBox.Size = new System.Drawing.Size(100, 20);
            this.Reponse_TextBox.TabIndex = 5;
            // 
            // Chercher_button
            // 
            this.Chercher_button.Location = new System.Drawing.Point(569, 162);
            this.Chercher_button.Name = "Chercher_button";
            this.Chercher_button.Size = new System.Drawing.Size(182, 23);
            this.Chercher_button.TabIndex = 6;
            this.Chercher_button.Text = "Chercher la classe";
            this.Chercher_button.UseVisualStyleBackColor = true;
            this.Chercher_button.Click += new System.EventHandler(this.Chercher_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 490);
            this.Controls.Add(this.Chercher_button);
            this.Controls.Add(this.Reponse_TextBox);
            this.Controls.Add(this.Reponse_label);
            this.Controls.Add(this.Poids_TextBox);
            this.Controls.Add(this.taille_TextBox);
            this.Controls.Add(this.Consigne_poids_label);
            this.Controls.Add(this.Consigne_taille_label);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Consigne_taille_label;
        private System.Windows.Forms.Label Consigne_poids_label;
        private System.Windows.Forms.TextBox taille_TextBox;
        private System.Windows.Forms.TextBox Poids_TextBox;
        private System.Windows.Forms.Label Reponse_label;
        private System.Windows.Forms.TextBox Reponse_TextBox;
        private System.Windows.Forms.Button Chercher_button;
    }
}

