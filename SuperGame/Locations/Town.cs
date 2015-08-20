using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SuperGame
{
    public class Town : ILocation
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
				public List<IBuilding> Buildings { get; private set; }
        public Color GameFieldColor { get; private set; }
				public Suburb Suburb { get; private set; }

				public Town(string name, int id, List<IBuilding> buildings, Color gameFieldColor, Suburb suburb)
        {
            Name = name;
            Id = id;
						Buildings = buildings;
            GameFieldColor = gameFieldColor;
						Suburb = suburb;
        }
    }
}
