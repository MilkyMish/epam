using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Task01
{
    class Program
    {
        public static String PowText(String source)
        {
            String result;
            result = Regex.Replace(source, @"(?<number>\d+)",
            number =>
            {
                double pownumber = Math.Pow(Convert.ToInt32(number.Value), 2);
                return pownumber.ToString();
            }, RegexOptions.Multiline);
            return result;
        }

        static void Main(string[] args)
        {
            String path = @"J:\1\test_dir\task1.txt";
            String s = File.ReadAllText(path);
            Console.WriteLine(s);
            s = PowText(s);
            File.WriteAllText(path, s);
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
