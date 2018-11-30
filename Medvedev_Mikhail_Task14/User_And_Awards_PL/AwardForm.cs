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
    public partial class AwardForm : Form
    {
        private readonly bool _createNew = true;
        public string Title { get; private set; } // ????
        public string Description { get; private set; }
       

        public AwardForm()
        {
            InitializeComponent();
   
        }
        public AwardForm(Awards award)
        {
            InitializeComponent();

            Title = award.Title;
            Description = award.Description;
            _createNew = false;
        }

        private void AwardForm_Load(object sender, EventArgs e)
        {
            txtTitle.Text = Title;
            txtDescription.Text = Description;
            if (_createNew)
            {
                Text = "Add new award";
                btnOk.Text = "Add";
            }
            else
            {
                Text = "Edit award";
                btnOk.Text = "Edit";
            }
        }

        private void txtTitle_Validated(object sender, EventArgs e)
        {
            Title = txtTitle.Text.Trim();
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            string input = txtTitle.Text.Trim();

            if (String.IsNullOrEmpty(input))
            {
                errorProvider.SetError(txtTitle, "Некорректное значение!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTitle, String.Empty);
                e.Cancel = false;
            }
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Description = txtDescription.Text.Trim();
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            string input = txtDescription.Text.Trim();

            if (String.IsNullOrEmpty(input))
            {
                errorProvider.SetError(txtDescription, "Некорректное значение!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtDescription, String.Empty);
                e.Cancel = false;
            }
        }

        /* 
       
        private void UserForm_Load(object sender, EventArgs e)
        {
            txtName.Text = Name;
            txtSurname.Text = Surname;
            pickBirthday.Value = BD;
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
                
        }*/
    }
}
