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
        public formChangeDetailsUser(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void formChangeDetailsUser_Load(object sender, EventArgs e)
        {
            resetValidLables(); // לאתחל לייבלים
        }

        protected override void btnConfirm_Click(object sender, EventArgs e)
        {
            resetValidLables(); // להחביא ליבלים

            bool valid = true; // לבדיקה

            if (txtLname.Text != "")
            {
                if (txtLname.Text.Any(Char.IsDigit) == true) // אם יש מספרים
                {
                    labValidLname.Text = "Can't enter digits inside a name";
                    valid = false;
                }
                else if (txtLname.Text.Any(Char.IsLetter) == false) // אם אין אותיות
                {
                    labValidLname.Text = "You must enter letters";
                    valid = false;
                }
            }
            else
            {
                labValidLname.Text = "Invalid";
                valid = false;
            }

            if (txtPassword.Text != "")
            {
                if (txtPassword.Text.Any(Char.IsWhiteSpace) == true) // מינוס אחד או רווחים
                {
                    labValidPassword.Text = "must not contain white-spaces";
                    valid = false;
                }
            }
            else
            {
                labValidPassword.Text = "Invalid";
                valid = false;
            }



            if (txtPassword.Text != txtConfirmPassword.Text) // סיסמאות שונות
            {
                labValidConfirmPassword.Text = "Passwords do not match";
                valid = false;
            }

            if (valid) // מידע תקין
            {
                user.Fname = txtFname.Text;
                user.Lname = txtLname.Text;
                user.Password = txtPassword.Text;

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

            labValidConfirmPassword.ForeColor = Color.Red;
            labValidPassword.ForeColor = Color.Red;
            labValidFname.ForeColor = Color.Red;
            labValidLname.ForeColor = Color.Red;
        }
    }
}
