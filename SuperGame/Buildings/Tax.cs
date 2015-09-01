using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperGame.Buildings;

namespace SuperGame 
{
	public class Tax : AbstractBuilding
	{
		public Tax( String name, Shape shape, Owner owner )
			: base(name, shape, owner)
		{

		}
	}
}