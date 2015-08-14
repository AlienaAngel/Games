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
        // В C# принято называть методы с большой буквы по style convention 
        public abstract void Draw(Graphics g);
        public abstract Color CheckHitCoords(Point point);
    }
}
