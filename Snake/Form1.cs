using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace RetroSnake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int routeX = 0, routeY = 0;
        Coords coordsHead=new Coords(2,1);
        private int CELL = 30;
        private int ROWS = 21;
        private int COLS = 21;
        private bool food = false;
        private Coords coordsFood = new Coords(1,1);
        private List<SnakeBlock> snakeBody = new List<SnakeBlock>();
        private void StandartSettings()
        {
            snakeBody.RemoveRange(0, snakeBody.Count);
            snakeBody.Add(new SnakeBlock(new Coords(1, 1)));
            //snakeBody.Add(new SnakeBlock(new Coords(0, 1)));
            coordsHead = new Coords(2, 1);
            routeX = 1;
            routeY = 0;
        }

        private void DrawSnake()
        {
            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush bg = new SolidBrush(pictureBox1.BackColor);
            int HOLE = 10;
            g.Clear(pictureBox1.BackColor);
            for (int i = snakeBody.Count-1; i >=0; i--)
            {
                
                //MessageBox.Show(((snakeBody[i].Coords.X) * CELL - CELL).ToString());
                g.FillRectangle(Brushes.Lime, (snakeBody[i].Coords.X-1) * CELL, (snakeBody[i].Coords.Y-1) * CELL, CELL, CELL);
                g.FillRectangle(bg, (snakeBody[i].Coords.X - 1) * CELL + (CELL * HOLE / 100), (snakeBody[i].Coords.Y - 1) * CELL + (CELL * HOLE / 100), CELL - 2 * (CELL * HOLE / 100), CELL - 2 * (CELL * HOLE / 100));
                g.FillRectangle(Brushes.Lime, (snakeBody[i].Coords.X - 1) * CELL + 2 * (CELL * HOLE / 100), (snakeBody[i].Coords.Y - 1) * CELL + 2 * (CELL * HOLE / 100), CELL - 4 * (CELL * HOLE / 100), CELL - 4 * (CELL * HOLE / 100));
            }
            g.FillRectangle(Brushes.Yellow, (coordsHead.X - 1) * CELL, (coordsHead.Y - 1) * CELL, CELL, CELL);
            g.FillRectangle(bg, (coordsHead.X - 1) * CELL + (CELL * HOLE / 100), (coordsHead.Y - 1) * CELL + (CELL * HOLE / 100), CELL - 2 * (CELL * HOLE / 100), CELL - 2 * (CELL * HOLE / 100));
            g.FillRectangle(Brushes.Yellow, (coordsHead.X - 1) * CELL + 2 * (CELL * HOLE / 100), (coordsHead.Y - 1) * CELL + 2 * (CELL * HOLE / 100), CELL - 4 * (CELL * HOLE / 100), CELL - 4 * (CELL * HOLE / 100));
            if (food)
            {
                g.FillRectangle(Brushes.Red, (coordsFood.X - 1) * CELL + 2 * (CELL * HOLE / 100), (coordsFood.Y - 1) * CELL + 2 * (CELL * HOLE / 100), CELL - 4 * (CELL * HOLE / 100), CELL - 4 * (CELL * HOLE / 100));
            }
            /*if (fail())
            {
                g.Clear(pictureBox1.BackColor);
            }*/
            //MessageBox.Show(snakeBody[0].Coords.Y.ToString());
            
        }

        private void gameStart_btn_Click(object sender, EventArgs e)
        {
            timer1.Start();
            gameStart_btn.Visible = false;
            gameStart_btn.Enabled = false;
            StandartSettings();
            DrawSnake();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    {
                        if (routeX != 0 || routeY != 1)
                        { 
                            routeX = 0; routeY = -1;
                        }
                        break;
                    }
                case Keys.A:
                    {
                        if (routeX != 1 || routeY != 0)
                        { 
                            routeX = -1; routeY = 0;
                        }
                        break;
                    }
                case Keys.S:
                    {
                        
                        if (routeX != 0 || routeY != -1)
                        {
                            routeX = 0; routeY = 1;
                        }
                        break;
                    }
                case Keys.D:
                    {
                        if (routeX != -1 || routeY != 0)
                        {
                            routeX = 1; routeY = 0;
                        }
                        break;
                    }
            }
        }

        private Coords getCoordsFood()
        {
            bool busy = false;
            int x, y;
            Random rnd = new Random();
            do
            {
                x = rnd.Next(ROWS) + 1;
                y = rnd.Next(COLS) + 1;
                busy = false;
                for (int i = 0; i < snakeBody.Count && !busy; i++)
                {
                    if (snakeBody[i].Coords.X == x && snakeBody[i].Coords.Y == y)
                    {
                        busy = true;
                    }
                }
                if (coordsHead.X == x && coordsHead.Y == y)
                {
                    busy = true;
                }
            } while (busy);
            //MessageBox.Show(x.ToString()+"  "+y.ToString());
            //StreamWriter writer = new StreamWriter("log.txt");
            //writer.WriteLine(x + ";" + y);
            //writer.Close();

            return(new Coords(x,y));
        }

        private void checkFood()
        {
           // MessageBox.Show(food.ToString());
            if(food && coordsHead.X == coordsFood.X && coordsHead.Y == coordsFood.Y)
            {
                addBlock();
                food = false;
            }
        }



        private void addBlock()
        {
            int xp=0;
            int yp=0;
            if (snakeBody.Count >= 2)
            {
                if (snakeBody[snakeBody.Count - 1].Coords.X > snakeBody[snakeBody.Count - 2].Coords.X)
                {
                    xp = 1;
                    yp = 0;
                }
                else
                {
                    xp = -1;
                    yp = 0;
                }
                if (snakeBody[snakeBody.Count - 1].Coords.Y > snakeBody[snakeBody.Count - 2].Coords.Y)
                {
                    xp = 0;
                    yp = 1;
                }
                else
                {
                    xp = 0;
                    yp = -1;
                }
            }
            else
            {
                if (snakeBody[snakeBody.Count - 1].Coords.X > coordsHead.X)
                {
                    xp = 1;
                    yp = 0;
                }
                else
                {
                    xp = -1;
                    yp = 0;
                }
                if (snakeBody[snakeBody.Count - 1].Coords.Y > coordsHead.Y)
                {
                    xp = 0;
                    yp = 1;
                }
                else
                {
                    xp = 0;
                    yp = -1;
                }
            }
            snakeBody.Add(new SnakeBlock(new Coords(snakeBody[snakeBody.Count - 1].Coords.X +xp, snakeBody[snakeBody.Count - 1].Coords.Y+yp)));
            //MessageBox.Show(snakeBody[snakeBody.Count-1].Coords.X.ToString());
        }
        private void checkCoords()
        {
            if (coordsHead.X > COLS) coordsHead.X = 1;
            if (coordsHead.X < 1) coordsHead.X = COLS;
            if (coordsHead.Y > ROWS) coordsHead.Y = 1;
            if (coordsHead.Y < 1) coordsHead.Y = ROWS;
        }

        private bool fail()
        {
            bool fl = false;
            for (int i = 0; i < snakeBody.Count && !fl; i++)
            {
                if (coordsHead.X == snakeBody[i].Coords.X && coordsHead.Y == snakeBody[i].Coords.Y)
                {
                    fl = true;
                }
            }
            return fl;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            checkCoords();
            if (!food)
            {
                coordsFood = getCoordsFood();
                food = true;
            }
            checkFood();
            Coords temp = new Coords(snakeBody[0].Coords.X, snakeBody[0].Coords.Y);
            snakeBody[0].Coords.X = coordsHead.X;
            snakeBody[0].Coords.Y = coordsHead.Y; 
            Coords temp1;
            for (int i = 1; i < snakeBody.Count; i++)
            {
                temp1 = new Coords(snakeBody[i].Coords.X, snakeBody[i].Coords.Y);
                snakeBody[i].Coords.X = temp.X;
                snakeBody[i].Coords.Y = temp.Y;
                temp = temp1;
            }
            coordsHead.X += routeX;
            coordsHead.Y += routeY;
            DrawSnake();
            if (fail())
            {
               // MessageBox.Show("Лох");
                StandartSettings();
            }
           // MessageBox.Show(snakeBody[0].Coords.X.ToString() + "  " + snakeBody[1].Coords.X.ToString());
        }

    }
}
