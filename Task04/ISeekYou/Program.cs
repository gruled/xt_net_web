using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISeekYou
{
    class Program
    {
        public delegate bool Predicate(int a);
        public static int[] Array = new int[1000];
        public static int Count = 1000;
        static void Main(string[] args)
        {
            Array = FillArray(Array, -50, 50);

            Console.WriteLine("Median time for 1 test: " + FirstTest());

            Console.WriteLine("Median time for 2 test: " + SecondTest());

            Console.WriteLine("Median time for 3 test: " + ThirdTest());

            Console.WriteLine("Median time for 4 test: " + FourthTest());

            Console.WriteLine("Median time for 5 test: " + FifthTest());

            Console.ReadLine();
        }
        static TimeSpan FirstTest()
        {
            int count = Count;
            TimeSpan[] times = new TimeSpan[count];
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < count; i++)
            {
                stopwatch.Start();
                FirstSearch(Array);
                stopwatch.Stop();
                times[i] = stopwatch.Elapsed;
            }

            times.OrderBy(x => x);
            return times[count / 2];
        }

        static TimeSpan SecondTest()
        {
            int count = Count;
            TimeSpan[] times = new TimeSpan[count];
            Stopwatch stopwatch = new Stopwatch();
            Predicate pr = IsPos;
            for (int i = 0; i < count; i++)
            {
                stopwatch.Start();
                SecondSearch(Array, pr);
                stopwatch.Stop();
                times[i] = stopwatch.Elapsed;
            }

            times.OrderBy(x => x);
            return times[count / 2];
        }

        static TimeSpan ThirdTest()
        {
            int count = Count;
            TimeSpan[] times = new TimeSpan[count];
            Stopwatch stopwatch = new Stopwatch();
            Predicate pr;
            pr = delegate (int i) { return i > 0; };
            for (int i = 0; i < count; i++)
            {
                stopwatch.Start();
                SecondSearch(Array, pr);
                stopwatch.Stop();
                times[i] = stopwatch.Elapsed;
            }

            times.OrderBy(x => x);
            return times[count / 2];
        }

        static TimeSpan FourthTest()
        {
            int count = Count;
            TimeSpan[] times = new TimeSpan[count];
            Stopwatch stopwatch = new Stopwatch();
            Predicate pr;
            pr = (int i) => i > 0;
            for (int i = 0; i < count; i++)
            {
                stopwatch.Start();
                SecondSearch(Array, pr);
                stopwatch.Stop();
                times[i] = stopwatch.Elapsed;
            }

            times.OrderBy(x => x);
            return times[count / 2];
        }

        static TimeSpan FifthTest()
        {
            int count = Count;
            TimeSpan[] times = new TimeSpan[count];
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < count; i++)
            {
                stopwatch.Start();
                ThirdSearch(Array);
                stopwatch.Stop();
                times[i] = stopwatch.Elapsed;
            }

            times.OrderBy(x => x);
            return times[count / 2];
        }


        static int[] FillArray(int[] array, int min, int max)
        {
            int[] myArray = array;
            Random rnd = new Random();
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = rnd.Next(min, max);
            }
            return myArray;
        }

        static void FirstSearch(int[] array)
        {
            int[] myArray = array;
            Queue<int> list = new Queue<int>();
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] > 0)
                {
                    list.Enqueue(myArray[i]);
                }
            }
        }

        public static bool IsPos(int i)
        {
            return i > 0;
        }

        static void SecondSearch(int[] array, Predicate isPredicate)
        {
            int[] myArray = array;
            Queue<int> list = new Queue<int>();
            for (int i = 0; i < myArray.Length; i++)
            {
                if (isPredicate(myArray[i]))
                {
                    list.Enqueue(myArray[i]);
                }
            }
        }

        static void ThirdSearch(int[] array)
        {
            int[] myArray = array;
            var res = myArray.Where(x => x > 0);
            foreach (var item in res)
            {
                int i = item;
                break;
            }
        }
    }
}
