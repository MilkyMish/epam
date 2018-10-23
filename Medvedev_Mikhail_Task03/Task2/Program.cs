using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Данная программа выводит на экран изображение \"треугольника\".");
            Console.WriteLine("Введите количество строк в треугольнике");
            Console.ForegroundColor = ConsoleColor.Green;
            int inc = 1;
            int N = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
             
                for (int a = 0; a < inc; a++)
                {
                    Console.Write("*");
                }
                inc++;
                Console.WriteLine();

               
            }
            Console.ReadKey();
        }
    }
}
