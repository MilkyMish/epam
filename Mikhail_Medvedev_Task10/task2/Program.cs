using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person john = new Person { Name = "John" };
            Person hugo = new Person { Name = "Hugo" };

            // подписываемся на события прихода людей
            hugo.Came += Office.PersonCame;
            john.Came += Office.PersonCame;

            // подписываемся на события ухода людей
            hugo.Leave += new EventHandler(Office.PersonLeft);
            john.Leave += new EventHandler(Office.PersonLeft);

            // люди приходят
            john.GoToWork();
            hugo.GoToWork();

            // люди уходят
            john.ToLeave();
            hugo.ToLeave();

            Console.ReadKey();
        }
    }
}
