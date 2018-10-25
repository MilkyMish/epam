using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task03
{
    class Program
    {
       
       
        static void Main(string[] args)
        {
            string text = @"his method advances us to the next valid array index,
               handling all the multiple dimension & bounds correctly.
               Think of it like an odometer in your car - we start with
               the last digit, increment it, and check for rollover.  if
               it rolls over, we set all digits to the right and including 
               the current to the appropriate lower bound.  do these overflow
               checks for each dimension, and if the most significant digit 
               has rolled over it's upper bound, we're done.";
            string pattern = @"\S+\w";
            Regex rgx = new Regex(pattern);
           // List<string> keywords = new List<string>();
            MatchCollection matches = rgx.Matches(text);
            Dictionary<string, int> resultDict = new Dictionary<string, int>();
            foreach (Match match in matches)
            {
                pattern = string.Format(@"\b({0})\b", match);
                rgx = new Regex(pattern);
                //поиск количества текущего слова в исходном тексте
                int countMatches = rgx.Matches(text).Count;
                //если не нашли, не добавляем в словарь
                if (countMatches != 0)
                {
                    if (!resultDict.ContainsKey(match.Value))
                    {
                        resultDict.Add(match.Value, countMatches);
                    }
                    
                   
                }
            }
            Console.ReadKey();
        }
    }
}
