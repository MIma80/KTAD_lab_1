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
        public string filePath;
        public string fileContent;
        public static string library = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
        public int[] charCount = new int[library.Length];
        public HashSet<char> characters = new HashSet<char>() {};
        public Form1()
        {
            InitializeComponent();
            foreach (var item in library)
            {
                characters.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                List<char> list = fileContent.ToCharArray().ToList();
                list.RemoveAll(p => library.Contains(p) == false);
                fileContent = String.Empty;
                for (int i = 0; i < list.Count; i++)
                {
                    fileContent += list[i];
                }
                label3.Text = "Обраний файл: " + filePath.Remove(0, filePath.LastIndexOf("\\") + 1);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fileContent == null)
            {
                return;
            }
            Array.Clear(charCount, 0, charCount.Length);
            foreach (char character in fileContent)
            {
                if (characters.Contains(character))
                {
                    charCount[library.IndexOf(character)]++;
                }
            }
            Form2 form = new Form2(charCount, fileContent);
            form.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
