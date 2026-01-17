using System;

namespace Lab4_Variant7
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Лабораторная работа 4, Вариант 7 ===");
                Console.WriteLine("1. Задание 1 - Вычисление Y по формуле");
                Console.WriteLine("2. Задание 2 - Проверка арифметического условия");
                Console.WriteLine("3. Задание 3 - Сумма чисел, кратных 3");
                Console.WriteLine("0. Выход");
                Console.WriteLine();
                Console.Write("Выберите задание: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Task1();
                        break;
                    case "2":
                        Task2();
                        break;
                    case "3":
                        Task3();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
                Console.ReadKey();
            }
        }

        // Задание 1: Вычисление Y по формуле
        static void Task1()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 1: Вычисление Y по формуле ===");
            Console.WriteLine();

            Console.Write("Введите значение x: ");
            int x = int.Parse(Console.ReadLine());

            int a = x + 2;
            int b = x - 3;
            int c = x + 5;

            Console.WriteLine();
            Console.WriteLine("a = x + 2 = {0}", a);
            Console.WriteLine("b = x - 3 = {0}", b);
            Console.WriteLine("c = x + 5 = {0}", c);
            Console.WriteLine();

            int minValue = Math.Min(a, Math.Min(b, c));
            int maxValue = Math.Max(a, Math.Max(b, c));

            double y;
            string formula;

            if (a == minValue)
            {
                y = (a + 110 * c) / (6.0 * b);
                formula = "(a + 110c) / 6b, a = min(a, b, c)";
            }
            else if (b == minValue)
            {
                y = (10 * c + 5 * a) / (14.0 * b);
                formula = "(10c + 5a) / 14b, b = min(a, b, c)";
            }
            else
            {
                y = maxValue;
                formula = "max(a, b, c), c = min(a, b, c)";
            }

            Console.WriteLine("Минимальное значение: {0}", minValue);
            Console.WriteLine("Использована формула: {0}", formula);
            Console.WriteLine("Результат Y = {0:F2}", y);
        }

        // Задание 2: Проверка арифметического условия
        static void Task2()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 2: Проверка арифметического условия ===");
            Console.WriteLine();

            Console.Write("Введите двузначное число (10-99): ");
            int number = int.Parse(Console.ReadLine());

            int tens = number / 10;
            int units = number % 10;

            long square = (long)number * number;
            long sumCubes = 4 * ((long)Math.Pow(tens, 3) + (long)Math.Pow(units, 3));

            Console.WriteLine();
            Console.WriteLine("Число: {0}", number);
            Console.WriteLine("Цифра десятков (a) = {0}", tens);
            Console.WriteLine("Цифра единиц (b) = {0}", units);
            Console.WriteLine();
            Console.WriteLine("n^2 = {0}", square);
            Console.WriteLine("4(a^3 + b^3) = {0}", sumCubes);
            Console.WriteLine();

            if (square == sumCubes)
            {
                Console.WriteLine("Ответ: ПОЛОЖИТЕЛЬНЫЙ");
            }
            else
            {
                Console.WriteLine("Ответ: ОТРИЦАТЕЛЬНЫЙ");
            }
        }

        // Задание 3: Сумма чисел, кратных 3
        static void Task3()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 3: Сумма чисел, кратных 3 ===");
            Console.WriteLine();

            Console.Write("Число 1: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Число 2: ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Число 3: ");
            int c = int.Parse(Console.ReadLine());

            Console.Write("Число 4: ");
            int d = int.Parse(Console.ReadLine());

            int sum = 0;
            string addedNumbers = "";

            if (a % 3 == 0)
            {
                sum += a;
                addedNumbers += a.ToString() + " ";
            }

            if (b % 3 == 0)
            {
                sum += b;
                addedNumbers += b.ToString() + " ";
            }

            if (c % 3 == 0)
            {
                sum += c;
                addedNumbers += c.ToString() + " ";
            }

            if (d % 3 == 0)
            {
                sum += d;
                addedNumbers += d.ToString() + " ";
            }

            Console.WriteLine();

            if (addedNumbers.Length > 0)
            {
                Console.WriteLine("Числа, кратные 3: {0}", addedNumbers.Trim());
                Console.WriteLine("Сумма чисел, кратных 3: {0}", sum);
            }
            else
            {
                Console.WriteLine("Нет чисел, кратных 3");
                Console.WriteLine("Сумма: 0");
            }
        }



    }
}