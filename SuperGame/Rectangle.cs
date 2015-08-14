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
        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private Color _color;

        public Rectangle(int x, int y, int width, int height, Color color)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _color = color;
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public Color Color
        {
            get { return _color; }
        }

        public override void draw(Graphics g)
        { 
            SolidBrush brush= new SolidBrush(_color);
            g.FillRectangle(brush, _x, _y, _width, _height);
        }

        public override Color checkHitCoords(Point point)
        {
            if (point.X >= _x && point.Y >= _y)
            {
                if (point.X <= _x + _width && point.Y <= _y + _height)
                    return _color;
            }
            return Color.White;
        }

    }
}
