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
using КТАД_lab_1;

namespace КТАД_lab_1
{

    public partial class Form2 : Form
    {
        public static string library = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
        int[] charactersCount = new int[library.Length];
        string fileContent;

        public Form2()
        {
            InitializeComponent();

        }
        public Form2(int[] arr, string fileContent)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            Array.Copy(arr, 0, charactersCount, 0, arr.Length);
            this.fileContent = fileContent;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < library.Length; i++)
            {
                var character = new Label();
                character.BorderStyle = BorderStyle.FixedSingle;
                character.Margin = new Padding(0);
                character.Text = library[i].ToString();
                character.BackColor = Color.CornflowerBlue;

                var occurances = new Label();
                occurances.BorderStyle = BorderStyle.FixedSingle;
                occurances.Margin = new Padding(0);
                occurances.BackColor = Color.CornflowerBlue;
                occurances.Text = charactersCount[i].ToString();

                var ocurr_percent = new Label();
                ocurr_percent.BorderStyle = BorderStyle.FixedSingle;
                ocurr_percent.Margin = new Padding(0);
                ocurr_percent.BackColor = Color.CornflowerBlue;
                if (charactersCount[i] == 0)
                    ocurr_percent.Text = "0";
                else
                    ocurr_percent.Text = Math.Round((double)charactersCount[i] / fileContent.Length, 6).ToString(); ;


                if (i % 2 == 1)
                {
                    //tableLayoutPanel2.ColumnStyles[i/2].Width = 500;
                    tableLayoutPanel2.Controls.Add(character, i / 2 + 1, 1);
                    tableLayoutPanel2.Controls.Add(occurances, i / 2 + 1, 2);
                    tableLayoutPanel2.Controls.Add(ocurr_percent, i / 2 + 1, 3);
                }
                else
                {
                    tableLayoutPanel4.Controls.Add(character, i / 2 + 1, 1);
                    tableLayoutPanel4.Controls.Add(occurances, i / 2 + 1, 2);
                    tableLayoutPanel4.Controls.Add(ocurr_percent, i / 2 + 1, 3);
                }


            }
            tableLayoutPanel2.Update();
            tableLayoutPanel4.Update();

            tableLayoutPanel2.Controls.Add(new Label() { Text = "Char" }, 0, 1);
            tableLayoutPanel2.Controls.Add(new Label() { Text = "Ki" }, 0, 2);
            tableLayoutPanel2.Controls.Add(new Label() { Text = "Pn" }, 0, 3);

            tableLayoutPanel4.Controls.Add(new Label() { Text = "Char" }, 0, 1);
            tableLayoutPanel4.Controls.Add(new Label() { Text = "Ki" }, 0, 2);
            tableLayoutPanel4.Controls.Add(new Label() { Text = "Pn" }, 0, 3);


            label1.Text = "Всього символів: " + charactersCount.Sum().ToString();
            label3.Text = "Pn Min: ";
            label2.Text = "Pn Max: " + library[Array.IndexOf(charactersCount, charactersCount.Max())];
            for (int i = 0; i < GetMinIndexes(charactersCount).Count; i++)
            {
                label3.Text += library[GetMinIndexes(charactersCount)[i]] + " ";
            }
            DrawBarChart(charactersCount);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DrawBarChart(int[] letterCount)
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

            for (int i = 0; i < letterCount.Length; i++)
            {
                series.Points.AddXY(i, 100 * Math.Round((double)charactersCount[i] / fileContent.Length, 3));
                series.Points[i].AxisLabel = library[i].ToString();
            }

            chart.Dock = DockStyle.Fill;
            chartContainer.Controls.Add(chart);
        }
        private static List<int> GetMinIndexes(int[] arr)
        {
            List<int> minIndexes = new List<int>();
            int minVal = arr[0];

            // Находим минимальное значение в массиве
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < minVal)
                {
                    minVal = arr[i];
                }
            }

            // Добавляем все индексы элементов, равных минимальному значению
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == minVal)
                {
                    minIndexes.Add(i);
                }
            }

            return minIndexes;
        }
    }
}
