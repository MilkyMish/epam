using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Entities;
using User_And_Awards_BL;


namespace User_And_Awards_PL
{
    public partial class MainForm : Form
    {
        private BindingList<UserWithAward> _users = new BindingList<UserWithAward>();
        private BindingList<Awards> _awards = new BindingList<Awards>();
        // private List<Users> users = new List<Users>();
        // private List<Awards> awards = new List<Awards>();
        private readonly DataBL data = new DataBL();
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
            UserForm form = new UserForm(user,(List<Awards>)data.GetAwardList());     //*

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                //Users user = new Users();
                user.Name = form.Name;
                user.Surname = form.Surname;
                user.Birthday = form.BD;
                user.Awards = form.userAwards;
                user.Id = userId++;

                //users.Add(user);         //*
                data.AddUser(user);

                UserWithAward userWithAward = new UserWithAward();
                userWithAward = UserWithAward.ModelMaker(user);
                
                _users.Add(userWithAward);


                var users = data.GetUserList();
                // users --> userwithawards
                // refreshUsersGrid(userswithawards);
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
                //awards.Add(award);         //*
                data.AddAward(award);   
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
                foreach (var item in (List<Users>)data.GetUserList()) //*
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
                

                UserForm form = new UserForm(editUser, (List<Awards>)data.GetAwardList()); //*
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    editUser.Name = form.Name;
                    editUser.Surname = form.Surname;
                    editUser.Birthday = form.BD;
                    editUser.Awards = form.userAwards;
                    //users[id] = editUser;                //*
                    data.EditUser(id, editUser);
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
                /*List<Users> temp = new List<Users>(users);
                for (int i = 0; i < temp.Count; i++)
                {
                    if (user.Id == temp[i].Id)
                    {
                        users.Remove(temp[i]);
                    }
                }*/
                data.RemoveUser(user.Id);
                _users.Remove(user);
                
            }
        }

        private void RemoveSelectedAward()
        {
            if (ctlAwards.SelectedCells.Count > 0)
            {
                Awards award = (Awards)ctlAwards.SelectedCells[0].OwningRow.DataBoundItem;
                /* List<Awards> temp = new List<Awards>(awards);
                 for (int i = 0; i < temp.Count; i++)
                 {
                     if (award.Id == temp[i].Id)
                     {
                         awards.Remove(temp[i]);
                     }
                 }
                 _awards.Remove(award);*/
                data.RemoveAward(award.Id);
                if (UsersAwardCheck(award))
                {
                    dropAwardFromUsers(award);
                }
                _awards.Remove(award);
                refreshAwardsGrid();
                refreshUsersGrid();
            }
        }

        private bool UsersAwardCheck(Awards award)
        {
            List<Users> temp = new List<Users>(data.GetUserList());
            foreach (var item in temp)
            {
                if (item.Awards!=null)
                {
                    for (int i = 0; i < item.Awards.Count; i++)
                    {
                        if (item.Awards[i] == award)
                        {
                            return true;
                        }
                    }
                }
                
            }

            return false;
        }


        private void dropAwardFromUsers(Awards award)
        {
            List<Users> temp = new List<Users>(data.GetUserList());
            BindingList<UserWithAward> tempView = new BindingList<UserWithAward>(_users);
            for (int i = 0; i < temp.Count; i++)
            {
                //users[i].Awards.Remove(award);             //*


                /* UserWithAward userWithAward = UserWithAward.ModelMaker(temp[i]);
                 for (int j = 0; i < temp[i].Awards.Count; j++)
                 {
                     if (temp[i].Awards.Contains(award))
                     {
                         userWithAward = data.RemoveUsersAward(temp[i], award);
                     }

                 }*/
                UserWithAward userWithAward = data.RemoveUsersAward(temp[i], award);

                for (int k = 0; k < tempView.Count; k++)
                    {
                        if (temp[i].Id == tempView[k].Id)
                        {                           
                            _users[k] = userWithAward;
                        }                                               

                        refreshUsersGrid();
                    }               
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ctlUsers.DataSource = _users;
            ctlAwards.DataSource = _awards;

            //data.AddAward(new Awards() { Title = "Best Guy", Description = "for really cool men",Id = awardId++ });
            //data.AddAward(new Awards() { Title = "Best Girl", Description = "for really cool women", Id = awardId++ });
            List<Awards> awards = (List<Awards>)data.GetAwardList();
            //_awards = (BindingList<Awards>)data.GetAwardList();
            for (int i = 0; i < awards.Count; i++)
            {
                _awards.Add(awards[i]);               
            }
            List<Users> users = (List<Users>)data.GetUserList();
            for (int i = 0; i < users.Count; i++)
            {
                _users.Add(UserWithAward.ModelMaker(users[i]));
            }
            /* Users user = new Users() { Name = "Arnold", Surname = "Layne", Birthday = new DateTime(1997, 1, 1), Id = userId++ };
             data.AddUser(user);

             _users.Add(new UserWithAward() { Name = "Arnold", Surname = "Layne", Birthday = new DateTime(1997, 1, 1), Id = user.Id });
           */
            refreshUsersGrid();
            ctlAwards.CurrentCell = null;
            ctlUsers.CurrentCell = null;
            refreshAwardsGrid();
        }
        private void refreshUsersGrid()
        {
            //var users = logic.GetUsersViewModel();
            ctlUsers.DataSource = _users;
           /* _users = null;
            List<Users> users = (List<Users>)data.GetUserList();
            for (int i = 0; i < users.Count; i++)
            {
                _users.Add(UserWithAward.ModelMaker(users[i]));
            }*/
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

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewUser();
        }
    }
}
