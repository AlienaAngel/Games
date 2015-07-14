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

namespace Chepuha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Line> Base = new List<Line>();
        public delegate void del();
        private void generateChepuha()
        {
            if (Base.Count > 0)
            {
                Random rnd = new Random();
                richTextBox1.Text = Base[rnd.Next(Base.Count)].Who + " " + Base[rnd.Next(Base.Count)].WithWhom + " " + Base[rnd.Next(Base.Count)].WhatDoing + ",\n";
                richTextBox1.Text += "чтобы " + Base[rnd.Next(Base.Count)].Why + " " + Base[rnd.Next(Base.Count)].Where + ",\n";
                string tempWhoCame = Base[rnd.Next(Base.Count)].WhoCame;
                string gender = "И сказал: ";
                var tempWhoCameSplit = tempWhoCame.Split(' ');
                if (tempWhoCameSplit[0] == "пришла")
                {
                    gender = "И сказала: ";
                }
                richTextBox1.Text += Base[rnd.Next(Base.Count)].When + ", " + tempWhoCame + ",\n";
                richTextBox1.Text += gender + Base[rnd.Next(Base.Count)].WhatSaid + "\n";
                richTextBox1.Text += "В конце концов " + Base[rnd.Next(Base.Count)].End;
            }
            else
            {
                MessageBox.Show("База не загружена");
            }
        }

        private void generate_btn_Click(object sender, EventArgs e)
        {
            del generate = generateChepuha; //если кто-то будет расширять этот бред, используйте делегаты для динамического полиморфизма
            generate();                          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string filename = "base.txt";
            loadBase(filename);
            //тут надо будет загружать по базе для каждого шаблона, если кто-то будет дописывать это
            

        }

        public void loadBase(string filename)
        {
            Base.RemoveRange(0, Base.Count);
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        var s = reader.ReadLine();
                        var lines = s.Split(';');
                        Line tempLine = new Line(lines[0], lines[1], lines[2], lines[3], lines[4], lines[5], lines[6], lines[7], lines[8]);
                        Base.Add(tempLine);
                    }
                }
            }
            catch (FileNotFoundException )
            {
                MessageBox.Show("Указанный файл не найден в каталоге с программой");
            }
            catch (Exception )
            {
                MessageBox.Show("Не удается прочитать файл");
            }
        }

        private void loadBase_btn_Click(object sender, EventArgs e)
        {
            loadBase(textBox1.Text);
        }

        private void aboutProgram_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Файл с базой должен лежать в том же каталоге, что и .exe файл\nВ каждой строке должны быть 9 значений, разделенных знаком \";\"\n https://vk.com/natasha_makhnach");
        }

        private bool checkColor = true;
        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            if (checkColor)
            {
                BackColor = Color.White;
                ForeColor = Color.Black;
                loadBase_btn.BackColor = Color.White;
                aboutProgram_btn.BackColor = Color.White;
                generate_btn.BackColor = Color.White;
                loadBase_btn.ForeColor = Color.Black;
                aboutProgram_btn.ForeColor = Color.Black;
                generate_btn.ForeColor = Color.Black;
                textBox1.BackColor = Color.White;
                textBox1.ForeColor = Color.Black;
                richTextBox1.BackColor = Color.White;
                richTextBox1.ForeColor = Color.Black;
                checkColor = false;
            }
            else
            {
                BackColor = Color.DarkSlateGray;
                ForeColor = Color.White;
                loadBase_btn.BackColor = Color.DarkSlateGray;
                aboutProgram_btn.BackColor = Color.DarkSlateGray;
                generate_btn.BackColor = Color.DarkSlateGray;
                loadBase_btn.ForeColor = Color.White;
                aboutProgram_btn.ForeColor = Color.White;
                generate_btn.ForeColor = Color.White;
                textBox1.BackColor = Color.DarkSlateGray;
                textBox1.ForeColor = Color.White;
                richTextBox1.BackColor = Color.DarkSlateGray;
                richTextBox1.ForeColor = Color.White;
                checkColor = true;
            }
        }
    }
}
