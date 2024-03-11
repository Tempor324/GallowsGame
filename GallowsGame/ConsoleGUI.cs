using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace GallowsGame //проблема с именованием, конфликт с system.console
                      //да и как вообще правильно использовать namespace?
{
    internal class ConsoleGUI : UserInterface
    {
        private static string Placeholder { get; set; } = "_";

        protected static List<string> Responses { get; set; } = [
            "",
            "Некорректный ввод! Введите букву английского алфавита.",
            "Введите букву, которую вы ещё не вводили.",
            "Ошибка!", //погодите, а для чего это нужно? Это же на виселице должно отображаться.
            "Вас повесили!",
            "Победа!",
            //"Ошибка: игра не началась." //должно работать по-другому, вероятно
            ]; //можно преобразовать в hash-map
        
        //также тянуть текст из файла, например, для текста на разных языках? 

        public static string Title { get; set; } = "Gallows game";
        
        public void Update()
        {
            Console.Clear();
            GallowsRender();
            WordRender();
            if (Game.UserInputList.Count() != 0)
            {
                UserInputListRender();
            }
            if (Game.NumberOfAttemps != 0)
            {
                NumberOfAttempsRender();
            }
            ResponseStatus status = CheckValue(Console.Read().ToString()[0]);
            switch (status) //поменять всё на hash-map
            {
                case ResponseStatus.InvalidInput:
                    //Console.WriteLine(Responses[])
                    break;
                case ResponseStatus.CharIsUsed:
                    break;
                case ResponseStatus.CorrectInput:
                    break;
                case ResponseStatus.PlayerMistake:
                    break;
            }

            //char userInput = UserRequest(); //поменять подход: нужно принимать от пользователя текст, его проверять и устанавливать статус, что будет выводиться далее.
            //UserResponseRender(userInput);
            //string a = Responses[0];
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        private void NumberOfAttempsRender()
        {
            throw new NotImplementedException();
        }

        private void GallowsRender()
        {
            throw new NotImplementedException();
        }

        private void WordRender()
        {
            throw new NotImplementedException();
        }

        //protected override char UserRequest(char a)
        //{
        //    throw new NotImplementedException();
        //    //return 'X';
        //}

        private void UserInputListRender()
        {
            throw new NotImplementedException();
        }

        //public override ResponseStatus CheckValue(char c) //переработать под enum
        //{
        //    if (!IsCharValid(c))
        //    {
        //        return ResponseStatus.InvalidInput;
        //    }
        //    if (Game.IsCharUsed(c))
        //    {
        //        return ResponseStatus.CharIsUsed;
        //    }
        //    if (Game.IsCharContained(c))
        //    {
        //        return ResponseStatus.PlayerMistake;
        //    }
        //}
    }
}
