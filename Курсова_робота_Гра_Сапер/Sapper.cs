using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

class Sapper
{
    public int cursorX = 0, cursorY = 0;
    public bool[,] Flag;
    public int Boombs;
    public int Width;
    public int Height;
    public bool[,] open;
    public int[,] sum;
    public Sapper(int width, int height, int boombs)
    {
        Width = width;
        Height = height;
        Boombs = boombs;

        sum = new int[width, height];
        open = new bool[width, height];
        Flag = new bool[width, height];
    }
}

