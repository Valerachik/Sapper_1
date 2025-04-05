using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace курсова
{
    internal class Program
    {
        static int cursorX = 0, cursorY = 0;
        static bool[,] open;
        static bool[,] Flag;
        static int boombs = 1;
        static int width = 10;
        static int height = 10;
        static void check(int[,] sum, int i, int j)
        {
            if (i>=0 && j >=0 && i <sum.GetLength(0) && j < sum.GetLength(1) && sum[i, j]!= 9)
            {
                sum[i, j] += 1;
            }
        }//для поля
        static void print(int[,] sum)
        {
            for (int i = 0; i < sum.GetLength(0); i++)
            {
                for (int j = 0; j < sum.GetLength(1); j++)
                {
                  
                    Console.Write("|");
                    if (i == cursorY && j == cursorX)
                    {
                        Console.BackgroundColor = ConsoleColor.White; 
                        Console.ForegroundColor = ConsoleColor.Black;  
                    }
                    if (Flag[i, j])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("F");
                    }
                    else if (open[i, j]) 
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
        static void print_opened(int[,] sum)
        {
            for (int i = 0; i < sum.GetLength(0); i++)
            {
                for (int j = 0; j < sum.GetLength(1); j++)
                {
                    Console.Write("|");
                    if (i == cursorY && j == cursorX) 
                    {
                        Console.BackgroundColor = ConsoleColor.White; 
                        Console.ForegroundColor = ConsoleColor.Black;  
                    }

                    if (sum[i, j] == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("Б");
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
        static void field_bombs(int[,] sum)
        {
            Random rnd = new Random();
            int g = 0;
            while (g < boombs) 
            {
                int i = rnd.Next(0, sum.GetLength(0));
                int j = rnd.Next(0, sum.GetLength(1));
                if(sum[i, j] != 9) 
                { 
                sum[i,j] = 9;
                    g++;
                }
            }

            for (int i = 0; i < sum.GetLength(0); i++)
            {
                for (int j = 0; j < sum.GetLength(1); j++)
                {
                    if (sum[i, j] == 9)
                    {
                        check(sum, i + 1, j);
                        check(sum, i - 1, j);
                        check(sum, i, j + 1);
                        check(sum, i, j - 1);
                        check(sum, i + 1, j - 1);
                        check(sum, i - 1, j + 1);
                        check(sum, i + 1, j + 1);
                        check(sum, i - 1, j - 1);
                    }
                }
            }
           
            
        }//поле
        static void movments(ConsoleKey key, int[,] sum)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow: 
                    if (cursorY > 0) 
                    {
                        cursorY--;
                    }
                    break;
                case ConsoleKey.DownArrow: 
                    if (cursorY < sum.GetLength(0) - 1)
                    {
                        cursorY++;
                    }
                    break;
                case ConsoleKey.LeftArrow: 
                    if (cursorX > 0)
                    {
                        cursorX--;
                    }
                    break;
                case ConsoleKey.RightArrow: 
                    if (cursorX < sum.GetLength(1) - 1)
                    {
                        cursorX++;
                    }
                    break;
                case ConsoleKey.Enter:
                    if (sum[cursorY, cursorX] == 9)
                    {
                        Console.Clear();
                        print_opened(sum);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("------GAME OVER------");
                        Thread.Sleep(2500);
                        Environment.Exit(0);
                    }
                    else if (sum[cursorY, cursorX] != 0)
                    {
                        open[cursorY, cursorX] = true;
                    }
                    else if (sum[cursorY, cursorX] == 0)
                    {
                        open[cursorY, cursorX] = true;
                        open_all_zero(sum);
                    }
                    break;
                case ConsoleKey.Escape:
                    if (cursorX < sum.GetLength(1) - 1)
                    {
                        break;
                    }
                    break;
                case ConsoleKey.F:
                    Flag[cursorY, cursorX] = true;
                    break;
            }
        }
        static void revealed_zero(int[,] sum)
        {
            int centerY = sum.GetLength(0) / 2;
            int centerX = sum.GetLength(1) / 2;

            int[] dx = { 1, 0, -1, 0 }; // Право, Вниз, Ліво, Вгору
            int[] dy = { 0, 1, 0, -1 };

            int x = cursorX, y = cursorY;
            int step = 1; // Кількість кроків у кожному напрямку
            int dir = 0;  // Напрямок (0 - вправо, 1 - вниз, 2 - вліво, 3 - вгору)


            while (step < Math.Max(sum.GetLength(0), sum.GetLength(1)) * 2) // Гарантуємо повний обхід
            {
                for (int i = 0; i < 2; i++) // Кожен цикл проходимо 2 рази (однакова довжина кроків)
                {
                    for (int j = 0; j < step; j++)
                    {
                        x += dx[dir];
                        y += dy[dir];

                        // Перевіряємо чи не виходимо за межі
                        if (x >= 0 && x < sum.GetLength(1) && y >= 0 && y < sum.GetLength(0))
                        {
                            open[y, x] = true; // Відкриваємо клітинку

                            // Якщо це НЕ 0 – зупиняємось (якщо треба)
                            if (sum[y, x] != 0)
                            {
                                return;
                            }
                        }
                    }
                    dir = (dir + 1) % 4; // Зміна напряму
                }
                step++; // Збільшуємо кроки після двох поворотів
            }
        }//оце треба даработать ще, це типу пусті відкриваються?????????
        static void open_all_zero(int[,] sum)
        {
            for(int i = 0;i<width;i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (sum[i, j] == 0)
                    {
                        open[i,j] = true;
                    }
                }
            }
        }
        static int check_win(int[,]sum)
        {
            int win = 0;
            for(int i = 0;i < sum.GetLength(0);i++)
            {
                for (int j =0;j < sum.GetLength(1); j++)
                {
                    if(sum[i,j] !=9 && open[i,j])
                    {
                        win++;
                    }
                    if(sum[i, j] == 9 && !open[i, j])
                    {
                        win++;
                    }
                }
            }
            return win;
        }
        static void custom_level()
        {
            int bombs, a, b;
            do
            {
                Console.WriteLine("Please, choose amount of colums: ");
                a = int.Parse(Console.ReadLine());
                Console.WriteLine("Please, chosee amount of rud: ");
                b = int.Parse(Console.ReadLine());
            } while (a < 2 || b < 2);

            do
            {
                Console.WriteLine("Please, choose amount of bombs: ");
                bombs = int.Parse(Console.ReadLine());
            } while (bombs >= a * b || bombs < 1);
        } //поки не трогать

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            ConsoleKey key;
            int[,] sum = new int[width, height];
            open = new bool[width, height];
            Flag = new bool[width, height];
            field_bombs(sum);
            Console.Title = "Сапер";
            Console.CursorVisible = false;
            do
            {
                Console.Clear();
                if (check_win(sum) == 100)
                {
                    print_opened(sum);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("------YOU WIN-------");
                    Thread.Sleep(2500);
                    break;
                }
                print(sum);
                key = Console.ReadKey(true).Key;
                movments(key, sum);
            } while (key != ConsoleKey.Escape);
        }
    }
}
