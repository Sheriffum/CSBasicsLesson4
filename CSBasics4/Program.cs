using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBasics4
{
    class Program
    {
        //Умовистов Андрей
        // 1 Дан целочисленный  массив из 20 элементов.Элементы массива  могут принимать  целые значения  от –10 000 до 10 000 включительно.
        //Заполнить случайными числами.Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. 
        //В данной задаче под парой подразумевается два подряд идущих элемента массива.
        //Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 

        // 2 Реализуйте задачу 1 в виде статического класса StaticClass;
        //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
        //б) *Добавьте статический метод для считывания массива из текстового файла.
        //Метод должен возвращать массив целых чисел;
        //в)**Добавьте обработку ситуации отсутствия файла на диске.

        // 3 а) Дописать класс для работы с одномерным массивом.
        //Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.
        //Создать свойство Sum, которое возвращает сумму элементов массива, 
        //метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива(старый массив, остается без изменений),  
        //метод Multi, умножающий каждый элемент массива на определённое число, 
        //свойство MaxCount, возвращающее количество максимальных элементов.
        //б)** Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу библиотеки
        //е) *** Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary<int, int>)

        static void Main(string[] args)
        {
           
            Helpers.Header("Массивы");

   
            var path = "in.txt";
            int[] arr = new int[20];

            //в)**Добавьте обработку ситуации отсутствия файла на диске.
            if (File.Exists(path))
            {
                arr = StaticClass.LoadArrFromFile(path);
                var arrLength = arr.Length;

                StaticClass.PrintArray(arr, splitByPairs: true, highlightDivisible: true, divisor: 3);


                Helpers.Print($"Количество пар: {StaticClass.CalculateSumm(arr)}", ConsoleColor.Green);

            } else
            {
                Helpers.Print("Файл не найден", ConsoleColor.Yellow);
            }



            //ДЕМО: Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.
            var ah = new ArrayHelper(10, 3, 5);
    
            ArrayHelper.PrintArray(ah.arr);


            //ДЕМО: Создать свойство Sum, которое возвращает сумму элементов массива, 
            Helpers.Print($"Сумма всех элементов: {ah.Sum}", ConsoleColor.Blue);

            //ДЕМО: метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива(старый массив, остается без изменений),  
            var inversedArr = ah.Inverse(ah.arr);
            Helpers.Print("Инверсированный массив: ", ConsoleColor.Blue);
            ArrayHelper.PrintArray(inversedArr);

            //ДЕМО: метод Multi, умножающий каждый элемент массива на определённое число, 
            Helpers.Print("Умноженный на 2 массив: ", ConsoleColor.Blue);
            ah.Multi(2);
            ArrayHelper.PrintArray(ah.arr);

            //ДЕМО: свойство MaxCount, возвращающее количество максимальных элементов.
            Helpers.Print($"Количество максимальных элементов: {ah.MaxCount}", ConsoleColor.Blue);


            //ДЕМО: е) *** Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary<int, int>)
            var frequencies = ah.GetFrequencies(ah.arr);
            Helpers.Print("Частоты вхождений:", ConsoleColor.Blue);
            foreach (var item in frequencies)
            {
                Console.WriteLine($"Элемент {item.Key} - {item.Value} раз");
            }


            Helpers.Print("Нажмите Enter для выхода");
            Console.ReadLine();
        }



        // 2 Реализуйте задачу 1 в виде статического класса StaticClass;
        //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
        //б) *Добавьте статический метод для считывания массива из текстового файла.
        //Метод должен возвращать массив целых чисел;
        //в)**Добавьте обработку ситуации отсутствия файла на диске.
        public static class StaticClass
        {

            // Вывод массива на экран попарно с подсветкой делящихся на три
            public static void PrintArray(int[] arr, bool splitByPairs = false, bool highlightDivisible = false, int divisor = 0)
            {
                Helpers.Print("Массив", ConsoleColor.Green);
                var arrLength = arr.Length;
                for (int i = 0; i < arrLength; i++)
                {
                    var color = ConsoleColor.White;
                    if (highlightDivisible && arr[i] % divisor == 0)
                    {
                        color = ConsoleColor.Blue;
                    }
                    Helpers.Print(arr[i].ToString(), color);


                    if (splitByPairs && i % 2 == 1) Console.WriteLine();
                }
            }

            //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
            public static int CalculateSumm(int[] arr)
            {
      
                var arrLength = arr.Length;


                var count = 0;
                for (int i = 0; i < arrLength; i++)
                {
                    // берем каждый четный элемент и его предыдущий (2 и 1, 4 и 3, ... ,20 и 19)
                    if (i > 0 && i % 2 == 1)
                    {
                        if (arr[i] % 3 == 0 || arr[i - 1] % 3 == 0)
                        {
                            count++;
                        }
                    }
                }
                return count;
            }


            //б) *Добавьте статический метод для считывания массива из текстового файла.
            //Метод должен возвращать массив целых чисел;
            public static int[] LoadArrFromFile(string path)
            {
                var text = File.ReadAllText(path);

                var numbers = text.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var count = numbers.Count();
                int[] result = new int[count];

                for (int i = 0; i < count; i++)
                {
                    Int32.TryParse(numbers[i], out result[i]);
                }
  
                return result;
            }
        }


      
    }
}
