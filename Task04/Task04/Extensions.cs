using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    public static class Extensions
    {
        public static int Sum(this int[] array)
        {
            if (array == null) throw new ArgumentNullException();
            if (array.Length > 0)
            {
                int[] myArray = array;
                int sum = 0;
                for (int i = 0; i < myArray.Length; i++)
                {
                    sum += myArray[i];
                }
                return sum;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public static bool IsPosInt(this string str)
        {
            if (str == null) throw new ArgumentNullException();
            if (str.Length == 0) throw new ArgumentException("Length of string must be greater than 0");
            string myString = str;
            bool manySign = false;
            bool sign = false;
            for (int i = 0; i < myString.Length; i++)
            {

                if (myString[i].Equals('-'))
                {
                    if (manySign) throw new ArgumentException("Too many \'-\' symbols");
                    manySign = true;
                    sign = true;
                }
                else
                {
                    if (myString[i].Equals('+'))
                    {
                        if (manySign) throw new ArgumentException("Too many \'+\' symbols");
                        manySign = true;
                    }
                    else
                    {
                        if (!(myString[i] >= '0' && myString[i] <= '9'))
                        {
                            if (!myString[i].Equals(' ')) throw new ArgumentException("Unexpected symbol for int string");
                        }
                    }
                }
            }

            return !sign;
        }
    }
}
