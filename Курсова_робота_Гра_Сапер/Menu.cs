
using System.Text;

class Menu
{
    // створити константи для більшої читаємості коду
    private int menuY = 0;
    private int page = 1;
    private string[] difficulty = { "Легка", "Середня", "Складна", "Користувацька", "Назад до головного меню" };
    private string[] menu = { "Нова гра", "Керування", "Вихід" };
    private string[] control = { "Назад до головно меню" };
    private const int MainMenuPage = 1;
    private const int ControlPage = 2;
    private const int DifficultyPage = 3;

    public void ShowMenu()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = "Сапер";
        Console.CursorVisible = false;
        while (true)
        {
            Console.Clear();
            ConsoleKey key;
            if (page == MainMenuPage)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Головне меню");
                Console.ResetColor();
                PrintMenu(menu);
                key = Console.ReadKey(true).Key;
                MovementMenu(key, menu);
            }
            else if (page == ControlPage)
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
                PrintMenu(control);
                key = Console.ReadKey(true).Key;
                MovementMenu(key, control);
            }
            else if (page == DifficultyPage)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Оберіть складність рівня");
                Console.ResetColor();
                PrintMenu(difficulty);
                key = Console.ReadKey(true).Key;
                MovementMenu(key, difficulty);
            }
        }
    }

    private void PrintMenu(string[] menu)
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

    private void MovementMenu(ConsoleKey key, string[] menu)
    {
        Levels levels = new Levels();
        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (menuY > 0)
                {
                    menuY--;
                }
                break;
            case ConsoleKey.DownArrow:
                if (menuY < menu.Length - 1)
                {
                    menuY++;
                }
                break;
            case ConsoleKey.Escape:
                page = MainMenuPage;
                ShowMenu();
                break;
            case ConsoleKey.Enter:
                if (page == MainMenuPage)
                {
                    if (menuY == 0)
                    {
                        page = DifficultyPage;
                    }
                    else if (menuY == 1)
                    {
                        page = ControlPage;
                        menuY = 0;
                    }
                    else if (menuY == 2)
                    {
                        Environment.Exit(0);
                    }
                }
                else if (page == ControlPage)
                {

                    page = MainMenuPage;
                    menuY = 0;

                }
                else if (page == DifficultyPage)
                {
                    switch (menuY)
                    {
                        case 0://складність була приблизно вирахувана за формулою стовпці*ряди*коефіцієнт складності 
                            Sapper sapperEasy = new Sapper(6, 6, 5); //коефіцієнт складності = 0.1
                            levels.Level(sapperEasy);
                            break;
                        case 1:
                            Sapper sapperMedium = new Sapper(8, 8, 10);//коефіцієнт складності = 0.15
                            levels.Level(sapperMedium);
                            break;
                        case 2:
                            Sapper sapperHard = new Sapper(10, 10, 20);//коефіцієнт складності = 0.2
                            levels.Level(sapperHard);
                            break;
                        case 3:
                            levels.CreateCustomLevel();
                            break;
                        case 4:
                            page = MainMenuPage;
                            menuY = 0;
                            break;
                    }
                }
                break;
        }
    }
}

