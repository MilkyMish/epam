using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace User_And_Awards_DAL
{
    public interface IData
    {
        void AddUser(Entities.Users user);
        void AddAward(Entities.Awards award);
        void EditUser(int id, Users user);
        void RemoveAward(int selectedId);
        //void test();
        System.Collections.Generic.IEnumerable<Entities.Users> GetUserList();
        System.Collections.Generic.IEnumerable<Entities.Awards> GetAwardList();
    }
}
