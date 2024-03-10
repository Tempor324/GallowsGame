using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame.Сlasses
{
    internal class ConsoleGUI : UserInterface
    {
        private static string Placeholder { get; set; } = "_";

        protected static List<string> Responses { get; set; } = [
            //"",
            "Некорректный ввод! Введите букву английского алфавита.",
            "Введите букву, которую вы ещё не вводили.",
            "Ошибка!", //погодите, а для чего это нужно? Это же на виселице должно отображаться.
            "Вас повесили!",
            "Победа!"
            ]; //нужно адаптировать под enum

        //private int ResponeStatusCode { get; set; } //перенёс из UI, так как нужен для вывода сообщения.
        
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

        public override void CheckValue(char c) //переработать под enum
        {
            if (!IsCharValid(c))
            {
                Console.WriteLine("Некорректный ввод! Введите букву английского алфавита.");
                return;
            }
            if (Game.IsCharUsed(c))
            {
                Console.WriteLine("Введите букву, которую вы ещё не вводили.");
                return;
            }
            if (Game.IsCharContained(c))
            {
                Console.WriteLine("Ошибка!");

            }
        }

        private bool IsCharValid(char c) 
        {
            throw new NotImplementedException();
            //return false; 
        }
        
    }
}
