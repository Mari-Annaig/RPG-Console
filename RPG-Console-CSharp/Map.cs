﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RPG_Console_CSharp
{
    class Map
    {
        private char[,] map;
        private char[,] mapOrigin;
        private string pieceName;
        private int width;
        private int height;

        public char[,] MyMap { get { return map; } set { map = value; } }
        public char[,] MapOrigin { get { return mapOrigin; } set { mapOrigin = value; } }
        public string PieceName { get { return pieceName; } set { pieceName = value; } }

        // constructor
        public Map(int w, int h)
        {
            map = new char[w, h];
            this.width = w;
            this.height = h;
        }

        public char[,] FillMap(char[,] map)
        {
            map = FillBorder(map);
            return map;
        }

        private char[,] FillBorder(char[,] map)
        {
            for (int i = 0; i < this.width; i++)
            {
                map[i, 0] = '|';
                map[i, (this.width - 2)] = '|';
            }
            for (int j = 0; j < this.height; j++)
            {
                map[0, j] = '_';
                map[(this.height - 2), j] = '_';
            }
            return map;
        }

        public char[,] FillMapWithFile(string path, char[,] map)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string ln = "";
                int i = 0;
                int j = 0;
                while ((ln = sr.ReadLine()) != null)
                {
                    foreach (char c in ln)
                    {
                        map[i, j] = c;
                        ++j;
                    }
                    ++i;
                    j = 0;
                }
            }
            mapOrigin = map;
            return map;
        }

        public bool IsWall(int x, int y)
        {
            return ((map[x, y] == '|') || (map[x, y] == '_'));
        }
    }
}
