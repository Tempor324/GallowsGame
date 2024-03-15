global using GallowsGame.Lib.Core;

namespace GallowsGame.ConsoleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI UI = new();
            while (true)
            {
                Console.WriteLine("Добро пожаловать в игру \"Виселица\"! \n");
                StartNewGameOrQuitApplication();
                UI.StartGame();
                while (true) 
                {
                    UI.Update();
                    UI.GetUserInput();
                    if (UI.IsEnd())
                    {
                        UI.Update();
                        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    }
                }
                
            }
        }

        static void StartNewGameOrQuitApplication()
        {
            Console.WriteLine("Начать новую игру(Y) или выйти из приложения(Q)? ");
            while (true)
            {
                char key = Console.ReadKey(true).KeyChar;
                if (key == 'q' || key == 'Q')
                {
                    Environment.Exit(0);
                }
                if (key == 'y' || key == 'Y')
                {
                    break;
                }

            }
        }
    }
}
