using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinamicArray
{
    class DinamicArray<T>:IEnumerable<T>, IEnumerable, ICloneable
    {
        private T[] _array;

        private int _length;

        public int Length => _length;

        public int Capacity
        {
            get => _array.Length;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _array = _correctCapacity(value);
                //_length = value;
            }
        }


        public DinamicArray()
        {
            _array = new T[8];
            _length = 0;
        }

        public DinamicArray(int size)
        {
            if (size >= 0)
            {
                _array = new T[size];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Size should be positive or 0");
            }

            _length = 0;
        }

        public DinamicArray(IEnumerable<T> collection)
        {
            _length = _lengthOfCollection(collection);
            _array = new T[_length];
            collection.GetEnumerator().Reset();
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = collection.GetEnumerator().Current;
                collection.GetEnumerator().MoveNext();
            }
        }

        public void Add(T element)
        {
            if (Length + 1 > _array.Length - 1)
            {
                _array = _increaseCapacity(_array);
            }

            _array[_length] = element;
            _length++;
        }

        public T this[int index]
        {
            get
            {
                if (index > Length || index < -Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return index >= 0 ? _array[index] : _array[Length + index];
            }
            set
            {
                if (index > Length || index < -Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                if (index >= 0)
                {
                    _array[index] = value;
                }
                else
                {
                    _array[Length + index] = value;
                }

            }
        }

        public void AddRange(IEnumerable<T> collection)
        {
            int collectionLength = _lengthOfCollection(collection);
            if (Length + collectionLength > _array.Length - 1)
            {
                _array = _increaseCapacity(_array, collectionLength);
            }

            foreach (var item in collection)
            {
                _array[_length] = item;
                _length++;
            }
        }

        public bool Remove(T element)
        {
            for (int i = 0; i < _length; i++)
            {
                if (_array[i].Equals(element))
                {
                    _array = _shiftDelete(_array, i);
                    _length--;
                    return true;
                }
            }

            return false;
        }

        public bool Insert(T element, int start)
        {
            if (start < 0 || start > Length)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }

            if (Length + 1 > _array.Length - 1)
            {
                _array = _increaseCapacity(_array);
            }
            _array = _shiftRight(_array, start);
            _length++;
            _array[start] = element;

            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return new ArrayEnumerator<T>(_array, Length);
        }


        #region Tools

        private T[] _correctCapacity(int size)
        {
            T[] myArray = new T[size];
            for (int i = 0; i < (size < Length ? size : Length); i++)
            {
                myArray[i] = _array[i];
            }

            _length = size < Length ? size : Length;
            return myArray;
        }

        private T[] _shiftDelete(T[] array, int start)
        {
            T[] myArray = array;
            for (int i = start; i < Length - start; i++)
            {
                myArray[i] = myArray[i + 1];
            }

            return myArray;
        }
        private T[] _shiftRight(T[] array, int start)
        {
            T[] myArray = array;
            for (int i = 0; i < Length - start; i++)
            {
                myArray[Length - i] = myArray[Length - i - 1];
            }

            return myArray;
        }

        private int _lengthOfCollection(IEnumerable<T> collection)
        {
            int sum = 0;
            foreach (var item in collection)
            {
                sum++;
            }

            return sum;
        }

        private T[] _increaseCapacity(T[] array)
        {
            int i = 1;
            T[] tmp = new T[array.Length];
            while (true)
            {
                if (array.Length < i)
                {

                    tmp = new T[i];
                    for (int j = 0; j < array.Length; j++)
                    {
                        tmp[j] = array[j];
                    }

                    break;
                }

                i <<= 1;
            }

            return tmp;
        }

        private T[] _increaseCapacity(T[] array, int sizeAnotherCollection)
        {
            int i = 1;
            T[] tmp = new T[array.Length];
            while (true)
            {
                if (array.Length + sizeAnotherCollection < i)
                {

                    tmp = new T[i];
                    for (int j = 0; j < array.Length; j++)
                    {
                        tmp[j] = array[j];
                    }

                    break;
                }

                i <<= 1;
            }

            return tmp;
        }

        #endregion


        public object Clone()
        {
            return _array.Clone();
        }

        public T[] ToArray()
        {
            T[] myArray = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                myArray[i] = _array[i];
            }
            return myArray;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)_array).GetEnumerator();
        }
    }
}
