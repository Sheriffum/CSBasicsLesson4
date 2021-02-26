using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arrays2D;

namespace Challenge5
{
    class Program
    {
        // Умовистов Андрей
        //*а) Реализовать библиотеку с классом для работы с двумерным массивом.
        //Реализовать конструктор, заполняющий массив случайными числами.
        //Создать методы, которые возвращают сумму всех элементов массива, 
        //сумму всех элементов массива больше заданного, 
        //свойство, возвращающее минимальный элемент массива, 
        //свойство, возвращающее максимальный элемент массива, 
        //метод, возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out).
        //**б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        //** в) Обработать возможные исключительные ситуации при работе с файлами.

        static void Main(string[] args)
        {
            Helpers.Header("Работа с двумерными массивами");

            
            try
            {
                //Заполнение массива случайными числами
                // var array2D = new Array2D(10, 10, -100, 100);
                //Сохранение массива в файл
                //array2D.SaveArray2DToFile("array2D.txt");
                var array2D = new Array2D("array2D.txt");
                Helpers.Print("Массив:", ConsoleColor.Green);
                array2D.PrintArray();

                Helpers.Print($"Сумма всех элементов массива {array2D.Sum()}", ConsoleColor.Green);
                Helpers.Print($"Сумма всех элементов массива, больших 0: {array2D.Sum(0)}", ConsoleColor.Green);
                Helpers.Print($"Минимальный элемент массива {array2D.Min}", ConsoleColor.Cyan);
                Helpers.Print($"Максимальный элемент массива {array2D.Max}", ConsoleColor.Yellow);

                var maxElementNumber = array2D.GetMaxElementNumber();
                Helpers.Print($"i = {maxElementNumber[0]}, j = {maxElementNumber[1]}", ConsoleColor.Yellow);
            }
            catch (Exception ex)
            {
                Helpers.Print(ex.Message, ConsoleColor.Red);
            }
           
            Helpers.Print("Нажмите Enter для выхода");
            Console.ReadLine();
        }
    }
}
