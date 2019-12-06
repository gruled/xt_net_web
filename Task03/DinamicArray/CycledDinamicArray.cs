using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinamicArray
{
    class CycledDynamicArray<T>: DinamicArray<T>
    {
        public new IEnumerator GetEnumerator()
        {
            return new AnotherArrayEnumerator<T>(ToArray(), Length);
        }   
    }
}
