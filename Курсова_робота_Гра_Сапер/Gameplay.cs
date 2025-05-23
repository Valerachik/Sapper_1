

class Gameplay
{
    private Sapper sapper;

    public Gameplay(Sapper s)
    {
        sapper = s;
    }

    public void InGameMovement(ConsoleKey key, int[,] sum)
    {
        ConsoleOutput con = new ConsoleOutput(sapper);
        Menu menu = new Menu();
        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (sapper.CursorY > 0)
                {
                    sapper.CursorY--;
                }
                break;
            case ConsoleKey.DownArrow:
                if (sapper.CursorY < sum.GetLength(0) - 1)
                {
                    sapper.CursorY++;
                }
                break;
            case ConsoleKey.LeftArrow:
                if (sapper.CursorX > 0)
                {
                    sapper.CursorX--;
                }
                break;
            case ConsoleKey.RightArrow:
                if (sapper.CursorX < sum.GetLength(1) - 1)
                {
                    sapper.CursorX++;
                }
                break;
            case ConsoleKey.Enter:
                if (sum[sapper.CursorY, sapper.CursorX] == Sapper.Bomb)
                {
                    Console.Clear();
                    con.PrintAnswer(sum);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("------GAME OVER------");
                    Console.ResetColor();
                    Thread.Sleep(2500);
                    menu.ShowMenu();
                }
                else if (sum[sapper.CursorY, sapper.CursorX] != Sapper.Empty)
                {
                    sapper.Open[sapper.CursorY, sapper.CursorX] = true;
                    if (sapper.Flag[sapper.CursorY, sapper.CursorX])
                    {
                        sapper.Flag[sapper.CursorY, sapper.CursorX] = false;
                        sapper.Flags++;
                    }
                }
                else if (sum[sapper.CursorY, sapper.CursorX] == Sapper.Empty)
                {
                    RevealedEmpty(sum);
                }
                break;
            case ConsoleKey.Escape:
                menu.ShowMenu();
                break;
            case ConsoleKey.F:
                if (!sapper.Open[sapper.CursorY, sapper.CursorX])
                {
                    if (sapper.Flags > 0)
                    {
                        if (sapper.Flag[sapper.CursorY, sapper.CursorX])
                        {
                            sapper.Flag[sapper.CursorY, sapper.CursorX] = false;
                            sapper.Flags++;
                        }
                        else
                        {
                            sapper.Flag[sapper.CursorY, sapper.CursorX] = true;
                            sapper.Flags--;
                        }
                    }
                    else if (sapper.Flags == 0)
                    {
                        if (sapper.Flag[sapper.CursorY, sapper.CursorX])
                        {
                            sapper.Flag[sapper.CursorY, sapper.CursorX] = false;
                            sapper.Flags++;
                        }
                    }
                }
                break;
        }
    }

    public void RevealedEmpty(int[,] sum)
    {
        bool[,] visited = new bool[sum.GetLength(0), sum.GetLength(1)];
        Queue<(int x, int y)> zero = new Queue<(int x, int y)>();
        zero.Enqueue((sapper.CursorX, sapper.CursorY));

        while (zero.Count > 0)
        {
            var (x, y) = zero.Dequeue();

            if (x < 0 || x >= sum.GetLength(1) || y < 0 || y >= sum.GetLength(0))
            {
                continue;
            }
            if (visited[y, x] || sapper.Open[y, x])
            {
                continue;
            }
            visited[y, x] = true;
            sapper.Open[y, x] = true;
            if (sapper.Flag[y, x])
            {
                sapper.Flag[y, x] = false;
                sapper.Flags++;
            }
            if (sum[y, x] != Sapper.Empty)
            {
                continue;
            }
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    zero.Enqueue((x + i, y + j));
                }
            }
        }
    }

    public int CheckWin(int[,] sum)
    {
        int win = 0;
        for (int i = 0; i < sum.GetLength(0); i++)
        {
            for (int j = 0; j < sum.GetLength(1); j++)
            {
                if (sum[i, j] != Sapper.Bomb && sapper.Open[i, j])
                {
                    win++;
                }
                if (sum[i, j] == Sapper.Bomb && !sapper.Open[i, j])
                {
                    win++;
                }
            }
        }
        return win;
    }
}

