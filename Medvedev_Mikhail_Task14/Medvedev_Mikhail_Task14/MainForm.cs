using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Medvedev_Mikhail_Task14
{
    public partial class MainForm : Form
    {
        private BindingList<UserWithAward> _users = new BindingList<UserWithAward>();
        private BindingList<Awards> _awards = new BindingList<Awards>();
        private List<Users> users = new List<Users>();
        private List<Awards> awards = new List<Awards>();
        private int userId = 1;
        private int awardId = 1;
        public MainForm()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ctlUsers.SelectedCells.Count > 0 & tabUsersAndAwards.SelectedTab == tabUsers)
            {
                AddNewUser();
            }
           
          
            if (ctlAwards.SelectedCells.Count > 0 & tabUsersAndAwards.SelectedTab == tabAwards)
            {
                AddNewAward();
            }
            
        }

        private void AddNewUser()
        {
            Users user = new Users();
            UserForm form = new UserForm(user,awards);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                //Users user = new Users();
                user.Name = form.Name;
                user.Surname = form.Surname;
                user.Birthday = form.BD;
                user.Awards = form.userAwards;
                user.Id = userId++;

                users.Add(user);

                UserWithAward userWithAward = new UserWithAward();
                userWithAward = UserWithAward.ModelMaker(user);
                
                _users.Add(userWithAward);
            
                //RABOTAY(userWithAward);
                refreshUsersGrid();
            }
        }

        private void AddNewAward()
        {
            AwardForm form = new AwardForm();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Awards award = new Awards();
                award.Title = form.Title;
                award.Description = form.Description;
                award.Id = awardId++;
                awards.Add(award);
                //refreshAwardsGrid();
                _awards.Add(award);

                refreshAwardsGrid();
            }
        }

        private void EditSelectedUser()
        {
            if (ctlUsers.SelectedCells.Count > 0)
            {
                UserWithAward user = (UserWithAward)ctlUsers.SelectedCells[0].OwningRow.DataBoundItem;
                Users editUser=null;
                int id = 0;
                foreach (var item in users)
                {                    
                    if (item.Id==user.Id)
                    {
                        editUser = item;
                    }
                    else
                    {
                        id++;
                    }
                }
                

                UserForm form = new UserForm(editUser, awards);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    editUser.Name = form.Name;
                    editUser.Surname = form.Surname;
                    editUser.Birthday = form.BD;
                    editUser.Awards = form.userAwards;
                    users[id] = editUser;
                    user = UserWithAward.ModelMaker(editUser);
                    //id = 0;
                    BindingList<UserWithAward> temp = new BindingList<UserWithAward>(_users);

                    for (int i = 0; i < temp.Count; i++)
                    {
                        if (temp[i].Id == user.Id)
                        {
                            _users[i] = user;
                        }
                    }    
                }
            }
        }

        private void EditSelectedAward()
        {
            if (ctlUsers.SelectedCells.Count > 0)
            {
                Awards award = (Awards)ctlAwards.SelectedCells[0].OwningRow.DataBoundItem;

                AwardForm form = new AwardForm(award);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    award.Title = form.Title;
                    award.Description = form.Description;
                    BindingList<Awards> temp = new BindingList<Awards>(_awards);
                    for (int i = 0; i < temp.Count; i++)
                    {
                        if (award.Id == temp[i].Id)
                        {
                            _awards[i] = award;
                        }
                    }
                    
                }
            }
        }

        private void RemoveSelectedUser()
        {
            if (ctlUsers.SelectedCells.Count > 0)
            {
                UserWithAward user = (UserWithAward)ctlUsers.SelectedCells[0].OwningRow.DataBoundItem;
                List<Users> temp = new List<Users>(users);
                for (int i = 0; i < temp.Count; i++)
                {
                    if (user.Id == temp[i].Id)
                    {
                        users.Remove(temp[i]);
                    }
                }
                _users.Remove(user);
                
            }
        }

        private void RemoveSelectedAward()
        {
            if (ctlUsers.SelectedCells.Count > 0)
            {
                Awards award = (Awards)ctlAwards.SelectedCells[0].OwningRow.DataBoundItem;
                List<Awards> temp = new List<Awards>(awards);
                for (int i = 0; i < temp.Count; i++)
                {
                    if (award.Id == temp[i].Id)
                    {
                        awards.Remove(temp[i]);
                    }
                }
                _awards.Remove(award);
                dropAwardFromUsers(award);
            }
        }

        private void dropAwardFromUsers(Awards award)
        {
            List<Users> temp = new List<Users>(users);
            BindingList<UserWithAward> tempView = new BindingList<UserWithAward>(_users);
            for (int i = 0; i < temp.Count; i++)
            {
               
                
                    users[i].Awards.Remove(award);

                    for (int k = 0; k < tempView.Count; k++)
                    {
                        if (temp[i].Id == tempView[k].Id)
                        {                           
                            _users[k] = UserWithAward.ModelMaker(users[i]);
                        }                                               

                        refreshUsersGrid();
                    }

                    
                
                
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ctlUsers.DataSource = _users;
            ctlAwards.DataSource = _awards;

            _awards.Add(new Awards() { Title = "Best Guy", Description = "for really cool men",Id=awardId++ });
            _awards.Add(new Awards() { Title = "Best Girl", Description = "for really cool women", Id = awardId++ });

            awards.Add(_awards[0]);
            awards.Add(_awards[1]);

            Users user = new Users() { Name = "Arnold", Surname = "Layne", Birthday = new DateTime(1997, 1, 1), Id = userId++ };
            users.Add(user);
            //UserWithAward userWithAward = new UserWithAward();
            _users.Add(new UserWithAward() { Name = "Arnold", Surname = "Layne", Birthday = new DateTime(1997, 1, 1), Id = user.Id });
            // userWithAward = UserWithAward.ModelMaker(user);

            //_users.Add(UserWithAward.ModelMaker(users[0]));   //падает если _users.Add(UserWithAward.ModelMaker(users[0])); 


            refreshUsersGrid();
            ctlAwards.CurrentCell = null;
            ctlUsers.CurrentCell = null;
            //refreshAwardsGrid();
        }
        private void refreshUsersGrid()
        {
            //var users = logic.GetUsersViewModel();
            ctlUsers.DataSource = _users;
            ctlUsers.Refresh();
        }

        private void refreshAwardsGrid()
        {
            //var users = logic.GetUsersViewModel();
            ctlAwards.DataSource = _awards;
            ctlAwards.Refresh();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            if (ctlUsers.SelectedCells.Count > 0)
            {
                EditSelectedUser();
            }
            if (ctlAwards.SelectedCells.Count > 0)
            {
                EditSelectedAward();
            }
        }

        private void eraseToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            if (ctlUsers.SelectedCells.Count > 0)
            {
                RemoveSelectedUser();
            }
            if (ctlAwards.SelectedCells.Count > 0)
            {
                RemoveSelectedAward();
            }
        }

        private void ctlAwards_SelectionChanged(object sender, EventArgs e)
        {
            if (ctlUsers.SelectedCells.Count > 0)
            {
                ctlUsers.CurrentCell = null;
            }
        }

        private void ctlUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (ctlAwards.SelectedCells.Count > 0)
            {
                ctlAwards.CurrentCell = null;
            }
        }
    }
}
