using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChepuhaEditor
{
    public partial class Manual : Form
    {
        public Manual()
        {
            InitializeComponent();
            richTextBox1.Text = "Как этим пользоваться:\nДля начала работы нажмите Файл->Новый либо Файл->Открыть.\nДля добавления новых строчек используйте в нижнем левом углу место для ввода количества добавляемых строк и кнопку.\n Не используйте символ \";\" при вводе, он зарезервирован для других целей. Свои созданные или отредактированные базы помещайте в каталог с программой Чепуха.\n Нашли баг? Пишите мне https://vk.com/natasha_makhnach";
        }
    }
}
