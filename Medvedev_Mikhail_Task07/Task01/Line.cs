using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Line : Figure
    {
        private double a1, a2;
        private double b1, b2;

        public override void Draw()
        {
            Console.WriteLine("Линия из точки x={0}, y={1} в точку x={2} y= {3} ", a1,a2,b1,b2);
        }

        public Line(double ax, double ay, double bx, double by)
        {
            a1 = ax;
            a2 = ay;
            b1 = bx;
            b2 = by;
        }

        //double length()
        
    }
}
