namespace CameliaApp
{
    partial class Chariots_Form
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
            this.consigne_Label = new System.Windows.Forms.Label();
            this.nombre_textbox = new System.Windows.Forms.TextBox();
            this.valider_button = new System.Windows.Forms.Button();
            this.ajouter_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // consigne_Label
            // 
            this.consigne_Label.Location = new System.Drawing.Point(10, 10);
            this.consigne_Label.Name = "consigne_Label";
            this.consigne_Label.Size = new System.Drawing.Size(280, 20);
            this.consigne_Label.TabIndex = 0;
            this.consigne_Label.Text = "Combien de chariot(s) souhaitez-vous ajouter ?";
            this.consigne_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nombre_textbox
            // 
            this.nombre_textbox.Location = new System.Drawing.Point(250, 10);
            this.nombre_textbox.Name = "nombre_textbox";
            this.nombre_textbox.Size = new System.Drawing.Size(40, 20);
            this.nombre_textbox.TabIndex = 1;
            // 
            // valider_button
            // 
            this.valider_button.Location = new System.Drawing.Point(110, 40);
            this.valider_button.Name = "valider_button";
            this.valider_button.Size = new System.Drawing.Size(80, 30);
            this.valider_button.TabIndex = 2;
            this.valider_button.Text = "Valider";
            this.valider_button.UseVisualStyleBackColor = true;
            this.valider_button.Click += new System.EventHandler(this.Valider_Button_Click);
            // 
            // ajouter_button
            // 
            this.ajouter_button.Location = new System.Drawing.Point(110, 10);
            this.ajouter_button.Name = "ajouter_button";
            this.ajouter_button.Size = new System.Drawing.Size(80, 30);
            this.ajouter_button.TabIndex = 3;
            this.ajouter_button.Text = "Valider";
            this.ajouter_button.UseVisualStyleBackColor = true;
            this.ajouter_button.Visible = false;
            this.ajouter_button.Click += new System.EventHandler(this.Ajouter_Button_Click);
            // 
            // Chariots_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 80);
            this.Controls.Add(this.ajouter_button);
            this.Controls.Add(this.valider_button);
            this.Controls.Add(this.nombre_textbox);
            this.Controls.Add(this.consigne_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Chariots_Form";
            this.Text = "Ajout des chariots";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Chariots_Form_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label consigne_Label;
        private System.Windows.Forms.TextBox nombre_textbox;
        private System.Windows.Forms.Button valider_button;
        private System.Windows.Forms.Button ajouter_button;
    }
}