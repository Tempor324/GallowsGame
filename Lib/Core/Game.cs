using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame.Lib.Core
{
    public class Game //GallowsGame конфликтует с именем пространства имён
    {
        //неподходящая и не совсем (или совсем не) корректная абстракция. Игра сразу сообщает, сколько есть знакомест,
        //какие заняты какими символами, и не требуется хранение индексов чисел отдельно от самих чисел
        //и да, пока просто переезд из интерфейса сюда
        public List<int> IndexesOfChars { get; set; } = [];

        private static string[] Words { get; set; } = ["speed", "fox", "football", "nitroglycerin"]; 
        //подключить подгрузку из файла
        //можно ещё засунуть время игры сюда. Или нет
        public const int MAX_NUMBER_OF_ATTEMPS = 6;
  
        private static string GetRandomWord()
        { 
            var random = new Random();
            return Words[random.Next(Words.Length-1)];            
        }

        //должна была быть структурой для хранения "пустого" слова, заполняемого игроком.
        //не работает, нулами не заполняется, иные символы - не совсем корректное решение
        //public List<char> UserInput { get; set; } = []; 
        public List<char> UserInputList { get; private set; } = []; 
        private string _hiddenWord;
        public string HiddenWord //для безопасности от копирования нужно сделать private, но проблема с отображением символов
        { 
            get => _hiddenWord; 
            set => _hiddenWord = value.Trim().ToLower(); 
        }

        public int GetHiddenWordLength()
        {
            return HiddenWord.Length;
        }

        public int NumberOfAttemps { get; private set; } = 0;


        public Game()
        {
            HiddenWord = GetRandomWord();
            //for (int i=0; i < HiddenWord.Length; i++)
            //{
            //    UserInput.Add(null); //не работает
            //}
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

        //на корректность и валидность должен проверять клиент, здесь - максимум исключение
    }
}
