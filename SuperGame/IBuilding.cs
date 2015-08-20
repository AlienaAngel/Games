using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGame 
{
	public delegate void BuildClickHandler(IBuilding owner);

  public interface IBuilding 
  {
		void Draw(Graphics g);
		Owner Owner { get; }
		String Name { get; }
		void Click(Point p);

		event BuildClickHandler enter;




    void Enter();
    void Exit();
    void Speak();
  }
}
