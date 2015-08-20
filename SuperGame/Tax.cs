﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGame 
{
  public class Tax : IBuilding
  {
		public String Name { get; private set; }
    public Shape Shape { get; private set; }
		public Owner Owner { get; private set; }

    public Tax(String name, Shape shape, Owner owner) 
    {
			Name = name;
			Shape = shape;
			Owner = owner;
    }

    public void Enter() {
      throw new NotImplementedException();
    }

    public void Exit() {
      throw new NotImplementedException();
    }

    public void Speak() {
      throw new NotImplementedException();
    }

		public void Draw(System.Drawing.Graphics g) {
			Shape.Draw(g);
		}



		public System.Drawing.Color Click(System.Drawing.Point p) {
			return Shape.CheckHitCoords(p);
		}
	}
}