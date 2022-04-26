using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Console_CSharp
{
    class Map
    {
        public string[,] map;

        // constructor
        public Map(int w, int h)
        {
            map = new string[w,h];
        }

        public string[,] FillMap(string[,] map)
        {
            return map;
        }
    }
}
