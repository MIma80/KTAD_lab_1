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

        public Form2()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.AppendText("Символ\t|Kx\t|Pn" + Environment.NewLine);
            for (int i = 0; i < Form1.characters.Count; i++)
            {
                string temp;
                if (Form1.library[i] == '\n')
                    temp = "\"enter\"" + "\t|" + Form1.characters[Form1.library[i]] + "\t|" + Math.Round(Form1.characters[Form1.library[i]] / (decimal)Form1.fileContent.Length, 5);
                else if(Form1.library[i] == '\r')
                    temp = "\"return\"" + "\t|" + Form1.characters[Form1.library[i]] + "\t|" + Math.Round(Form1.characters[Form1.library[i]] / (decimal)Form1.fileContent.Length, 5);
                else if (Form1.library[i] == ' ')
                    temp = "\"space\"" + "\t|" + Form1.characters[Form1.library[i]] + "\t|" + Math.Round(Form1.characters[Form1.library[i]] / (decimal)Form1.fileContent.Length, 5);
                else
                    temp = "\"" + Form1.library[i] + "\"" + "\t|" + Form1.characters[Form1.library[i]] + "\t|" + Math.Round(Form1.characters[Form1.library[i]] / (decimal)Form1.fileContent.Length, 5);
                textBox1.AppendText(temp + Environment.NewLine);
            }
            int letterCount = 0;
            Form1.library.ToCharArray().ToList().ForEach(delegate (char i) {
                letterCount += Form1.characters[i];
            });
            label1.Text = "Всього символів: " + letterCount;
            label2.Text = "Pn MAX: " + FindAllMax();
            label3.Text = "Pn MIN: " + FindAllMin();

        }

        private string FindAllMin()
        {
            int min = 1;
            List<char> list = new List<char>();
            foreach (var item in Form1.library)
            {
                if (min > Form1.characters[item] && Form1.characters[item] != 0)
                {
                    min = Form1.characters[item];
                }
            }
            foreach (var item in Form1.library)
            {
                if (min == Form1.characters[item])
                {
                    list.Add(item);
                }
            }
            string result = string.Empty;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == '\n')
                    result += "\"enter\" ";
                else if (list[i] == '\r')
                    result += "\"return\" ";
                else if (list[i] == ' ')
                    result += "\"space\" ";
                else
                    result += "\"" + list[i] + "\" ";
            }
            return result;
        }
        private string FindAllMax()
        {
            int max = Form1.characters[Form1.library[0]];
            List<char> list = new List<char>();
            foreach (var item in Form1.library)
            {
                if (max < Form1.characters[item])
                {
                    max = Form1.characters[item];
                }
            }
            foreach (var item in Form1.library)
            {
                if (max == Form1.characters[item])
                {
                    list.Add(item);
                }
            }
            string result = string.Empty;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == '\n')
                    result += "\"enter\" ";
                else if (list[i] == '\r')
                    result += "\"return\" ";
                else if (list[i] == ' ')
                    result += "\"space\" ";
                else
                    result += "\"" + list[i] + "\" ";
            }
            return result;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
