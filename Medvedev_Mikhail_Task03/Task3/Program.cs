using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Данная программа выводит на экран изображение равностороннего треугольника.");
            Console.WriteLine("Введите количество строк в треугольнике");
            Console.ForegroundColor = ConsoleColor.Green;
            int inc = 1;
            int N = Int32.Parse(Console.ReadLine());
            int probel = N - 1;
            for (int i = 0; i < N; i++)
            {
                for (int b = 0; b < probel; b++) //добавление пробелов
                {
                    Console.Write(" ");
                }
                probel--;

                for (int a = 0; a < inc; a++)
                {
                    Console.Write("*");

                    if (a==inc-1)                 //добавление второй половины треугольника
                    {
                        for (int secondhalf = 0; secondhalf < a; secondhalf++)
                        {
                            Console.Write("*");
                        }
                    }
                }
            
                inc++;
                Console.WriteLine();
                

            }
            Console.ReadKey();
        }
    }
}
