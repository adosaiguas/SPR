using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SPR.Forms
{
    public partial class ChartsForm : Form
    {
        public ChartsForm()
        {
            InitializeComponent();
        }

        private void ChartsForm_Load(object sender, EventArgs e)
        {

        }

       public void createMockChart()
        {
            double yValueCPU, yValueIODisk, yValueRAM, yValueIISSessions;
            yValueCPU = 50.0;
            yValueIODisk = 25.0;
            yValueRAM = 90.0;
            yValueIISSessions = 15.0;

            Random random = new Random();
            this.chartName.Series.Clear();
            this.chartName.Series.Add("CPU");
            this.chartName.Series.Add("IO");
            this.chartName.Series.Add("RAM");
            this.chartName.Series.Add("IIS Sessions");

            for (int pointIndex = 0; pointIndex < 20000; pointIndex++)
            {
                yValueCPU = yValueCPU + (random.NextDouble() * 10.0 - 5.0);
                yValueIODisk = yValueIODisk + (random.NextDouble() * 10.0 - 5.0);
                yValueRAM = yValueRAM + (random.NextDouble() * 10.0 - 5.0);
                yValueIISSessions = yValueIISSessions + (random.NextDouble() * 10.0 - 5.0);

                this.chartName.Series["CPU"].Points.AddY(yValueCPU);
                this.chartName.Series["IO"].Points.AddY(yValueIODisk);
                this.chartName.Series["RAM"].Points.AddY(yValueRAM);
                this.chartName.Series["IIS Sessions"].Points.AddY(yValueIISSessions);
            }

            chartName.Series["CPU"].ChartType = SeriesChartType.FastLine;
            chartName.Series["IO"].ChartType = SeriesChartType.FastLine;
            chartName.Series["RAM"].ChartType = SeriesChartType.FastLine;
            chartName.Series["IIS Sessions"].ChartType = SeriesChartType.FastLine;

            Directory.CreateDirectory("charts");
            chartName.SaveImage("charts\\mockChart.jpg", ChartImageFormat.Jpeg);

        }
    }
}
