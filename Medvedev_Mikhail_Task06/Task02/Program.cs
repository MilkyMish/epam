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
                return CheckRad;
            }

            set
            {
                try
                {
                    if (value<=0)
                    {
                        throw new Exception("R<=0");
                    }
                    else
                    {
                        CheckRad = value;
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Радиус равен или меньше нуля");
                }
                
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

    class Ring : Round
    {
        private double CheckInnerRad;
        public double InnerRad
        {
            get
            {
                return CheckInnerRad;
            }

            set
            {
                try
                {
                    if ((value <= 0)&(value >= rad))
                    {
                        throw new Exception("r<=0 or r>=R");
                    }
                    else
                    {
                        CheckInnerRad = value;
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Радиус равен или меньше нуля или больше внешнего радиуса");

                }
            }
        }
        public double Area(double R)
        {
            return 3.14*R*R;
        }

        private double CheckRingArea;
        public double RingArea
        {
            get
            {
                return CheckRingArea;
            }
            set
            {
                try
                {
                    if ((rad!=0)|(InnerRad!=0)|(InnerRad<rad))
                    {
                        CheckRingArea = Area() - Area(InnerRad);
                    }
                    else
                    {
                        throw new Exception("какой-то из радиусов равен нулю, либо внешний меньше внутреннего");
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("какой-то из радиусов равен нулю, либо внешний меньше внутреннего");
                }
            }
        }
        private double Length(double R)
        {
            return 2 * 3.14 * R;
        }

        private double CheckLengthSum;

        public double RingLengthSum
        {
            get
            {
                return CheckLengthSum;
            }
            set
            {
                try
                {
                    if ((rad != 0) | (InnerRad != 0) | (InnerRad < rad))
                    {
                        CheckLengthSum = Length(rad) + Length(InnerRad);
                    }
                    else
                    {
                        throw new Exception("какой-то из радиусов равен нулю, либо внешний меньше внутреннего");
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("какой-то из радиусов равен нулю, либо внешний меньше внутреннего");
                }
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Ring ring = new Ring();
            ring.x = 10;
            ring.y = 10;
            ring.rad = 10;
            ring.InnerRad = 5;
            ring.RingLengthSum=1;
            ring.RingArea = 1;
            Console.WriteLine(ring.RingLengthSum);
            Console.WriteLine(ring.RingArea);

            Console.ReadKey();
        }
    }
}
