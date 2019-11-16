using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_0._0_0._5_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задания 1-3
            Console.WriteLine("Задание 0.1 SEQUENCE\n" + Sequence(15));
            Console.WriteLine();
            Console.WriteLine("Задание 0.2 SIMPLE\n" + Simple(7) + "\n");
            Console.WriteLine("Задание 0.3 SQUARE");
            Square(5);
            //Задание 4(Task 0.5)
            Console.WriteLine("Задание 0.4 ARRAY");
            int[][] array;
            array = CreateArray();
            array = Fill(array);
            array = RandomizeArray(array);
            Console.WriteLine("Not sorted array:");
            DrawArray(array);
            array = Sort(array);
            Console.WriteLine("Sorted array:");
            DrawArray(array);
            Console.ReadLine();
        }

        static string Sequence(int n) //Задание 0.1. SEQUENCE
        {
            if (n < 1)
            {
                return "Введено не положительное число";
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 1; i < n; i++)
            {
                stringBuilder.Append(i).Append(',');
            }

            stringBuilder.Append(n);
            return stringBuilder.ToString();
        }

        static string Simple(int n) //Задание 0.2. SIMPLE
        {
            if (n < 1)
            {
                return "Введено не положительное число";
            }

            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    return n + " не простое число";
                }
            }

            return n + " Простое число";
        }

        static void Square(int n) //Задание 0.3. SQUARE
        {
            if (n < 1 || n % 2 == 0)
            {
                Console.WriteLine("Введено не положительное нечетное целое число");
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if ((i == (n / 2)) && (j == (n / 2)))
                        {
                            Console.Write(' ');
                        }
                        else
                        {
                            Console.Write('*');
                        }
                    }

                    Console.WriteLine();
                }
            }
        }

        static int[][] CreateArray()
        {
            int n;
            Console.Write("Размер массива: ");
            n = Convert.ToInt32(Console.ReadLine());
            if (n < 0)
            {
                Console.WriteLine("Введено отрицательное число");
                n = 0;
            }

            return new int[n][];
        }

        static int[][] Fill(int[][] array)
        {
            int[][] MyArray = array;
            for (int i = 0; i < MyArray.Length; i++)
            {
                int j;
                Console.Write("Размер массива[" + i + "]: ");
                j = Convert.ToInt32(Console.ReadLine());
                MyArray[i] = new int[j];
            }

            return MyArray;
        }

        static int[][] RandomizeArray(int[][] array)
        {
            int[][] MyArray = array;
            Random random = new Random();
            for (int i = 0; i < MyArray.Length; i++)
            {
                for (int j = 0; j < MyArray[i].Length; j++)
                {
                    MyArray[i][j] = random.Next(0, 100);
                }
            }

            return MyArray;
        }

        static void DrawArray(int[][] array)
        {
            Console.Write("{");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{");
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + ",");
                }

                Console.Write("},");
            }

            Console.WriteLine("}");
        }

        static int[][] Sort(int[][] array)
        {
            //Сортировка массива по количеству элементов
            int[][] MyArray = array;
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < MyArray.Length - 1; i++)
                {
                    if (MyArray[i].Length > MyArray[i + 1].Length)
                    {
                        var tmp = MyArray[i];
                        MyArray[i] = MyArray[i + 1];
                        MyArray[i + 1] = tmp;
                        flag = true;
                    }
                }
            }

            //Копирование значений массива в массивах с последующей их сортировкой
            int count = 0;
            for (int i = 0; i < MyArray.Length; i++)
            {
                count += MyArray[i].Length;
            }

            int[] values = new int[count];

            count = 0;
            for (int i = 0; i < MyArray.Length; i++)
            {
                for (int j = 0; j < MyArray[i].Length; j++)
                {
                    values[count] = MyArray[i][j];
                    count++;
                }
            }

            flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < values.Length - 1; i++)
                {
                    if (values[i] > values[i + 1])
                    {
                        var tmp = values[i];
                        values[i] = values[i + 1];
                        values[i + 1] = tmp;
                        flag = true;
                    }
                }
            }

            //Запись отсортированных значений в массивы массивах
            count = 0;
            for (int i = 0; i < MyArray.Length; i++)
            {
                for (int j = 0; j < MyArray[i].Length; j++)
                {
                    MyArray[i][j] = values[count];
                    count++;
                }
            }

            return MyArray;
        }
    }
}