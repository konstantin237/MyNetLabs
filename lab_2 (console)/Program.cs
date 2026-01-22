using System;

namespace lab_2
{
    class Program
    {
        static int GetLastDigit(int n)
        {
            return n % 10;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите натуральное число n (n <= 100): ");
                int n = int.Parse(Console.ReadLine());

                int lastDigit = GetLastDigit(n);
                Console.WriteLine("Последняя цифра числа: " + lastDigit);

                Console.Write("Выполнить ещё раз? (y/n): ");
                string answer = Console.ReadLine();

                if (answer != "y" && answer != "Y")
                    break;

                Console.WriteLine();
            }
        }
    }
}
