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

        Console.WriteLine("Выберите номер области (1, 2, 3 или 4):");
        string selected_area = Console.ReadLine();
        int area = Convert.ToInt32(selected_area);

        Console.WriteLine($"Вы ввели точку с координатами ({point_X}, {point_Y}) и выбрали область N{selected_area}");

        bool isInSelectedArea = false;

        int limit_Y;

        switch (point_X, point_Y)
        {
            case ( > 0, > 0):
                Console.WriteLine("Точка находится в первой четверти");

                limit_Y = max_X - point_X;
                //Console.WriteLine($"Точка находится вне диагонали (Область (N4).")

                if (point_X < max_X && point_Y < limit_Y)
                {
                    isInSelectedArea = area == 1;
                    Console.WriteLine("Точка находится в области N1");
                }
                else
                {
                    isInSelectedArea = area == 4;
                    Console.WriteLine("Точка находится в области N4");
                }
                break;

            case ( < 0, > 0):
                Console.WriteLine("Точка находится во второй четверти");

                limit_Y = Math.Abs(min_X + Math.Abs(point_X));
                //Console.WriteLine($"Точка находится вне диагонали (Область (N4).")

                if (point_X > min_X && point_Y < limit_Y)
                {
                    isInSelectedArea = area == 2;
                    Console.WriteLine("Точка находится в область N2");
                }
                else
                {
                    isInSelectedArea = area == 3;
                    Console.WriteLine("Точка находится в область N3");
                }
                break;

            case ( < 0, < 0):
                Console.WriteLine("Точка находится в третьей четверти");

                limit_Y = min_X - point_X;
                //Console.WriteLine($"Точка находится вне диагонали (Область (N4).")

                if (point_X > min_X && point_Y > limit_Y)
                {
                    isInSelectedArea = area == 1;
                    Console.WriteLine("Точка находится в область N1");
                }
                else
                {
                    isInSelectedArea = area == 3;
                    Console.WriteLine("Точка находится в области N3");
                }
                break;

            case ( > 0, < 0):
                Console.WriteLine("Точка находится в четвёртой четверти");

                limit_Y = min_X + Math.Abs(point_X);
                //Console.WriteLine($"Точка находится вне диагонали (Область (N4).")

                if (point_X < max_X && point_Y < limit_Y)
                {
                    isInSelectedArea = area == 2;
                    Console.WriteLine("Точка находится в области N2");
                }
                else
                {
                    isInSelectedArea = area == 4;
                    Console.WriteLine("Точка находится в область N4");
                }
                break;
        }

        Console.WriteLine($"Принадлежит ли точка области N{selected_area}: {isInSelectedArea}");

        // Добавляем ожидание нажатия клавиши перед завершением
        Console.WriteLine("Нажмите любую клавишу для завершения...");
        Console.ReadKey();
    }
}
