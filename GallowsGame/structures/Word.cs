using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame.structures
{
    /// <summary>
    /// This is a useless structure in this project. However, I won't be removing this or moving the implementation to another class.
    /// For now.
    /// </summary>
    struct Word
    {
        private string _word;
        //private List<char> _chars = new List<char>();

        public Word(string word)
        {
            word = word.Trim().ToLower();
            _word = word;
           // _chars.AddRange(word);
        }

        public bool IsContainChar(char c)
        {
            return _word.Contains(c);
        }

        public List<int> FindIndexOfChar(char c)
        {
            List<int> result = new List<int>();
            for (int i=0; i < _word.Length; i++)
            {
                if (_word[i]==c)
                {
                    result.Add(i);
                }
            }
            return result;
        }
    }
}
//Hovewer, i don't delete this or remove realization into Game class.
//в прочем, нет, нужен прямой доступ к размеру строки. Не думаю, что оборачивать метод в структуре в свой метод целесообразно