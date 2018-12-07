using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public  class Users
    {

        string Check;
        int CheckAge;
        string CheckSur;
        string CheckMiddle;
        public int Id;


        /*public Users(int Id, string name, string surname,  DateTime birthday)
        {
            this.Id = Id;
            Name = name;
            Surname = surname;           
            Birthday = birthday;

            что такое адо нет как открыть кноннешкен
            HTTP что такое, статусы сообщениий 300-400-500 и тд всего 5
            что такое html css tag css, css selecter,mvc (pattern), naming conventions, 
            win forms (технология)  

            sql
            1. select
            2. leftjoin 
            3. group by запрос из двух таблиц

            ооп
            принципы ооп
            делегаты, события, транзакция в скл, память, ссылка что такое, делегат - ссылка на метод, ссылка -а дрес где находятся данные
            этапы компляции си- имл - ассемблер
            как сортировать коллекцимя 6 вариантов линк(ордербай,дсцендинг и тп)

        }*/

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
                   // throw new ArgumentNullException("surname cant be empty");
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

       /* int CheckId;
        public int Id
        {
            get
            {
                return CheckId;
            }
            set
            {
                if (true)
                {
                    CheckId = value;
                }
            }
        }*/

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

        public List<Awards> Awards { get; set; }
    }
}
