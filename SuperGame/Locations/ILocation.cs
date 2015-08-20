using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGame {
	public interface ILocation {
		List<IBuilding> Buildings { get; }
		int Id { get; }
		Color GameFieldColor { get; }
		Suburb Suburb { get; }
	}
}
