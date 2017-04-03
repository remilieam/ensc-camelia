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
            this.chariots_button = new System.Windows.Forms.Button();
            this.distance_button = new System.Windows.Forms.Button();
            this.temps_button = new System.Windows.Forms.Button();
            this.rafraichir_button = new System.Windows.Forms.Button();
            this.dynamique_button = new System.Windows.Forms.Button();
            this.chrono_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // chariots_button
            // 
            this.chariots_button.Location = new System.Drawing.Point(524, 40);
            this.chariots_button.Name = "chariots_button";
            this.chariots_button.Size = new System.Drawing.Size(90, 40);
            this.chariots_button.TabIndex = 0;
            this.chariots_button.Text = "Ajouter des chariots";
            this.chariots_button.UseVisualStyleBackColor = true;
            this.chariots_button.Click += new System.EventHandler(this.Chariots_Button_Click);
            // 
            // distance_button
            // 
            this.distance_button.Location = new System.Drawing.Point(524, 131);
            this.distance_button.Name = "distance_button";
            this.distance_button.Size = new System.Drawing.Size(90, 40);
            this.distance_button.TabIndex = 1;
            this.distance_button.Text = "Distance";
            this.distance_button.UseVisualStyleBackColor = true;
            this.distance_button.Click += new System.EventHandler(this.Distance_Button_Click);
            // 
            // temps_button
            // 
            this.temps_button.Location = new System.Drawing.Point(524, 226);
            this.temps_button.Name = "temps_button";
            this.temps_button.Size = new System.Drawing.Size(90, 40);
            this.temps_button.TabIndex = 2;
            this.temps_button.Text = "Temps";
            this.temps_button.UseVisualStyleBackColor = true;
            this.temps_button.Click += new System.EventHandler(this.Temps_Button_Click);
            // 
            // rafraichir_button
            // 
            this.rafraichir_button.Location = new System.Drawing.Point(524, 304);
            this.rafraichir_button.Name = "rafraichir_button";
            this.rafraichir_button.Size = new System.Drawing.Size(90, 40);
            this.rafraichir_button.TabIndex = 3;
            this.rafraichir_button.Text = "Rafraîchir";
            this.rafraichir_button.UseVisualStyleBackColor = true;
            this.rafraichir_button.Click += new System.EventHandler(this.Rafraichir_Button_Click);
            // 
            // dynamique_button
            // 
            this.dynamique_button.Location = new System.Drawing.Point(524, 392);
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
            this.Controls.Add(this.temps_button);
            this.Controls.Add(this.distance_button);
            this.Controls.Add(this.chariots_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Entrepot_Form";
            this.Text = "Entrepôt";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button chariots_button;
        private System.Windows.Forms.Button distance_button;
        private System.Windows.Forms.Button temps_button;
        private System.Windows.Forms.Button rafraichir_button;
        private System.Windows.Forms.Button dynamique_button;
        private System.Windows.Forms.Timer chrono_timer;
    }
}