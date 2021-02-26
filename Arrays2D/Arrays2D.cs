using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2D
{
    // Умовистов Андрей
    //*а) Реализовать библиотеку с классом для работы с двумерным массивом.
    //Реализовать конструктор, заполняющий массив случайными числами.
    //Создать методы, которые возвращают 
    // сумму всех элементов массива, 
    //сумму всех элементов массива больше заданного, 
    //свойство, возвращающее минимальный элемент массива, 
    //свойство, возвращающее максимальный элемент массива, 
    //метод, возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out).
    //**б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    //** в) Обработать возможные исключительные ситуации при работе с файлами.

    public class Array2D
    {
        public int[,] Arr { get; set; }

        //Реализовать конструктор, заполняющий массив случайными числами.
        public Array2D(int rows, int cols, int min, int max)
        {
        
            Arr = new int[rows, cols];
            var rand = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Arr[i, j] = rand.Next(min, max);
                }
            }
        }

        //**б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        public Array2D(string path)
        {
            if (File.Exists(path))
            {
                Arr = LoadArray2DFromFile(path);
            }
            else
            {
                throw new Exception("Файл не существует!");
            }


        }
        //**б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        public int[,] LoadArray2DFromFile(string path)
        {
            int[,] result;

            var lines = File.ReadAllLines(path);
            var firstLine = lines.First();
            //считаем количество чисел в первой строке
            var firstSplitLine = firstLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var cols = firstSplitLine.Count();

            var rows = lines.Count();


            result = new int[rows, cols];


            var linesLength = lines.Length;
            // Заполняем массив из файла
            for (int i = 0; i < lines.Length; i++)
            {
                var splitLine = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < cols; j++)
                {
                    Int32.TryParse(splitLine[j], out result[i, j]);
                }
            }
            return result;

        }

        //**б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        public void SaveArray2DToFile(string path)
        {
            var rows = Arr.GetLength(0);
            var cols = Arr.GetLength(1);

            string[] lines = new string[rows];

            
            for (int i = 0; i < rows; i++)
            {
                var line = "";
                for (int j = 0; j < cols; j++)
                {
                    line += Arr[i, j];
                    //для последнего не добавляем пробел
                    if (cols - j > 1) line += " ";
                }
                lines[i] = line;
            }

            File.WriteAllLines(path, lines);
        }

        //метод, возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out).

        public int[] GetMaxElementNumber()
        {
            var result = new int[2];
            var rows = Arr.GetLength(0);
            var cols = Arr.GetLength(1);
            var max = Arr[0, 0];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Arr[i, j] > max)
                    {
                        max = Arr[i, j];
                        result[0] = i;
                        result[1] = j;
                    }
                }
            }

            return result;


        }

        //свойство, возвращающее минимальный элемент массива, 
        public int Min { get
            {
                var result = Arr[0,0];
                var rows = Arr.GetLength(0);
                var cols = Arr.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (Arr[i, j] < result) result = Arr[i, j];
                    }
                }

                return result;
            }
        }

        //свойство, возвращающее максимальный элемент массива, 
        public int Max
        {
            get
            {
                var result = Arr[0, 0];
                var rows = Arr.GetLength(0);
                var cols = Arr.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (Arr[i, j] > result) result = Arr[i, j];
                    }
                }

                return result;
            }
        }

        public void PrintArray()
        {
            var rows = Arr.GetLength(0);
            var cols = Arr.GetLength(1);
       
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{Arr[i, j],4}");
                }
                Console.WriteLine();
            }
        }

        //Создать методы, которые возвращают 
        // сумму всех элементов массива, 
        public int Sum()
        {
            var rows = Arr.GetLength(0);
            var cols = Arr.GetLength(1);
            var sum = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sum += Arr[i, j];
                }
            }
            return sum;
        }
        //Создать методы, которые возвращают 
        //сумму всех элементов массива больше заданного, 
        public int Sum(int min)
        {
            var rows = Arr.GetLength(0);
            var cols = Arr.GetLength(1);
            var sum = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Arr[i,j]> min)
                        sum += Arr[i, j];
                }
            }
            return sum;
        }

    }
}
