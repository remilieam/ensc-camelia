namespace CameliaApp
{
    partial class Chemin_Form
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
            this.chariot_label = new System.Windows.Forms.Label();
            this.distance_radiobutton = new System.Windows.Forms.RadioButton();
            this.temps_radiobutton = new System.Windows.Forms.RadioButton();
            this.objet_label = new System.Windows.Forms.Label();
            this.objet_x_textbox = new System.Windows.Forms.TextBox();
            this.objet_y_textbox = new System.Windows.Forms.TextBox();
            this.objet_k_listbox = new System.Windows.Forms.ListBox();
            this.objet_z_textbox = new System.Windows.Forms.TextBox();
            this.valider_button = new System.Windows.Forms.Button();
            this.realite_radiobutton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // chariot_label
            // 
            this.chariot_label.Location = new System.Drawing.Point(10, 10);
            this.chariot_label.Name = "chariot_label";
            this.chariot_label.Size = new System.Drawing.Size(340, 20);
            this.chariot_label.TabIndex = 0;
            this.chariot_label.Text = "Chemin le plus court en terme de… ?";
            this.chariot_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // distance_radiobutton
            // 
            this.distance_radiobutton.AutoSize = true;
            this.distance_radiobutton.Location = new System.Drawing.Point(65, 40);
            this.distance_radiobutton.Name = "distance_radiobutton";
            this.distance_radiobutton.Size = new System.Drawing.Size(67, 17);
            this.distance_radiobutton.TabIndex = 1;
            this.distance_radiobutton.TabStop = true;
            this.distance_radiobutton.Text = "Distance";
            this.distance_radiobutton.UseVisualStyleBackColor = true;
            // 
            // temps_radiobutton
            // 
            this.temps_radiobutton.AutoSize = true;
            this.temps_radiobutton.Location = new System.Drawing.Point(163, 40);
            this.temps_radiobutton.Name = "temps_radiobutton";
            this.temps_radiobutton.Size = new System.Drawing.Size(57, 17);
            this.temps_radiobutton.TabIndex = 2;
            this.temps_radiobutton.TabStop = true;
            this.temps_radiobutton.Text = "Temps";
            this.temps_radiobutton.UseVisualStyleBackColor = true;
            // 
            // objet_label
            // 
            this.objet_label.Location = new System.Drawing.Point(10, 70);
            this.objet_label.Name = "objet_label";
            this.objet_label.Size = new System.Drawing.Size(340, 20);
            this.objet_label.TabIndex = 3;
            this.objet_label.Text = "Choisissez l’objet à récupérer (ligne, colonne, orientation, hauteur) :";
            this.objet_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // objet_x_textbox
            // 
            this.objet_x_textbox.Location = new System.Drawing.Point(46, 100);
            this.objet_x_textbox.Name = "objet_x_textbox";
            this.objet_x_textbox.Size = new System.Drawing.Size(40, 20);
            this.objet_x_textbox.TabIndex = 4;
            this.objet_x_textbox.Text = "15";
            // 
            // objet_y_textbox
            // 
            this.objet_y_textbox.Location = new System.Drawing.Point(122, 100);
            this.objet_y_textbox.Name = "objet_y_textbox";
            this.objet_y_textbox.Size = new System.Drawing.Size(40, 20);
            this.objet_y_textbox.TabIndex = 5;
            this.objet_y_textbox.Text = "6";
            // 
            // objet_k_listbox
            // 
            this.objet_k_listbox.FormattingEnabled = true;
            this.objet_k_listbox.Items.AddRange(new object[] {
            "Nord",
            "Sud"});
            this.objet_k_listbox.Location = new System.Drawing.Point(198, 100);
            this.objet_k_listbox.Name = "objet_k_listbox";
            this.objet_k_listbox.Size = new System.Drawing.Size(40, 30);
            this.objet_k_listbox.TabIndex = 6;
            // 
            // objet_z_textbox
            // 
            this.objet_z_textbox.Location = new System.Drawing.Point(274, 100);
            this.objet_z_textbox.Name = "objet_z_textbox";
            this.objet_z_textbox.Size = new System.Drawing.Size(40, 20);
            this.objet_z_textbox.TabIndex = 7;
            this.objet_z_textbox.Text = "5";
            // 
            // valider_button
            // 
            this.valider_button.Location = new System.Drawing.Point(140, 140);
            this.valider_button.Name = "valider_button";
            this.valider_button.Size = new System.Drawing.Size(80, 30);
            this.valider_button.TabIndex = 8;
            this.valider_button.Text = "Valider";
            this.valider_button.UseVisualStyleBackColor = true;
            this.valider_button.Click += new System.EventHandler(this.Valider_Button_Click);
            // 
            // realite_radiobutton
            // 
            this.realite_radiobutton.AutoSize = true;
            this.realite_radiobutton.Location = new System.Drawing.Point(257, 40);
            this.realite_radiobutton.Name = "realite_radiobutton";
            this.realite_radiobutton.Size = new System.Drawing.Size(58, 17);
            this.realite_radiobutton.TabIndex = 9;
            this.realite_radiobutton.TabStop = true;
            this.realite_radiobutton.Text = "Réalité";
            this.realite_radiobutton.UseVisualStyleBackColor = true;
            // 
            // Chemin_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 180);
            this.Controls.Add(this.realite_radiobutton);
            this.Controls.Add(this.chariot_label);
            this.Controls.Add(this.distance_radiobutton);
            this.Controls.Add(this.temps_radiobutton);
            this.Controls.Add(this.objet_label);
            this.Controls.Add(this.objet_y_textbox);
            this.Controls.Add(this.objet_x_textbox);
            this.Controls.Add(this.objet_k_listbox);
            this.Controls.Add(this.objet_z_textbox);
            this.Controls.Add(this.valider_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Chemin_Form";
            this.Text = "Sélection d’un chariot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Chemin_Form_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label chariot_label;
        private System.Windows.Forms.RadioButton distance_radiobutton;
        private System.Windows.Forms.RadioButton temps_radiobutton;
        private System.Windows.Forms.Label objet_label;
        private System.Windows.Forms.TextBox objet_x_textbox;
        private System.Windows.Forms.TextBox objet_y_textbox;
        private System.Windows.Forms.ListBox objet_k_listbox;
        private System.Windows.Forms.TextBox objet_z_textbox;
        private System.Windows.Forms.Button valider_button;
        private System.Windows.Forms.RadioButton realite_radiobutton;
    }
}