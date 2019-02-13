namespace SPR.Forms
{
    partial class ChartsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartName = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartName)).BeginInit();
            this.SuspendLayout();
            // 
            // chartName
            // 
            this.chartName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.chartName.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            chartArea1.Name = "ChartArea1";
            this.chartName.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartName.Legends.Add(legend1);
            this.chartName.Location = new System.Drawing.Point(16, 15);
            this.chartName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartName.Name = "chartName";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "CPU";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series2.Legend = "Legend1";
            series2.Name = "IO";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.Teal;
            series3.Legend = "Legend1";
            series3.Name = "RAM";
            series4.ChartArea = "ChartArea1";
            series4.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            series4.Legend = "Legend1";
            series4.Name = "IIS Sessions";
            this.chartName.Series.Add(series1);
            this.chartName.Series.Add(series2);
            this.chartName.Series.Add(series3);
            this.chartName.Series.Add(series4);
            this.chartName.Size = new System.Drawing.Size(735, 369);
            this.chartName.TabIndex = 0;
            this.chartName.Text = "chartCPU";
            // 
            // ChartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.chartName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ChartsForm";
            this.Text = "ChartCPU";
            this.Load += new System.EventHandler(this.ChartsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartName;
    }
}