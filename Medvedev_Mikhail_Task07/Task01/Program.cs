using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{



    class Program
    {
        static void Main(string[] args)
        {
            Figure[] fig = new Figure[10];

            Random randomGenerator = new Random();
            for (int i = 0; i < fig.Length; i++)
            {
                switch (randomGenerator.Next(3))
                {
                    case 0:
                        fig[i] = new Rectangle(0, 0, 10, 10, 20, 20, 20, 0);
                        break;
                    case 1:
                        fig[i] = new Round(10, 10, 5);
                        break;
                    case 2:
                        fig[i] = new Ring(0, 0, 10, 5);
                        break;
                }
            }

            foreach (Figure figure in fig)
            {
                figure.Draw();
            }
        }
    }
}

