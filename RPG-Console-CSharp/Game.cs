using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Console_CSharp
{
    class Game
    {
        private Map map;
        private Perso perso;
        private List<Enemy> enemiesBase;

        // constructor
        public Game()
        {
            map = new Map(10, 10);
            perso = new Perso(10, new List<Attack>());

            for (int i = 0; i < 10; i++)
            {
                enemiesBase.Add(new Enemy(3, "crachat", 1, 1));
            }
        }
    }
}
