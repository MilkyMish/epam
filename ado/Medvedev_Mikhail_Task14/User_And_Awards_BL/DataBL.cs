using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using User_And_Awards_DAL;

namespace User_And_Awards_BL
{
    public class DataBL
    {

        private readonly IData DataDAO;
        int userId = 1;
        int awardId = 1;

        public DataBL()
        {
           // DataDAO = new DataDAO();
            var connectionstr = ConfigurationManager.ConnectionStrings["MyConnetionString"].ConnectionString;
            DataDAO = new DataSqlDAO(connectionstr);
        }

        #region users

        public void AddUser(string name, string surname, DateTime birthday, int id /*, List<Awards> awards*/ )
        {
            Users user = new Users
            {
                Name = name,
                Surname = surname,
                Birthday = birthday,
                Id = id
            
            };
            DataDAO.AddUser(user);
           // DataDAO.test();
        }

        public void AddUser(Users user)
        {      
              if (user == null)
                throw new ArgumentException("user");
            DataDAO.AddUser(user);
        }



        public IEnumerable<Users> GetUserList()
        {
            return DataDAO.GetUserList();
        }
      

        public IEnumerable<Users> InitUserList()
        {

            Users user = new Users() { Name = "Arnold", Surname = "Layne", Birthday = new DateTime(1997, 1, 1), Id = userId++ };
            DataDAO.AddUser(user);
            return DataDAO.GetUserList();
        }

        public void RemoveUser(int selectedId)
        {
            RemoveUser(selectedId);
        }

        public void EditUser(int UserId, Users NewUser)
        {
            DataDAO.EditUser(userId, NewUser);
        }

        #endregion

        #region awards

        public void AddAward(string title, string description, int id )
        {
            Awards award = new Awards
            {
                Title = title,
                Description = description,
                Id = id

            };
            DataDAO.AddAward(award);
        }

        public void AddAward(Awards award)
        {
            if (award == null)
                throw new ArgumentException("award");
            DataDAO.AddAward(award);
        }


        public IEnumerable<Awards> InitAwardList()
        {
            Awards award = new Awards()
            {
                Title = "Best Guy",
                Description = "for really cool men",
                Id = awardId++
            };

            DataDAO.AddAward(award);
            DataDAO.AddAward(new Awards() { Title = "Best Girl", Description = "for really cool women", Id = awardId++ });

            return DataDAO.GetAwardList();
        }

        public IEnumerable<Awards> GetAwardList()
        {
            return DataDAO.GetAwardList();
        }

        public void RemoveAward(int selectedId)
        {
            DataDAO.RemoveAward(selectedId);
        }

        public UserWithAward RemoveUsersAward(Users user,Awards award)
        {
            return RemoveUsersAward(user,award);
        }
        #endregion
    }
}
