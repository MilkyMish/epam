using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task02
{
    class Program
    { 
        private static string  Uniq(string s)
        {
            List<char> used = new List<char>();
            StringBuilder uniq = new StringBuilder();
            foreach (char i in s)
            {
                if (used.IndexOf(i) == -1)
                {
                    used.Add(i);
                    uniq.Append(i);
                }
            }
            return uniq.ToString();
        }

    
        static void Main(string[] args)
        {
            Console.WriteLine("программa удваивает в первой введенной строке все символы, принадлежащие второй введенной строке.");

            StringBuilder first = new StringBuilder("написать программу, которая");
            StringBuilder second = new StringBuilder("описание");

            string check = Uniq(second.ToString());

            for (int i = 0; i < check.Length; i++)
            {
                string l = check[i].ToString();
                first.Replace(l, l + l);
            }

            Console.WriteLine(first);
            Console.ReadKey();
        }
    }
}
