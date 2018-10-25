using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikhail_Medvedev_Task09
{
    class Program
    {
  
        static void Main(string[] args)
        {
            
            List<int> round = new List<int>(new int[] { 1,2,3,4,5,6,7,8,9,10 });
            RemoveEachSecondItem(round);
            LinkedList<int> linkround = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            RemoveEachSecondItem(linkround);
            Console.WriteLine(round[0]);
            Console.WriteLine(linkround.First.Value);
            Console.ReadLine();

        }


        public static void RemoveEachSecondItem<T>(ICollection<T> list) where T: new()
        {
            //T buffer= new T();
            //int Cap = list.Count();
            //T[] bufferArray = new T[Cap];
            //list.CopyTo(bufferArray, 0);
            //bufferArray.ToList();
            
            //bufferArray = list.ToArray();
            //int index = 0;
            List<T> buffer = new List<T>();
            
            do
            {
                int counter = 1;
                bool checkenter = false;
                IEnumerator<T> Numer = list.GetEnumerator();
                while (Numer.MoveNext())
                {
                    if ( checkenter==false)
                    {
                        Numer.Reset();
                        Numer.MoveNext();
                        checkenter = true;
                    }
                    if (counter == 1)
                    {
                        buffer.Add(Numer.Current);
                        //list.Remove(Numer.Current);
                        //bufferArray[index] = Numer.Current;
                        counter++;
                       // index++;
                    }
                    else
                    {
                        //index++;
                        counter=1;
                    }

                }
                list.Clear();
                foreach (var item in buffer)
                {
                    list.Add(item);
                }
                buffer.Clear();
                //list = bufferArray.ToList();
               // bufferArray = null;
            } while (list.Count != 1);
            /* int index = 0;
            foreach (var item in list)
            {
                if (counter == 2)
                {
                    index++;
                    counter = 1;
                }
                else
                {
                    bufferArray[index] = item;
                    counter++;
                    index++;
                }
            }
            list.Clear();*/


        }

        /*public static void RemoveEachSecondItem<T>(T list) where T : List<int>
        {

            do
            {
                int step = 0;
                int counter = 1;
                for (int i = 0; i < list.Count + step; i++)
                    {                  
                        if (counter == 2)
                        {
                            list.RemoveAt(i - step);
                            counter = 1;
                            step++;
                        }
                        else
                        {
                            counter++;
                        }
                    }

            } while (list.Count != 1);
        }*/

       /* public static void RemoveEachSecondItem(LinkedList<int> list)
        {
            LinkedListNode<int> node;
            do
            {
                int counter = 1;
                for (node = list.First; node != null; node = node.Next)
                {
                    if (counter==2)
                    {
                        list.Remove(node.Next);
                       // node.List
                        counter = 1;
                    }
                    else
                    {
                        counter++;
                    }
                }

            } while (list.Count != 1);
        }*/
    }
}
