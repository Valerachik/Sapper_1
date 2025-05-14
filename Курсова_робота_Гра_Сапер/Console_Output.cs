using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Console_Output
{
    private Sapper sapper;
    public Console_Output(Sapper s)
    {
        this.sapper = s;
    }
    public void print(int[,] sum)
    {
        
        for (int i = 0; i < sum.GetLength(0); i++)
        {
            for (int j = 0; j < sum.GetLength(1); j++)
            {

                Console.Write("|");
                if (i == sapper.cursorY && j == sapper.cursorX)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                if (sapper.Flag[i, j])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("F");
                }
                else if (sapper.open[i, j])
                {
                    if (sum[i, j] == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("X");
                    }
                    else if (sum[i, j] == 0)
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
                    Console.Write("'");
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
    public void print_opened(int[,] sum)
    {
        for (int i = 0; i < sum.GetLength(0); i++)
        {
            for (int j = 0; j < sum.GetLength(1); j++)
            {
                Console.Write("|");
                if (i == sapper.cursorY && j == sapper.cursorX)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                if (sum[i, j] == 9)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("X");
                }
                else if (sum[i, j] == 0)
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

