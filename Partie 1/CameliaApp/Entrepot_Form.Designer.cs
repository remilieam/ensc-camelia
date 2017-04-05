namespace CameliaApp
{
    partial class Entrepot_Form
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
            this.rafraichir_button = new System.Windows.Forms.Button();
            this.dynamique_button = new System.Windows.Forms.Button();
            this.chrono_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // rafraichir_button
            // 
            this.rafraichir_button.Location = new System.Drawing.Point(524, 150);
            this.rafraichir_button.Name = "rafraichir_button";
            this.rafraichir_button.Size = new System.Drawing.Size(90, 40);
            this.rafraichir_button.TabIndex = 3;
            this.rafraichir_button.Text = "Rafraîchir";
            this.rafraichir_button.UseVisualStyleBackColor = true;
            this.rafraichir_button.Click += new System.EventHandler(this.Rafraichir_Button_Click);
            // 
            // dynamique_button
            // 
            this.dynamique_button.Location = new System.Drawing.Point(524, 330);
            this.dynamique_button.Name = "dynamique_button";
            this.dynamique_button.Size = new System.Drawing.Size(90, 40);
            this.dynamique_button.TabIndex = 4;
            this.dynamique_button.Text = "Dynamique";
            this.dynamique_button.UseVisualStyleBackColor = true;
            this.dynamique_button.Click += new System.EventHandler(this.Dynamique_Button_Click);
            // 
            // chrono_timer
            // 
            this.chrono_timer.Interval = 1000;
            this.chrono_timer.Tick += new System.EventHandler(this.Chrono_Timer_Tick);
            // 
            // Entrepot_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 524);
            this.Controls.Add(this.dynamique_button);
            this.Controls.Add(this.rafraichir_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Entrepot_Form";
            this.Text = "Entrepôt";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button rafraichir_button;
        private System.Windows.Forms.Button dynamique_button;
        private System.Windows.Forms.Timer chrono_timer;
    }
}