using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGame 
{
	public class GameContext 
	{
		public List<ILocation> Locations { get; set; }
		public ILocation ActiveLocation { get; set; }
		public bool IsInSuburb { get; set; }
		public Hero Hero { get; set; }

		public GameContext(List<ILocation> locations, Hero hero) {
			Locations = locations;
			ActiveLocation = Locations[0];
			IsInSuburb = false;
			Hero = hero;
		}

	}
}
