using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Console_CSharp
{
    class Perso : Character
    {
        public Perso(int pv, List<Attack> attacks) : base(pv, attacks)
        {

        }

        public Perso(int pv, string attackName, int damage, int range) : base(pv, attackName, damage, range)
        {

        }
    }
}
