using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class HorizontalLine:Figure
    {

        public HorizontalLine(int xRight, int xLeft, int y, char sym)
        {
            pList = new List<Point>();
            for (int x = xRight; x < xLeft; x++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }

        }
       
    }
}
