using System;
using System.Collections.Generic;
using System.Text;

namespace lab__3
{
    internal class Program

    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Лабораторная работа 3, Вариант 7 ===");
                Console.WriteLine("1. Задание 1 - Определение области точки");
                Console.WriteLine("2. Задание 2 - Принадлежность точки выбранной области");
                Console.WriteLine("3. Задание 3 - Определение карты");
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

        static void Task1()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 1 ===");

            int max_X = 12;
            int min_X = -12;

            Console.WriteLine("Введите координату x:");
            string inputX = Console.ReadLine();
            int point_X = Convert.ToInt32(inputX);

            Console.WriteLine("Введите координату y:");
            string inputY = Console.ReadLine();
            int point_Y = Convert.ToInt32(inputY);

            Console.WriteLine("Вы ввели точку с координатами ({0}, {1})", point_X, point_Y);

            bool is_M_in_N1 = false;
            bool is_M_in_N2 = false;
            bool is_M_in_N3 = false;
            bool is_M_in_N4 = false;

            int limit_Y;

            if (point_X > 0 && point_Y > 0)
            {
                Console.WriteLine("Точка находится в первой четверти");
                limit_Y = max_X - point_X;

                if (point_X < max_X && point_Y < limit_Y)
                {
                    is_M_in_N1 = true;
                    Console.WriteLine("Точка находится в области N1");
                }
                else
                {
                    is_M_in_N4 = true;
                    Console.WriteLine("Точка находится в области N4");
                }
            }
            else if (point_X < 0 && point_Y > 0)
            {
                Console.WriteLine("Точка находится во второй четверти");
                limit_Y = Math.Abs(min_X + Math.Abs(point_X));

                if (point_X > min_X && point_Y < limit_Y)
                {
                    is_M_in_N2 = true;
                    Console.WriteLine("Точка находится в области N2");
                }
                else
                {
                    is_M_in_N3 = true;
                    Console.WriteLine("Точка находится в области N3");
                }
            }
            else if (point_X < 0 && point_Y < 0)
            {
                Console.WriteLine("Точка находится в третьей четверти");
                limit_Y = min_X - point_X;

                if (point_X > min_X && point_Y > limit_Y)
                {
                    is_M_in_N1 = true;
                    Console.WriteLine("Точка находится в области N1.");
                }
                else
                {
                    is_M_in_N3 = true;
                    Console.WriteLine("Точка находится в области N3.");
                }
            }
            else if (point_X > 0 && point_Y < 0)
            {
                Console.WriteLine("Точка находится в четвёртой четверти");
                limit_Y = min_X + Math.Abs(point_X);

                if (point_X < max_X && point_Y < limit_Y)
                {
                    is_M_in_N2 = true;
                    Console.WriteLine("Точка находится в области N2.");
                }
                else
                {
                    is_M_in_N4 = true;
                    Console.WriteLine("Точка находится в области N4.");
                }
            }
            else
            {
                Console.WriteLine("Точка находится на оси координат");
            }
        }


        static void Task2()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 2 ===");

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

            Console.WriteLine("Вы ввели точку с координатами ({0}, {1}) и выбрали область N{2}",
                point_X, point_Y, selected_area);

            bool isInSelectedArea = false;
            int limit_Y;

            if (point_X > 0 && point_Y > 0)
            {
                Console.WriteLine("Точка находится в первой четверти");
                limit_Y = max_X - point_X;

                if (point_X < max_X && point_Y < limit_Y)
                {
                    isInSelectedArea = (area == 1);
                    Console.WriteLine("Точка находится в области N1");
                }
                else
                {
                    isInSelectedArea = (area == 4);
                    Console.WriteLine("Точка находится в области N4");
                }
            }
            else if (point_X < 0 && point_Y > 0)
            {
                Console.WriteLine("Точка находится во второй четверти");
                limit_Y = Math.Abs(min_X + Math.Abs(point_X));

                if (point_X > min_X && point_Y < limit_Y)
                {
                    isInSelectedArea = (area == 2);
                    Console.WriteLine("Точка находится в область N2");
                }
                else
                {
                    isInSelectedArea = (area == 3);
                    Console.WriteLine("Точка находится в область N3");
                }
            }
            else if (point_X < 0 && point_Y < 0)
            {
                Console.WriteLine("Точка находится в третьей четверти");
                limit_Y = min_X - point_X;

                if (point_X > min_X && point_Y > limit_Y)
                {
                    isInSelectedArea = (area == 1);
                    Console.WriteLine("Точка находится в область N1");
                }
                else
                {
                    isInSelectedArea = (area == 3);
                    Console.WriteLine("Точка находится в области N3");
                }
            }
            else if (point_X > 0 && point_Y < 0)
            {
                Console.WriteLine("Точка находится в четвёртой четверти");
                limit_Y = min_X + Math.Abs(point_X);

                if (point_X < max_X && point_Y < limit_Y)
                {
                    isInSelectedArea = (area == 2);
                    Console.WriteLine("Точка находится в области N2");
                }
                else
                {
                    isInSelectedArea = (area == 4);
                    Console.WriteLine("Точка находится в область N4");
                }
            }

            // ИЗМЕНЕНИЕ ЗДЕСЬ: преобразуем bool в "да"/"нет"
            string result = isInSelectedArea ? "да" : "нет";
            Console.WriteLine("Принадлежит ли точка области N{0}: {1}", selected_area, result);
        }

        static void Task3()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 3 ===");

            Console.WriteLine("Введите номер масти (1 - пики, 2 - трефы, 3 - бубны, 4 - червы):");
            int suitNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите номер достоинства карты (6 - 14):");
            int rankNumber = Convert.ToInt32(Console.ReadLine());

            string suit;
            switch (suitNumber)
            {
                case 1:
                    suit = "пик";
                    break;
                case 2:
                    suit = "треф";
                    break;
                case 3:
                    suit = "бубен";
                    break;
                case 4:
                    suit = "червей";
                    break;
                default:
                    suit = "неизвестной масти";
                    break;
            }

            string rank;
            switch (rankNumber)
            {
                case 6:
                    rank = "Шестерка";
                    break;
                case 7:
                    rank = "Семерка";
                    break;
                case 8:
                    rank = "Восьмерка";
                    break;
                case 9:
                    rank = "Девятка";
                    break;
                case 10:
                    rank = "Десятка";
                    break;
                case 11:
                    rank = "Валет";
                    break;
                case 12:
                    rank = "Дама";
                    break;
                case 13:
                    rank = "Король";
                    break;
                case 14:
                    rank = "Туз";
                    break;
                default:
                    rank = "неизвестного достоинства";
                    break;
            }

            if (suit == "неизвестной масти" || rank == "неизвестного достоинства")
            {
                Console.WriteLine("Введены некорректные номера масти или достоинства карты.");
            }
            else
            {
                Console.WriteLine("Полное название карты: {0} {1}", rank, suit);
            }
        }
    }

}
