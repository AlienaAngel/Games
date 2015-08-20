using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGame 
{
  public class Owner
	{
		public String Name { get; private set; }
		public Owner(String name) {
			Name = name;
		}
  }
}
