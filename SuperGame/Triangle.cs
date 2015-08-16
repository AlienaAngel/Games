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

        private double GetSquare(Point p1, Point p2, Point p3) {

            double[,] m = {{p2.X - p1.X, p2.Y - p1.Y},
                           { p3.X - p1.X, p3.Y - p1.Y}};

            return Math.Abs( m[0,0]*m[1,1] - m[0,1]*m[1,0] ) / 2f;
        }

        public override Color CheckHitCoords(Point point)
        {
            
            double s = GetSquare(Pt1, Pt2, Pt3);
            double s1 = GetSquare(point, Pt2, Pt3);
            double s2 = GetSquare(Pt1, point, Pt3);
            double s3 = GetSquare(Pt1, Pt2, point);

            double eps = 0.01;
            double diff = s - (s1 + s2 + s3);

            return   (Math.Abs(diff) < eps)?Color:Color.White;
        }
    }
}
