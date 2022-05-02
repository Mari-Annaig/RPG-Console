using System;

namespace RPG_Console_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            Map m = new Map(3, 2);
            m.FillMap(m.map);
            g.TheGame(m.map);
        }
    }
}
