using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("программа определяет среднюю длину слова во введенной текстовой строке");
            Console.WriteLine("Введите строку");
            string input = Console.ReadLine();
            string pattern = @"\b(\w+)";
            int sum=0;
            int i = 1;
            Regex regex = new Regex(pattern);
            foreach (Match match in regex.Matches(input))
            {
               
                Console.WriteLine(match.Groups[1].Value);
                var length = match.Groups[1].Value.Length;
                sum = (sum + length);                          
                Console.WriteLine(sum/i);
                i++;
            }


            Console.ReadKey();
        }
    }
}
