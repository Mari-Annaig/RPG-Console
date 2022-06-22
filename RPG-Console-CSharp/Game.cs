using System;
using System.Collections.Generic;
using System.IO;
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
            perso = new Perso(10, new List<Attack>(), (2, 8));
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
                    if ((i != perso.X) || (j != perso.Y))
                    {
                        Console.Write(map[i, j]);
                    }
                    else
                    {
                        Console.Write('P');
                    }
                }
                Console.WriteLine();
            }
        }

        private void DescribePlace(bool isInfoEntend, string pieceName)
        {
            string folder = "Description";
            // lecture du fichier puis affiche le texte
            if (isInfoEntend)
            {
                folder += "_Extend";
            }

            using (StreamReader sr = new StreamReader("../../../" + folder + "/" + pieceName + ".txt"))
            {
                string ln = "";
                while ((ln = sr.ReadLine()) != null)
                {
                    Console.WriteLine(ln);
                }
            }
        }

        public void UpdatePositionPerso(int x, int y)
        {
            // switch sur les cases à éviter
            switch (map.MyMap[x, y])
            {
                case 'E':
                    Console.WriteLine("This an E");
                    // enemi donc mode battle
                    inDeplacement = false;
                    inBattle = true;
                    break;
                case '|':
                    Console.WriteLine("This |");
                    // mur, pas aller plus loin
                    break;
                default:
                    // Console.WriteLine("This is default");
                    // map.MyMap[x, y] = 'P';
                    switch (map.MyMap[x, y])
                    {
                        case 'L':
                            Console.WriteLine("Vous êtes sur un lit");
                            break;
                        case 'S':
                            // escalier -> passer à la pièce suivante
                            break;
                        default:
                            break;
                    }
                    break;
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
            //map.MyMap[perso.X, perso.Y] = 'P';
            PrintMap(map.MyMap);
            while (!endGame)
            {
                // affichage de la map
                if (inDeplacement)
                {
                    (int, int) pos = perso.Move();
                    int x = pos.Item1 + perso.X;
                    int y = pos.Item2 + perso.Y;

                    if ((!map.IsWall(x, y)) && (x > 0) && (x < 10) && (y > 0) && (y < 10))
                    {
                        perso.X = x;
                        perso.Y = y;
                        UpdatePositionPerso(perso.X, perso.Y);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Vous n'avez pas le pouvoir de traverser les murs");
                    }
                }
                else
                {
                    perso.Action(inBattle);
                }
                PrintMap(map.MyMap);
                Console.WriteLine(map.MyMap[perso.X, perso.Y]);
                // desciption global de l'espace
                DescribePlace(false, map.PieceName);

                // demande une action au joueur
                

            }
        }
    }
}
