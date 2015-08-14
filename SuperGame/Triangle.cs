using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SuperGame
{
    public class Triangle : Shape
    {
        private Point _pt1;
        private Point _pt2;
        private Point _pt3;
        private Color _color;

        public Triangle(Point pt1, Point pt2, Point pt3, Color color)
        {
            _pt1 = pt1;
            _pt2 = pt2;
            _pt3 = pt3;
            _color = color;
        }

        public Point Pt1
        {
            get { return _pt1; }
        }

        public Point Pt2
        {
            get { return _pt2; }
        }

        public Point Pt3
        {
            get { return _pt3; }
        }

        public Color Color
        {
            get { return _color; }
        }

        public override void draw(Graphics g)
        {
            SolidBrush brush = new SolidBrush(_color);
            g.FillPolygon(brush, new Point[3] { _pt1, _pt2, _pt3 });
        }

        public override Color checkHitCoords(Point point)
        {
            return Color.White;
        }
    }
}
