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

namespace ChepuhaEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Line> Base = new List<Line>();
        int COLUMN_COUNT = 9;


        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти? Несохраненные данные не будут сохранены", "Выход", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                setStartSettings();
                loadBase(openFileDialog1.FileName);
                writeToDataGridView(Base, dataGridView1);
            }
            label4.Text = dataGridView1.RowCount.ToString();
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
            catch (FileNotFoundException)
            {
                MessageBox.Show("Указанный файл не найден");
            }
            catch (Exception)
            {
                MessageBox.Show("Не удается прочитать файл");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = COLUMN_COUNT;
            List<string> columnHeaders = new List<string>();
            initColumnHeadersList(columnHeaders);
            setColumnHeaders(columnHeaders);
        }

        private void initColumnHeadersList(List<string> columnHeaders)
        {
            columnHeaders.Add("Кто");
            columnHeaders.Add("С кем");
            columnHeaders.Add("Что делали");
            columnHeaders.Add("Зачем");
            columnHeaders.Add("Где");
            columnHeaders.Add("Когда");
            columnHeaders.Add("Кто пришел");
            columnHeaders.Add("Что сказал");
            columnHeaders.Add("Чем дело кончилось");
        }

        private void setColumnHeaders(List<string> columnHeaders)
        {
            for (int i = 0; i < COLUMN_COUNT; i++)
            {
                dataGridView1.Columns[i].HeaderText = columnHeaders[i];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool validity = false;
            int rowsCount = -1;
            validity = int.TryParse(textBox1.Text, out rowsCount);
            if (validity && rowsCount < 0)
            {
                validity = false;
            }
            if (validity)
            {
                dataGridView1.RowCount += rowsCount;
            }
            label4.Text = dataGridView1.RowCount.ToString();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                readFromDataGridView(out Base);
                writeToFile(Base, saveFileDialog1.FileName);
            }
        }

        private void readFromDataGridView(out List<Line> db)
        {
            db = new List<Line>();
            if (checkValidDataGrid(dataGridView1))
            {
                db.RemoveRange(0, db.Count);
                for (int row = 0; row < dataGridView1.RowCount; row++)
                {
                    Line tempLine = new Line(dataGridView1[0, row].Value.ToString(), dataGridView1[1, row].Value.ToString(), dataGridView1[2, row].Value.ToString(), dataGridView1[3, row].Value.ToString(), dataGridView1[4, row].Value.ToString(), dataGridView1[5, row].Value.ToString(), dataGridView1[6, row].Value.ToString(), dataGridView1[7, row].Value.ToString(), dataGridView1[8, row].Value.ToString());
                    db.Add(tempLine);
                }
            }

        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setStartSettings();
            for (int row = 0; row < dataGridView1.RowCount; row++)
            {
                dataGridView1.Rows.Clear();
            }
            label4.Text = dataGridView1.RowCount.ToString();

        }

        private void setStartSettings()
        {
            dataGridView1.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
            сохранитьКакToolStripMenuItem.Enabled = true;
            Base.RemoveRange(0,Base.Count);
            textBox2.Visible = true;
            button2.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
        }

       
        private bool checkValidDataGrid(DataGridView dataGridView1)
        {
            bool validity = false;
            for (int row = 0; row < dataGridView1.RowCount; row++)
            {
                validity = true;
                for (int col = 0; col < dataGridView1.ColumnCount && validity; col++)
                {
                    if (dataGridView1[col, row].Value == null || dataGridView1[col,row].Value.ToString().Contains(';'))
                    {
                        //MessageBox.Show("[" + col.ToString() + "," + row.ToString() + "]");
                        validity = false;
                    }
                }
                if (!validity)
                {
                    MessageBox.Show("Возможно есть пустые строки или точка с запятой");
                    break;
                }
            }
            if (dataGridView1.ColumnCount < 1)
            {
                validity = false;
            }
            return validity;
        }

        private void writeToFile(List<Line> db, string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            for(int i=0;i<db.Count;i++)
            {
                string line;
                line = db[i].Who;
                line += ";" + db[i].WithWhom;
                line += ";" + db[i].WhatDoing;
                line += ";" + db[i].Why;
                line += ";" + db[i].Where;
                line += ";" + db[i].When;
                line += ";" + db[i].WhoCame;
                line += ";" + db[i].WhatSaid;
                line += ";" + db[i].End;
                if (i <= db.Count - 2)
                {
                    writer.WriteLine(line);
                }
                else
                {
                    writer.Write(line);
                }
            }
            writer.Close();
        }

        private void writeToDataGridView(List<Line> db, DataGridView dataGridView1)
        {
            dataGridView1.RowCount = db.Count;
            label4.Text = dataGridView1.RowCount.ToString();
            //dataGridView1.ColumnCount = COLUMN_COUNT;

            if (db.Count > 0)
            {
                for (int row = 0; row < db.Count; row++)
                {
                    dataGridView1[0, row].Value = db[row].Who;
                    dataGridView1[1, row].Value = db[row].WithWhom;
                    dataGridView1[2, row].Value = db[row].WhatDoing;
                    dataGridView1[3, row].Value = db[row].Why;
                    dataGridView1[4, row].Value = db[row].Where;
                    dataGridView1[5, row].Value = db[row].When;
                    dataGridView1[6, row].Value = db[row].WhoCame;
                    dataGridView1[7, row].Value = db[row].WhatSaid;
                    dataGridView1[8, row].Value = db[row].End;
                }
            }
            else
            {
                MessageBox.Show("С файлом что-то не то...");
            }
        }

        private void просмотрСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manual manual = new Manual();
            manual.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool validity = false;
            int rowsCount = -1;
            validity = int.TryParse(textBox2.Text, out rowsCount);
            if (rowsCount > dataGridView1.RowCount)
            {
                validity = false;
            }
            if (validity)
            {
                dataGridView1.RowCount -= rowsCount;
            }
            label4.Text = dataGridView1.RowCount.ToString();
        }

            
    }
}
