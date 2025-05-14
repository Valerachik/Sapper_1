using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Levels
{
    public void custom_level()
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

        Sapper sapper = new Sapper(a, b, bombs);
        Gameplay game = new Gameplay(sapper);
        Console_Output con = new Console_Output(sapper);
        Initialization_Methods init = new Initialization_Methods(sapper);
        ConsoleKey key;
        init.field_bombs(sapper.sum);
        do
        {
            Console.Clear();
            if (game.check_win(sapper.sum) == sapper.Width * sapper.Height)
            {
                con.print_opened(sapper.sum);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------YOU WIN-------");
                Thread.Sleep(2500);
                break;
            }
            con.print(sapper.sum);
            key = Console.ReadKey(true).Key;
            game.movments(key, sapper.sum);
        } while (key != ConsoleKey.Escape);
    } 

    public void hard_level()
    {
        Sapper sapper = new Sapper(10, 10, 15);
        Gameplay game = new Gameplay(sapper);
        Console_Output con = new Console_Output(sapper);
        Initialization_Methods init = new Initialization_Methods(sapper);
        ConsoleKey key;
        init.field_bombs(sapper.sum);
        do
        {
            Console.Clear();
            if (game.check_win(sapper.sum) == sapper.Width * sapper.Height)
            {
                con.print_opened(sapper.sum);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------YOU WIN-------");
                Thread.Sleep(2500);
                break;
            }
            con.print(sapper.sum);
            key = Console.ReadKey(true).Key;
            game.movments(key, sapper.sum);
        } while (key != ConsoleKey.Escape);
    }

    public void medium_level()
    {
        Sapper sapper = new Sapper(8, 8, 10);
        Gameplay game = new Gameplay(sapper);
        Console_Output con = new Console_Output(sapper);
        Initialization_Methods init = new Initialization_Methods(sapper);
        ConsoleKey key;
        init.field_bombs(sapper.sum);
        do
        {
            Console.Clear();
            if (game.check_win(sapper.sum) == sapper.Width * sapper.Height)
            {
                con.print_opened(sapper.sum);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------YOU WIN-------");
                Thread.Sleep(2500);
                break;
            }
            con.print(sapper.sum);
            key = Console.ReadKey(true).Key;
            game.movments(key, sapper.sum);
        } while (key != ConsoleKey.Escape);
    }

    public void easy_level()
    {
        Sapper sapper = new Sapper(6, 6, 5);
        Gameplay game = new Gameplay(sapper);
        Console_Output con = new Console_Output(sapper);
        Initialization_Methods init = new Initialization_Methods(sapper);
        ConsoleKey key;
        init.field_bombs(sapper.sum);
        do
        {
            Console.Clear();
            if (game.check_win(sapper.sum) == sapper.Width * sapper.Height)
            {
                con.print_opened(sapper.sum);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------YOU WIN-------");
                Thread.Sleep(2500);
                break;
            }
            con.print(sapper.sum);
            key = Console.ReadKey(true).Key;
            game.movments(key, sapper.sum);
        } while (key != ConsoleKey.Escape);
    }
}

