using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    class Program
    {
        /// <summary>
        /// Акулов Д.С. вторая д.з.
        /// </summary>
        /// <param name="args"></param>
        // public int summar;
        static void Main(string[] args)
        {

            switch (Helps.Msg_int("Выберите задачу от 1 до 7"))
            {

                case 1: // Задача 1 
                    Console.WriteLine("Минимальное число из указанных вами> " +
                        $"{Z_1(Helps.Msg_double("Введите X>"), Helps.Msg_double("Введите Y>"), Helps.Msg_double("Введите Z>"))}"); // найти минимум из 3 чисел
                    break;
                case 2: // Задача 2 
                    switch (Helps.Msg_int("Выберите 1 из двух вариантов решения \n(для int и для плавающей запятой..)>"))
                    {
                        case 1:
                            // для Int просто делим и отсекаем остаток
                            Console.WriteLine("Количество цифр в вашем числе> " +
                                $"{Z_2(Helps.Msg_int("Введите число>"))}");
                            break;
                        case 2:
                            // для double проще просто посчитать кол-во символов в строке
                            Console.WriteLine("Количество цифр в вашем числе> " +
                                $"{Z_2_global(Helps.Msg_string("Введите число>"))}");
                            break;
                        default:
                            break;
                    }
                    break;
                case 3: // Задача 3
                    Console.WriteLine($"Сумма введенных нечетных положительных чисел: {Z_3(Helps.Msg_int("Введите число>"))}");
                    break;
                case 4: // Задача 4
                    bool result = Z_4(Helps.Msg_string("Логин:"), Helps.Msg_string("Пароль:"));
                    Console.WriteLine($"Подключение - {result}");
                    if (result == true)
                    {
                        //do something
                    }
                    else
                    {
                        // kill user
                    }
                    break;
                case 5: // Задача 5
                    Console.WriteLine($"Ваш ИМТ: {Z_5(Helps.Msg_double("Введите вес, в кг:"), Helps.Msg_double("Введите рост, в см:"))}");
                    break;
                case 6: // Задача 6
                    Z_6();
                    break;
                case 7:
                    switch (Helps.Msg_int("Выбери 1 или 2(со звездочкой)"))
                    {
                        case 1:
                            Z_7_1(Helps.Msg_int("Первое число"), Helps.Msg_int("Второе число"));
                            break;
                        case 2:
                            Console.WriteLine($" {counter(Helps.Msg_int("Первое число"), Helps.Msg_int("Второе число"))}");
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            Helps.Pause();
        }
        static double Z_1(double x, double y, double z) // найти минимум из 3 чисел
        {
            double result = Math.Min(Math.Min(x, y), z); // вычисление минимума из трех чисел
            // можно сравнивать все три попарно, но так мне кажется лучше

            return result;
        }

        static int Z_2(int x)
        {
            // способ для целых чисел
            var count = 0;
            while (x != 0)
            {
                x /= 10;
                count++;
            }
            return count;
        }

        static int Z_2_global(string x)
        {
            // способ для любых чисел в диапазоне double
            while (!double.TryParse(x, out double check))
            {
                Console.WriteLine("Ошибка ввода числа.");
                Console.Write("Введите число> ");
                x = Console.ReadLine();
            }
            int count = x.Replace(".", "").Replace(",", "").Length; // в зависимости от региона пользователя могут быть и . и ,
            return count;
        }

        static int Z_3(int x)
        {
            int result = 0;
            int checker = x;
            while (checker != 0)
            {
                checker = Helps.Msg_int("Введите число>");
                if (checker / 2 != 0 && checker > 0)
                {
                    result = result + checker;
                }
            }
            return result;
        }

        static bool Z_4(string x, string y)
        {
            int count = 1;
            do
            {
                if (x.Equals("root") && y.Equals("GeekBrains"))
                {
                    return true;
                }

                Console.WriteLine("Неверно! Осталось попыток {0}", 3 - count);
                count++;
                x = Helps.Msg_string("Логин:");
                y = Helps.Msg_string("Пароль:");
            } while (count < 3);
            return false;
        }

        static double Z_5(double weight, double height)
        {
            // Хотел сделать разделение для мужчин и женщин, но почему-то на вики общая таблица ИМТ
            int flag = 2; // флаг нужен, чтобы понять, человеку надо похудеть, набрать или ничего не делать, поставил 2, потому-что страхуюсь от всяких рандомных случаев когда 0 вылезает.
            double c = Math.Round((weight / ((height / 100) * (height / 100))));
            if (c < 16)
            {
                Console.WriteLine("Выраженный дефицит массы тела");
                flag = 3;
            }
            else if (c >= 16 && c < 18.5)
            {
                Console.WriteLine("Недостаточная (дефицит) массы тела");
                flag = 3;
            }
            else if (c >= 18.5 && c < 25)
            {
                Console.WriteLine("Норма");
                flag = 5;

            }
            else if (c >= 25 && c < 30)
            {
                Console.WriteLine("Избыточная масса тела (предожирение)");
                flag = 6;
            }
            else if (c >= 30 && c < 35)
            {
                Console.WriteLine("Ожирение");
                flag = 6;
            }
            else if (c >= 35 && c < 40)
            {
                Console.WriteLine("Ожирение резкое");
                flag = 6;
            }
            else if (c >= 40)
            {
                Console.WriteLine("Очень резкое ожирение");
                flag = 6;
            }
            if (flag == 6)
            {
                double new_weight = (height / 100) * (height / 100) * 21;
                Console.WriteLine($"Вам нужно похудеть на:{weight - Math.Round(new_weight)}");
            }
            else if (flag == 3)
            {
                double new_weight = (height / 100) * (height / 100) * 21;
                Console.WriteLine($"Вам нужно набрать:{Math.Round(new_weight) - weight}");
            }
            return c;
        }

        static void Z_6()
        {
            DateTime x = DateTime.Now;
            int count = 0;
            for (int i = 1; i <= 1000000000; i++)
            {

                int counter = 0;
                int i_number = i;
                int summary = 0;
                while (i_number != 0)
                {
                    counter = i_number % 10; // остаток = цифре
                    i_number /= 10; // убираем цифру из числа
                    summary = summary + counter; // суммируем все цифры числа
                }
                if (i % summary == 0)
                {
                    count++;
                }
            }
            DateTime y = DateTime.Now;
            double seconds = (y - x).TotalSeconds;
            Console.WriteLine($"Время выполнения: {seconds} секунд \nКоличество таких чисел: {count}");
        }

        static void Z_7_1(int x, int y)
        {
            if (x <= y)
            {
                Console.Write($"{x}; ");
                Z_7_1(x + 1, y);
            }
        }

        static int counter(int x, int y)
        {
            if (x >= y)
            {
                return 0;
            }
            return x + counter(x + 1, y);
        }
    }
}
