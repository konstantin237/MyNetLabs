using System;

class Program
{
    static void Main()
    {
        // Запрос числа a у пользователя
        Console.Write("Введите число a (1 < a ≤ 1.5): ");
        double a;

        // Проверяем корректность ввода
        while (!double.TryParse(Console.ReadLine(), out a) || a <= 1 || a > 1.5)
        {
            Console.Write("Ошибка! Введите число a в диапазоне (1 < a ≤ 1.5): ");
        }

        // Переменная для хранения текущего значения последовательности
        double currentNumber;
        int n = 2; // Начинаем с 1 + 1/2

        // Ищем первое число последовательности, которое меньше a
        do
        {
            currentNumber = 1 + (1.0 / n);
            n++; // Переход к следующему члену последовательности
        } while (currentNumber >= a);

        // Вывод найденного значения
        Console.WriteLine($"Первое число последовательности, меньшее {a}: {currentNumber} (при n = {n - 1})");

        // Ожидание ввода перед закрытием программы
        Console.ReadLine();
    }
}
