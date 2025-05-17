using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

class Sapper
{
    public int CursorX = 0, CursorY = 0;
    public bool[,] Flag;
    public int Bombs;
    public int Flags;
    public int Width;
    public int Height;
    public bool[,] Open;
    public int[,] gameField;
    public Sapper(int width, int height, int bombs)
    {
        Width = width;
        Height = height;
        Bombs = bombs;
        Flags = bombs;
        gameField = new int[width, height];
        Open = new bool[width, height];
        Flag = new bool[width, height];
    }
}

