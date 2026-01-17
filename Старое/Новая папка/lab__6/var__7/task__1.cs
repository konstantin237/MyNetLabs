using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите последовательность чисел, заканчивающуюся нулем:");

        int countPositive = 0;  // Количество положительных чисел
        int prevNumber = 0;  // Предыдущее число
        bool isFirst = true; // Флаг первого числа

        int maxDiff = 0; // Максимальная разница
        int num1 = 0, num2 = 0; // Числа с наибольшей разницей

        while (true)
        {
            try
            {
                Console.Write("Введите число: ");
                int number = int.Parse(Console.ReadLine() ?? "0");

                if (number == 0)
                    break; // Конец последовательности

                if (number > 0)
                    countPositive++; // Считаем положительные числа

                if (!isFirst)
                {
                    int diff = Math.Abs(number - prevNumber);
                    if (diff > maxDiff)
                    {
                        maxDiff = diff;
                        num1 = prevNumber;
                        num2 = number;
                    }
                }

                prevNumber = number;
                isFirst = false; // После первого числа выключаем флаг
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка! Введите корректное число.");
            }
        }

        // Вывод результатов
        Console.WriteLine($"\nКоличество положительных чисел: {countPositive}");

        if (!isFirst)
            Console.WriteLine($"Наиболее далекие соседние числа: {num1} и {num2} (разница {maxDiff})");
        else
            Console.WriteLine("Последовательность не содержит данных.");

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
