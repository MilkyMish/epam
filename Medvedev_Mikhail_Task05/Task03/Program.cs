using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task03
{
    class Triangle
    {
        double CheckA = -1, CheckB = -1, CheckC = -1;

        public double   A
        {
            get
            {
                
                if ((CheckA > 0) & ( (CheckC + CheckB >CheckA) | CheckB == -1 | CheckC == -1) )
                {
                    return CheckA;
                }
              //  Console.WriteLine("oops, mistake. A=-1");
                return -1;
            }
            set
            {
                CheckA = value;
            }
        }

        public double B
        {
            get
            {

                if ((CheckB > 0) & ((CheckC + CheckA > CheckB) | CheckA == -1 | CheckC == -1))
                {
                    return CheckB;
                }
               // Console.WriteLine("oops, mistake. B=-1");
                return -1;
            }
            set
            {
                CheckB = value;
            }
        }

        public double C
        {
            get
            {

                if ((CheckC > 0) & ((CheckB + CheckA > CheckC) | CheckA == -1 | CheckB == -1))
                {
                    return CheckC;
                }
                //Console.WriteLine("oops, mistake. C=-1");
                return -1;
            }
            set
            {
                CheckC = value;
            }
        }

        public double Perimeter()
        {
            if ( A == -1 | B == -1 | C == -1 )
            {
                Console.WriteLine("Ну все, приплыли. A={0}, B={1}, C={2}",A,B,C);
                return -1;
            }
            return A + B + C;
        }

        public double Area()
        {
            if (A == -1 | B == -1 | C == -1)
            {
                Console.WriteLine("Ну все, приплыли. A={0}, B={1}, C={2}", A, B, C);
                return -1;
            }
            double p = (0.5 * (A + B + C));
            double s= Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            return s;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle();
            triangle.A = 10;
            triangle.B = 20;
            triangle.C = 40;
            triangle.Perimeter();
            triangle.Area();
            triangle.C = 15;
            triangle.Perimeter();
            triangle.Area();

        }
    }
}
