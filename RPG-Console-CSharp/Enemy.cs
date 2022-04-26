using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Console_CSharp
{
    class Enemy : Character
    {
        public Enemy(int pv, List<Attack> attacks) : base(pv, attacks)
        {
            
        }

        public Enemy(int pv, string attackName, int damage, int range) : base(pv, attackName, damage, range)
        {

        }
    }
}
