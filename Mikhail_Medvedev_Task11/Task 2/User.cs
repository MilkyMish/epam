using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medvedev_Mikhail_Task06
{
    public class User
    {

        //private string name;
        string Check;
        int CheckAge;
        string CheckSur;
        string CheckMiddle;
        //string CheckBirth;
        //string pattern = @"[0-3][1-9].[0,1][1-9].[1,2][0,9]\d\d";

        public User(string name, string surname, string middleName, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            MiddleName = middleName;
            Birthday = birthday;
        }

        public string Name
        {
            get
            {
                return Check;


            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cant be empty");
                }
                else
                {
                    Check = value;
                }

            }

        }

        public string Surname
        {
            get
            {
                return CheckSur;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("surname cant be empty");
                }
                else
                {
                    CheckSur = value;
                }
            }
        }

        public string MiddleName
        {
            get
            {
                return CheckMiddle;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Middlename can't be empty");
                }
                else
                {
                    CheckMiddle = value;
                }
            }
        }

        //public string Birthday
        //{
        //    get
        //    {
        //        /* // DateTime.TryParse
        //         Regex regex = new Regex(pattern);
        //         foreach (Match match in regex.Matches(CheckBirth))
        //         {
        //             return CheckBirth;
        //         }
        //         if ((CheckBirth == null) | (CheckBirth == ""))
        //         {
        //             return "--.--.----";
        //         }
        //         return "--.--.----";*/
        //        return CheckBirth;

        //    }
        //    set
        //    {
        //        try
        //        {
        //            if (!(DateTime.TryParse(value, out DateTime Useless))|!(Useless.Equals(DateTime.Today)))
        //            {
        //                throw new Exception();
        //            }
        //            else
        //            {
        //                CheckBirth = value;
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine("дата не соответствует стандартам");

        //        }

        //    }
        //}
        private DateTime CheckDateTime;

        public DateTime Birthday
        {
            get
            {
                return CheckDateTime;
            }
            set
            {
                if (value.Date > DateTime.Now)
                {
                    throw new ArgumentException("BD in Future");
                }
                else
                {
                    CheckDateTime = value;
                }
            }
        }


        public int Age
        {
            get
            {
                DateTime now = new DateTime ();
                now = DateTime.Now;
                int.TryParse(now.Year.ToString(), out int yearNow);
                int.TryParse(Birthday.Year.ToString(), out int yearBD);
                if ((now.Month<=Birthday.Month)&&(Birthday.Month == now.Month)&&!(Birthday.Day <= now.Day)) 
                {    
                        return yearNow - yearBD - 1;    
                }
                else //был
                {
                    return yearNow - yearBD;
                }
               
            }
        }
    }
}
