namespace Formulaire
{
    partial class Non_Supervise_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Non_Supervise_Form));
            this.NbLignes_Label = new System.Windows.Forms.Label();
            this.NbLignes_TextBox = new System.Windows.Forms.TextBox();
            this.NbColonnes_Label = new System.Windows.Forms.Label();
            this.NbColonnes_TextBox = new System.Windows.Forms.TextBox();
            this.CoefApprentissage_Label = new System.Windows.Forms.Label();
            this.CoefApprentissage_TextBox = new System.Windows.Forms.TextBox();
            this.Carte_Button = new System.Windows.Forms.Button();
            this.Classes_Button = new System.Windows.Forms.Button();
            this.Nouveau_Button = new System.Windows.Forms.Button();
            this.Resultat_PictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Resultat_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NbLignes_Label
            // 
            this.NbLignes_Label.Location = new System.Drawing.Point(10, 15);
            this.NbLignes_Label.Name = "NbLignes_Label";
            this.NbLignes_Label.Size = new System.Drawing.Size(160, 20);
            this.NbLignes_Label.TabIndex = 0;
            this.NbLignes_Label.Text = "Nombres de lignes de la carte :";
            this.NbLignes_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NbLignes_TextBox
            // 
            this.NbLignes_TextBox.Location = new System.Drawing.Point(170, 15);
            this.NbLignes_TextBox.Name = "NbLignes_TextBox";
            this.NbLignes_TextBox.Size = new System.Drawing.Size(50, 20);
            this.NbLignes_TextBox.TabIndex = 1;
            this.NbLignes_TextBox.Text = "80";
            // 
            // NbColonnes_Label
            // 
            this.NbColonnes_Label.Location = new System.Drawing.Point(240, 15);
            this.NbColonnes_Label.Name = "NbColonnes_Label";
            this.NbColonnes_Label.Size = new System.Drawing.Size(170, 20);
            this.NbColonnes_Label.TabIndex = 2;
            this.NbColonnes_Label.Text = "Nombres de colonnes de la carte :";
            this.NbColonnes_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NbColonnes_TextBox
            // 
            this.NbColonnes_TextBox.Location = new System.Drawing.Point(410, 15);
            this.NbColonnes_TextBox.Name = "NbColonnes_TextBox";
            this.NbColonnes_TextBox.Size = new System.Drawing.Size(50, 20);
            this.NbColonnes_TextBox.TabIndex = 3;
            this.NbColonnes_TextBox.Text = "80";
            // 
            // CoefApprentissage_Label
            // 
            this.CoefApprentissage_Label.Location = new System.Drawing.Point(480, 15);
            this.CoefApprentissage_Label.Name = "CoefApprentissage_Label";
            this.CoefApprentissage_Label.Size = new System.Drawing.Size(150, 20);
            this.CoefApprentissage_Label.TabIndex = 4;
            this.CoefApprentissage_Label.Text = "Coefficient d’apprentissage :";
            this.CoefApprentissage_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CoefApprentissage_TextBox
            // 
            this.CoefApprentissage_TextBox.Location = new System.Drawing.Point(630, 15);
            this.CoefApprentissage_TextBox.Name = "CoefApprentissage_TextBox";
            this.CoefApprentissage_TextBox.Size = new System.Drawing.Size(50, 20);
            this.CoefApprentissage_TextBox.TabIndex = 5;
            this.CoefApprentissage_TextBox.Text = "0,8";
            // 
            // Carte_Button
            // 
            this.Carte_Button.Location = new System.Drawing.Point(730, 10);
            this.Carte_Button.Name = "Carte_Button";
            this.Carte_Button.Size = new System.Drawing.Size(80, 30);
            this.Carte_Button.TabIndex = 6;
            this.Carte_Button.Text = "Kohonen";
            this.Carte_Button.UseVisualStyleBackColor = true;
            this.Carte_Button.Click += new System.EventHandler(this.Carte_Button_Click);
            // 
            // Classes_Button
            // 
            this.Classes_Button.Enabled = false;
            this.Classes_Button.Location = new System.Drawing.Point(730, 50);
            this.Classes_Button.Name = "Classes_Button";
            this.Classes_Button.Size = new System.Drawing.Size(80, 30);
            this.Classes_Button.TabIndex = 7;
            this.Classes_Button.Text = "Regrouper";
            this.Classes_Button.UseVisualStyleBackColor = true;
            this.Classes_Button.Click += new System.EventHandler(this.Classes_Button_Click);
            // 
            // Nouveau_Button
            // 
            this.Nouveau_Button.Enabled = false;
            this.Nouveau_Button.Location = new System.Drawing.Point(730, 90);
            this.Nouveau_Button.Name = "Nouveau_Button";
            this.Nouveau_Button.Size = new System.Drawing.Size(80, 30);
            this.Nouveau_Button.TabIndex = 8;
            this.Nouveau_Button.Text = "Nouveau";
            this.Nouveau_Button.UseVisualStyleBackColor = true;
            this.Nouveau_Button.Click += new System.EventHandler(this.Nouveau_Button_Click);
            // 
            // Resultat_PictureBox
            // 
            this.Resultat_PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("Resultat_PictureBox.Image")));
            this.Resultat_PictureBox.Location = new System.Drawing.Point(10, 50);
            this.Resultat_PictureBox.Name = "Resultat_PictureBox";
            this.Resultat_PictureBox.Size = new System.Drawing.Size(800, 800);
            this.Resultat_PictureBox.TabIndex = 9;
            this.Resultat_PictureBox.TabStop = false;
            // 
            // Non_Supervise_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 860);
            this.Controls.Add(this.NbLignes_Label);
            this.Controls.Add(this.NbLignes_TextBox);
            this.Controls.Add(this.NbColonnes_Label);
            this.Controls.Add(this.NbColonnes_TextBox);
            this.Controls.Add(this.CoefApprentissage_Label);
            this.Controls.Add(this.CoefApprentissage_TextBox);
            this.Controls.Add(this.Carte_Button);
            this.Controls.Add(this.Classes_Button);
            this.Controls.Add(this.Nouveau_Button);
            this.Controls.Add(this.Resultat_PictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "Non_Supervise_Form";
            this.Text = "Apprentissage Non-Supervisé";
            ((System.ComponentModel.ISupportInitialize)(this.Resultat_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NbLignes_Label;
        private System.Windows.Forms.TextBox NbLignes_TextBox;
        private System.Windows.Forms.Label NbColonnes_Label;
        private System.Windows.Forms.TextBox NbColonnes_TextBox;
        private System.Windows.Forms.Label CoefApprentissage_Label;
        private System.Windows.Forms.TextBox CoefApprentissage_TextBox;
        private System.Windows.Forms.Button Carte_Button;
        private System.Windows.Forms.Button Classes_Button;
        private System.Windows.Forms.Button Nouveau_Button;
        private System.Windows.Forms.PictureBox Resultat_PictureBox;
    }
}