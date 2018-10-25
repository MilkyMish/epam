using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class DynamicArrayEnumerator<T> where T : IEnumerator, new()
    {
        private DynamicArray<T> array;
        private int index;
        private int endIndex;
        private int startIndex;    // Save for Reset.
       // private int[] _indices;    // The current position in a multidim array
       // private bool _complete;

        public DynamicArrayEnumerator(DynamicArray<T> array, int index, int count)
        {
            this.array = array;
            this.index = index - 1;
            startIndex = index;
            endIndex = index + count;
        }
  

        public T Current => array[index];

      //  object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            index++;
            return true;
        }

        public void Reset()
        {
            index = startIndex - 1; 
        }
    }
}
