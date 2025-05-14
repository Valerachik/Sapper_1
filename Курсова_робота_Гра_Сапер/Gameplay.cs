using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Gameplay
{
    private Sapper sapper;
    public Gameplay(Sapper s)
    {
        this.sapper = s;
    }
    public void movments(ConsoleKey key, int[,] sum)
    {
        Console_Output con = new Console_Output(sapper);
        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (sapper.cursorY > 0)
                {
                    sapper.cursorY--;
                }
                break;
            case ConsoleKey.DownArrow:
                if (sapper.cursorY < sum.GetLength(0) - 1)
                {
                    sapper.cursorY++;
                }
                break;
            case ConsoleKey.LeftArrow:
                if (sapper.cursorX > 0)
                {
                    sapper.cursorX--;
                }
                break;
            case ConsoleKey.RightArrow:
                if (sapper.cursorX < sum.GetLength(1) - 1)
                {
                    sapper.cursorX++;
                }
                break;
            case ConsoleKey.Enter:
                if (sum[sapper.cursorY, sapper.cursorX] == 9)
                {
                    Console.Clear();
                    con.print_opened(sum);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("------GAME OVER------");
                    Thread.Sleep(2500);
                    Environment.Exit(0);
                }
                else if (sum[sapper.cursorY, sapper.cursorX] != 0)
                {
                    sapper.open[sapper.cursorY, sapper.cursorX] = true;
                }
                else if (sum[sapper.cursorY, sapper.cursorX] == 0)
                {
                    revealed_zero(sum);
                }
                break;
            case ConsoleKey.Escape:
                if (sapper.cursorX < sum.GetLength(1) - 1)
                {
                    break;
                }
                break;
            case ConsoleKey.F:
                sapper.Flag[sapper.cursorY, sapper.cursorX] = true;
                break;
        }
    }
    public void revealed_zero(int[,] sum)
    {
        bool[,] visited = new bool[sum.GetLength(0), sum.GetLength(1)];
        Queue<(int x, int y)> zero = new Queue<(int x, int y)>();
        zero.Enqueue((sapper.cursorX, sapper.cursorY));

        while (zero.Count > 0)
        {
            var (x, y) = zero.Dequeue();

            if (x < 0 || x >= sum.GetLength(1) || y < 0 || y >= sum.GetLength(0)) //не дивимось на те шо не підходить 
            {
                continue;
            }
            if (visited[x, y] || sapper.open[x, y])// і на те що вже бачили теж не дивимось
            {
                continue;
            }
            visited[x, y] = true;
            sapper.open[x, y] = true;
            if (sum[x, y] != 0) // не дивимось на сусідів клітинки де не 0 (бо якщо там цифра один сусід точно бомба!!)
            {
                continue;
            }


            for (int i = -1; i <= 1; i++)//а от тут якщо клітинки 0 то всіх сусідів додаємо
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
    public int check_win(int[,] sum)
    {
        int win = 0;
        for (int i = 0; i < sum.GetLength(0); i++)
        {
            for (int j = 0; j < sum.GetLength(1); j++)
            {
                if (sum[i, j] != 9 && sapper.open[i, j])
                {
                    win++;
                }
                if (sum[i, j] == 9 && !sapper.open[i, j])
                {
                    win++;
                }
            }
        }
        return win;
    }
}

