using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public delegate void PersonCame(Person p, DateTime date);
    //public delegate void PersonLeave(Person p, DateTime date);

    public class Person
    {
        public String Name { get; set; }
        public event PersonCame Came;
        public event EventHandler Leave;

        public void GoToWork()
        {
            if (Came != null)
            {
                Came(this, DateTime.Now);
            }
        }

        public void ToLeave()
        {
            if (Leave != null)
            {
                Leave(this, EventArgs.Empty);
            }
        }

        public void Greet(string anotherPerson, DateTime date)
        {

            if (date.Hour <= 11) Console.WriteLine("'Good morning, {0}!', said {1}.", anotherPerson, Name);
            if ((date.Hour > 11) && (date.Hour <= 17)) Console.WriteLine("'Good day, {0}!', said {1}.", anotherPerson, Name);
            if (date.Hour > 17) Console.WriteLine("'Good evening, {0}!', said {1}.", anotherPerson, Name);
        }

        public void SayGoodbye(string anotherPerson)
        {
            Console.WriteLine("Bye, {0}!', said {1}.", anotherPerson, Name);
        }

        public void SayaboutDick(string anotherPerson)
        {
            Console.WriteLine("Holy Dick, {0}!!!', yelled {1}.", anotherPerson, Name);
        }

    }

}
