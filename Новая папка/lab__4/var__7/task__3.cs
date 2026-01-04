using System;

class Program
{
    static void Main()
    {
        // Ввод чисел
        Console.WriteLine("Введите четыре целых числа:");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());

        // Вычисление суммы чисел, кратных 3
        int sum = 0;

        if (a % 3 == 0)
            sum += a;

        if (b % 3 == 0)
            sum += b;

        if (c % 3 == 0)
            sum += c;

        if (d % 3 == 0)
            sum += d;

        // Вывод результата
        Console.WriteLine("Сумма чисел, кратных 3: " + sum);
    }
}
