using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SuperGame
{
    public interface Shape
    {
        void Draw(Graphics g);
        Color CheckHitCoords(Point point);
    }
}
