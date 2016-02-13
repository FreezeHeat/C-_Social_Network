using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialNetwork
{
    public partial class formChangeDetailsUser : formChangeDetails
    {
        private User user;
        private String[] maritalStatuses = new String[] { "Single", "Married", "Married with children" };
        private Database database = Database.getDatabase();

        public formChangeDetailsUser(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void formChangeDetailsUser_Load(object sender, EventArgs e)
        {
            resetValidLables(); // לאתחל לייבלים
            cbMaritalStatus.Items.AddRange(maritalStatuses);
        }

        protected override void btnConfirm_Click(object sender, EventArgs e)
        {
            resetValidLables(); // להחביא ליבלים

            bool valid = true; // לבדיקה
            String result;

            result = user.checkFname(txtFname.Text);
            if(result != null)
            {
                valid = false;
                labValidFname.Text = result;
            }

            result = user.checkLname(txtLname.Text);
            if (result != null)
            {
                valid = false;
                labValidLname.Text = result;
            }

            result = user.checkPassword(txtPassword.Text);
            if (result != null)
            {
                valid = false;
                labValidFname.Text = result;
            }

            if(txtPassword.Text != txtConfirmPassword.Text)
            {
                valid = false;
                labValidConfirmPassword.Text = "Password do not match";
            }

            result = user.checkDob(txtDob.Text);
            if(result != null)
            {
                valid = false;
                labValidDob.Text = result;
            }

            result = user.checkCity(txtCity.Text);
            if (result != null)
            {
                valid = false;
                labValidCity.Text = result;
            }

            if (cbMaritalStatus.SelectedItem == null)
            {
                valid = false;
                labValidMaritalStatus.Text = "Must select a status";
            }

            result = user.checkInfo(txtInfo.Text);
            if (result != null)
            {
                valid = false;
                labValidInfo.Text = result;
            }


            if (valid) // מידע תקין
            {
                user.Fname = txtFname.Text;
                user.Lname = txtLname.Text;
                user.Password = txtPassword.Text;
                user.Dob = txtDob.Text;
                user.City = txtCity.Text;
                user.MaritalStatus = cbMaritalStatus.SelectedText;
                user.Info = txtInfo.Text;

                List<String> list = new List<String>() { user.Fname, user.Lname, user.Password, user.Dob, user.City, user.MaritalStatus, user.Info };
                database.changeUserDetails(list);
                MessageBox.Show("Succesful!");
                this.Close();
            }
        }

        protected override void resetValidLables()
        {
            labValidConfirmPassword.Text = "";
            labValidPassword.Text = "";
            labValidFname.Text = "";
            labValidLname.Text = "";
            labValidDob.Text = "";
            labValidCity.Text = "";
            labValidMaritalStatus.Text = "";
            labValidInfo.Text = "";


            labValidConfirmPassword.ForeColor = Color.Red;
            labValidPassword.ForeColor = Color.Red;
            labValidFname.ForeColor = Color.Red;
            labValidLname.ForeColor = Color.Red;
            labValidDob.ForeColor = Color.Red;
            labValidCity.ForeColor = Color.Red;
            labValidMaritalStatus.ForeColor = Color.Red;
            labValidInfo.ForeColor = Color.Red;
        }
    }
}
