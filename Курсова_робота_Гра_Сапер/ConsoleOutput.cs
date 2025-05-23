

class ConsoleOutput
{
    private Sapper sapper;

    public ConsoleOutput(Sapper s)
    {
        sapper = s;
    }

    public void PrintGameField(int[,] sum)
    {
        for (int i = 0; i < sum.GetLength(0); i++)
        {
            for (int j = 0; j < sum.GetLength(1); j++)
            {

                Console.Write("|");
                if (i == sapper.CursorY && j == sapper.CursorX)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                if (sapper.Flag[i, j])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("F");
                }
                else if (sapper.Open[i, j])
                {
                    if (sum[i, j] == Sapper.Bomb)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("X");
                    }
                    else if (sum[i, j] == Sapper.Empty)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(sum[i, j]);
                    }
                }
                else
                {
                    Console.Write("\u25A0"); // \u25A0 - ■ 
                }
                Console.ResetColor();
            }
            Console.Write("|");
            Console.WriteLine();
            for (int v = 0; v < sum.GetLength(1); v++)
            {
                Console.Write("--");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Прапорців усього: {sapper.Flags}");
    }

    public void PrintAnswer(int[,] sum)
    {
        for (int i = 0; i < sum.GetLength(0); i++)
        {
            for (int j = 0; j < sum.GetLength(1); j++)
            {
                Console.Write("|");
                if (i == sapper.CursorY && j == sapper.CursorX)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                if (sum[i, j] == Sapper.Bomb)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("X");
                }
                else if (sum[i, j] == Sapper.Empty)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(sum[i, j]);
                }

                Console.ResetColor();
            }
            Console.Write("|");
            Console.WriteLine();
            for (int v = 0; v < sum.GetLength(1); v++)
            {
                Console.Write("--");
            }
            Console.WriteLine();
        }
    }
}

