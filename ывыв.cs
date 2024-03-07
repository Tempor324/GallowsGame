using System;

public class Class1
{
    public class MyClass
    {
        private int myProperty;

        public int MyProperty
        {
            get { return myProperty; }
            set
            {
                // Ваша логика обработки значения
                if (value >= 0)
                {
                    myProperty = value;

                    // Возврат значения, например, статуса исполнения операции или кода ошибки
                    // В данном случае возвращается 0, чтобы указать успешное выполнение
                    return 0;
                }
                else
                {
                    // Возвращается код ошибки, например, -1 для указания некорректного значения
                    return -1;
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass myObject = new MyClass();

            // Пример использования
            int result = myObject.MyProperty = 42;

            // Проверка результата
            if (result == 0)
            {
                Console.WriteLine("Операция выполнена успешно");
            }
            else
            {
                Console.WriteLine("Произошла ошибка. Код ошибки: " + result);
            }
        }
    }
}
