using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medvedev_Mikhail_Task01
{
    class Program
    {
        //попробовал по-разному обработать исключения
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сторону А");
            int a,b = 0;
            
            bool check = int.TryParse(Console.ReadLine(), out  a);
            if ((check == false) | (a == 0))
                Console.WriteLine("Ошибка ввода");

            try

            {
                Console.WriteLine("Введите сторону B");
                b = Int32.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine("Введите сторону B");
                b = Int32.Parse(Console.ReadLine());
            }
            finally
            {
                if (b != 0)
                {
                    Console.WriteLine(a * b);
                }
                else
                {
                    Console.WriteLine("b=0");
                }
                Console.ReadKey();
            }
        }

    }
}
