using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace User_And_Awards_DAL
{
    public class DataDAO //: IData
    {
        private List<Users> users = new List<Users>();
        private List<Awards> awards = new List<Awards>();
        
        public void AddUser(Users user)
        {
            if (user == null)
                throw new ArgumentException("user");

            users.Add(user);
        }

        public IEnumerable<Users> GetUserList()
        {
            return users;
        }

        public  void RemoveUser(int selectedId)
        {
            List<Users> temp = new List<Users>(users);
           
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Id == selectedId)
                {
                    users.RemoveAt(temp[i].Id);
                }                
            }           
        }

        public void EditUser(int UserId, Users NewUser)
        {
            List<Users> temp = new List<Users>(users);

            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Id == UserId)
                {
                    users[i]=NewUser;
                }
            }
        }

        #region awards

        public void RemoveAward(int selectedId)
        {
            List<Awards> temp = new List<Awards>(awards);

            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Id == selectedId)
                {
                    awards.RemoveAt(temp[i].Id);
                }
            }
        }

        public UserWithAward RemoveUsersAward(Users user, Awards award)
        {
            foreach (var item in users)
            {
                if (user.Id == item.Id)
                {
                    item.Awards.Remove(award);
                    return UserWithAward.ModelMaker(item);
                }
            }
            return UserWithAward.ModelMaker(user);
        }

        public void AddAward(Awards award)
        {
            if (award == null)
                throw new ArgumentException("award");

            awards.Add(award);
        }

        public IEnumerable<Awards> GetAwardList()
        {
            return awards;
        }

        #endregion
    }
}
