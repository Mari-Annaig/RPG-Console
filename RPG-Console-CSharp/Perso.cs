using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RPG_Console_CSharp
{
    class Perso : Character
    {
        private (int, int) pos;

        public (int, int) Position { get { return pos; } set { pos = value; } }
        public int X { get { return pos.Item1; } set { pos.Item1 = value; } }
        public int Y { get { return pos.Item2; } set { pos.Item2 = value; } }

        public Perso(int pv, List<Attack> attacks, (int, int) positionDepart) : base(pv, attacks)
        {
            this.pos = positionDepart;
        }

        public Perso(int pv, string attackName, int damage, int range, (int, int) positionDepart) : base(pv, attackName, damage, range)
        {
            this.pos = positionDepart;
        }

        public void Action(bool inBattle)
        {
            Console.WriteLine("Action que vous pouvez faire : ");
            if (inBattle)
            {
                Console.WriteLine("1-Attaquer");
                Console.WriteLine("2-Esquiver");
                Console.WriteLine("Entrer le chiffre");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        // liste des attaques
                        Console.WriteLine("Vos attaques :");
                        for (int i = 0; i < this.attacks.Count; i++)
                        {
                            Console.WriteLine(i + "-" + this.attacks[i].Name);
                        }
                        Console.WriteLine("Entrer le chiffre");
                        break;
                    case "2":
                        // esquive
                        Console.WriteLine("Esquive");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("1-Passer en mode déplacement");
                Console.WriteLine("2-Avoir plus d'informations sur l'endroit");
                Console.WriteLine("3-Ouvrir le menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        // passe en mode déplacement
                        Game.InDeplacement = true;
                        break;
                    case "2":
                        // ouvrir le fichier avec plus d'info
                        // Appeler une fonction de map
                        break;
                    case "3":
                        Console.WriteLine("Quel menu ?\n Merci de choisir une véritable action");
                        break;
                    default:
                        Console.WriteLine("Veuillez entre le chiffre de l'action");
                        Action(inBattle);
                        break;
                }
            }
        }

        public (int,int) Move()
        {
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    return (-1, 0);
                case ConsoleKey.DownArrow:
                    return (1, 0);
                case ConsoleKey.RightArrow:
                    return (0, 1);
                case ConsoleKey.LeftArrow:
                    return (0, -1);
                default:
                    return (0, 0);
            }
        }
    }
}
