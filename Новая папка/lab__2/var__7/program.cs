using System;

class Program
{
    static void Main()
    {
        // Просим пользователя ввести натуральное число n
        Console.Write("Введите натуральное число n (n ≤ 100): ");
        
        // Считываем введенное значение и преобразуем его в целое число
        int n = int.Parse(Console.ReadLine());
        
        // Последняя цифра числа n находится с помощью операции деления по модулю на 10
        int lastDigit = n % 10;
        
        // Выводим результат на экран
        Console.WriteLine("Последняя цифра числа: " + lastDigit);
    }
}