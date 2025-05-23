

class Sapper
{
    public int CursorX = 0, CursorY = 0;
    public bool[,] Flag;
    public int Bombs;
    public int Flags;
    public int Width;
    public int Height;
    public bool[,] Open;
    public int[,] GameField;
    public const int Bomb = 9;
    public const int Empty = 0;

    public Sapper(int width, int height, int bombs)
    {
        Width = width;
        Height = height;
        Bombs = bombs;
        Flags = bombs;
        GameField = new int[width, height];
        Open = new bool[width, height];
        Flag = new bool[width, height];
    }
}

