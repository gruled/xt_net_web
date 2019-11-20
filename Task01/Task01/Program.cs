using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle();

            Triangle();

            AnotherTriangle();

            XMasTree();

            SumOfNumbers();

            FontAdjustment();

            ArrayProcessing();

            NoPositive();

            NonNegativeSum();

            Array2D();

            AverageStringLength();

            CharDoubler();
            Console.ReadLine();
        }

        static void Rectangle()
        {
            Console.WriteLine("Задание 1.1");
            int a = ReadPositiveInt("a");
            int b = ReadPositiveInt("b");
            Console.WriteLine("Площадь=" + (a * b));
        }

        static int ReadPositiveInt(string name)
        {
            while (true)
            {
                Console.Write("Введите " + name + ": ");
                string str = Console.ReadLine();
                if (int.TryParse(str, out _))
                {
                    int tmp = int.Parse(str);
                    if (tmp > 0)
                    {
                        return tmp;
                    }

                    Console.WriteLine("Введено неверное значение");
                }
            }
        }

        static void Triangle()
        {
            Console.WriteLine("\nЗадание 1.2");
            int n = ReadPositiveInt("n");
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write('*');
                }

                Console.WriteLine();
            }
        }

        static void AnotherTriangle()
        {
            Console.WriteLine("\nЗадание 1.3");
            int n = ReadPositiveInt("n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < (n - (i * 2 + 1) / 2); j++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < i * 2 + 1; j++)
                {
                    Console.Write('*');
                }

                Console.WriteLine();
            }
        }


        static void XMasTree()
        {
            Console.WriteLine("\nЗадание 1.4");
            int n = ReadPositiveInt("n");
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    for (int k = 0; k < (n - (j * 2 + 1) / 2); k++)
                    {
                        Console.Write(" ");
                    }

                    for (int k = 0; k < j * 2 + 1; k++)
                    {
                        Console.Write('*');
                    }

                    Console.WriteLine();
                }
            }
        }

        static void SumOfNumbers()
        {
            Console.WriteLine("\nЗадание 1.5");
            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine("Sum of numbers:" + sum);
        }

        static void FontAdjustment()
        {
            Console.WriteLine("\nЗадание 1.6");
            TypeParameters list = TypeParameters.None;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Параметры надписи: " + list.ToString());
                int input = ReadFontInt();
                switch (input)
                {
                    case 0:
                        flag = false;
                        break;
                    case 1:
                        list = ManageEnum(list, TypeParameters.Bold);
                        break;
                    case 2:
                        list = ManageEnum(list, TypeParameters.Italic);
                        break;
                    case 3:
                        list = ManageEnum(list, TypeParameters.Underline);
                        break;
                }
            }

        }

        static TypeParameters ManageEnum(TypeParameters list, TypeParameters type)
        {
            return list.HasFlag(type)
                ? list ^ type
                : list | type;
        }

        static int ReadFontInt()
        {
            while (true)
            {
                Console.Write("Введите:\n\t1: bold\n\t2: italic\n\t3: underline\n\t0: выход\n");
                string str = Console.ReadLine();
                if (int.TryParse(str, out _))
                {
                    return int.Parse(str);
                }
            }
        }

        [Flags]
        private enum TypeParameters
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }

        static void ArrayProcessing()
        {
            Console.WriteLine("\nЗадание 1.7");
            int[] array = new int[10];
            RandomizeArray(array);
            Console.WriteLine("Неотсортированный массив:");
            DrawArray(array);
            Sort(array);
            Console.WriteLine("Отсортированный массив: ");
            DrawArray(array);
            Console.WriteLine("Минимальное значение: " + array[0]);
            Console.WriteLine("Максимальное значение : " + array[array.Length - 1]);
        }

        static void Sort(int[] array)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        var tmp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = tmp;
                        flag = true;
                    }
                }
            }
        }

        static void DrawArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine();
        }

        static void NoPositive()
        {
            Console.WriteLine("\nЗадание 1.8");
            int size = 3;
            int[,,] array = new int[size, size, size];
            Randomize3DArray(array);
            Console.WriteLine("Изначальный массив: ");
            Draw3DArray(array);
            ChangePos3DArray(array);
            Console.WriteLine("Новый массив: ");
            Draw3DArray(array);
        }

        static void Draw3DArray(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.Write(array[i, j, k] + " ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }

        static void Randomize3DArray(int[,,] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = random.Next(-10, 10);
                    }
                }
            }
        }

        static void ChangePos3DArray(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (array[i, j, k] > 0)
                        {
                            array[i, j, k] = 0;
                        }
                    }
                }
            }
        }

        static void NonNegativeSum()
        {
            Console.WriteLine("Задание 1.9");
            int size = 5;
            int[] array = new int[size];
            RandomizeArray(array);
            Console.WriteLine("Массив: ");
            DrawArray(array);
            Console.WriteLine("Сумма: " + SumNonNegativeArray(array));
        }

        static void RandomizeArray(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10, 10);
            }
        }

        static int SumNonNegativeArray(int[] array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                if (item > 0)
                {
                    sum += item;
                }
            }

            return sum;
        }

        static void Array2D()
        {
            Console.WriteLine("\nЗадание 1.10");
            int size = 3;
            int[,] array = new int[size, size];
            Randomize2DArray(array);
            Draw2DArray(array);
            Console.WriteLine("Сумма: " + SumEvenPos2DArray(array));
        }

        static void Randomize2DArray(int[,] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(10);
                }
            }
        }

        static int SumEvenPos2DArray(int[,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += array[i, j];
                    }
                }
            }

            return sum;
        }

        static void Draw2DArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        static void AverageStringLength()
        {
            Console.WriteLine("\nЗадание 1.11");
            Console.Write("Исходная строка: ");
            string str = Console.ReadLine();
            string[] array = str.Split();
            float sum = 0;
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (Char.IsPunctuation(array[i][j]))
                    {
                        array[i] = array[i].Remove(j, 1);
                    }
                }
            }

            foreach (var item in array)
            {
                if (item.Length > 0)
                {
                    sum += item.Length;
                    count++;
                }
            }

            Console.WriteLine("AVG: " + (sum / count));
        }

        static void CharDoubler()
        {
            Console.WriteLine("\nЗадание 1.12");
            StringBuilder resStr = new StringBuilder();
            Console.Write("Введите первую строку: ");
            string firstStr = Console.ReadLine();
            Console.Write("Введите вторую строку: ");
            string secStr = Console.ReadLine();
            foreach (var sym in firstStr)
            {
                resStr.Append(sym);
                if (secStr.Contains(sym))
                {
                    resStr.Append(sym);
                }
            }

            Console.WriteLine("Результирующая строка: " + resStr);
        }
    }
}