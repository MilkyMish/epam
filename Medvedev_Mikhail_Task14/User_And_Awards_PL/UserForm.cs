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

namespace User_And_Awards_PL
{
    public partial class UserForm : Form
    {
        private readonly bool _createNew = true;
        public string Name { get; private set; } // ????
        public string Surname { get; private set; }
        public DateTime BD { get; private set; }
        private DateTime CheckBD;
        public List<Awards> userAwards = new List<Awards>();
        private List<Awards> currentAwards = new List<Awards>();
        public UserForm(/*BindingList<Awards> _awards*/)
        {
            InitializeComponent();
           // listUsersAwards.Items.Add(_awards);
        }
        public UserForm(Users user, List<Awards> _awards)
        {
            InitializeComponent();
            Name = user.Name;
            Surname = user.Surname;
            
            if (user.Birthday != CheckBD)
            {
                BD = user.Birthday;
                pickBirthday.Value = user.Birthday;
            }
            else
            {
                BD = DateTime.Now;
                pickBirthday.Value = DateTime.Now;
                //???
            }
            
            userAwards = new List<Awards>(_awards);
            if (user.Awards!=null)
            {
                currentAwards = new List<Awards>(user.Awards);
            }
            


            // listUsersAwards.Items.Add(_awards);
            _createNew = false;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            txtName.Text = Name;
            txtSurname.Text = Surname;

            if (CheckBD == BD) 
            {
                pickBirthday.Value = DateTime.Now;
            }
            else
            {
                pickBirthday.Value = BD;
            }

            if (currentAwards.Count == userAwards.Count) //если у него все награды
            {
                foreach (var item in currentAwards)
                {
                    listUsersAwards.Items.Add(item.Title, true);
                }
            }
            else
            {
                awardCheck(); 
            }
            // listUsersAwards.Items.Add(MainForm._awards);
            if (_createNew)
            {
                Text = "Add new user";
                btnOk.Text = "Add";
            }
            else
            {
                Text = "Edit user";
                btnOk.Text = "Edit";
            }
                
        }

        private void awardCheck()
        {
            for (int i = 0; i < userAwards.Count; i++)
            {
                if (currentAwards.Contains(userAwards[i]))
                {
                    listUsersAwards.Items.Add(userAwards[i].Title, true);
                }
                else
                {
                    listUsersAwards.Items.Add(userAwards[i].Title);
                }
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            /* string inputName = txtName.Text.Trim();
             string inputSurName = txtSurname.Text.Trim();
             //|| String.IsNullOrEmpty(inputSurName)

             if (String.IsNullOrEmpty(inputName))
             {
                 errorProvider.SetError(txtName, "Некорректное значение!");              
             }
             else
             {
                 errorProvider.SetError(txtName, String.Empty);

            MainForm._awards[i].Title
             }*/
            //List<int> userAwards = new List<int>();
            var temp = new List<Awards>();
            for (int id = 0; id < listUsersAwards.Items.Count; id++)
            {
                if (listUsersAwards.GetItemChecked(id))
                {
                    foreach (var item in userAwards)
                    {
                        if (item.Id == userAwards[id].Id)
                        {
                            temp.Add(item);
                        }
                    }                  
                }
            }
            userAwards = null;
            userAwards = new List<Awards>(temp);
            //List<Awards> awards = listUsersAwards.CheckedItems[];
            //UserWithAward userWithAward = new UserWithAward(user, userAwards);
            DialogResult = ValidateChildren() ?  DialogResult.OK  : DialogResult.None;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            string input = txtName.Text.Trim();

            if (String.IsNullOrEmpty(input))
            {
                errorProvider.SetError(txtName, "Некорректное значение!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtName, String.Empty);
                e.Cancel = false;
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Name = txtName.Text.Trim();
        }

        private void txtSurname_Validating(object sender, CancelEventArgs e)
        {
            string input = txtSurname.Text.Trim();

            if (String.IsNullOrEmpty(input))
            {
                errorProvider.SetError(txtSurname, "Некорректное значение!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtSurname, String.Empty);
                e.Cancel = false;
            }
        }

        private void txtSurname_Validated(object sender, EventArgs e)
        {
            Surname = txtSurname.Text.Trim();
        }

        private void pickBirthday_Validating(object sender, CancelEventArgs e)
        {
            DateTime input = pickBirthday.Value;
            DateTime edge = new DateTime(1900, 12, 1); // год - месяц - день 
            if (input > DateTime.Now || input < edge)
            {
                errorProvider.SetError(txtName, "Некорректное значение!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtName, String.Empty);
                e.Cancel = false;
            }
        }

        private void pickBirthday_Validated(object sender, EventArgs e)
        {
            BD = pickBirthday.Value;
        }

        
    }
}
