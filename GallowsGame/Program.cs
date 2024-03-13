global using GallowsGame.Lib.Core;

namespace GallowsGame.ConsoleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("Добро пожаловать в игру \"Виселица\"! \n");
                Console.WriteLine("Начать новую игру(Y) или выйти из приложения(Q)? ");
                while (true)
                {
                    char key = Console.ReadKey().KeyChar;
                    if (key == 'q' || key == 'Q')
                    {
                        Environment.Exit(0);
                    }
                    if (key == 'y' || key == 'Y')
                    {
                        break;
                    }
                }
                ConsoleGUI UI = new(); //в цикле, так как много значений, которые нужно обнулять
                UI.StartGame();
                while (true) 
                {
                    UI.Update();
                    UI.GetUserInput();
                    if (UI.IsEnd())
                    {
                        UI.Update();
                        UI.Status = null;
                        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                        Console.ReadKey(false);
                        Console.Clear();
                        break;
                    }
                }
                
            }
        }
    }
}
