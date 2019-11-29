using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Figure> list = new List<Figure>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Введите команду:" +
                                  "\n\r1- Добавить фигуру" +
                                  "\n\r2- Посмотреть список фигур" +
                                  "\n\r0- Выход");
                int i = Tools.ReadInt(0, 2);
                switch (i)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        Tools.AddFigure(list);
                        break;
                    case 2:
                        Tools.PrintFigures(list);
                        break;

                }
            }
        }
    }
}
