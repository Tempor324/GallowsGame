//using Lib.Core;

namespace GallowsGame.Lib.Core
{
    /// <summary>
    /// интерфейс для взаимодействия клиента с игрой. Принимает информацию от игрока, проверяет валидность ввода, 
    /// передаёт сообщения экземпляру игры и информацию пользователю.
    /// Проще говоря, все действия с объектом Game должны осуществляться через потомков данного класса.
    /// </summary>
    public abstract class UserInterface
    {
        protected Game Game { get; set; }

        protected List<int> IndexesOfChars { get; set; } = [];
        //protected GameStatus status { get; set; }

        protected static bool IsCharValid(char c)
        {
            return c >= 97 & c <= 122;
        }

        public UserInterface() 
        {
            //status = GameStatus.GameIsNull;
        }

        public virtual void StartGame()
        {
            Game = new Game();
            //status = GameStatus.None;
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
                if (Game.NumberOfAttemps == Game.MaxNumberOfAttemps)
                {
                    return ResponseStatus.Lose;
                }
                return ResponseStatus.PlayerMistake;
            }
            IndexesOfChars.AddRange(Game.FindAllIndexesOfChar(c));
            if (IndexesOfChars.Count == Game.HiddenWord.Length)
            {
                return ResponseStatus.Win;
            }
            return ResponseStatus.CorrectInput;
        }
    }
}