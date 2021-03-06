﻿namespace SuperviseApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Supervise_Form));
            this.NbCouches_Label = new System.Windows.Forms.Label();
            this.NbCouches_TextBox = new System.Windows.Forms.TextBox();
            this.NbNeurones_Label = new System.Windows.Forms.Label();
            this.NbNeurones_TextBox = new System.Windows.Forms.TextBox();
            this.NbIterations_Label = new System.Windows.Forms.Label();
            this.NbIterations_TextBox = new System.Windows.Forms.TextBox();
            this.CoefApprentissage_Label = new System.Windows.Forms.Label();
            this.CoefApprentissage_TextBox = new System.Windows.Forms.TextBox();
            this.Reseau_Button = new System.Windows.Forms.Button();
            this.Resultat_PictureBox = new System.Windows.Forms.PictureBox();
            this.Chrono_Timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Resultat_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NbCouches_Label
            // 
            this.NbCouches_Label.Location = new System.Drawing.Point(10, 10);
            this.NbCouches_Label.Name = "NbCouches_Label";
            this.NbCouches_Label.Size = new System.Drawing.Size(150, 20);
            this.NbCouches_Label.TabIndex = 0;
            this.NbCouches_Label.Text = "Nombres de couches totales :";
            this.NbCouches_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NbCouches_TextBox
            // 
            this.NbCouches_TextBox.Location = new System.Drawing.Point(160, 10);
            this.NbCouches_TextBox.Name = "NbCouches_TextBox";
            this.NbCouches_TextBox.Size = new System.Drawing.Size(50, 20);
            this.NbCouches_TextBox.TabIndex = 1;
            this.NbCouches_TextBox.Text = "3";
            // 
            // NbNeurones_Label
            // 
            this.NbNeurones_Label.Location = new System.Drawing.Point(330, 10);
            this.NbNeurones_Label.Name = "NbNeurones_Label";
            this.NbNeurones_Label.Size = new System.Drawing.Size(180, 20);
            this.NbNeurones_Label.TabIndex = 2;
            this.NbNeurones_Label.Text = "Nombres de neurones par couches :";
            this.NbNeurones_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NbNeurones_TextBox
            // 
            this.NbNeurones_TextBox.Location = new System.Drawing.Point(510, 10);
            this.NbNeurones_TextBox.Name = "NbNeurones_TextBox";
            this.NbNeurones_TextBox.Size = new System.Drawing.Size(50, 20);
            this.NbNeurones_TextBox.TabIndex = 3;
            this.NbNeurones_TextBox.Text = "6";
            // 
            // NbIterations_Label
            // 
            this.NbIterations_Label.Location = new System.Drawing.Point(10, 40);
            this.NbIterations_Label.Name = "NbIterations_Label";
            this.NbIterations_Label.Size = new System.Drawing.Size(150, 20);
            this.NbIterations_Label.TabIndex = 4;
            this.NbIterations_Label.Text = "Nombre d’itérations :";
            this.NbIterations_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NbIterations_TextBox
            // 
            this.NbIterations_TextBox.Location = new System.Drawing.Point(160, 40);
            this.NbIterations_TextBox.Name = "NbIterations_TextBox";
            this.NbIterations_TextBox.Size = new System.Drawing.Size(50, 20);
            this.NbIterations_TextBox.TabIndex = 5;
            this.NbIterations_TextBox.Text = "500";
            // 
            // CoefApprentissage_Label
            // 
            this.CoefApprentissage_Label.Location = new System.Drawing.Point(330, 40);
            this.CoefApprentissage_Label.Name = "CoefApprentissage_Label";
            this.CoefApprentissage_Label.Size = new System.Drawing.Size(180, 20);
            this.CoefApprentissage_Label.TabIndex = 6;
            this.CoefApprentissage_Label.Text = "Coefficient d’apprentissage :";
            this.CoefApprentissage_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CoefApprentissage_TextBox
            // 
            this.CoefApprentissage_TextBox.Location = new System.Drawing.Point(510, 40);
            this.CoefApprentissage_TextBox.Name = "NbNeurones_TextBox";
            this.CoefApprentissage_TextBox.Size = new System.Drawing.Size(50, 20);
            this.CoefApprentissage_TextBox.TabIndex = 7;
            this.CoefApprentissage_TextBox.Text = "0,5";
            // 
            // Reseau_Button
            // 
            this.Reseau_Button.Location = new System.Drawing.Point(730, 20);
            this.Reseau_Button.Name = "Reseau_Button";
            this.Reseau_Button.Size = new System.Drawing.Size(80, 30);
            this.Reseau_Button.TabIndex = 8;
            this.Reseau_Button.Text = "Valider";
            this.Reseau_Button.UseVisualStyleBackColor = true;
            this.Reseau_Button.Click += new System.EventHandler(this.Reseau_Button_Click);
            // 
            // Resultat_PictureBox
            // 
            this.Resultat_PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("Resultat_PictureBox.Image")));
            this.Resultat_PictureBox.Location = new System.Drawing.Point(10, 70);
            this.Resultat_PictureBox.Name = "Resultat_PictureBox";
            this.Resultat_PictureBox.Size = new System.Drawing.Size(800, 800);
            this.Resultat_PictureBox.TabIndex = 9;
            this.Resultat_PictureBox.TabStop = false;
            // 
            // Chrono_Timer
            // 
            this.Chrono_Timer.Interval = 1000;
            this.Chrono_Timer.Tick += new System.EventHandler(this.Chrono_Timer_Tick);
            // 
            // Supervise_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 880);
            this.Controls.Add(this.NbCouches_Label);
            this.Controls.Add(this.NbCouches_TextBox);
            this.Controls.Add(this.NbNeurones_Label);
            this.Controls.Add(this.NbNeurones_TextBox);
            this.Controls.Add(this.NbIterations_Label);
            this.Controls.Add(this.NbIterations_TextBox);
            this.Controls.Add(this.CoefApprentissage_Label);
            this.Controls.Add(this.CoefApprentissage_TextBox);
            this.Controls.Add(this.Reseau_Button);
            this.Controls.Add(this.Resultat_PictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Supervise_Form";
            this.Text = "Apprentissage Supervisé";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Supervise_Form_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Resultat_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label NbCouches_Label;
        private System.Windows.Forms.TextBox NbCouches_TextBox;
        private System.Windows.Forms.Label NbNeurones_Label;
        private System.Windows.Forms.TextBox NbNeurones_TextBox;
        private System.Windows.Forms.Label NbIterations_Label;
        private System.Windows.Forms.TextBox NbIterations_TextBox;
        private System.Windows.Forms.Label CoefApprentissage_Label;
        private System.Windows.Forms.TextBox CoefApprentissage_TextBox;
        private System.Windows.Forms.Button Reseau_Button;
        private System.Windows.Forms.PictureBox Resultat_PictureBox;
        private System.Windows.Forms.Timer Chrono_Timer;
    }
}