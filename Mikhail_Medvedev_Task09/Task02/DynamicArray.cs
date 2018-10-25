using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
     class DynamicArray<T> where T : /*struct,IEnumerable<T>,*/  new()
    {
        int index;
        private T[] array;
        private T[] buffer;
        private int length;
        public int Capacity => array.Length;

        public DynamicArray()
        {
            array = new T[8];
            length = 0;
        }

        public DynamicArray(int amount)
        {
            array = new T[amount];
            length = 0;
        }

        public DynamicArray(T[] inputArray)
        {
            //int amountinput = 0;
            //foreach (T item in inputArray) //определяю объем входного массива
            //{
            //    amountinput++;
            //}
            //array = new T[amountinput];
            //int i=0;
            //foreach (T item in inputArray) //копирую элементы в новый
            //{
            //    array[i] = inputArray[i];
            //    i++;
            //}
            inputArray.CopyTo(array, 0);
            length = inputArray.Length;

        }
        public DynamicArray(IEnumerable<T> collection)
        {
            int counter = 0;
            array = new T[collection.Count()];
            foreach (var item in collection)
            {
                array[counter] = item;
                counter++;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            //for (int i = 0; i < array.Length; i++)
            //{
            //    yield return array[i];

            //    if (i == 5)
            //        yield break;
            //}
            DynamicArrayEnumerator<T> enumerator = new DynamicArrayEnumerator<>(array, index , length);
            return enumerator;
        }
       

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /* public int GetCurrent()
         {
             return array[index];
         }

         public bool MoveNext()
         {
             currentIndex++;
             return true;
         }

         public void Reset()
         {
             currentIndex = 1;
         }*/

        public T this[int index]
        {
            set
            {
                if (index>=length)
                {
                    throw new ArgumentOutOfRangeException("Индексатор за пределами массива");
                }
                array[index] = value;
            }
            get
            {
               
                return array[index];
            }
        }

        private void Buffermaker()
        {
            buffer = new T[Capacity];
        }

        private void IncreaseCapacity(int newCapacity)
        {
            Array.Resize(ref array, newCapacity);
        }
        
        public void Insert(int index, T obj)
        {
            if (index>=Capacity)
            {
                IncreaseCapacity(Capacity * 2);              
            }
            for (int i = length; i >= index; i--)
            {
                array[i + 1] = array[i];
            }
            array[index] = obj;
            length++;
        }

        public void AddRange(T[] inputArray)
        {
            int inputCapacity = inputArray.Length;
           
            if (inputCapacity >= Capacity - length) // no space
            {
                IncreaseCapacity(Capacity + inputCapacity);
            }
            inputArray.CopyTo(array, length);
            length = length + inputCapacity;
        }

        public void Add(T element)
        {
            // Insert(length, element);
            if(length+1 >= Capacity)
            {
                IncreaseCapacity(Capacity * 2);
            }
            array[length+1] = element;
            length++;
        }

        //private T nulmaker()
        //{
        //    DynamicArray<T> element = new DynamicArray<T>(1) ;
        //    switch (element)
        //    {
        //        default:
        //            break;
        //    }
        //}

        public bool Remove(int numberOfElement)
        {
            if (numberOfElement >= length)
            {
                return false;
            }
            else
            {              
                for (int i = numberOfElement; i < length-1; i++)
                {
                    array[i] = array[i + 1];
                }
                length--;
                return true;
            }
            
        }

        //public bool Remove(T element)
        //{

        //}
    }

}
