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
        public Point Pt1 { get; private set; }
        public Point Pt2 { get; private set; }
        public Point Pt3 { get; private set; }
        public Color Color { get; private set; }

        public Triangle(Point pt1, Point pt2, Point pt3, Color color)
        {
            Pt1 = pt1;
            Pt2 = pt2;
            Pt3 = pt3;
            Color = color;
        }

        public override void Draw(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color);
            g.FillPolygon(brush, new Point[3] { Pt1, Pt2, Pt3 });
        }

        public override Color CheckHitCoords(Point point)
        {
            return Color.White;
        }
    }
}
