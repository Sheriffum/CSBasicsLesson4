using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4
{
    class Program
    {
        //Умовистов Андрей
        //Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
        //Создайте структуру Account, содержащую Login и Password.

        static void Main(string[] args)
        {

            Helpers.Header("Авторизация");

            Account[] users;
            var path = "users.txt";
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                var linesLength = lines.Length;
                if (linesLength==0)
                {
                    Helpers.Print("В файле нет строк!", ConsoleColor.Red);

                } else 
                {
                    users = new Account[linesLength];
                    // Получаем пользователей из файла
                    for (int i = 0; i < lines.Length; i++)
                    {
                        var splitLine = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (splitLine.Length == 2)
                        {
                            users[i] = new Account { Login = splitLine[0], Password = splitLine[1] };
                    }
                    }
           
                    // Просим авторизоваться
                    var attempts = 3;
                    bool isAutorized = Authorize(users, attempts);


                    if (isAutorized)
                    {
                        Helpers.Print("Поздравляем. Вы успешно авотризовались", ConsoleColor.Green);
                    }
                    else
                    {
                        Helpers.Print("Ты кто такой? Давай до свидания!", ConsoleColor.Red);
                    }
                }
                

            }
            else
            {
                Helpers.Print("Файл не найден", ConsoleColor.Yellow);
            }



            Helpers.Print("Нажмите Enter для выхода");
            Console.ReadLine();
        }

        public struct Account
        {
            public string Login;
            public string Password;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="attempts"></param>
        /// <returns>sad</returns>
        private static bool Authorize(Account[] users, int attempts)
        {
            while (attempts > 0)
            {
                attempts--;

                Console.Write("Введите логин: ");
                var login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                var password = Console.ReadLine();
                var tmpAccount = new Account { Login = login, Password = password };
                if (users.Contains(tmpAccount))
                    return true;
                else
                    Helpers.Print($"Введены неверные логин/пароль. Осталось попыток: {attempts}", ConsoleColor.Yellow);
            }
            return false;
        }
    }
}
