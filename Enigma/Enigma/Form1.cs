using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enigma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }       
        Rotors rot1 = new Rotors();
        Rotors rot2 = new Rotors();
        Rotors rot3 = new Rotors();
        Reflector refl = new Reflector();
        string Alph = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private void Form1_Load(object sender, EventArgs e)
        {
            string r1 = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
            string r2 = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
            string r3 = "BDFHJLCPRTXVZNYEIWGAKMUSQO"; 
            rot1.str = r1.ToCharArray();            
            rot2.str = r2.ToCharArray();            
            rot3.str = r3.ToCharArray();
        }
        //Основная функция для кнопк
        public void Work(char m)
        {            
            richTextBox1.Text += m.ToString();
            // меняем букву в соответствии с коммутатором
            TextBox[] tb = {textBox1, textBox2, textBox3, textBox4, textBox5, textBox6,
             textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13,
             textBox14, textBox15, textBox16, textBox17, textBox18, textBox19,
             textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26};
            string k = m.ToString();
            for (int i=0; i<26;i++)
            {
                if (k == tb[i].Tag.ToString() && tb[i].Text != "")
                {
                    k = tb[i].Text;
                    break;
                }
            }
            //устанавливаем условие вращения роторов            
            if (rot3.a != 25)
                rot3.a++;
            else rot3.a = 0;
            if (rot3.a == 22)
            {
                if (rot2.a != 25)
                    rot2.a++;
                else rot2.a = 0;
                if (rot2.a == 5)
                {
                    if (rot1.a != 25)
                        rot1.a++;
                    else rot1.a = 0;
                }
            }
            // покажем изменение положения ротеров в форме
            textBox27.Text = Alph[rot1.a].ToString();
            textBox28.Text = Alph[rot2.a].ToString();
            textBox29.Text = Alph[rot3.a].ToString();
            int x = Convert.ToInt32(Convert.ToInt32(k[0]) - Convert.ToInt32('A'));
            x = rot3.Right(x);
            x = rot2.Right(x);
            x = rot1.Right(x);
            x = refl.Move(x);         //Рефлектор
            x = rot1.Back(x);
            x = rot2.Back(x);
            x = rot3.Back(x);
            // пропускаем выходное значение через коммутатор
            k = Alph[x].ToString();
            for (int i = 0; i < 26; i++)
            {
                if (k == tb[i].Tag.ToString() && tb[i].Text != "")
                {
                    k = tb[i].Text;
                    break;
                }
            }            
            richTextBox2.Text += k.ToString();
            // массив загорающихся выходных значениях
             Label[] lb = {label1, label2, label3, label4, label5, label6, label7,
             label8, label9, label10, label11, label12, label13, label14, label15,
             label16, label17, label18, label19, label20, label21, label22, label23,
             label24, label25, label26};
            for (int i=0; i<26; i++)
            {
                if (k == lb[i].Text)
                {
                    lb[i].BackColor = Color.Gold;
                }
                else lb[i].BackColor = Color.White;
            }            
        }
        // Ротор 3 правый
        private void TextBox29_TextChanged(object sender, EventArgs e)
        {
            if (textBox29.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else
            {
                textBox30.Visible = false;
                rot3.a = Convert.ToInt32(Convert.ToChar(textBox29.Text)) - Convert.ToInt32('A');
            }
        }        
        // Ротор 2
        private void TextBox28_TextChanged(object sender, EventArgs e)
        {
            if (textBox28.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else
            {
                textBox30.Visible = false;
                rot2.a = Convert.ToInt32(Convert.ToChar(textBox28.Text)) - Convert.ToInt32('A');
            }
        }
        //Ротор 1 левый
        private void TextBox27_TextChanged(object sender, EventArgs e)
        {
            if (textBox27.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else
            {
                textBox30.Visible = false;
                rot1.a = Convert.ToInt32(Convert.ToChar(textBox27.Text)) - Convert.ToInt32('A');
            }
        }
        //Коммутатро Q
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //Коммутатро W
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //Коммутатро E
        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //Коммутатро R
        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //Коммутатор T
        private void TextBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        // Коммутатор Z
        private void TextBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //Коммутатор U
        private void TextBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        // Коммутатор I
        private void TextBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        // Коммутатор O
        private void TextBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //Комутатор A
        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //Коммутатор S
        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        // Коммутатор D
        private void TextBox18_TextChanged(object sender, EventArgs e)
        {
            if (textBox18.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //Коммутатор F
        private void TextBox17_TextChanged(object sender, EventArgs e)
        {
            if (textBox17.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        // Коммутатор G
        private void TextBox16_TextChanged(object sender, EventArgs e)
        {
            if (textBox16.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //Коммутатор H
        private void TextBox15_TextChanged(object sender, EventArgs e)
        {
            if (textBox15.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //Коммутатор J
        private void TextBox14_TextChanged(object sender, EventArgs e)
        {
            if (textBox14.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //Коммутатор K
        private void TextBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //Коммутатор P
        private void TextBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //Коммутатор Y
        private void TextBox23_TextChanged(object sender, EventArgs e)
        {
            if (textBox23.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //Коммутатор X
        private void TextBox22_TextChanged(object sender, EventArgs e)
        {
            if (textBox22.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //коммутатор C
        private void TextBox21_TextChanged(object sender, EventArgs e)
        {
            if (textBox21.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        // Коммутатор V
        private void TextBox20_TextChanged(object sender, EventArgs e)
        {
            if (textBox20.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //Коммутатор B
        private void TextBox19_TextChanged(object sender, EventArgs e)
        {
            if (textBox19.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        // Коммутатор N
        private void TextBox26_TextChanged(object sender, EventArgs e)
        {
            if (textBox26.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        // Коммутатор M
        private void TextBox25_TextChanged(object sender, EventArgs e)
        {
            if (textBox25.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //Коммуатор L
        private void TextBox24_TextChanged(object sender, EventArgs e)
        {
            if (textBox24.Text.Length != 1)
            {
                textBox30.Text = "Вы допустили ошибку!";
                textBox30.Visible = true;
            }
            else textBox30.Visible = false;
        }
        //кнопка E
        private void Button8_Click(object sender, EventArgs e)
        {
            Work('E');
        }
        //Кнопка Q
        private void Button1_Click(object sender, EventArgs e)
        {
            Work('Q');
        }
        //Кнопка W
        private void Button9_Click(object sender, EventArgs e)
        {
            Work('W');
        }
        //Кнопка R
        private void Button7_Click(object sender, EventArgs e)
        {
            Work('R');
        }
        //Кнопка T
        private void Button6_Click(object sender, EventArgs e)
        {
            Work('T');
        }
        //Кнопка Z
        private void Button5_Click(object sender, EventArgs e)
        {
            Work('Z');
        }
        //Кнопка U
        private void Button4_Click(object sender, EventArgs e)
        {
            Work('U');
        }
        //Кнопка I
        private void Button3_Click(object sender, EventArgs e)
        {
            Work('I');
        }
        //Кнопка O
        private void Button2_Click(object sender, EventArgs e)
        {
            Work('O');
        }
        //Кнопка A
        private void Button18_Click(object sender, EventArgs e)
        {
            Work('A');
        }
        //Кнопка S
        private void Button10_Click(object sender, EventArgs e)
        {
            Work('S');
        }
        //Кнопка D
        private void Button11_Click(object sender, EventArgs e)
        {
            Work('D');
        }
        //Кнопка F
        private void Button12_Click(object sender, EventArgs e)
        {
            Work('F');
        }
        //Кнопка G
        private void Button13_Click(object sender, EventArgs e)
        {
            Work('G');
        }
        //Кнопка H
        private void Button14_Click(object sender, EventArgs e)
        {
            Work('H');
        }
        //Кнопка J
        private void Button15_Click(object sender, EventArgs e)
        {
            Work('J');
        }
        //Кнопка K
        private void Button16_Click(object sender, EventArgs e)
        {
            Work('K');
        }
        //Кнопка P
        private void Button26_Click(object sender, EventArgs e)
        {
            Work('P');
        }
        //Кнопка Y
        private void Button17_Click(object sender, EventArgs e)
        {
            Work('Y');
        }
        //Кнопка X
        private void Button19_Click(object sender, EventArgs e)
        {
            Work('X');
        }
        //Кнопка C
        private void Button20_Click(object sender, EventArgs e)
        {
            Work('C');
        }
        //Кнопка V
        private void Button21_Click(object sender, EventArgs e)
        {
            Work('V');
        }
        //Кнопка B
        private void Button22_Click(object sender, EventArgs e)
        {
            Work('B');
        }
        //Кнопка N
        private void Button23_Click(object sender, EventArgs e)
        {
            Work('N');
        }
        //Кнопка M
        private void Button24_Click(object sender, EventArgs e)
        {
            Work('M');
        }
        //Кнопка L
        private void Button25_Click(object sender, EventArgs e)
        {
            Work('L');
        }
    }
}
