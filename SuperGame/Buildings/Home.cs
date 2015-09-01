using SuperGame.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SuperGame {
	public class Home : AbstractBuilding
	{
		public Home( String name, Shape shape, Owner owner )
			: base(name, shape, owner)
		{

		}

	}
}
