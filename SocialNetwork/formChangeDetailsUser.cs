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
            this.user = user;
            InitializeComponent();
            resetValidLables();
            loadUserDetails();
        }

        private void formChangeDetailsUser_Load(object sender, EventArgs e)
        {
            resetValidLables(); 
            cbMaritalStatus.Items.AddRange(maritalStatuses);
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

        protected override void loadUserDetails()
        {
            txtFname.Text = user.Fname;
            txtLname.Text = user.Lname;
            txtDob.Text = user.Dob;
            txtCity.Text = user.City;
            cbMaritalStatus.SelectedText = user.MaritalStatus;
            txtInfo.Text = user.Info;
        }

        protected override void btnConfirm_Click_1(object sender, EventArgs e)
        {
            resetValidLables(); 

            bool valid = true; 
            String result;
            String[] values = new String[8];
            String[] originalValues =
                {user.Fname, user.Lname, user.Password, user.MaritalStatus, user.Dob, user.City, user.Status, user.Info };

            result = user.checkFname(txtFname.Text);
            if (result != null && txtFname.Text != "")
            {
                valid = false;
                labValidFname.Text = result;
            }
            else { values[0] = txtFname.Text; }

            result = user.checkLname(txtLname.Text);
            if (result != null && txtLname.Text != "")
            {
                valid = false;
                labValidLname.Text = result;
            }
            else { values[1] = txtLname.Text; }

            result = user.checkPassword(txtPassword.Text);
            if (result != null && txtPassword.Text != "")
            {
                valid = false;
                labValidPassword.Text = result;
            }
            else { values[2] = txtPassword.Text; }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                valid = false;
                labValidConfirmPassword.Text = "Password do not match";
                values[2] = null;
            }

            if (cbMaritalStatus.SelectedItem == null)
            {
                valid = false;
                labValidMaritalStatus.Text = "Must select a status";
            }
            else { values[3] = cbMaritalStatus.SelectedText; }

            result = user.checkDob(txtDob.Text);
            if (result != null && txtDob.Text != "")
            {
                valid = false;
                labValidDob.Text = result;
            }
            else { values[4] = txtDob.Text; }

            result = user.checkCity(txtCity.Text);
            if (result != null && txtCity.Text != "")
            {
                valid = false;
                labValidCity.Text = result;
            }
            else { values[5] = txtCity.Text; }

            values[6] = user.Status;

            result = user.checkInfo(txtInfo.Text);
            if (result != null && txtInfo.Text != "")
            {
                valid = false;
                labValidInfo.Text = result;
            }
            else { values[7] = txtInfo.Text; }

            if (!valid)
            {
                labValidFname.Show();
                labValidLname.Show();
                labValidPassword.Show();
                labValidConfirmPassword.Show();
                labValidDob.Show();
                labValidCity.Show();
                labValidMaritalStatus.Show();
                labValidInfo.Show();

                labValidFname.ForeColor = Color.Red;
                labValidLname.ForeColor = Color.Red;
                labValidPassword.ForeColor = Color.Red;
                labValidConfirmPassword.ForeColor = Color.Red;
                labValidDob.ForeColor = Color.Red;
                labValidCity.ForeColor = Color.Red;
                labValidMaritalStatus.ForeColor = Color.Red;
                labValidInfo.ForeColor = Color.Red;
            }

            else {
                for (int i = 0; i < values.Length; i++)
                {
                    
                    if (values[i] == null || values[i] == "")
                    {
                        values[i] = originalValues[i];
                    }
                }

                MessageBox.Show(user.changeDetails(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]));
            }
        }
    }
}
