using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikhail_Medvedev_Task10
{
    public static class Sorting
    {
        public static bool Ascending<T>(T left, T right, string[] nothing, int nothing2) where T : IComparable<T>
        {     
            return (left.CompareTo(right) > 0);
        }

        public static bool Alphabeting(int nothing, int nothing2, string[] items, int i) 
        {
            if (items[i - 1].Length == items[i].Length)
            {
                string left = items[i - 1];
                string right = items[i];
                int count = 0;
                do
                {
                    if (left[count] != right[count])
                    {
                        if (left[count] > right[count])
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        count++;
                    }
                    else
                    {
                        return false;
                    }
                } while (right[count] != '\n' || left[count] != '\n');
            }
            return false;
        }


        public static void Swap<T>(T[] items, int left, int right) 
        {
            if (left != right)
            {
                T temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }       
        }

        public delegate bool Function(int left, int right, string[] array, int i);

        public static void Sort(this String[] items, Function order) 
        {

            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < items.Length; i++)
                {

                    if (order(items[i - 1].Length, items[i].Length, items, i))
                    {
                        Swap(items, i - 1, i);
                        swapped = true;
                    }
                    
                }
            } while (swapped != false);
        }
    }
}
