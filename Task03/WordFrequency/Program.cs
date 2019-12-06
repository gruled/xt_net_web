using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            WordFrequency("Hello. Hello world. Hello new world. Hello brave new world.");
            Console.ReadLine();
        }
        static void WordFrequency(string str)
        {
            string[] array = str.ToLower().Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            foreach (var item in array)
            {
                if (myDictionary.ContainsKey(item))
                {
                    myDictionary[item]++;
                }
                else
                {
                    myDictionary.Add(item, 1);
                }
            }

            foreach (var item in myDictionary)
            {
                Console.WriteLine(item.Key + " --count: " + item.Value);
            }
        }
    }
}
