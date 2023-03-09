using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace КТАД_lab_1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            DrawBarChart();
        }

        private void chartContainer_Paint(object sender, PaintEventArgs e)
        {

        }
        private void DrawBarChart()
        {
            chartContainer.Controls.Clear();

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            ChartArea chartArea = new ChartArea();
            chartArea.Name = "Кількість символів";
            chartArea.AxisX.Title = "Символи";
            chartArea.AxisY.Title = "%";

            chart.ChartAreas.Add(chartArea);

            Series series = new Series();
            series.Name = "Символи";
            series.ChartType = SeriesChartType.Column;
            chart.Series.Add(series);
            chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

            for (int i = 0; i < Form1.library.Length; i++)
            {
                series.Points.AddXY(i, 100 * Math.Round(Form1.characters[Form1.library[i]] / (decimal)Form1.fileContent.Length, 5));
                if (Form1.library[i] == ' ')
                {
                    series.Points[i].AxisLabel = "space";
                }
                else if(Form1.library[i] == '\n')
                {
                    series.Points[i].AxisLabel = "enter";
                }
                else if (Form1.library[i] == '\r')
                {
                    series.Points[i].AxisLabel = "return";
                }
                else
                {
                    series.Points[i].AxisLabel = Form1.library[i].ToString();
                }
            }

            chart.Dock = DockStyle.Fill;
            chartContainer.Controls.Add(chart);
        }
    }
}
