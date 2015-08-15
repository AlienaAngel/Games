using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SuperGame
{
    public class Rectangle : Shape
    {
        // X, Y - у тебя же для этого есть Point, не так ли ?)
        //нафига вводить сюда лишний Point? я не вижу особого смысла. Вполне можно и поотдельности
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Color Color { get; private set; }

        public Rectangle(int x, int y, int width, int height, Color color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color;
        }

        public override void Draw(Graphics g)
        { 
            SolidBrush brush= new SolidBrush(Color);
            g.FillRectangle(brush, X, Y, Width, Height);
        }

        public override Color CheckHitCoords(Point point)
        {
            if (point.X >= X && point.Y >= Y)
            {
                if (point.X <= X + Width && point.Y <= Y + Height)
                    return Color;
            }
            return Color.White;
        }

    }
}
