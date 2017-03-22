namespace entrepot
{
    partial class selection_form
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
            this.objet_label = new System.Windows.Forms.Label();
            this.chariot_x_textbox = new System.Windows.Forms.TextBox();
            this.chariot_y_textbox = new System.Windows.Forms.TextBox();
            this.objet_x_textbox = new System.Windows.Forms.TextBox();
            this.objet_y_textbox = new System.Windows.Forms.TextBox();
            this.objet_z_textbox = new System.Windows.Forms.TextBox();
            this.valider_button = new System.Windows.Forms.Button();
            this.objet_k_listbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // chariot_label
            // 
            this.chariot_label.Location = new System.Drawing.Point(10, 10);
            this.chariot_label.Name = "chariot_label";
            this.chariot_label.Size = new System.Drawing.Size(340, 20);
            this.chariot_label.TabIndex = 0;
            this.chariot_label.Text = "Choisissez le chariot à déplacer (ligne, colonne) :";
            this.chariot_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // objet_label
            // 
            this.objet_label.Location = new System.Drawing.Point(10, 86);
            this.objet_label.Name = "objet_label";
            this.objet_label.Size = new System.Drawing.Size(340, 20);
            this.objet_label.TabIndex = 1;
            this.objet_label.Text = "Choisissez l’objet à récupérer (ligne, colonne, orientation, hauteur) :";
            this.objet_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chariot_x_textbox
            // 
            this.chariot_x_textbox.Location = new System.Drawing.Point(10, 40);
            this.chariot_x_textbox.Name = "chariot_x_textbox";
            this.chariot_x_textbox.Size = new System.Drawing.Size(40, 20);
            this.chariot_x_textbox.TabIndex = 2;
            // 
            // chariot_y_textbox
            // 
            this.chariot_y_textbox.Location = new System.Drawing.Point(70, 40);
            this.chariot_y_textbox.Name = "chariot_y_textbox";
            this.chariot_y_textbox.Size = new System.Drawing.Size(40, 20);
            this.chariot_y_textbox.TabIndex = 3;
            // 
            // objet_x_textbox
            // 
            this.objet_x_textbox.Location = new System.Drawing.Point(10, 123);
            this.objet_x_textbox.Name = "objet_x_textbox";
            this.objet_x_textbox.Size = new System.Drawing.Size(40, 20);
            this.objet_x_textbox.TabIndex = 4;
            // 
            // objet_y_textbox
            // 
            this.objet_y_textbox.Location = new System.Drawing.Point(70, 123);
            this.objet_y_textbox.Name = "objet_y_textbox";
            this.objet_y_textbox.Size = new System.Drawing.Size(40, 20);
            this.objet_y_textbox.TabIndex = 5;
            // 
            // objet_z_textbox
            // 
            this.objet_z_textbox.Location = new System.Drawing.Point(199, 123);
            this.objet_z_textbox.Name = "objet_z_textbox";
            this.objet_z_textbox.Size = new System.Drawing.Size(40, 20);
            this.objet_z_textbox.TabIndex = 7;
            // 
            // valider_button
            // 
            this.valider_button.Location = new System.Drawing.Point(133, 194);
            this.valider_button.Name = "valider_button";
            this.valider_button.Size = new System.Drawing.Size(75, 23);
            this.valider_button.TabIndex = 8;
            this.valider_button.Text = "Valider";
            this.valider_button.UseVisualStyleBackColor = true;
            this.valider_button.Click += new System.EventHandler(this.valider_button_Click);
            // 
            // objet_k_listbox
            // 
            this.objet_k_listbox.FormattingEnabled = true;
            this.objet_k_listbox.Items.AddRange(new object[] {
            "Nord",
            "Sud"});
            this.objet_k_listbox.Location = new System.Drawing.Point(119, 123);
            this.objet_k_listbox.Name = "objet_k_listbox";
            this.objet_k_listbox.Size = new System.Drawing.Size(53, 30);
            this.objet_k_listbox.TabIndex = 9;
            // 
            // selection_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 242);
            this.Controls.Add(this.objet_k_listbox);
            this.Controls.Add(this.valider_button);
            this.Controls.Add(this.objet_z_textbox);
            this.Controls.Add(this.objet_y_textbox);
            this.Controls.Add(this.objet_x_textbox);
            this.Controls.Add(this.chariot_y_textbox);
            this.Controls.Add(this.chariot_x_textbox);
            this.Controls.Add(this.objet_label);
            this.Controls.Add(this.chariot_label);
            this.Name = "selection_form";
            this.Text = "Sélection d’un chariot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.selection_form_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label chariot_label;
        private System.Windows.Forms.Label objet_label;
        private System.Windows.Forms.TextBox chariot_x_textbox;
        private System.Windows.Forms.TextBox chariot_y_textbox;
        private System.Windows.Forms.TextBox objet_x_textbox;
        private System.Windows.Forms.TextBox objet_y_textbox;
        private System.Windows.Forms.TextBox objet_z_textbox;
        private System.Windows.Forms.Button valider_button;
        private System.Windows.Forms.ListBox objet_k_listbox;
    }
}