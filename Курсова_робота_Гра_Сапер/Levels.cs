using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Levels
{
    public void custom_level()
    {
        int bombs = 0, a = 0, b = 0;
        Console.Clear();

        do
        {
            bool validInput = true;
            while (validInput)
            {
                try
                {
                    Console.Write("Введіть кількість рядів: ");
                    a = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    validInput = false;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Ви ввели не число! Спробуйте ще раз");
                    validInput = true;
                }
                catch (ArgumentNullException)
                {
                    Console.Clear();
                    Console.WriteLine("Ви не ввели значення! Спробуйте ще раз.");
                }
            }
            Console.Clear();
            if (a < 2)
            {
                Console.Write("Кількість рядів не може буть менше за 2! Спробуйте ще раз");
                Console.WriteLine();
            }
            if (a > 14)
            {
                Console.Write("Кількість рядів не може буть більша за 14! Спробуйте ще раз");
                Console.WriteLine();
            }
        } while (a < 2 || a > 14);
        Console.Clear();
        do
        {
            bool validInput = true;
            while (validInput)
            {
                try
                {
                    Console.Write("Введіть кількість стовпців: ");
                    b = int.Parse(Console.ReadLine());
                    validInput = false;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Ви ввели не число! Спробуйте ще раз");
                    validInput = true;
                }
                catch (ArgumentNullException)
                {
                    Console.Clear();
                    Console.WriteLine("Ви не ввели значення! Спробуйте ще раз.");
                }
            }
            Console.Clear();
            if (b < 2)
            {
                Console.Write("Кількість стовпців не може буть менше за 2! Спробуйте ще раз");
                Console.WriteLine();
            }
            if (b > 28)
            {
                Console.Write("Кількість стовпців не може буть більша за 28! Спробуйте ще раз");
                Console.WriteLine();
            }
        } while (b < 2 || b > 28);
        Console.WriteLine();
        Console.Clear();
        do
        {
            bool validInput = true;
            while (validInput)
            {
                try
                {
                    Console.Write("Введіть кількість бомб: ");
                    bombs = int.Parse(Console.ReadLine());
                    validInput = false;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Ви ввели не число! Спробуйте ще раз.");
                }
                catch (ArgumentNullException)
                {
                    Console.Clear();
                    Console.WriteLine("Ви не ввели значення! Спробуйте ще раз.");
                }
            }
            if (bombs >= a * b)
            {
                Console.Clear();
                Console.Write("Бомб не може буть більше ніж клітинок на полі! Спробуйте ще раз!");
                Console.WriteLine();
            }
            if (bombs < 1)
            {
                Console.Clear();
                Console.Write("На полі повинна бути хоча б одна бомба! Спробуйте ще раз!");
                Console.WriteLine();
            }
        } while (bombs >= a * b || bombs < 1);
        Console.Clear();
        Sapper sapper = new Sapper(a, b, bombs);
        level(sapper);
    }

    public void level(Sapper sapper)
    {
        Menu menu = new Menu();
        Gameplay game = new Gameplay(sapper);
        Console_Output con = new Console_Output(sapper);
        Initialization_Methods init = new Initialization_Methods(sapper);
        ConsoleKey key;
        init.field_bombs(sapper.gameField);
        do
        {
            Console.Clear();
            if (game.check_win(sapper.gameField) == sapper.Width * sapper.Height)
            {
                con.print_opened(sapper.gameField);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------YOU WIN-------");
                Console.ResetColor();
                Thread.Sleep(2500);
                menu.menu();
            }
            con.print(sapper.gameField);
            key = Console.ReadKey(true).Key;
            game.movements(key, sapper.gameField);
        } while (key != ConsoleKey.Escape);
    }
}

