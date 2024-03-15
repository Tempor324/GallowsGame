//using Lib.Core;

namespace GallowsGame.Lib.Core
{
    /// <summary>
    /// интерфейс для взаимодействия клиента с игрой. Принимает информацию от игрока, проверяет валидность ввода, 
    /// передаёт сообщения экземпляру игры и информацию пользователю.
    /// Проще говоря, все действия с объектом Game должны осуществляться через потомков данного класса.
    /// P.s. если я правильно понимаю, по сути, этот класс выполняет роль API для взаимодействия с игрой. Для корректности
    /// следует переписать реализацию, сделать её более "стандартной"
    /// </summary>
    public abstract class UserInterface
    {
        protected Game Game { get; set; }

        
        
        public virtual void StartGame()
        {
            Game = new Game();
            //IndexesOfChars = new List<int>();
        }

        public ResponseStatus CheckValue(char c)
        {
            if (!IsCharValid(c))
            {
                return ResponseStatus.InvalidInput;
            }
            if (Game.IsCharWasUsed(c))
            {
                return ResponseStatus.CharIsUsed;
            }
            if (!Game.IsCharContained(c))
            {
                if (Game.NumberOfAttemps == Game.MAX_NUMBER_OF_ATTEMPS)
                {
                    return ResponseStatus.Lose;
                }
                return ResponseStatus.PlayerMistake;
            }
            Game.IndexesOfChars.AddRange(Game.FindAllIndexesOfChar(c));
            if (Game.IndexesOfChars.Count == Game.GetHiddenWordLength())
            {
                return ResponseStatus.Win;
            }
            return ResponseStatus.CorrectInput;
        }

        protected static bool IsCharValid(char c)
        {
            return c >= 97 & c <= 122;
        }
       
    }
}