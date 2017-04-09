namespace CameliaApp
{
    partial class Arbre_Form
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
            this.texte_ouverts_label = new System.Windows.Forms.Label();
            this.chiffre_ouverts_label = new System.Windows.Forms.Label();
            this.texte_fermes_label = new System.Windows.Forms.Label();
            this.chiffre_fermes_label = new System.Windows.Forms.Label();
            this.arbre_treeview = new System.Windows.Forms.TreeView();
            this.fin_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // texte_ouverts_label
            // 
            this.texte_ouverts_label.Location = new System.Drawing.Point(10, 10);
            this.texte_ouverts_label.Name = "texte_ouverts_label";
            this.texte_ouverts_label.Size = new System.Drawing.Size(160, 20);
            this.texte_ouverts_label.TabIndex = 0;
            this.texte_ouverts_label.Text = "Nœuds ouverts :";
            this.texte_ouverts_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chiffre_ouverts_label
            // 
            this.chiffre_ouverts_label.Location = new System.Drawing.Point(180, 10);
            this.chiffre_ouverts_label.Name = "chiffre_ouverts_label";
            this.chiffre_ouverts_label.Size = new System.Drawing.Size(60, 20);
            this.chiffre_ouverts_label.TabIndex = 1;
            this.chiffre_ouverts_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // texte_fermes_label
            // 
            this.texte_fermes_label.Location = new System.Drawing.Point(10, 40);
            this.texte_fermes_label.Name = "texte_fermes_label";
            this.texte_fermes_label.Size = new System.Drawing.Size(160, 20);
            this.texte_fermes_label.TabIndex = 2;
            this.texte_fermes_label.Text = "Nœuds fermés :";
            this.texte_fermes_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chiffre_fermes_label
            // 
            this.chiffre_fermes_label.Location = new System.Drawing.Point(180, 40);
            this.chiffre_fermes_label.Name = "chiffre_fermes_label";
            this.chiffre_fermes_label.Size = new System.Drawing.Size(60, 20);
            this.chiffre_fermes_label.TabIndex = 3;
            this.chiffre_fermes_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // arbre_treeview
            // 
            this.arbre_treeview.Location = new System.Drawing.Point(10, 70);
            this.arbre_treeview.Name = "arbre_treeview";
            this.arbre_treeview.Size = new System.Drawing.Size(230, 230);
            this.arbre_treeview.TabIndex = 4;
            // 
            // fin_button
            // 
            this.fin_button.Location = new System.Drawing.Point(85, 310);
            this.fin_button.Name = "fin_button";
            this.fin_button.Size = new System.Drawing.Size(80, 30);
            this.fin_button.TabIndex = 5;
            this.fin_button.Text = "OK";
            this.fin_button.UseVisualStyleBackColor = true;
            this.fin_button.Click += new System.EventHandler(this.Fin_Button_Click);
            // 
            // Arbre_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 350);
            this.Controls.Add(this.texte_ouverts_label);
            this.Controls.Add(this.chiffre_ouverts_label);
            this.Controls.Add(this.texte_fermes_label);
            this.Controls.Add(this.chiffre_fermes_label);
            this.Controls.Add(this.arbre_treeview);
            this.Controls.Add(this.fin_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "Arbre_Form";
            this.Text = "Arbre de recherche";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Arbre_Form_FormClosed);
        }

        #endregion

        private System.Windows.Forms.Label texte_ouverts_label;
        private System.Windows.Forms.Label chiffre_ouverts_label;
        private System.Windows.Forms.Label texte_fermes_label;
        private System.Windows.Forms.Label chiffre_fermes_label;
        private System.Windows.Forms.TreeView arbre_treeview;
        private System.Windows.Forms.Button fin_button;
    }
}