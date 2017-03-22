namespace entrepot
{
    partial class entrepot_form
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
            this.chariots_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chariots_button
            // 
            this.chariots_button.Location = new System.Drawing.Point(524, 242);
            this.chariots_button.Name = "chariots_button";
            this.chariots_button.Size = new System.Drawing.Size(90, 40);
            this.chariots_button.TabIndex = 0;
            this.chariots_button.Text = "Cliquez ici !";
            this.chariots_button.UseVisualStyleBackColor = true;
            this.chariots_button.Click += new System.EventHandler(this.chariots_button_Click);
            // 
            // entrepot_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 524);
            this.Controls.Add(this.chariots_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "entrepot_form";
            this.Text = "Entrepôt";
            this.Load += new System.EventHandler(this.entrepot_form_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button chariots_button;
    }
}