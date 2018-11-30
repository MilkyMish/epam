using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities
{
    public class UserWithAward
    {
        string Check;
        //int CheckAge;
        string CheckSur;
        //string CheckMiddle;
        public int Id;


        public static UserWithAward ModelMaker(Users user)
        {
            var model = new UserWithAward();
            model.Id = user.Id;
            model.Name = user.Name;
            model.Surname = user.Surname;
            model.Birthday = user.Birthday;
            if (user.Awards!=null)
            {
                model.Awards = string.Join(", ", user.Awards.Select(r => r.Title));
            }
            else
            {
                model.Awards = string.Empty;
            }
            return model;
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
                    CheckSur = value;
                     throw new ArgumentNullException("surname cant be empty");
                }
                else
                {
                    CheckSur = value;
                }
            }
        }

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
                DateTime now = new DateTime();
                now = DateTime.Now;
                int.TryParse(now.Year.ToString(), out int yearNow);
                int.TryParse(Birthday.Year.ToString(), out int yearBD);
                if ((now.Month <= Birthday.Month) && (Birthday.Month == now.Month) && !(Birthday.Day <= now.Day))
                {
                    return yearNow - yearBD - 1;
                }
                else //был
                {
                    return yearNow - yearBD;
                }

            }
        }

        public string Awards { get; set; }
    }

}
