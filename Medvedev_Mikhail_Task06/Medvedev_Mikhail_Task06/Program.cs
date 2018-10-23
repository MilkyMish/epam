using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Medvedev_Mikhail_Task06
{
    class User
    {

        private string name;
        string Check;
        int CheckAge;
        string CheckSur;
        string CheckMiddle;
        string CheckBirth;
        string pattern = @"[0-3][1-9].[0,1][1-9].[1,2][0,9]\d\d";

        public string Name
        {
            get
            {
              return Check;
                
    
            }
            set
            {
                try
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new Exception("ПУСТО");
                    }
                    else
                    {
                        Check = value;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Введена пустая строка");
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
                try
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new Exception("ПУСТО");
                    }
                    else
                    {
                        CheckSur = value;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Введена пустая строка");
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
                try
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new Exception();
                    }
                    else
                    {
                        CheckMiddle = value;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Введена пустая строка");
                }
            }
        }

        public string Birthday
        {
            get
            {
                /* // DateTime.TryParse
                 Regex regex = new Regex(pattern);
                 foreach (Match match in regex.Matches(CheckBirth))
                 {
                     return CheckBirth;
                 }
                 if ((CheckBirth == null) | (CheckBirth == ""))
                 {
                     return "--.--.----";
                 }
                 return "--.--.----";*/
                return CheckBirth;

            }
            set
            {
                try
                {
                    if (!DateTime.TryParse(value, out DateTime Useless))
                    {
                        throw new Exception();
                    }
                    else
                    {
                        CheckBirth = value;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("дата не соответствует стандартам");
                    
                }

            }
        }


        public int Age
        {
            get
            {
      
                return CheckAge;
            }

            set
            {
                try
                {
                    if ((CheckAge <= 0) | (CheckAge > 110))
                    {
                        CheckAge = value;
                    }
                    else
                    {
                        throw new Exception("Возраст меньше нуля или больше 110");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Возраст меньше нуля или больше 110");
                    
                }
               
            }
        }
    }

    class Employee : User
    {
        private string CheckWorkPosition;

        public string WorkPosition
        {
            get
            {
                return CheckWorkPosition;
            }
            set
            {
                try
                {

                    if (string.IsNullOrEmpty(value))
                    {
                        throw new Exception("ПУСТО");
                    }
                    else
                    {
                        CheckWorkPosition = value;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Введена пустая строка");
                }         
            }
        }

        private int CheckWorkExp;

        public int WorkExpirience
        {
            get
            {
                return CheckWorkExp;
            }
            set
            {
                try
                {

                    if ((value < 1) | (value > 100))
                    {
                        throw new Exception("Выходит за границы");
                    }
                    else
                    {
                        CheckWorkExp = value;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Введен стаж либо меньше 1 либо больше 100");
                }
            }
        }

        private int CheckRating;

        public int Rating
        {
            get
            {
                return CheckRating;
            }
            set
            {
                try
                {

                    if ((value <1)|(value>10))
                    {
                        throw new Exception("Выходит за границы");
                    }
                    else
                    {
                        CheckRating = value;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Введен рейтинг либо меньше 1 либо больше 10");
                }
            }
        }

        private string CheckBoss;

        public string Boss
        {
            get
            {
                return CheckBoss;
            }
            set
            {
                try
                {

                    if (string.IsNullOrEmpty(value))
                    {
                        throw new Exception("ПУСТО");
                    }
                    else
                    {
                        CheckBoss = value;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Введена пустая строка");
                }
            }
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            //User ui = new User();
            //ui.Name = "Pe";
            //ui.Surname = "Gad";
            //ui.Age = 26;
            //ui.Age = 0;
            //ui.Name = "";
            //ui.Surname = "";
            //ui.Birthday = "04.04.1994";
            //ui.Birthday = "00.04.1994";
            Employee employee = new Employee();
            employee.Name = "Eleonora";
            employee.Surname = "Prodrazvertkina";
            employee.MiddleName = "Apollinareivna";
            employee.Age = 25;
            employee.Birthday = "04.04.1993";
            employee.WorkExpirience = 1;
            employee.WorkPosition = "Head of Security";
            employee.Boss = "Herasim Jagermeisterovich Cosmozvyozdov";
            employee.Rating = 10;
        }
    }
}
