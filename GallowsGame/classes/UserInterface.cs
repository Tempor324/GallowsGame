using GallowsGame.enums;

namespace GallowsGame.Сlasses
{
    /// <summary>
    /// интерфейс для взаимодействия клиента с игрой. Принимает информацию от игрока, проверяет валидность ввода, 
    /// передаёт сообщения экземпляру игры и информацию пользователю.
    /// Проще говоря, все действия с объектом Game должны осуществляться через потомков данного класса.
    /// </summary>
    public abstract class UserInterface
    {
        protected Game Game { get; set; }

        protected ResponseStatus Status { get; set; }

        //protected static List<string> Responses { get; set; } = [
        //    //"",
        //    "Некорректный ввод! Введите букву английского алфавита.",
        //    "Введите букву, которую вы ещё не вводили.",
        //    "Ошибка!", //погодите, а для чего это нужно? Это же на виселице должно отображаться.
        //    "Вас повесили!",
        //    "Победа!"
        //    ]; //можно использовать не список, а перечисление enum
        //напоминание: изучить работу с кодами статуса

        public void StartGame()
        {
            Game = new Game();
        }

        /// <summary>
        /// приём информации от игрока через интерфейсы ввода
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public abstract void CheckValue(char c); //!!определиться с типом вывода и кодами статуса!!
        //{
        //    if (!IsCharValid(c))
        //    {
        //        Console.WriteLine("Некорректный ввод! Введите букву английского алфавита.");
        //        return;
        //    }
        //    if (Game.IsCharUsed(c))
        //    {
        //        Console.WriteLine("Введите букву, которую вы ещё не вводили.");
        //        return;
        //    }
        //    if (Game.IsCharContained(c))
        //    {
        //        Console.WriteLine("Ошибка!");

        //    }
        //}

        protected bool IsCharValid(char c)
        {
            throw new NotImplementedException();
            //return false; 
        }
    }
}