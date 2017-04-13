namespace ApprentissageApp
{
    partial class Apprentissage_Form
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
            this.Supervise_Button = new System.Windows.Forms.Button();
            this.Non_Supervise_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Supervise_Button
            // 
            this.Supervise_Button.Location = new System.Drawing.Point(60, 45);
            this.Supervise_Button.Name = "Supervise_Button";
            this.Supervise_Button.Size = new System.Drawing.Size(180, 60);
            this.Supervise_Button.TabIndex = 0;
            this.Supervise_Button.Text = "Apprentissage Supervisé";
            this.Supervise_Button.UseVisualStyleBackColor = true;
            this.Supervise_Button.Click += new System.EventHandler(this.Supervise_Button_Click);
            // 
            // Non_Supervise_Button
            // 
            this.Non_Supervise_Button.Location = new System.Drawing.Point(60, 155);
            this.Non_Supervise_Button.Name = "Non_Supervise_Button";
            this.Non_Supervise_Button.Size = new System.Drawing.Size(180, 60);
            this.Non_Supervise_Button.TabIndex = 1;
            this.Non_Supervise_Button.Text = "Apprentissage Non-Supervisé";
            this.Non_Supervise_Button.UseVisualStyleBackColor = true;
            this.Non_Supervise_Button.Click += new System.EventHandler(this.Non_Supervise_Button_Click);
            // 
            // Apprentissage_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 268);
            this.Controls.Add(this.Non_Supervise_Button);
            this.Controls.Add(this.Supervise_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Apprentissage_Form";
            this.Text = "Apprentissage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Supervise_Button;
        private System.Windows.Forms.Button Non_Supervise_Button;
    }
}