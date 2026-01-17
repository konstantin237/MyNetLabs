using System;
using System.Globalization;

namespace Lab1_Variant7
{
    class Program
    {
        static void Main()
        {
            // ================== ЗАДАНИЕ 1 ==================
            // Вывод информации о системе
            ShowSystemInfo();

            // Вывод области определения функции
            ShowWarnings();

            // ================== ОСНОВНОЙ ЦИКЛ ==================
            // Позволяет выполнять вычисления многократно
            while (true)
            {
                Console.WriteLine();
                Console.Write("Введите значение x (или exit для выхода): ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
                    break;

                bool isInt;
                double x;

                // Попытка преобразовать введённую строку в число
                try
                {
                    x = ParseNumber(input, out isInt);
                }
                catch
                {
                    Console.WriteLine("Ошибка: введено не числовое значение.");
                    continue;
                }

                // Проверка области определения
                if (!IsValidX(x))
                    continue;

                Console.WriteLine();

                // ================== ЗАДАНИЕ 2 ==================
                // Вызов перегруженного метода
                double result;

                if (isInt)
                {
                    result = Calc((int)x);
                    Console.WriteLine("Использован перегруженный метод Calc(int).");
                }
                else
                {
                    result = Calc(x);
                    Console.WriteLine("Использован перегруженный метод Calc(double).");
                }

                Console.WriteLine("Результат вычисления: {0:F6}", result);
                Console.WriteLine();

                // ================== ЗАДАНИЕ 3 ==================
                // Табличный вывод значений
                DrawTable(x, isInt);

                Console.WriteLine();
                Console.WriteLine("Тип аргумента: " + (isInt ? "int" : "double"));
            }
        }

        // ================== ИНФОРМАЦИЯ О СИСТЕМЕ ==================
        static void ShowSystemInfo()
        {
            Console.WriteLine("Версия операционной системы: " + Environment.OSVersion);
            Console.WriteLine("Текущая дата и время: " + DateTime.Now);
        }

        // ================== ПРЕДУПРЕЖДЕНИЯ И ПОЯСНЕНИЯ ==================
        static void ShowWarnings()
        {
            Console.WriteLine();
            Console.WriteLine("Ограничения и пояснения для значения x:");
            Console.WriteLine();

            Console.WriteLine("1) x не может быть равен 1,");
            Console.WriteLine("   так как (1 - x) = 0 и происходит деление на ноль.");
            Console.WriteLine();

            Console.WriteLine("2) Не вводить значения");
            Console.WriteLine("   x = PI / 2 + PI * k, где k принадлежит Z,");
            Console.WriteLine("   так как для этих значений тангенс не определён.");
            Console.WriteLine();

            Console.WriteLine("Пояснение:");
            Console.WriteLine("PI прибл. равно 3.14159, поэтому PI / 2  прибл. равно 1.5708.");
            Console.WriteLine("Тангенс не определён при x прибл. равно  1.5708, 4.7124, -1.5708 и т.д.");
            Console.WriteLine();

            Console.WriteLine("Важно:");
            Console.WriteLine("Вещественные числа в компьютере представлены приближённо,");
            Console.WriteLine("поэтому значения, близкие к PI / 2, могут быть обработаны");
            Console.WriteLine("как допустимые из-за численной погрешности.");
            Console.WriteLine();

            Console.WriteLine("Функция Math.Tan принимает аргумент в радианах,");
            Console.WriteLine("а не в градусах (90 градусов = PI / 2 радиан).");
        }

        // ================== ПРОВЕРКА ДОПУСТИМОСТИ x ==================
        static bool IsValidX(double x)
        {
            // Проверка деления на ноль
            if (x == 1)
            {
                Console.WriteLine("Ошибка: x = 1 недопустим (деление на ноль).");
                return false;
            }

            // Проверка неопределённости тангенса
            if (IsTangentUndefined(x))
            {
                Console.WriteLine("Ошибка: tg(x) не определён, так как cos(x) = 0.");
                Console.WriteLine("Запрещены значения x = PI / 2 + PI * k.");
                return false;
            }

            return true;
        }

        // ================== АВТООПРЕДЕЛЕНИЕ ТИПА ЧИСЛА ==================
        static double ParseNumber(string input, out bool isInt)
        {
            // Разрешаем ввод с точкой и с запятой
            input = input.Replace(',', '.');

            int intValue;
            if (int.TryParse(input, out intValue))
            {
                isInt = true;
                return intValue;
            }

            double doubleValue;
            if (double.TryParse(
                input,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out doubleValue))
            {
                isInt = false;
                return doubleValue;
            }

            throw new Exception();
        }

        // ================== ЗАДАНИЕ 2 (ПЕРЕГРУЗКА МЕТОДОВ) ==================
        static double Calc(int x)
        {
            return CalcInternal(x);
        }

        static double Calc(double x)
        {
            return CalcInternal(x);
        }

        // ================== ОБЩИЙ МЕТОД РАСЧЁТА ==================
        // Формула:
        // 1/4 * ( (1 + x^2) / (1 - x) + 1/2 * tg(x) )
        static double CalcInternal(double x)
        {
            return 0.25 * ((1 + x * x) / (1 - x) + 0.5 * Math.Tan(x));
        }

        // ================== ПРОВЕРКА ТАНГЕНСА ==================
        static bool IsTangentUndefined(double x)
        {
            // Тангенс не определён, если cos(x) = 0.
            // Из-за погрешностей используется eps.
            const double eps = 1e-10;
            return Math.Abs(Math.Cos(x)) < eps;
        }

        // ================== ТАБЛИЧНЫЙ ВЫВОД ==================
        static void DrawTable(double x, bool isInt)
        {
            Console.WriteLine("+----------------------+----------------------+");
            Console.WriteLine("|          x           |        f(x)          |");
            Console.WriteLine("+----------------------+----------------------+");

            double fx = CalcInternal(x);

            Console.WriteLine(
                "| {0,20} | {1,20:F6} |",
                isInt ? ((int)x).ToString() : x.ToString("F3"),
                fx
            );

            Console.WriteLine("+----------------------+----------------------+");
        }
    }
}
