using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGame
{
    public class Town
    {
        private string _name;
        private int _id;
        private List<Shape> _objects;

        public Town(string name, int id, List<Shape> objects)
        {
            _name = name;
            _id = id;
            _objects = objects;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Id
        {
            get { return _id; }
        }

        public List<Shape> Objects
        {
            get { return _objects; }
        }
    }
}
