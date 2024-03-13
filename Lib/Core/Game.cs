using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame.Lib.Core
{
    public class Game
    {
        private static string[] Words { get; set; } = ["speed", "fox", "football", "nitroglycerin"]; //подключить подгрузку из файла
        //можно ещё засунуть время игры сюда. Или нет
        private static string GetRandomWord()
        { 
            var random = new Random();
            return Words[random.Next(Words.Length-1)];            
        }

        //public GameStatus Status { get; set; } = GameStatus.Default;

        private string _hiddenWord;
        public string HiddenWord 
        { 
            get => _hiddenWord; 
            private set => _hiddenWord = value.Trim().ToLower(); 
        }
        public static int MaxNumberOfAttemps { get; set; } = 6;
        public int NumberOfAttemps { get; private set; } = 0;
        public List<char> UserInputList { get; private set; } = []; 

        //есть ли принципиальная разница между конструктором и гипотетическим методом StartGame?
        public Game()
        {
            HiddenWord = GetRandomWord();
        }

        public bool IsCharWasUsed(char c)
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
           var result = new List<int>();
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
