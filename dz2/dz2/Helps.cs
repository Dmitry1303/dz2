using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    /// <summary>
    /// Дополнительные плюшки для продуктивности
    /// </summary>
    class Helps
    {
        public static void Print(string ms, int x, int y)
        {
            // печатает в нужной области экрана
            Console.SetCursorPosition(x, y);
            Console.WriteLine(ms);
        }
        public static void Pause()
        {
            // пауза, чтобы консоль не закрылась
            Console.ReadKey();
        }
        public static string Msg_string(string ms)
        {
            //выводит сообщение пользователя и собирает его в string. Проверки не нужны
            Console.WriteLine(ms + " ");
            string result = Console.ReadLine();
            return result;
        }
        public static double Msg_double(string msg)
        {

            //выводит сообщение пользователя и собирает его в double
            Console.Write(msg + " ");
            var input = Console.ReadLine();
            double result;
            while (!double.TryParse(input, out result))
            {
                Console.WriteLine("Ошибка ввода числа.");
                Console.Write(msg +" ");
                input = Console.ReadLine();
            }
            return result;
        }
        public static int Msg_int(string msg)
        {
            //выводит сообщение пользователя и собирает его в int
            Console.Write(msg + " ");
            var input = Console.ReadLine();
            int result;
            while (!int.TryParse(input, out result))
            {
                Console.WriteLine("Ошибка ввода числа.");
                Console.Write(msg + " ");
                input = Console.ReadLine();
            }
            return result;
        }
    }
}
