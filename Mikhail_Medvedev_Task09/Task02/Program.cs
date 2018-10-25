using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
   
    class Program
    {
        static void Main(string[] args)
        {
            int a = new int();

            Random random = new Random();
            DynamicArray<float> database = new DynamicArray<float>();
            for (int i = 0; i < 10; i++)
            {
                float rnd = random.Next(25);
                //database.Insert(i, rnd);
                database.Add(rnd);
            }
            //float[] check = new float[6];
            //for (int i = 0; i < 6; i++)
            //{
            //    check[i] = random.Next(256);
            //}
            //database.AddRange(11, check);
            for (int i = 0; i < database.Capacity; i++)
            {

            }
            foreach (var item in database)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
