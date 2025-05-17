using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

class Menu
{
    private int menuY = 0;
    private int page = 0;
    private string[] difficulty = { "Легка", "Середня", "Складна", "Користувацька", "Назад до головного меню" };
    private string[] menu_1 = { "Нова гра", "Керування", "Вихід" };
    private string[] control = { "Назад до головно меню" };
    Levels levels = new Levels();
    public void menu()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = "Сапер";
        Console.CursorVisible = false;
        ConsoleKey key;
        while (true)
        {
            Console.Clear();
            if (page == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Головне меню");
                Console.ResetColor();
                print_menu(menu_1);
                key = Console.ReadKey(true).Key;
                menu_movement(key, menu_1);
            }
            else if (page == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Керування в грі");
                Console.ResetColor();
                Console.WriteLine("↑ - рух вгору");
                Console.WriteLine("↓ – рух вниз");
                Console.WriteLine("← – рух вліво");
                Console.WriteLine("→ – рух вправо");
                Console.WriteLine("F - поставити прапорець/забрати прапорець");
                Console.WriteLine("Enter - відкрити клітинку");
                Console.WriteLine("Escape - вийти в головне меню");
                print_menu(control);
                key = Console.ReadKey(true).Key;
                menu_movement(key, control);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Оберіть складність рівня");
                Console.ResetColor();
                print_menu(difficulty);
                key = Console.ReadKey(true).Key;
                menu_movement(key, difficulty);
            }
        }
    }

    private void print_menu(string[] menu)
    {
        for (int i = 0; i < menu.Length; i++)
        {
            if (i == menuY)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("  " + menu[i]);
            }
            else
            {
                Console.WriteLine(menu[i]);
            }
            Console.ResetColor();
        }
    }

    private void menu_movement(ConsoleKey key, string[] Menu)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (menuY > 0)
                {
                    menuY--;
                }
                break;
            case ConsoleKey.DownArrow:
                if (menuY < Menu.Length - 1)
                {
                    menuY++;
                }
                break;
            case ConsoleKey.Escape:
                page = 0;
                menu();
                break;
            case ConsoleKey.Enter:
                if (page == 0)
                {
                    if (menuY == 0)
                    {
                        page += 2;
                    }
                    else if (menuY == 1)
                    {
                        page++;
                        menuY = 0;
                    }
                    else if (menuY == 2)
                    {
                        Environment.Exit(0);
                    }
                }
                else if (page == 1)
                {

                    page--;
                    menuY = 0;

                }
                else if (page == 2)
                {
                    switch (menuY)
                    {
                        case 0://складність була приблизно вирахувана за формулою стовпці*ряди*коефіцієнт складності 
                            Sapper sapperEasy = new Sapper(6, 6, 5); //коефіцієнт складності = 0.1
                            levels.level(sapperEasy);
                            break;
                        case 1:
                            Sapper sapperMedium = new Sapper(8, 8, 10);//коефіцієнт складності = 0.15
                            levels.level(sapperMedium);
                            break;
                        case 2:
                            Sapper sapperHard = new Sapper(10, 10, 20);//коефіцієнт складності = 0.2
                            levels.level(sapperHard);
                            break;
                        case 3:
                            levels.custom_level();
                            break;
                        case 4:
                            page -= 2;
                            menuY = 0;
                            break;
                    }
                }
                break;
        }
    }
}

