using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor
{
    class Tools
    {
        public static int ReadInt(int min, int max)
        {
            while (true)
            {
                string str = Console.ReadLine();
                int i;
                if (Int32.TryParse(str, out i))
                {
                    if (i >= min && i <= max)
                    {
                        return i;
                    }

                    Console.WriteLine("Введенное число не в диапазоне " + min + "-" + max);
                }
                else
                {
                    Console.WriteLine("Введите число, а не строку");
                }
            }
        }

        public static double ReadDouble(double min, double max)
        {
            while (true)
            {
                string str = Console.ReadLine();
                double i;
                if (Double.TryParse(str, out i))
                {
                    if (i >= min && i <= max)
                    {
                        return i;
                    }

                    Console.WriteLine("Введенное число не в диапазоне " + min + "-" + max);
                }
                else
                {
                    Console.WriteLine("Введите число, а не строку");
                }
            }
        }

        public static double ReadDouble(string name)
        {
            while (true)
            {
                Console.Write("Введите " + name+": ");
                string str = Console.ReadLine();
                double i;
                if (Double.TryParse(str, out i))
                {
                    return i;
                }
                try
                {
                    throw new ArgumentException("Exception: Введите число, а не строку" +
                                                "\n\rПомните, что коммандная строка чувствительна к символу точка или запятая");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public static void PrintFigures(List<Figure> list)
        {
            foreach (var VARIABLE in list)
            {
                Console.WriteLine(VARIABLE.GetType());
                VARIABLE.GetDescription();
                Console.WriteLine();
            }
        }

        public static void AddFigure(List<Figure> list)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Введите фигуру:" +
                                  "\n\r1- Линия" +
                                  "\n\r2- Окружность" +
                                  "\n\r3- Прямоугольник" +
                                  "\n\r4- Круг" +
                                  "\n\r5- Кольцо" +
                                  "\n\r0- Выход");
                int i = Tools.ReadInt(0, 5);

                switch (i)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        list.Add(new Line(new Vector2(ReadDouble("X"), ReadDouble("Y")),
                                            new Vector2(ReadDouble("X"), ReadDouble("Y"))));
                        break;
                    case 2:
                        list.Add(new Circle(new Vector2(ReadDouble("X"), ReadDouble("Y")), ReadDouble("Радиус")));
                        break;
                    case 3:
                        list.Add(new Rectangle(new Vector2(ReadDouble("X"), ReadDouble("Y")), ReadDouble("Ширина"), ReadDouble("Высота")));
                        break;
                    case 4:
                        list.Add(new Round(new Vector2(ReadDouble("X"), ReadDouble("Y")), ReadDouble("Радиус")));
                        break;
                    case 5:
                        list.Add(new Ring(new Vector2(ReadDouble("X"), ReadDouble("Y")), ReadDouble("Внутренний радиус"), ReadDouble("Внешний радиус")));
                        break;
                }
            }
        }

    }
}
