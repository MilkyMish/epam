using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medvedev_Mikhail_Task06
{
    public class Employee : /*User,*/ IEquatable<Employee>
    {
        
        public bool Equals(Employee other)
        {
            return (this.workpos == other.workpos && 
                this.workExp == other.workExp && 
                this.rating == other.rating && 
                this.boss == other.boss && 
                this.Salary == other.Salary&& base.Equals(other)); 
        }
        private string workpos;

        public string WorkPosition
        {
            get
            {
                return workpos;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Work Position can't be empty");
                }
                else
                {
                    workpos = value;
                }
            }
        }

        private int workExp;

        public int WorkExpirience
        {
            get
            {
                return workExp;
            }
            set
            {
                if ((value < 1) | (value > 100))
                {
                    throw new ArgumentException("Выходит за границы");
                }
                else
                {
                    workExp = value;
                }
            }
        }

        private int rating;

        public int Rating
        {
            get
            {
                return rating;
            }
            set
            {
                if ((value < 1) | (value > 10))
                {
                    throw new ArgumentException("Выходит за границы");
                }
                else
                {
                    rating = value;
                }
            }
        }

        private string boss;

        public string Boss
        {
            get
            {
                return boss;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Boss Name cannot be empty.");
                }
                else
                {
                    boss = value;
                }
            }
        }

        private int CheckSalary;

        public int Salary
        {
            get
            {
                return CheckSalary;
            }
            set
            {
                try
                {

                    if (value < 1)
                    {
                        throw new ArgumentException("Выходит за границы");
                    }
                    else
                    {
                        rating = value;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Зарплата отрицательная");
                }
            }
        }

        
    }
}
