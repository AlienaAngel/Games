using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGame
{
    public class Hero
    {
        public int Health { get; private set; }
        public int Mana { get; private set; }
        public int Capacity { get; private set; }
        public int Weight { get; private set; }
        public int Money { get; private set; }

        public Hero()
        {
            Health = 100;
            Mana = 100;
            Capacity = 20;
            Money = 100;
            Weight = 0;
        }
    }
}
