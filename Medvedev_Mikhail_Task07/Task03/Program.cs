using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    class Program
    {
        //static void GetElement(IIndexable series, int index)
        //{
          
          
        //}

        static void PrintSeries(ISeries series)
        {
            
            series.Reset();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(series.GetCurrent());
                series.MoveNext();
               
            }

           // Console.WriteLine("Элемент серии номер{0} равен {1}",index,);

        
        }
        static void Main(string[] args)
        {
            ISeries progression = new ArithmeticalProgression(2, 2);
            IIndexable indexable = new ArithmeticalProgression(2, 2); 
			Console.WriteLine("Progression:");
			PrintSeries(progression);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(indexable[i]);      //демонстрация того, что индекс работает
            }

			ISeries list = new List(new double[] { 5, 8, 6, 3, 1 });
			Console.WriteLine("List:");
			PrintSeries(list);
        }
    }
}
