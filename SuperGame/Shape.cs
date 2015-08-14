using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SuperGame
{
    abstract public class Shape
    {
        public abstract void draw(Graphics g);
        public abstract Color checkHitCoords(Point point);

    }
}
