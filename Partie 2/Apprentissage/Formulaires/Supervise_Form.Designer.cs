﻿namespace Formulaire
{
    partial class Supervise_Form
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
            this.NbCouches_Label = new System.Windows.Forms.Label();
            this.NbCouches_TextBox = new System.Windows.Forms.TextBox();
            this.Reseau_Button = new System.Windows.Forms.Button();
            this.NbNeurones_TextBox = new System.Windows.Forms.TextBox();
            this.NbNeurones_Label = new System.Windows.Forms.Label();
            this.Resultat_PictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Resultat_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NbCouches_Label
            // 
            this.NbCouches_Label.Location = new System.Drawing.Point(10, 10);
            this.NbCouches_Label.Name = "NbCouches_Label";
            this.NbCouches_Label.Size = new System.Drawing.Size(200, 20);
            this.NbCouches_Label.TabIndex = 0;
            this.NbCouches_Label.Text = "Nombres de couches totales :";
            this.NbCouches_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NbCouches_TextBox
            // 
            this.NbCouches_TextBox.Location = new System.Drawing.Point(210, 10);
            this.NbCouches_TextBox.Name = "NbCouches_TextBox";
            this.NbCouches_TextBox.Size = new System.Drawing.Size(50, 20);
            this.NbCouches_TextBox.TabIndex = 1;
            // 
            // Reseau_Button
            // 
            this.Reseau_Button.Location = new System.Drawing.Point(100, 80);
            this.Reseau_Button.Name = "Reseau_Button";
            this.Reseau_Button.Size = new System.Drawing.Size(80, 30);
            this.Reseau_Button.TabIndex = 2;
            this.Reseau_Button.Text = "Valider";
            this.Reseau_Button.UseVisualStyleBackColor = true;
            this.Reseau_Button.Click += new System.EventHandler(this.Reseau_Button_Click);
            // 
            // NbNeurones_TextBox
            // 
            this.NbNeurones_TextBox.Location = new System.Drawing.Point(210, 50);
            this.NbNeurones_TextBox.Name = "NbNeurones_TextBox";
            this.NbNeurones_TextBox.Size = new System.Drawing.Size(50, 20);
            this.NbNeurones_TextBox.TabIndex = 4;
            // 
            // NbNeurones_Label
            // 
            this.NbNeurones_Label.Location = new System.Drawing.Point(10, 50);
            this.NbNeurones_Label.Name = "NbNeurones_Label";
            this.NbNeurones_Label.Size = new System.Drawing.Size(200, 20);
            this.NbNeurones_Label.TabIndex = 3;
            this.NbNeurones_Label.Text = "Nombres de neurones par couches :";
            this.NbNeurones_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Resultat_PictureBox
            // 
            this.Resultat_PictureBox.Location = new System.Drawing.Point(13, 129);
            this.Resultat_PictureBox.Name = "Resultat_PictureBox";
            this.Resultat_PictureBox.Size = new System.Drawing.Size(800, 800);
            this.Resultat_PictureBox.TabIndex = 5;
            this.Resultat_PictureBox.TabStop = false;
            // 
            // Supervise_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 944);
            this.Controls.Add(this.Resultat_PictureBox);
            this.Controls.Add(this.NbNeurones_TextBox);
            this.Controls.Add(this.NbNeurones_Label);
            this.Controls.Add(this.Reseau_Button);
            this.Controls.Add(this.NbCouches_TextBox);
            this.Controls.Add(this.NbCouches_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Supervise_Form";
            this.Text = "Apprentissage Supervisé";
            ((System.ComponentModel.ISupportInitialize)(this.Resultat_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NbCouches_Label;
        private System.Windows.Forms.TextBox NbCouches_TextBox;
        private System.Windows.Forms.Button Reseau_Button;
        private System.Windows.Forms.TextBox NbNeurones_TextBox;
        private System.Windows.Forms.Label NbNeurones_Label;
        private System.Windows.Forms.PictureBox Resultat_PictureBox;
    }
}