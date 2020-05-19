namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectCity = new System.Windows.Forms.ComboBox();
            this.origin = new System.Windows.Forms.TextBox();
            this.destination = new System.Windows.Forms.TextBox();
            this.searchRoute = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // selectCity
            // 
            this.selectCity.FormattingEnabled = true;
            this.selectCity.Location = new System.Drawing.Point(53, 33);
            this.selectCity.Name = "selectCity";
            this.selectCity.Size = new System.Drawing.Size(188, 24);
            this.selectCity.TabIndex = 0;
            this.selectCity.Text = "Sélectionnez une ville";
            this.selectCity.SelectedIndexChanged += new System.EventHandler(this.selectCity_SelectedIndexChanged);
            // 
            // origin
            // 
            this.origin.Location = new System.Drawing.Point(53, 93);
            this.origin.Name = "origin";
            this.origin.Size = new System.Drawing.Size(275, 22);
            this.origin.TabIndex = 1;
            this.origin.Text = "Entrez une adresse de départ";
            // 
            // destination
            // 
            this.destination.Location = new System.Drawing.Point(53, 132);
            this.destination.Name = "destination";
            this.destination.Size = new System.Drawing.Size(275, 22);
            this.destination.TabIndex = 2;
            this.destination.Text = "Entrez une adresse de destination";
            // 
            // searchRoute
            // 
            this.searchRoute.Location = new System.Drawing.Point(149, 172);
            this.searchRoute.Name = "searchRoute";
            this.searchRoute.Size = new System.Drawing.Size(179, 23);
            this.searchRoute.TabIndex = 3;
            this.searchRoute.Text = "Rechercher un itinéraire";
            this.searchRoute.UseVisualStyleBackColor = true;
            this.searchRoute.Click += new System.EventHandler(this.searchRoute_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(53, 222);
            this.result.Multiline = true;
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(571, 254);
            this.result.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 492);
            this.Controls.Add(this.result);
            this.Controls.Add(this.searchRoute);
            this.Controls.Add(this.destination);
            this.Controls.Add(this.origin);
            this.Controls.Add(this.selectCity);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox selectCity;
        private System.Windows.Forms.TextBox origin;
        private System.Windows.Forms.TextBox destination;
        private System.Windows.Forms.Button searchRoute;
        private System.Windows.Forms.TextBox result;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

