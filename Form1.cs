using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КТАД_lab_1
{
    public partial class Form1 : Form
    {
        public static string filePath;
        public static string fileContent;
        public static string library;
        public static Dictionary<char, int> characters = new Dictionary<char, int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileContent = string.Empty;
            ClearDictionaryAndLibrary();

            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                var fileStream = openFileDialog1.OpenFile();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
                for (int i = 0; i < fileContent.Length; i++)
                {
                    if (characters.ContainsKey(fileContent[i]))
                        characters[fileContent[i]]++;
                    else
                    {
                        characters.Add(fileContent[i], 1);
                        library += fileContent[i];
                    }
                        
                }
                label3.Text = "Обраний файл: " + filePath.Remove(0, filePath.LastIndexOf("\\") + 1);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fileContent == string.Empty)
            {
                return;
            }
            Form2 form = new Form2();
            form.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fileContent == string.Empty)
            {
                return;
            }
            Form3 form = new Form3();
            form.Show();
        }
        private void ClearDictionaryAndLibrary()
        {
            library = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZzАаБбВвГгҐґДдЕеЄєЖжЗзИиІіЇїЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщьЮюЯя ,<>?!{}[]\';:\"";
            characters.Clear();
            foreach (var charecter in library)
            characters.Add(charecter, 0);
        }
    }
}
