using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SuperGame
{
    public class Suburb
    {
        public int Id { get; private set; }
        public List<IBuilding> Buildings { get; private set; }
        public Color GameFieldColor { get; private set; }

				public Suburb(int id, List<IBuilding> buildings, Color gameFieldColor)
        {
            Id = id;
						Buildings = buildings;
            GameFieldColor = gameFieldColor;
        }
    }
}
