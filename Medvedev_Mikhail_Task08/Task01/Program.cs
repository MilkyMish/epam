using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            int a=new int();
            
            
            Random random = new Random();            
            DynamicArray<float> database = new DynamicArray<float>();
            for (int i = 0; i < 10; i++)
            {
                float rnd = random.Next(25);
                database.Insert(i, rnd);
            }
            //float[] check = new float[6];
            //for (int i = 0; i < 6; i++)
            //{
            //    check[i] = random.Next(256);
            //}
            //database.AddRange(11, check);
            for (int i = 0; i < database.arrayCapacity; i++)
            {

            }
            Console.ReadKey();
            
        }
    }
}
