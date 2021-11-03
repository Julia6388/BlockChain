using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Шифратор
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     

        private void Button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files'(*.txt| *.txt| All files (*.*)|*.*)";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                FileStream filestream = File.Open(fileName, FileMode.Open, FileAccess.Read);
                if (filestream != null)
                {
                    StreamReader streamreader = new StreamReader(filestream);
                    richTextBox1.Text = streamreader.ReadToEnd();
                    filestream.Close();
                }
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            string Alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

            for (int i = 0; i <= 32; i++)
            {
                char ai = Convert.ToChar(Alph[i]);
            }
            int key = Convert.ToInt32(textBox1.Text);
            string text = richTextBox1.Text;
            for (int i = 0; i < text.Length ; i++)
            {
                char bi = Convert.ToChar(text[i]);
                bi = Convert.ToChar(Convert.ToInt32(bi) + key);
                richTextBox2.Text += Convert.ToString(bi);
            }
            
        }
        
        private void Button8_Click(object sender, EventArgs e)
        {
            richTextBox3.Clear();
            // обрабатываем исходный текст
            int[] A = new int[33];
            string text = richTextBox1.Text;
            string Alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            char[] alp = new char[33];
            for (int i = 0; i < 33; i++)
                alp[i] = Convert.ToChar(Alph[i]);
            for (int i = 0; i < 33; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    char bj = Convert.ToChar(text[j]);
                    if (bj == alp[i])
                        A[i]++;
                }
            }
            for (int i = 0; i < 33; i++)
            {
                for (int k = i + 1; k < 33; k++)
                {
                    if (A[i] < A[k])
                    {
                        int temp = A[i];
                        A[i] = A[k];
                        A[k] = temp;
                        char temps = alp[i];
                        alp[i] = alp[k];
                        alp[k] = temps;
                    }
                }
            }
            // обрабатываем зашифрованный тескт 
            string text2 = richTextBox2.Text;
            int[] A2 = new int[33];
            char[] alp2 = new char[33];
            for (int i = 0; i < 33; i++)
                alp2[i] = Convert.ToChar(Alph[i]);
            for (int i = 0; i < 33; i++)
            {
                for (int j = 0; j < text2.Length; j++)
                {
                    char kj = Convert.ToChar(text2[j]);
                    if (kj == alp2[i])
                        A2[i]++;
                }
            }
            for (int i = 0; i < 33; i++)
            {
                for (int k = i + 1; k < 33; k++)
                {
                    if (A2[i] < A2[k])
                    {
                        int temp = A2[i];
                        A2[i] = A2[k];
                        A2[k] = temp;
                        char temps = alp2[i];
                        alp2[i] = alp2[k];
                        alp2[k] = temps;
                    }
                }
            }
             int key =  Convert.ToInt32(alp2[0]) - Convert.ToInt32(alp[0]) ;
            char[] enc = new char[text2.Length];
            for (int i=0;i<text2.Length; i++)
            {
                enc[i] = Convert.ToChar(Convert.ToInt32(text2[i]) - key);
                richTextBox3.Text += enc[i];
            }
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            string Alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string text2 = richTextBox2.Text;
            int[] A2 = new int[33];
            char[] alp2 = new char[33];
            for (int i = 0; i < 33; i++)
                alp2[i] = Convert.ToChar(Alph[i]);
            for (int i = 0; i < 33; i++)
            {
                for (int j = 0; j < text2.Length; j++)
                {
                    char kj = Convert.ToChar(text2[j]);
                    if (kj == alp2[i])
                        A2[i]++;
                }
            }
            for (int i = 0; i < 33; i++)
            {
                for (int k = i + 1; k < 33; k++)
                {
                    if (A2[i] < A2[k])
                    {
                        int temp = A2[i];
                        A2[i] = A2[k];
                        A2[k] = temp;
                        char temps = alp2[i];
                        alp2[i] = alp2[k];
                        alp2[k] = temps;
                    }
                }
            }
            for (int i = 0; i < 33; i++)
            {
                chart2.Series[0].Points.AddXY(Convert.ToString(alp2[i]), A2[i]);
            }
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            int[] A = new int[33];
            string text = richTextBox1.Text;
            string Alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            char[] alp = new char[33];
            for (int i = 0; i < 33; i++)
                alp[i] = Convert.ToChar(Alph[i]);
            for (int i = 0; i < 33; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    char bj = Convert.ToChar(text[j]);
                    if (bj == alp[i])
                        A[i]++;
                }
            }
            for (int i = 0; i < 33; i++)
            {
                for (int k = i + 1; k < 33; k++)
                {
                    if (A[i] < A[k])
                    {
                        int temp = A[i];
                        A[i] = A[k];
                        A[k] = temp;
                        char temps = alp[i];
                        alp[i] = alp[k];
                        alp[k] = temps;
                    }
                }
                richTextBox2.Text += alp[i].ToString();
            }
            /*  string newal= null;
              for (int i=0;i<33;i++)
              {
                  newal = newal + alp[i].ToString();
              }
            */
            for (int i = 0; i < 33; i++)
            {
                chart1.Series[0].Points.AddXY(Convert.ToString(alp[i]), A[i]);
            }
        }
    }
}
