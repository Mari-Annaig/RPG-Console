using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Console_CSharp
{
    class Character
    {
        private int pv;
        private List<Attack> attacks; // <name, <range, damage>>

        public Character(int pv, List<Attack> attacks)
        {
            this.pv = pv;
            this.attacks = attacks;
        }

        public Character(int pv, string attackName, int damage, int range)
        {
            this.pv = pv;
            attacks.Add(new Attack(attackName, damage, range));
        }
    }
}
