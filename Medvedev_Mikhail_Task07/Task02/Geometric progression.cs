using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Geometric_progression : ISeries
    {
        double start, step;
        double next;

        public Geometric_progression(double start, double step)
        {
            this.start = start;
            this.step = step;
            next = start * step;
        }



        double ISeries.GetCurrent()
        {
            return next;
        }

        bool ISeries.MoveNext()
        {
            next = next * step;
            return true;
        }

        void ISeries.Reset()
        {
            next = step * start;
        }
    }
}
