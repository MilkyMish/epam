using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Rectangle : Figure
    {
        private double ax,ay, bx,by, cx,cy, dx,dy;
        public Rectangle(int aX, int aY, int bX, int bY,int cX, int cY, int dX, int dY)
        {
            ax = aX;
            ay = aY;
            bx = bX;
            by = bY;
            cx = cX;
            cy = cY;
            dx = dX;
            dy = dY;
        }
        public override void Draw()
        {
            Console.WriteLine("Прямоугольник с точками A({0}.{1}) B({2}.{3}) C({4}.{5}) D({6}.{7})", ax, ay, bx, by, cx, cy, dx, dy);
        }
    }
}
