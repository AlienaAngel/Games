using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGame
{
    public class Town
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        public List<Shape> Objects { get; private set; }

        public Town(string name, int id, List<Shape> objects)
        {
            Name = name;
            Id = id;
            Objects = objects;
        }
    }
}
