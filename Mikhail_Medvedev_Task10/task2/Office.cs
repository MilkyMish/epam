using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Office
    {
        static Message greetByUs;
        static MessageBye sayGoodbyeByUs;
        static MessageDick messageDick;
        delegate void MessageDick(string dick);
        delegate void Message(string name, DateTime date);
        delegate void MessageBye(string name);

        ////public static void GoWork (String name)

        //public void GoWork(String name)
        //{

        //}

        public static void PersonCame(Person person, DateTime date)
        {
            if (person != null)
            {
                Console.WriteLine("{0} has come", person.Name);
                if (greetByUs != null)
                {
                    greetByUs(person.Name, date);
                }
                greetByUs += new Message(person.Greet);
                sayGoodbyeByUs += person.SayGoodbye;
                messageDick += person.SayaboutDick;
            }
        }

        public static void PersonLeft(object sender, EventArgs e)
        {
            var person = sender as Person;
            if (person != null)
            {
                greetByUs -= person.Greet;
                sayGoodbyeByUs -= person.SayGoodbye;
                messageDick -= person.SayaboutDick;
                Console.WriteLine("{0} has left", person.Name);
                if (sayGoodbyeByUs != null)
                {
                    sayGoodbyeByUs(person.Name);
                    messageDick(person.Name);
                }
            }
        }
    }
}
