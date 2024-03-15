using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace GallowsGame.ConsoleGame   //проблема с именованием, конфликт с system.console
                                    //да и как вообще правильно использовать namespace?
{
    internal class ConsoleUI : UserInterface
    {
        public const string TITLE  = "Gallows game v. alpha 01.02";

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

        public ResponseStatus? Status { get; private set; }

        public override void StartGame()
        {
            base.StartGame();
            Status = ResponseStatus.CorrectInput;
        }

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
        
        public void GetUserInput()
        {
            Console.Write("Ваш ввод: ");
            char userInput = Console.ReadKey().KeyChar;
            Status = CheckValue(userInput);
        }

        public bool IsEnd()
        {
            return Status == ResponseStatus.Win || Status == ResponseStatus.Lose;
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
            for (int i = 0; i < Game.GetHiddenWordLength(); i++)
            {
                if (Game.IndexesOfChars.Contains(i))
                {
                    Console.Write(Game.HiddenWord[i]); //убрать прямое обращение к строке и закрыть к не доступ
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
            Console.Write("Введенные буквы: ");
            Console.WriteLine(string.Join(", ", Game.UserInputList));
        }

        private void NumberOfAttempsRender()
        {
            Console.WriteLine($"Попыток осталось: {Game.MAX_NUMBER_OF_ATTEMPS - Game.NumberOfAttemps}");
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
