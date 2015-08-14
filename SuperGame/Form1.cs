using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Hero hero = new Hero();
        public List<Town> towns = new List<Town>();
        public int currentTownId = 1;

        private void newGame_btn_Click(object sender, EventArgs e)
        {
            createDrawInterface(hero);
            createTowns();
            drawScene();
        }


        Label health_lbl;
        Label mana_lbl;
        Label weight_lbl;
        Label money_lbl;
        Panel interface_panel;
        Button inventory_btn;
        public void createDrawInterface(Hero hero)
        {
            Color back = new Color();
            back = Color.White;

            health_lbl = new Label();
            health_lbl.Name = "health_lbl";
            health_lbl.Text = "Здоровье "+hero.Health.ToString();
            health_lbl.ForeColor = Color.Red;
            health_lbl.BackColor = back;
            health_lbl.Location = new Point(90, 400);
            health_lbl.BringToFront();
            Controls.Add(health_lbl);

            mana_lbl = new Label();
            mana_lbl.Name = "mana_lbl";
            mana_lbl.Text = "Мана " + hero.Mana.ToString();
            mana_lbl.ForeColor = Color.Blue;
            mana_lbl.BackColor = back;
            mana_lbl.Location = new Point(450, 400);
            Controls.Add(mana_lbl);

            weight_lbl = new Label();
            weight_lbl.Name = "weight_lbl";
            weight_lbl.Text = "Вес " + hero.Weight.ToString()+"/"+hero.Capacity.ToString();
            weight_lbl.ForeColor = Color.Black;
            weight_lbl.BackColor = back;
            weight_lbl.Location = new Point(90, 425);
            Controls.Add(weight_lbl);

            money_lbl = new Label();
            money_lbl.Name = "money_lbl";
            money_lbl.Text = "Золото " + hero.Money.ToString();
            money_lbl.ForeColor = Color.Goldenrod;
            money_lbl.BackColor = back;
            money_lbl.Location = new Point(450, 425);
            Controls.Add(money_lbl);

            inventory_btn = new Button();
            inventory_btn.Name = "inventory_btn";
            inventory_btn.Text = "Рюкзак";
            inventory_btn.BackColor = back;
            inventory_btn.Location = new Point(550, 400);
            inventory_btn.Click += new EventHandler (inventory_btn_Click); 
            Controls.Add(inventory_btn);

            interface_panel = new Panel();
            interface_panel.Location = new Point(0, 370);
            interface_panel.Width = 635;
            interface_panel.Height = 100;
            interface_panel.BackColor = back;
            Controls.Add(interface_panel);

            Graphics g = interface_panel.CreateGraphics();
            g.FillRectangle(Brushes.Black, 0, 0, interface_panel.Width, 3);
        }

        private void inventory_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Здесь замешаны делегаты");
        }

        public void createTowns()
        { 
            List<Shape> obj = new List<Shape>();
            obj.Add(new Rectangle(70, 25, 50, 60, Color.Red));
            obj.Add(new Rectangle(190, 48, 50, 60, Color.Green));
            obj.Add(new Triangle(new Point(80, 290), new Point(99, 120), new Point(200, 130), Color.Yellow));
            Town town = new Town("Айвендейл", 1, obj);
            towns.Add(town);

        }

        
        public void drawScene()
        {
            Graphics g = gameField.CreateGraphics();
            for (int i = 0; i < towns.Count; i++)
            {
                if (currentTownId == towns[i].Id)
                {
                    for (int j = 0; j < towns[i].Objects.Count; j++)
                    {
                        towns[i].Objects[j].Draw(g);
                    }
                }
            }
        }

        private void gameField_MouseClick(object sender, MouseEventArgs e)
        {
            Color clr = new Color();
            clr = Color.White;
            for (int i = 0; i < towns[currentTownId - 1].Objects.Count; i++) // !
            {
                clr = towns[currentTownId - 1].Objects[i].CheckHitCoords(e.Location);
                if (clr != Color.White)
                {
                    break;
                }
            }
            if (clr == Color.Red)
            {
                MessageBox.Show("Красный");
            }
            else
            {
                if (clr == Color.Green)
                {
                    MessageBox.Show("Зеленый");
                }

            }
        }

    }
}
