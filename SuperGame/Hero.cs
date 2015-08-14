using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGame
{
    public class Hero
    {
        private int _health;
        private int _mana;
        private int _capacity;
        private int _weight;
        private int _money;

        public Hero()
        {
            _health = 100;
            _mana = 100;
            _capacity = 20;
            _money = 100;
            _weight = 0;
        }

        public int Health
        {
            get { return _health; }
        }

        public int Mana
        {
            get { return _mana; }
        }

        public int Capacity
        {
            get { return _capacity; }
        }

        public int Weight
        {
            get { return _weight; }
        }

        public int Money
        {
            get { return _money; }
        }

    }
}
