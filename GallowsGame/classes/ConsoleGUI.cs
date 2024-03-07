using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame.Сlasses
{
    internal class ConsoleGUI
    {
        private static string Placeholder { get; set; } = "_";
        //также тянуть текст из файла, например, для текста на разных языках? 

        private Game Game { get; set; }

        private static List<string> Responses { get; set; } = [
            "",
            "Некорректный ввод! Введите букву английского алфавита.",
            "Введите букву, которую вы ещё не вводили.",
            "Ошибка!", //погодите, а для чего это нужно? Это же на виселице должно отображаться.
            "Вас повесили!",
            "Победа!"
            ]; 
        private int ResponeCode {  get; set; } 
            //почему-то не нравится такой вариант реализации, но все варианты, что крутятся в голове, кажутся либо
            //логичным продолжением этой идеи, либо чем-то ещё более худшим или вовсе неосмысленным бредом.


        public static string Title { get; set; } = "Gallows game";

        public void StartGame(Game game)
        {
            if (game == null)
            {
                Console.WriteLine("Error, game is NULL");
                return;
            }
            Game = game;
            Update();
        }
        
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
            char userInput = UserRequest(); //поменять подход: нужно принимать от пользователя текст, его проверять и устанавливать статус, что будет выводиться далее.
            UserResponseRender(userInput);
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

        private char UserRequest()
        {
            throw new NotImplementedException();
            //return 'X';
        }

        private void UserInputListRender()
        {
            throw new NotImplementedException();
        }

        private void UserResponseRender(char c) //переработать полностью
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
