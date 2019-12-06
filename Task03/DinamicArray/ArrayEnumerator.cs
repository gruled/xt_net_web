using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinamicArray
{
    class ArrayEnumerator<T> : IEnumerator
    {
        private T[] _items;
        private int _position = -1;
        private int _lenght;

        public ArrayEnumerator(T[] items, int length)
        {
            this._items = items;
            this._lenght = length;
        }

        public object Current
        {
            get
            {
                if (_position == -1 || _position >= _lenght)
                {
                    throw new InvalidOperationException();
                }

                return _items[_position];
            }
        }

        public bool MoveNext()
        {
            if (_position < _lenght - 1)
            {
                _position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}