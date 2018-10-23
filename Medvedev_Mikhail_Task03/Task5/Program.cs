using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Данная программа выводит на экран сумму всех чисел меньше 1000, кратных 3, или 5.");
            int[] array = new int[999];
            for (int i = 0; i < 999; i++)
            {
                array[i] = i+1;
            }
           
            int output = 0;
            for (int i = 0; i < 999; i++)
            {
                if ((array[i]%3==0) | (array[i] % 5 == 0))
                {
                    output = output + array[i];
                }
            }
            Console.WriteLine("Сумма чисел меньше тысячи кратных пяти и трем равна " + output);
            Console.ReadKey();
        }
    }
}
