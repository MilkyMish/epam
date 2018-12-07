using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medvedev_Mikhail_Task14
{
    public class Awards
    {
        string CheckTitle;
        public string Title
        {
            get
            {
                return CheckTitle;
            }
            set
            {
                if (string.IsNullOrEmpty(value)&&(value.Length>49))
                {
                    throw new ArgumentNullException("Name cant be empty or Title is too long");
                }
                else
                {
                    CheckTitle = value;
                }

            }

        }

        string CheckDescription;
        public string Description
        {
            get
            {
                return CheckDescription;
            }
            set
            {
                if (string.IsNullOrEmpty(value)&&(value.Length>249))
                {
                    throw new ArgumentNullException("Name cant be empty or Description is too long");
                }
                else
                {
                    CheckDescription = value;
                }

            }

        }
        public int Id;
        //private int genID(int currentID)
        //{
        //    return 1;
        //}
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
    }
}
