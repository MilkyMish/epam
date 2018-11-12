using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikhail_Medvedev_Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] array = { "Rammstein", "Metallica", "Kolya Baskov", "Anna German", "Tame Impala", "Morricone" };
            Console.WriteLine("{0}", string.Join("\n", array));
            Console.WriteLine();
            array.Sort(Sorting.Ascending);
            Console.WriteLine("{0}", string.Join("\n", array));
            Console.WriteLine();
            array.Sort(Sorting.Alphabeting);
            Console.WriteLine("{0}", string.Join("\n", array));
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
