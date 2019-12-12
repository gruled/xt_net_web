using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
//using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task04
{
    class Program
    {

        public static event Action EndOfSort;
        public static object[] Titles = {"Silent Hill", "Resident Evil", "Dead Space"};
        public static string[] Array = {"AliceB", "AliceA", "Charlie", "Ann"};
        public static object[] Animals = {"Lion", "Cat", "Elephant"};

        static void Main(string[] args)
        {
            //4.1 CUSTOM SORT
            Console.WriteLine("Custom sort:");
            CustomSort(Titles, MyCompare, out Titles);
            foreach (var item in Titles)
            {
                Console.WriteLine(item);
            }

            //4.2 CUSTOM SORT DEMO
            Console.WriteLine(Environment.NewLine + "Custom sort demo");
            CustomSort(Array, MyCompareString, out Array);
            foreach (var item in Array)
            {
                Console.WriteLine(item);
            }

            //4.4 NUMBER ARRAY SUM
            Console.WriteLine(Environment.NewLine + "Number array sum");
            NumberArraySum();

            //4.5 TO INT OR  NOT TO INT
            Console.WriteLine(Environment.NewLine + "To int or not to int");
            string str = "-451";
            Console.WriteLine("String " + str + " is: " + str.IsPosInt());


            //4.3 SORTING UNIT
            EndOfSort += Display;
            SortMultiThread(Animals, MyCompare);

            Console.ReadLine();

        }


        private static void Display()
        {
            Console.WriteLine(Environment.NewLine + "Multi thread sort:");
            for (int i = 0; i < Animals.Length; i++)
            {
                Console.WriteLine(Animals[i].ToString());
            }
        }

        static T[] CustomSort<T>(T[] array, Func<T, T, int> comparator)
        {
            T[] myArray = array;
            bool flag;
            while (true)
            {
                flag = false;
                for (int i = 0; i < myArray.Length - 1; i++)
                {
                    int res = comparator(myArray[i], myArray[i + 1]);
                    if (res == 1)
                    {
                        flag = true;
                        var tmp = myArray[i + 1];
                        myArray[i + 1] = myArray[i];
                        myArray[i] = tmp;
                    }
                }

                if (!flag) break;
            }

            return myArray;
        }

        static void NumberArraySum()
        {
            int[] array = {1, 3, 4, 7, 9};
            Console.Write("Array: ");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine(Environment.NewLine + "Sum: " + array.Sum());
        }

        public static int MyCompare<T>(T object1, T object2)
        {
            if (object1.ToString().Length > object2.ToString().Length)
            {
                return 1;
            }

            if (object1.ToString().Length < object2.ToString().Length)
            {
                return -1;
            }

            return 0;
        }

        public static int MyCompareString(string object1, string object2)
        {
            if (object1.Length > object2.Length)
            {
                return 1;
            }

            if (object1.Length < object2.Length)
            {
                return -1;
            }

            for (int i = 0; i < object1.Length; i++)
            {
                if (object1[i] > object2[i])
                {
                    return 1;
                }

                if (object1[i] < object2[i])
                {
                    return -1;
                }

            }

            return 0;

        }

        static void CustomSort<T>(T[] array, Func<T, T, int> comparator, out T[] a)
        {
            a = CustomSort(array, comparator);
        }

        static void SortMultiThread<T>(T[] array, Func<T, T, int> comparator)
        {
            T[] myArray = default;
            Thread myThread = new Thread(() =>
            {
                CustomSort(array, comparator, out myArray);
                array = myArray;
                EndOfSort?.Invoke();
            });
            myThread.Start();
        }
    }
}