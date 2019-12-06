using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost
{
    class Program
    {
        static void Main(string[] args)
        {
            StartLost(7);
            Console.ReadLine();
        }
        static void StartLost(int n)
        {
            Queue<string> queue = new Queue<string>();
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue("Player " + (i + 1));
            }

            bool acceptDelete = false;
            if (n != 0)
            {
                while (queue.Count != 1)
                {
                    Queue<string> tmp = new Queue<string>();
                    int count = queue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        if (!acceptDelete)
                        {
                            tmp.Enqueue(queue.Dequeue());
                        }
                        else
                        {
                            Console.WriteLine("Delete: " + queue.Dequeue());
                        }

                        acceptDelete = !acceptDelete;
                    }

                    for (int i = 0; i < tmp.Count; i++)
                    {
                        tmp.Enqueue(tmp.Dequeue());
                    }

                    queue = tmp;
                }

                Console.WriteLine("---Lost: " + queue.Dequeue());
            }
        }
    }
}
