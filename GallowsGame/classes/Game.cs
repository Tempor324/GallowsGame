using GallowsGame.structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame
{
    internal class Game
    {
        private static string[] _words = { "speed", "fox", "football", "nitroglycerin" }; //подключить подгрузку из файла
        //можно ещё засунуть время игры сюда. Или нет
        private string _hiddenWord;

        public string HiddenWord 
        { 
            get => _hiddenWord; 
            private set => _hiddenWord = value.Trim().ToLower(); 
        }

        public int NumberOfAttemps { get; private set; } = 0;
        public List<char> UserInputList { get; private set; } = new List<char>(); 

        /// <summary>
        /// получаем рандомный номер в пределах размера массива
        /// возвращаем слово по индексу
        /// </summary>
        /// <returns></returns>
        private static string GetRandomWord()
        { 
            var random = new Random();
            return _words[random.Next(_words.Length-1)];            
        }
        
        //есть ли принципиальная разница между конструктором и гипотетическим методом StartGame?
        public Game(/*out int Length*/)
        {
            HiddenWord = GetRandomWord();
            //Length = HiddenWord.Length; //нет, бредовая идея, точно также можно передавать и само слово
        }

        public bool IsCharUsed(char c)
        {
            return UserInputList.Contains(c);
        }

        public bool IsCharContained(char c)
        {
            c = char.ToLower(c);
            UserInputList.Add(c);
            UserInputList.Sort();
            bool result = HiddenWord.Contains(c);
            if (!result)
                NumberOfAttemps++;
            return result;
        }

        public List<int> FindAllIndexesOfChar(char c)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < HiddenWord.Length; i++)
            {
                if (HiddenWord[i] == c)
                {
                    result.Add(i);
                }
            }
            return result;
        }

        //напрашивается логика для победы/поражения, но не знаю, как это лучше реализовать, и стоит ли реализовывать в игровом классе

        //проверка корректности ввода
        //здесь же можно проверить на валидность.
        //должны быть какие-то коды для сообщений вызывающему методу
        //...хотя нет, на корректность и валидность должен проверять клиент, здесь - максимум исключение


    }
}
