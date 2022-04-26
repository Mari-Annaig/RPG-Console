using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Console_CSharp
{
    class Attack
    {
        private string name;
        private int damage;
        private int range;

        public string Name { get { return name; } }
        public int Damage { get { return damage; } }
        public int Range { get { return range; } }

        public Attack(string name, int damage, int range)
        {
            this.name = name;
            this.damage = damage;
            this.range = range;
        }

    }
}
