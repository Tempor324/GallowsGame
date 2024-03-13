using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace GallowsGame.ConsoleGame   //проблема с именованием, конфликт с system.console
                                    //да и как вообще правильно использовать namespace?
{
    internal class ConsoleGUI : UserInterface
    {
        private static string Placeholder { get; set; } = "_";
            
        private static Dictionary<ResponseStatus, string> Responses { get; set; } = new()
        {
            [ResponseStatus.InvalidInput] = "Некорректный ввод! Введите букву английского алфавита.",
            [ResponseStatus.CharIsUsed] = "Введите букву, которую вы ещё не вводили.",
            [ResponseStatus.PlayerMistake] = "Ошибка!",
            [ResponseStatus.CorrectInput] = "",
            [ResponseStatus.Win] = "Победа!",
            [ResponseStatus.Lose] = "Вас повесили!"
        };
        //также тянуть текст из файла, например, для текста на разных языках? 

        public static string Title { get; set; } = "Gallows game v. alpha 01";

        public ResponseStatus? Status { get; set; } //пришлось сделать public set, иначе я не знаю, как обнулять его без пересоздания UI

        public void Update()
        {
            Console.Clear();
            GallowsRender();
            WordRender();
            if (Game.UserInputList.Count != 0)
            {
                UserInputListRender();
            }
            if (Game.NumberOfAttemps != 0)
            {
                NumberOfAttempsRender();
            }
            ResponseRender();
            //GetUserInput();
        }

        public bool IsEnd()
        {
            return Status == ResponseStatus.Win || Status == ResponseStatus.Lose;
        }

        private void NumberOfAttempsRender()
        {
            Console.WriteLine($"Попыток осталось: {Game.MaxNumberOfAttemps - Game.NumberOfAttemps}");
        }

        private void GallowsRender()
        {
            switch (Game.NumberOfAttemps) //переделать, это не надо так хранить
            {
                case 0:
                    Console.WriteLine("""
                        '-------'
                        |       |
                        |      [ ]
                        |
                        |
                        |
                        """);
                    break;
                case 1:
                    Console.WriteLine("""
                        '-------'
                        |       |
                        |      [O]
                        |
                        |
                        |
                        """);
                    break;
                case 2:
                    Console.WriteLine("""
                        '-------'
                        |       |
                        |      [O]
                        |       |
                        |
                        |
                        """);
                    break;
                case 3:
                    Console.WriteLine("""
                        '-------'
                        |       |
                        |      [O]
                        |      /|
                        |
                        |
                        """);
                    break;
                case 4:
                    Console.WriteLine("""
                        '-------'
                        |       |
                        |      [O]
                        |      /|\
                        |
                        |
                        """);
                    break;
                case 5:
                    Console.WriteLine("""
                        '-------'
                        |       |
                        |      [O]
                        |      /|\
                        |      /
                        |
                        """);
                    break;
                case 6:
                    Console.WriteLine("""
                        '-------'
                        |       |
                        |      [O]
                        |      /|\
                        |      / \
                        |
                        """);
                    break;
            }
        }

        private void WordRender()
        {
            //throw new NotImplementedException();
            Console.Write("Слово: ");
            for (int i = 0; i < Game.HiddenWord.Length; i++)
            {
                if (IndexesOfChars.Contains(i))
                {
                    Console.Write(Game.HiddenWord[i]);
                }
                else
                {
                    Console.Write(Placeholder+' ');
                }
            }
            Console.WriteLine();
        }

        private void UserInputListRender()
        {
            Console.WriteLine("Введенные буквы: ");
            foreach (char c in Game.UserInputList) //не так это должно работать
            {
                Console.Write(c + ", ");
            }
            Console.WriteLine();
        }

        public void GetUserInput()
        {
            Console.Write("Ваш ввод: ");
            char userInput = Console.ReadKey().KeyChar;
            Status = CheckValue(userInput);
        }

        private void ResponseRender()
        {
            //if( Status == null || Status == ResponseStatus.CorrectInput) //лишняя проверка, получается
            //{
            //    return;
            //} 
            Console.WriteLine(Responses[Status ?? ResponseStatus.CorrectInput]); //чтобы компилятор не ругался на ResponseStatus? сделал проверку
        }
    }
}
