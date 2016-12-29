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
    public partial class formChangeDetails : Form
    {
        protected int index;
        private Account account;

        public formChangeDetails()
        {
            InitializeComponent();
        }
        public formChangeDetails(Account account)
        {
            this.account = account;
            InitializeComponent();
            loadUserDetails();
            resetValidLables();
        }

        private void formChangeDetails_Load(object sender, EventArgs e)
        {
            
        }

        
        

        

        protected virtual void resetValidLables()
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

        protected virtual void loadUserDetails()
        {
            txtFname.Text = account.Fname;
            txtLname.Text = account.Lname;
        }

        protected virtual void btnConfirm_Click_1(object sender, EventArgs e)
        {
            resetValidLables(); 

            bool valid = true; 
            String result;
            String[] values = new String[3];
            String[] originalValues =
                {account.Fname, account.Lname, account.Password};

            result = account.checkFname(txtFname.Text);
            if (result != null && txtFname.Text != "")
            {
                valid = false;
                labValidFname.Text = result;
            }
            else { values[0] = txtFname.Text; }

            result = account.checkLname(txtLname.Text);
            if (result != null && txtLname.Text != "")
            {
                valid = false;
                labValidLname.Text = result;
            }
            else { values[1] = txtLname.Text; }

            result = account.checkPassword(txtPassword.Text);
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

            if (!valid)
            {
                labValidFname.Show();
                labValidLname.Show();
                labValidPassword.Show();
                labValidConfirmPassword.Show();
            }

            else {
                for (int i = 0; i < values.Length; i++)
                {
                    
                    if (values[i] == null || values[i] == "")
                    {
                        values[i] = originalValues[i];
                    }
                }

                MessageBox.Show(account.changeDetails(values[0], values[1], values[2]));
            }
        }
    }
}
