using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Triangle(int N, int max)
        {
            
            int inc = 1;
            int probel = max - 1;
            for (int i = 0; i < N; i++)
            {
                if (N==0)
                {
                    probel = max - 1;
                    for (int b = 0; b < probel; b++) //добавление пробелов
                    {
                        Console.Write(" ");
                    }
                    probel--;
                    Console.Write("*");
                }
                for (int b = 0; b < probel; b++) //добавление пробелов
                {
                    Console.Write(" ");
                }
                probel--;

                for (int a = 0; a < inc; a++)
                {
                    Console.Write("*");

                    if (a == inc - 1)                 //добавление второй половины треугольника
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
           // Console.ReadKey();
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Данная программа выводит на экран изображение \"елочки\" ");
            Console.WriteLine("Введите количество треуголников в  \"елочке\" ");
            Console.ForegroundColor = ConsoleColor.Green;
            int length = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                Triangle(i+1,length);
            }
            Console.ReadKey();
        }
    }
}
