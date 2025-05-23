

class Levels
{
    public void CreateCustomLevel()
    {
        int width = CheckRows();
        int height = CheckColumns();
        int bombs = CheckBombs(width, height);
        Sapper sapper = new Sapper(width, height, bombs);
        Level(sapper);
    }

    private static int CheckRows()
    {
        int rows = 0;
        Console.Clear();
        do
        {
            bool validInput = true;
            while (validInput)
            {
                try
                {
                    Console.Write("Введіть кількість рядів: ");
                    rows = int.Parse(Console.ReadLine());
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
            if (rows < 2)
            {
                Console.Write("Кількість рядів не може буть менше за 2! Спробуйте ще раз");
                Console.WriteLine();
            }
            if (rows > 14)
            {
                Console.Write("Кількість рядів не може буть більша за 14! Спробуйте ще раз");
                Console.WriteLine();
            }
        } while (rows < 2 || rows > 14);

        return rows;
    }

    private static int CheckColumns()
    {
        int columns = 0;
        Console.Clear();
        do
        {
            bool validInput = true;
            while (validInput)
            {
                try
                {
                    Console.Write("Введіть кількість стовпців: ");
                    columns = int.Parse(Console.ReadLine());
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
            if (columns < 2)
            {
                Console.Write("Кількість стовпців не може буть менше за 2! Спробуйте ще раз");
                Console.WriteLine();
            }
            if (columns > 28)
            {
                Console.Write("Кількість стовпців не може буть більша за 28! Спробуйте ще раз");
                Console.WriteLine();
            }
        } while (columns < 2 || columns > 28);
        return columns;
    }

    private static int CheckBombs(int width, int height)
    {
        int bombs = 0;
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
            if (bombs >= width * height)
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
        } while (bombs >= width * height || bombs < 1);
        Console.Clear();
        return bombs;
    }

    public void Level(Sapper sapper)
    {
        Menu menu = new Menu();
        Gameplay game = new Gameplay(sapper);
        ConsoleOutput con = new ConsoleOutput(sapper);
        InitializationMethods init = new InitializationMethods(sapper);
        ConsoleKey key;
        init.FillBombs(sapper.GameField);
        do
        {
            Console.Clear();
            if (game.CheckWin(sapper.GameField) == sapper.Width * sapper.Height)
            {
                con.PrintAnswer(sapper.GameField);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------YOU WIN-------");
                Console.ResetColor();
                Thread.Sleep(2500);
                menu.ShowMenu();
            }
            con.PrintGameField(sapper.GameField);
            key = Console.ReadKey(true).Key;
            game.InGameMovement(key, sapper.GameField);
        } while (key != ConsoleKey.Escape);
    }
}

