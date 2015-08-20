using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGame 
{
  public interface IBuilding 
  {
		void Draw(Graphics g);
		Owner Owner { get; }
		Color Click(Point p);
    void Enter();
    void Exit();
    void Speak();
  }
}
