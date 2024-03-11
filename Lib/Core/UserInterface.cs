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

        protected GameStatus status { get; set; }

        public UserInterface() 
        {
            status = GameStatus.GameIsNull;
        }

        public virtual void StartGame() //подробнее изучить механизм "наследования" методов
        {
            Game = new Game();
            status = GameStatus.None;
        }

        public virtual ResponseStatus CheckValue(char c)
        {
            if (!IsCharValid(c))
            {
                return ResponseStatus.InvalidInput;
            }
            if (Game.IsCharUsed(c))
            {
                return ResponseStatus.CharIsUsed;
            }
            if (Game.IsCharContained(c))
            {
                return ResponseStatus.PlayerMistake;
            }
            return ResponseStatus.CorrectInput;
        }

        protected bool IsCharValid(char c)
        {
            //if (Status == ResponseStatus.GameIsNull)
            //{
            //    return false; //ох, как мне не нравится этот подход, но ничего толкового в голову не приходит.
            //}
            return c >= 97 & c <= 122;
        }
    }
}