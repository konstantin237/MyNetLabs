using System;

class Program
{
    static void Main()
    {
        // Запрашиваем у пользователя количество чисел в последовательности
        Console.Write("Введите количество элементов n: ");
        
        // Читаем ввод и конвертируем в целое число
        int n = int.Parse(Console.ReadLine());

        // Проверяем, что n больше 0
        if (n <= 0)
        {
            Console.WriteLine("Ошибка: n должно быть натуральным числом (n > 0).");
            return;
        }

        // Создаём массив для хранения чисел
        int[] numbers = new int[n];

        // Вводим числа
        Console.WriteLine($"Введите {n} целых чисел через пробел:");
        string[] input = Console.ReadLine().Split(); // Считываем строку и разбиваем на массив строк

        // Проверяем корректность ввода
        if (input.Length != n)
        {
            Console.WriteLine("Ошибка: количество введённых чисел не совпадает с n.");
            return;
        }

        // Заполняем массив
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(input[i]); // Преобразуем строку в целое число
        }

        // Находим минимальное и максимальное значение в массиве
        int min = numbers[0]; // Инициализируем min первым элементом массива
        int max = numbers[0]; // Инициализируем max первым элементом массива

        // Проходим по всем элементам массива
        for (int i = 1; i < n; i++)
        {
            if (numbers[i] < min) min = numbers[i]; // Обновляем min, если нашли меньшее значение
            if (numbers[i] > max) max = numbers[i]; // Обновляем max, если нашли большее значение
        }

        // Проверяем, выполняется ли условие max - min <= 25
        bool conditionMet = (max - min) <= 25;

        // Выводим результат
        Console.WriteLine($"Максимальное число: {max}");
        Console.WriteLine($"Минимальное число: {min}");
        Console.WriteLine($"Разница: {max - min}");
        Console.WriteLine($"Условие (max - min ≤ 25): {conditionMet}");
    }
}
