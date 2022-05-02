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
        private bool endGame;

        // constructor
        public Game()
        {
            map = new Map(10, 10);
            perso = new Perso(10, new List<Attack>());
            enemiesBase = new List<Enemy>();
            for (int i = 0; i < 10; i++)
            {
                enemiesBase.Add(new Enemy(3, "crachat", 1, 1));
            }
            endGame = false;
        }

        private void PrintMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        private void DescribePlace(string pathFileDescribe)
        {
            // lecture du fichier puis affiche le texte
        }

        public void TheGame(char[,] map)
        {
            // Vous avez perdu !

            // TO DO
            // - déplacements
            // - combats
            // - changement de salles/map

            while (!endGame)
            {
                // affichage de la map
                PrintMap(map);
                // desciption global de l'espace
                DescribePlace(""); // mettre le path

                // demande une action au joueur
                

            }
        }
    }
}
