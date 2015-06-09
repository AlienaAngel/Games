using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroSnake
{
    class SnakeBlock
    {
        private Coords _coords;

        public SnakeBlock(Coords coords)
        {
            _coords = coords;
        }

        public Coords Coords
        {
            get { return _coords; }
            set { _coords = value; }
        }
       
    }
}
