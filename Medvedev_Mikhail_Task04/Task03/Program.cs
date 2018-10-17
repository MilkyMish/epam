using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task03
{
    class Program
    {
        

        static void Main(string[] args)
        {
            //Console.WriteLine(CultureInfo.GetCultures( ).ToString);
            //DateTime time = new DateTime(2015, 7, 20, 18, 30, 25);
            CultureInfo ru = new CultureInfo("ru-ru");
            CultureInfo en = new CultureInfo("en-us");
            Console.Write(ru.DateTimeFormat.FullDateTimePattern);
            Console.WriteLine(" <- в России. Отображение даты и времени. В США -> " + en.DateTimeFormat.FullDateTimePattern);
            Console.Write(ru.NumberFormat.CurrencyDecimalSeparator);
            Console.WriteLine("<- в России. Разделительный символ в дробях. В США ->" + en.NumberFormat.CurrencyDecimalSeparator);
            Console.Write(ru.NumberFormat.CurrencyGroupSeparator);
            Console.WriteLine("<- в России. Разделительный символ в группах. В США ->" + en.NumberFormat.CurrencyGroupSeparator);
            // Console.WriteLine(en.Calendar.
            Console.ReadKey();
        }
    }
}
