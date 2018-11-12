using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mathematic
{
    public static class Mathematics
    {
        public static int Fact(int number)
        {
            if (number == 0)
            {
                return 1;
            }
            int result = Math.Sign(number);
            for (int i = 1; i <= Math.Abs(number); i++)
            {
                result *= i;
            }
            return result;
        }

        public static int Pow(int number, int power)
        {
            int result = 1;
            for (int i = 1; i <= power; i++)
            {
                result *= number;
            }
            return result;
        }
    }
}
