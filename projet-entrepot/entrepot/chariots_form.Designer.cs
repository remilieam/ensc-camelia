namespace entrepot
{
    partial class chariots_form
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
            this.nbc_label = new System.Windows.Forms.Label();
            this.nbc_textbox = new System.Windows.Forms.TextBox();
            this.nbc_button = new System.Windows.Forms.Button();
            this.chariots_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nbc_label
            // 
            this.nbc_label.Location = new System.Drawing.Point(10, 10);
            this.nbc_label.Name = "nbc_label";
            this.nbc_label.Size = new System.Drawing.Size(280, 20);
            this.nbc_label.TabIndex = 0;
            this.nbc_label.Text = "Combien de chariot(s) souhaitez-vous ajouter ?";
            this.nbc_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nbc_textbox
            // 
            this.nbc_textbox.Location = new System.Drawing.Point(250, 10);
            this.nbc_textbox.Name = "nbc_textbox";
            this.nbc_textbox.Size = new System.Drawing.Size(40, 20);
            this.nbc_textbox.TabIndex = 1;
            // 
            // nbc_button
            // 
            this.nbc_button.Location = new System.Drawing.Point(110, 40);
            this.nbc_button.Name = "nbc_button";
            this.nbc_button.Size = new System.Drawing.Size(80, 30);
            this.nbc_button.TabIndex = 2;
            this.nbc_button.Text = "Valider";
            this.nbc_button.UseVisualStyleBackColor = true;
            this.nbc_button.Click += new System.EventHandler(this.nbc_button_Click);
            // 
            // chariots_button
            // 
            this.chariots_button.Location = new System.Drawing.Point(110, 10);
            this.chariots_button.Name = "chariots_button";
            this.chariots_button.Size = new System.Drawing.Size(80, 30);
            this.chariots_button.TabIndex = 3;
            this.chariots_button.Text = "Valider";
            this.chariots_button.UseVisualStyleBackColor = true;
            this.chariots_button.Visible = false;
            this.chariots_button.Click += new System.EventHandler(this.chariots_button_Click);
            // 
            // chariots_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 80);
            this.Controls.Add(this.chariots_button);
            this.Controls.Add(this.nbc_button);
            this.Controls.Add(this.nbc_textbox);
            this.Controls.Add(this.nbc_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "chariots_form";
            this.Text = "Ajout des chariots";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.chariots_form_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label nbc_label;
        private System.Windows.Forms.TextBox nbc_textbox;
        private System.Windows.Forms.Button nbc_button;
        private System.Windows.Forms.Button chariots_button;
    }
}