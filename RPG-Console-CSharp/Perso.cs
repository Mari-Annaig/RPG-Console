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
                        break;
                    case "2":
                        // ouvrir le fichier avec plus d'info
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

        public void Move()
        {

        }
    }
}
