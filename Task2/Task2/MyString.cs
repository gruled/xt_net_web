using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class MyString
    {
        private char[] _value;

        public string Value => ToString();

        public int Length => _value.Length;

        public MyString(string str)
        {
            _value = str.ToCharArray();
        }

        public MyString(char[] arrayChars)
        {
            _value = arrayChars;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;

            if (obj.GetType() == GetType())
            {
                MyString myString1 = (MyString)obj;
                if (myString1.GetHashCode() == this.GetHashCode())
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = 45632879;
            int sum = 0;
            int power = 10;
            for (int i = 0; i < _value.Length; i++)
            {
                if (i != 0)
                {
                    power *= 10;
                }

                sum += hashCode * (_value[i] * power);
            }

            return sum;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < _value.Length; i++)
            {
                str += _value[i];
            }

            return str;
        }

        public char[] ToCharArray()
        {
            return _value;
        }

        public static MyString Cancat(params char[][] array)
        {
            int size = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    size++;
                }
            }

            char[] arr = new char[size];
            size = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    arr[size] = array[i][j];
                    size++;
                }
            }

            return new MyString(arr);
        }

        public static MyString Cancat(params MyString[] strings)
        {

            char[][] array = new char[strings.GetLength(0)][];
            for (int i = 0; i < strings.Length; i++)
            {
                array[i] = strings[i].ToCharArray();
            }

            return Cancat(array);
        }

        public bool Contains(string str)
        {
            if (str.Length > _value.Length)
            {
                return false;
            }

            int sum;
            for (int i = 0; i < _value.Length - str.Length + 1; i++)
            {
                sum = 0;
                for (int j = 0; j < str.Length; j++)
                {
                    if (_value[i + j].Equals(str[j]))
                    {
                        sum++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (sum == str.Length)
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(char value)
        {
            for (int i = 0; i < _value.Length; i++)
            {
                if (_value[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(MyString myString)
        {
            return Contains(myString.ToString());
        }

        public MyString GetCopy()
        {
            return new MyString(_value);
        }

        public static MyString operator +(MyString me, MyString he)
        {
            return Cancat(me, he);
        }
    }
}
