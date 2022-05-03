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
        private bool inBattle;
        private static bool inDeplacement;

        public static bool InDeplacement { get { return inDeplacement; } set { inDeplacement = value; } }

        // constructor
        public Game()
        {
            map = new Map(10, 10);
            map.PieceName = "chambre";
            perso = new Perso(10, new List<Attack>());
            enemiesBase = new List<Enemy>();
            for (int i = 0; i < 10; i++)
            {
                enemiesBase.Add(new Enemy(3, "crachat", 1, 1));
            }
            endGame = false;
            inBattle = false;
            inDeplacement = false;
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

        private void DescribePlace(bool isInfoEntend, string pieceName)
        {
            // lecture du fichier puis affiche le texte
        }

        public void UpdatePositionPerso(int x, int y)
        {
            // utiliser mapOrigin pour remettre la case dans l'état où elle était
            if ((map.MyMap.GetLength(0) < x) && (map.MyMap.GetLength(1) < y))
            {
                // switch sur les cases à éviter
                switch (map.MyMap[x,y])
                {
                    case 'E':
                        // enemi donc mode battle
                        inDeplacement = false;
                        inBattle = true;
                        break;
                    case '|':
                        // mur, pas aller plus loin
                        break;
                    default:
                        map.MyMap[x, y] = 'P';
                        switch (map.MapOrigin[x,y])
                        {
                            case 'L':
                                Console.WriteLine("Vous êtes sur un lit");
                                break;
                            case 'S':
                                // escalier
                                break;
                            default:
                                break;
                        }
                        break;
                }
            }
        }

        public void TheGame()
        {
            // Vous avez perdu !

            // TO DO
            // - déplacements
            // - combats
            // - changement de salles/map
            map.FillMapWithFile("../../../Map/" + map.PieceName + ".txt", map.MyMap);
            PrintMap(map.MyMap);
            while (!endGame)
            {
                // affichage de la map
                if (inDeplacement)
                {
                    int x = 0;
                    int y = 0;

                    (x, y) = perso.Move();
                    UpdatePositionPerso(x, y);
                    Console.Clear();
                }
                else
                {
                    perso.Action(inBattle);
                }
                PrintMap(map.MyMap);
                // desciption global de l'espace
                DescribePlace(false, map.PieceName); // mettre le path

                // demande une action au joueur
                

            }
        }
    }
}
