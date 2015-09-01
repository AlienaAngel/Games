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

				GameContext gameContext;

        private void newGame_btn_Click(object sender, EventArgs e)
        {
						List<ILocation> locations = CreateTowns();
						Hero hero = new Hero();
						gameContext = new GameContext(locations, hero);
            createDrawInterface(hero);
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

				
        public List<ILocation> CreateTowns()
        {
						List<ILocation> locations = new List<ILocation>();

						Tax tax = new Tax("Налоговая", new Triangle(new Point(80, 290), new Point(99, 120), new Point(200, 130), Color.Yellow), new Owner("Имя Фамилия 1"));
						Home home1 = new Home("Дом 1", new Rectangle(70, 25, 50, 60, Color.Red), new Owner("Имя Фамилия 2"));
						Home home2 = new Home("Дом 2", new Rectangle(190, 48, 50, 60, Color.Green), new Owner("Имя Фамилия 3"));
						Home home3 = new Home("Дом 3", new Rectangle(370, 55, 70, 37, Color.DarkOrange), new Owner("Имя Фамилия 4"));

						List<IBuilding> b = new List<IBuilding> { tax, home1, home2, home3 };

						tax.enter += tax_enter;
						home1.enter += tax_enter;
						home2.enter += tax_enter;
						home3.enter += change_location;


						List<IBuilding> bS = new List<IBuilding>();
						Home home = new Home("Дом", new Rectangle(370, 55, 70, 37, Color.SandyBrown), new Owner("None"));
						bS.Add(home);
						home.enter += change_location;
						Suburb suburb = new Suburb(1, bS, Color.Lavender);
						
						Town town = new Town("Айвендейл", 1, b, Color.DodgerBlue, suburb);
						
						locations.Add(town);

						return locations;	
				}

				void tax_enter(IBuilding owner) {
					
					MessageBox.Show(owner.Name);
				}

				void change_location(IBuilding owner) {
					gameContext.IsInSuburb=!gameContext.IsInSuburb;
					drawScene();
				}

	      public void drawScene()
        {
            Graphics g = gameField.CreateGraphics();
						ILocation loc = gameContext.ActiveLocation;
						
						if (gameContext.IsInSuburb) {
							g.Clear(loc.GameFieldColor);
							loc.Suburb.Buildings.ForEach(x => x.Draw(g));
						} else {
							g.Clear(loc.Suburb.GameFieldColor);
							loc.Buildings.ForEach(x => x.Draw(g));
						}
        }

        private void gameField_MouseClick(object sender, MouseEventArgs e)
        {
					gameContext
						.ActiveLocation
						.Buildings
						.ForEach(x => x.Click(e.Location));
        }

    }
}
