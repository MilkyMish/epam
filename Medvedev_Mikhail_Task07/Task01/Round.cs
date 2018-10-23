using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Round : Figure
    {
        public double x, y;    //Спросить про уровень защиты
        private double CheckRad;

        public double Rad
        {
            get
            {
                return CheckRad;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("R<=0");
                }
                else
                {
                    CheckRad = value;
                }

            }
        }
        public Round(double x1, double y1, double R)
        {
            x = x1;
            y = y1;
            Rad = R;
        }
        public override void Draw()
        {
            Console.WriteLine("круг с центром в точке A({0} . {1}) и радиусом = {2}", x,y,Rad);
        }

    }
}
