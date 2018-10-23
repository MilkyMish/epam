using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Round
    {
        public int x, y;
        double CheckRad;

        public double rad
        {
            get
            {
                if (!(CheckRad <= 0))
                {
                    return CheckRad;
                }
               // Console.WriteLine("oops, mistake. R=1");
                return 1;
            }

            set
            {
                CheckRad = value;
            }
           
        }
        public double Length()
        {
            return 2 * 3.14 * rad;
        }

        public double Area()
        {
            return 3.14 * rad * rad;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Round krug = new Round();
                krug.x = 1;
                krug.y = 1;
                krug.rad = -20;
                krug.Length();
                krug.Area();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                throw;
            }
          


        }
    }
}
