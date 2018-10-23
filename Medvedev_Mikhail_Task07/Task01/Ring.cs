using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Ring : Figure
    {
        double x, y, rad;
        private double CheckInnerRad;
        public double InnerRad
        {
            get
            {
                return CheckInnerRad;
            }

            set
            {
                if ((value <= 0) & (value >= rad))
                {
                    throw new ArgumentException("r<=0 or r>=R");
                }
                else
                {
                    CheckInnerRad = value;
                }
            }
        }

        public  Ring(double x1, double y1, double r, double innerR)  // спросить про ошибку
        {
            x = x1;
            y = y1;
            rad = r;
            InnerRad = innerR;
         }

        public override void Draw()
        {
            Console.WriteLine("Кольцо с центром x={0} y={1} внутренним радиусом = {2} и внешним радиусом {3}",x,y,InnerRad,rad);
        }
    }
}
