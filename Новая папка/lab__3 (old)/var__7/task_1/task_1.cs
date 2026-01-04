using System;

class Program
{
    static void Main()
    {
        int max_X = 12;
        int min_X = -12;

        Console.WriteLine("Введите координату x:");
        string inputX = Console.ReadLine();
        int point_X = Convert.ToInt32(inputX);

        Console.WriteLine("Введите координату y:");
        string inputY = Console.ReadLine();
        int point_Y = Convert.ToInt32(inputY);

        Console.WriteLine($"Вы ввели точку с координатами ({point_X}, {point_Y})");

        bool is_M_in_N1 = false;
        bool is_M_in_N2 = false;
        bool is_M_in_N3 = false;
        bool is_M_in_N4 = false;

        int limit_Y;

        switch ((point_X, point_Y))
        {
            case ( > 0, > 0):
                Console.WriteLine("Точка находится в первой четверти");

                limit_Y = max_X - point_X;

                if (point_X < max_X && point_Y < limit_Y)
                {
                    is_M_in_N1 = true;
                    Console.WriteLine($"Точка находится в области N1");
                }
                else
                {
                    is_M_in_N4 = true;
                    Console.WriteLine($"Точка находится в области N4");
                }

                break;
            case ( < 0, > 0):
                Console.WriteLine("Точка находится во второй четверти");

                limit_Y = Math.Abs(min_X + Math.Abs(point_X));

                if (point_X > min_X && point_Y < limit_Y)
                {
                    is_M_in_N2 = true;
                    Console.WriteLine($"Точка находится в области N2");
                }
                else
                {
                    is_M_in_N3 = true;
                    Console.WriteLine($"Точка находится в области N3");
                }

                break;
            case ( < 0, < 0):
                Console.WriteLine("Точка находится в третьей четверти");

                limit_Y = min_X - point_X;

                if (point_X > min_X && point_Y > limit_Y)
                {
                    is_M_in_N1 = true;
                    Console.WriteLine($"Точка находится в области N1.");
                }
                else
                {
                    is_M_in_N3 = true;
                    Console.WriteLine($"Точка находится в области N3.");
                }

                break;
            case ( > 0, < 0):
                Console.WriteLine("Точка находится в четвёртой четверти");

                limit_Y = min_X + Math.Abs(point_X);

                if (point_X < max_X && point_Y < limit_Y)
                {
                    is_M_in_N2 = true;
                    Console.WriteLine($"Точка находится в области N2.");
                }
                else
                {
                    is_M_in_N4 = true;
                    Console.WriteLine($"Точка находится в области N4.");
                }

                break;
        }

        // Добавляем ожидание нажатия клавиши перед завершением
        Console.WriteLine("Нажмите любую клавишу для завершения...");
        Console.ReadKey();
    }
}
