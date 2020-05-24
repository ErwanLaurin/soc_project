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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.selectCity = new System.Windows.Forms.ComboBox();
            this.origin = new System.Windows.Forms.TextBox();
            this.destination = new System.Windows.Forms.TextBox();
            this.searchRoute = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.elevationChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.elevationChart)).BeginInit();
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
            this.origin.Location = new System.Drawing.Point(281, 85);
            this.origin.Name = "origin";
            this.origin.Size = new System.Drawing.Size(275, 22);
            this.origin.TabIndex = 1;
            this.origin.Tag = "";
            this.origin.TextChanged += new System.EventHandler(this.origin_TextChanged);
            // 
            // destination
            // 
            this.destination.Location = new System.Drawing.Point(281, 128);
            this.destination.Name = "destination";
            this.destination.Size = new System.Drawing.Size(275, 22);
            this.destination.TabIndex = 2;
            // 
            // searchRoute
            // 
            this.searchRoute.Location = new System.Drawing.Point(377, 179);
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
            // elevationChart
            // 
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.Title = "Altitude (m)";
            chartArea1.Name = "ChartArea1";
            this.elevationChart.ChartAreas.Add(chartArea1);
            this.elevationChart.Location = new System.Drawing.Point(645, 200);
            this.elevationChart.Name = "elevationChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Topologie du trajet en vélo";
            this.elevationChart.Series.Add(series1);
            this.elevationChart.Size = new System.Drawing.Size(651, 322);
            this.elevationChart.TabIndex = 5;
            this.elevationChart.Text = "chart1";
            title1.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.TileFlipX;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            title1.Name = "Title1";
            title1.Text = "Topologie du trajet en vélo";
            this.elevationChart.Titles.Add(title1);
            this.elevationChart.Click += new System.EventHandler(this.elevation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Entrez une adresse de départ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Entrez une adresse de destination";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 652);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.elevationChart);
            this.Controls.Add(this.result);
            this.Controls.Add(this.searchRoute);
            this.Controls.Add(this.destination);
            this.Controls.Add(this.origin);
            this.Controls.Add(this.selectCity);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.elevationChart)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart elevationChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

