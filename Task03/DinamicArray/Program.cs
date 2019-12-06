using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            DinamicArray<string> arr = new DinamicArray<string>();
            List<string> li = new List<string>();
            li.Add("ff");
            arr.AddRange(li);
            arr.Add("Beta");
            arr.Add("Alpha");
            arr.Remove("Alpha");
            arr[0] = "Dima";
            arr.Insert("Omega", 1);
            arr[-2] = "omg";
            foreach (var VARIABLE in arr)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.WriteLine("Capacity: " + arr.Capacity);
            Console.WriteLine("Length: " + arr.Length);

            //Cycled
            CycledDynamicArray<string> art = new CycledDynamicArray<string>();
            art.Add("hello");
            art.Add("new");
            art.Add("world");

            //Раскоментируйте чтобы увидеть зацикленный вывод элементов
            //foreach (var VARIABLE in art)    
            //{
            //    Console.WriteLine(VARIABLE);
            //}

            Console.ReadLine();
        }
    }
}
