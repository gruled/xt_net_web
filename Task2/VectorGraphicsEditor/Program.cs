using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor
{
    class Program
    {
        public static string text1 = "Choise command:" +
                               "\n\r\t 1: Create figure" +
                               "\n\r\t 2: Print figures" +
                               "\n\r\t 0: Exit";

        public static string text2 = "Choise command:" +
                                     "\n\r\t 1: Create line" +
                                     "\n\r\t 2: Create circle" +
                                     "\n\r\t 3: Create rectangle" +
                                     "\n\r\t 4: Create round" +
                                     "\n\r\t 5: Create ring" +
                                     "\n\r\t 0: Exit";
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            List<Figure> list = new List<Figure>();
            bool exit = false;
            while (!exit)
            {
                int command = ReadIntCommand(0, 2, text1);
                switch (command)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        AddFigure(list);
                        break;
                    case 2:
                        PrintFigures(list);
                        break;
                }
            }

        }

        static int ReadIntCommand(int min, int max, string text)
        {
            while (true)
            {
                Console.WriteLine(text);
                string str = Console.ReadLine();
                int i;
                if (Int32.TryParse(str, out i))
                {
                    if (i >= min && i <= max)
                    {
                        return i;
                    }

                    Console.WriteLine("Value of command must be from" + min + " to " + max);
                }
                else
                {
                    Console.WriteLine("Value of command must be type int");
                }
            }
        }

        static double ReadDouble(string name)
        {
            while (true)
            {
                Console.Write("Введите " + name + ": ");
                string str = Console.ReadLine();
                double i;
                if (Double.TryParse(str, out i))
                {
                    return i;
                }

                Console.WriteLine("Value must be type double");
            }
        }

        static void AddFigure(List<Figure> list)
        {
            bool exit = false;
            while (!exit)
            {
                int command = ReadIntCommand(0, 5, text2);
                switch (command)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        list.Add(new Line(new Vector2(ReadDouble("X"), ReadDouble("Y")), new Vector2(ReadDouble("X"), ReadDouble("Y"))));
                        break;
                    case 2:
                        list.Add(new Rectangle(new Vector2(ReadDouble("X"), ReadDouble("Y")), ReadDouble("Width"), ReadDouble("Height")));
                        break;
                    case 3:
                        list.Add(new Circle(new Vector2(ReadDouble("X"), ReadDouble("Y")), ReadDouble("Radius")));
                        break;
                    case 4:
                        list.Add(new Round(new Vector2(ReadDouble("X"), ReadDouble("Y")), ReadDouble("Radius")));
                        break;
                    case 5:
                        list.Add(new Ring(new Vector2(ReadDouble("X"), ReadDouble("Y")), ReadDouble("Inner radius"), ReadDouble("Outer radius")));
                        break;
                }
            }

        }


        static void PrintFigures(List<Figure> list)
        {
            foreach (var figure in list)
            {
                Console.WriteLine(figure.GetDescription());
            }
        }
    }
}
