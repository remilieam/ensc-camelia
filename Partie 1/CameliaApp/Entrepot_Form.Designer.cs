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
            this.detail_button = new System.Windows.Forms.Button();
            this.rafraichir_button = new System.Windows.Forms.Button();
            this.dynamique_button = new System.Windows.Forms.Button();
            this.realite_button = new System.Windows.Forms.Button();
            this.reinitialiser_button = new System.Windows.Forms.Button();
            this.chrono_timer = new System.Windows.Forms.Timer(this.components);
            this.realite_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // detail_button
            // 
            this.detail_button.Location = new System.Drawing.Point(524, 72);
            this.detail_button.Name = "detail_button";
            this.detail_button.Size = new System.Drawing.Size(90, 40);
            this.detail_button.TabIndex = 0;
            this.detail_button.Text = "Détail";
            this.detail_button.UseVisualStyleBackColor = true;
            this.detail_button.Click += new System.EventHandler(this.Detail_Button_Click);
            // 
            // rafraichir_button
            // 
            this.rafraichir_button.Location = new System.Drawing.Point(524, 143);
            this.rafraichir_button.Name = "rafraichir_button";
            this.rafraichir_button.Size = new System.Drawing.Size(90, 40);
            this.rafraichir_button.TabIndex = 1;
            this.rafraichir_button.Text = "Rafraîchir";
            this.rafraichir_button.UseVisualStyleBackColor = true;
            this.rafraichir_button.Click += new System.EventHandler(this.Rafraichir_Button_Click);
            // 
            // dynamique_button
            // 
            this.dynamique_button.Location = new System.Drawing.Point(524, 223);
            this.dynamique_button.Name = "dynamique_button";
            this.dynamique_button.Size = new System.Drawing.Size(90, 40);
            this.dynamique_button.TabIndex = 2;
            this.dynamique_button.Text = "Dynamique";
            this.dynamique_button.UseVisualStyleBackColor = true;
            this.dynamique_button.Click += new System.EventHandler(this.Dynamique_Button_Click);
            // 
            // realite_button
            // 
            this.realite_button.Location = new System.Drawing.Point(524, 300);
            this.realite_button.Name = "realite_button";
            this.realite_button.Size = new System.Drawing.Size(90, 40);
            this.realite_button.TabIndex = 3;
            this.realite_button.Text = "Réalité";
            this.realite_button.UseVisualStyleBackColor = true;
            this.realite_button.Click += new System.EventHandler(this.Realite_Button_Click);
            // 
            // reinitialiser_button
            // 
            this.reinitialiser_button.Location = new System.Drawing.Point(524, 374);
            this.reinitialiser_button.Name = "reinitialiser_button";
            this.reinitialiser_button.Size = new System.Drawing.Size(90, 40);
            this.reinitialiser_button.TabIndex = 4;
            this.reinitialiser_button.Text = "Réinitialiser";
            this.reinitialiser_button.UseVisualStyleBackColor = true;
            this.reinitialiser_button.Click += new System.EventHandler(this.Reinitialiser_Button_Click);
            // 
            // chrono_timer
            // 
            this.chrono_timer.Interval = 1000;
            this.chrono_timer.Tick += new System.EventHandler(this.Chrono_Timer_Tick);
            // 
            // realite_timer
            // 
            this.realite_timer.Interval = 1000;
            this.realite_timer.Tick += new System.EventHandler(this.Realite_Timer_Tick);
            // 
            // Entrepot_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 524);
            this.Controls.Add(this.detail_button);
            this.Controls.Add(this.rafraichir_button);
            this.Controls.Add(this.dynamique_button);
            this.Controls.Add(this.realite_button);
            this.Controls.Add(this.reinitialiser_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Entrepot_Form";
            this.Text = "Entrepôt";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button detail_button;
        private System.Windows.Forms.Button rafraichir_button;
        private System.Windows.Forms.Button dynamique_button;
        private System.Windows.Forms.Button reinitialiser_button;
        private System.Windows.Forms.Button realite_button;
        private System.Windows.Forms.Timer chrono_timer;
        private System.Windows.Forms.Timer realite_timer;
    }
}