using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task01
{
    class User
    {
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
                if ((Check == null) | (Check == ""))
                {
                    return "name";
                }
                return Check;
                
            }
            set
            {
                if (Check == null)
                {
                    Check = value;
                }
            }
        }

        public string Surname
        {
            get
            {
                if ((CheckSur == null) | (CheckSur == "")) 
                {
                    return "surname";
                }
                return CheckSur;
               
            }
            set
            {
                CheckSur = value;
            }
        }

        public string MiddleName
        {
            get
            {
                if ((CheckMiddle == null) | (CheckMiddle == ""))
                {
                    return "-";
                }
                return CheckMiddle;

            }
            set
            {
                CheckMiddle = value;
            }
        }

        public string Birthday
        {
            get
            {
                Regex regex = new Regex(pattern);
                foreach (Match match in regex.Matches(CheckBirth))
                {
                    return CheckBirth;
                }
                if ((CheckBirth == null) | (CheckBirth == "")) 
                {
                    return "--.--.----";
                }
                return "--.--.----";

            }
            set
            {
                CheckBirth = value;

            }
        }


        public int Age
        {
            get
            {
                if ((CheckAge <= 0) | (CheckAge > 110))
                    return 1;
                return CheckAge;
            }

            set
            {
                CheckAge = value;
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {            
            User ui = new User();
            ui.Name = "Petya";
            ui.Surname = "Gad";
            ui.Age = 26;
            ui.Age = 0;
            ui.Name = "";
            ui.Surname = "";
            ui.Birthday = "04.04.1994";
            ui.Birthday = "00.04.1994";
        }
    }
}
