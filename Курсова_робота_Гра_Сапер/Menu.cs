using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Menu
{
    public void menu()
    {
        Levels levels = new Levels();
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = "Сапер";
        Console.CursorVisible = false;
        levels.hard_level();
    }
}

