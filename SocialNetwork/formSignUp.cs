using SocialNetwork.source;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialNetwork
{
    public partial class formSignUp : Form
    {
        private Database database = Database.getDatabase();
        private String[] maritalStatuses = new String[] { "Single", "Married", "Married with children" };
        private Home parent;
        private formAccount formParent;

        public formSignUp(Home parent)
        {
            InitializeComponent();
            this.parent = parent;
            cbFormType.Items.Add(Program.permissionLevels.User);
            cbFormType.Items.Add(Program.permissionLevels.TechSupport);
            cbFormType.Items.Add(Program.permissionLevels.Admin);
            cbFormType.SelectedIndex = 0;
            cbFormType.Hide();
            labFormType.Hide();
            this.userScheme();
        }

        public formSignUp(formAccount formParent, Account account, int access)
        {
            InitializeComponent();
            this.formParent = formParent;
            cbFormType.Show();
            labFormType.Show();
            cbFormType.Items.Add(Program.permissionLevels.User);
            cbFormType.Items.Add(Program.permissionLevels.TechSupport);
            cbFormType.Items.Add(Program.permissionLevels.Admin);
            Program.permissionLevels permission = (Program.permissionLevels)access;

            switch (permission)
            {
                case Program.permissionLevels.User:
                    this.userScheme();
                    cbFormType.SelectedIndex = 0;
                    this.cbFormType.Refresh();
                    break;
                case Program.permissionLevels.TechSupport:
                    this.techScheme();
                    cbFormType.SelectedIndex = 1;
                    this.cbFormType.Refresh();
                    break;
                case Program.permissionLevels.Admin:
                    this.adminScheme();
                    cbFormType.SelectedIndex = 2;
                    this.cbFormType.Refresh();
                    break;
                default:
                    MessageBox.Show("Exception, wrong permission");
                    return;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            resetValidLables(); 

            List<bool> valid = new List<bool>(); 
            Program.permissionLevels permission = (Program.permissionLevels)cbFormType.SelectedItem;

            switch (permission)
            {
                case Program.permissionLevels.User:
                    valid.Add(checkIfUsernameExists());
                    valid.Add(checkUsername());
                    valid.Add(checkPassword());
                    valid.Add(checkPasswordsMatch());
                    valid.Add(checkFname());
                    valid.Add(checkLname());
                    valid.Add(checkDate());
                    valid.Add(checkCity());
                    valid.Add(checkMaritalStatus());
                    valid.Add(checkInfo());
                    break;
                case Program.permissionLevels.TechSupport:
                    valid.Add(checkIfUsernameExists());
                    valid.Add(checkUsername());
                    valid.Add(checkPassword());
                    valid.Add(checkPasswordsMatch());
                    valid.Add(checkFname());
                    valid.Add(checkLname());
                    break;
                case Program.permissionLevels.Admin:
                    valid.Add(checkIfUsernameExists());
                    valid.Add(checkUsername());
                    valid.Add(checkPassword());
                    valid.Add(checkPasswordsMatch());
                    valid.Add(checkFname());
                    valid.Add(checkLname());
                    break;
                default:
                    MessageBox.Show("Exceptional Exception - permission unknown - exiting program");
                    return;
                    break;
            }

            if (valid.Contains(false) == false) 
            {
                switch (permission)
                {
                    case Program.permissionLevels.User:
                        User user = new User(txtUsername.Text, txtFname.Text, txtLname.Text, txtPassword.Text,
                            cbMaritalStatus.SelectedText, txtDob.Text, txtCity.Text, txtInfo.Text, "");
                        this.database.addUser(user);
                        break;
                    case Program.permissionLevels.TechSupport:
                        TechSupport tech = new TechSupport(txtUsername.Text, txtFname.Text, txtLname.Text, txtPassword.Text);
                        this.database.addTech(tech);
                        break;
                    case Program.permissionLevels.Admin:
                        Admin admin = new Admin(txtUsername.Text, txtFname.Text, txtLname.Text, txtPassword.Text);
                        this.database.addAdmin(admin);
                        break;
                    default:
                        MessageBox.Show("Exceptional Exception - permission unknown - exiting program");
                        return;
                        break;
                }

                MessageBox.Show("Succesful!");
                this.Close();


            }
        }

        private void formSignUp_Load(object sender, EventArgs e)
        {
            resetValidLables(); 
            cbMaritalStatus.Items.AddRange(maritalStatuses); 
        }

        private void resetValidLables()
        {
            labValidDob.Text = "";
            labValidConfirmPassword.Text = "";
            labValidPassword.Text = "";
            labValidCity.Text = "";
            labValidFname.Text = "";
            labValidLname.Text = "";
            labValidMaritalStatus.Text = "";
            labValidUsername.Text = ""; 
            labValidInfo.Text = "";

            labValidDob.ForeColor = Color.Red; 
            labValidConfirmPassword.ForeColor = Color.Red;
            labValidPassword.ForeColor = Color.Red;
            labValidCity.ForeColor = Color.Red;
            labValidFname.ForeColor = Color.Red;
            labValidLname.ForeColor = Color.Red;
            labValidMaritalStatus.ForeColor = Color.Red;
            labValidUsername.ForeColor = Color.Red;
            labValidInfo.ForeColor = Color.Red;
        }

        public void userScheme() 
        {
            txtUsername.Show();
            txtPassword.Show();
            txtConfirmPassword.Show();
            txtFname.Show();
            txtLname.Show();
            txtDob.Show();
            txtCity.Show();
            cbMaritalStatus.Show();
            txtInfo.Show();

            txtUsername.Show();
            labValidPassword.Show();
            labValidConfirmPassword.Show();
            labValidFname.Show();
            labValidLname.Show();
            labValidDob.Show();
            labValidCity.Show();
            labValidMaritalStatus.Show();
            labValidInfo.Show();

            resetValidLables();
            this.Refresh();
        }

        public void techScheme() 
        {
            txtUsername.Show();
            txtPassword.Show();
            txtConfirmPassword.Show();
            txtFname.Show();
            txtLname.Show();
            txtDob.Hide();
            txtCity.Hide();
            cbMaritalStatus.Hide();
            txtInfo.Hide();

            txtUsername.Show();
            labValidPassword.Show();
            labValidConfirmPassword.Show();
            labValidFname.Show();
            labValidLname.Show();
            labValidDob.Hide();
            labValidCity.Hide();
            labValidMaritalStatus.Hide();
            labValidInfo.Hide();

            resetValidLables();
            this.Refresh();
        }

        public void adminScheme() 
        {
            txtUsername.Show();
            txtPassword.Show();
            txtConfirmPassword.Show();
            txtFname.Show();
            txtLname.Show();
            txtDob.Hide();
            txtCity.Hide();
            cbMaritalStatus.Hide();
            txtInfo.Hide();
            cbFormType.Show();
            labFormType.Show();

            txtUsername.Show();
            labValidPassword.Show();
            labValidConfirmPassword.Show();
            labValidFname.Show();
            labValidLname.Show();
            labValidDob.Hide();
            labValidCity.Hide();
            labValidMaritalStatus.Hide();
            labValidInfo.Hide();

            resetValidLables();
            this.Refresh();
        }

        private bool checkIfUsernameExists()
        {
            if (database.checkIfUserExists(txtUsername.Text) == true) 
            {
                labValidUsername.Text = "Username already exists";
                return false;
            }
            return true;
        }

        private bool checkUsername()
        {
            if (txtUsername.Text != "")
            {
                if (txtUsername.Text.Any(Char.IsWhiteSpace) == true) 
                {
                    labValidUsername.Text = "must not contain white-spaces";
                    return false;
                }
            }
            else
            {
                labValidUsername.Text = "Invalid";
                return false;
            }

            return true;
        }

        private bool checkFname()
        {
            if (txtFname.Text != "")
            {
                if (txtFname.Text.Any(Char.IsDigit) == true) 
                {
                    labValidFname.Text = "Can't enter digits inside a name";
                    return false;
                }
                else if (txtFname.Text.Any(Char.IsLetter) == false) 
                {
                    labValidFname.Text = "You must enter letters";
                    return false;
                }
            }
            else
            {
                labValidFname.Text = "Invalid";
                return false;
            }

            return true;
        }

        private bool checkLname()
        {
            if (txtLname.Text != "")
            {
                if (txtLname.Text.Any(Char.IsDigit) == true) 
                {
                    labValidLname.Text = "Can't enter digits inside a name";
                    return false;
                }
                else if (txtLname.Text.Any(Char.IsLetter) == false) 
                {
                    labValidLname.Text = "You must enter letters";
                    return false;
                }
            }
            else
            {
                labValidLname.Text = "Invalid";
                return false;
            }

            return true;
        }

        private bool checkDate()
        {
            
            if (Regex.IsMatch(txtDob.Text, @"^(\d{2})/(\d{2})/(\d{4})$") == true) 
            {
                String[] values = txtDob.Text.Split('/'); 
                int day = Int32.Parse(values[0]);
                int month = Int32.Parse(values[1]);
                int year = Int32.Parse(values[2]);

                bool validDate = true;

                DateTime temp = DateTime.Now; 

                if (year > temp.Year || year < (temp.Year - 120)) 
                {
                    labValidDob.Text += "Invalid Year ";
                    validDate = false;
                }

                if (month > 12 || month < 1) 
                {
                    labValidDob.Text += "Invalid Month ";
                    validDate = false;
                }

                if (validDate && (day < 1 || day > DateTime.DaysInMonth(year, month))) 
                {
                    labValidDob.Text += "Invalid Day ";
                    validDate = false;
                }

                if (!validDate)
                {
                    return false;
                }

                return true;
            }
            else
            {
                labValidDob.Text = "Invalid Date";
                return false;
            }
        }

        private bool checkPassword()
        {
            if (txtPassword.Text != "")
            {
                if (txtPassword.Text.Any(Char.IsWhiteSpace) == true) 
                {
                    labValidPassword.Text = "must not contain white-spaces";
                    return false;
                }
            }
            else
            {
                labValidPassword.Text = "Invalid";
                return false;
            }

            return true;
        }

        private bool checkMaritalStatus()
        {
            if (cbMaritalStatus.SelectedItem == null)
            {
                labValidMaritalStatus.Text = "Invalid";
                return false;
            }
            return true;
        }

        private bool checkCity()
        {
            if (txtCity.Text != "")
            {
                if (txtCity.Text.Any(Char.IsDigit) == true) 
                {
                    labValidCity.Text = "Can't enter digits";
                    return false;
                }
                else if (txtLname.Text.Any(Char.IsLetter) == false) 
                {
                    labValidCity.Text = "You must enter text";
                    return false;
                }
            }
            else
            {
                labValidCity.Text = "Invalid";
                return false;
            }

            return true;
        }

        private bool checkInfo()
        {
            if (txtInfo.Text != "")
            {
                if (txtInfo.Text.Any(Char.IsLetter) == false) 
                {
                    labValidInfo.Text = "You must enter text";
                    return false;
                }
            }

            return true;
        }

        private bool checkPasswordsMatch()
        {
            if (txtPassword.Text != txtConfirmPassword.Text) 
            {
                labValidConfirmPassword.Text = "Passwords do not match";
                return false;
            }

            return true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labValidInfo_Click(object sender, EventArgs e)
        {

        }

        private void txtInfo_TextChanged(object sender, EventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (parent != null)
            {
                parent.Show();
            }
            else if (formParent != null)
            {
                formParent.Show();
            }
        }

        private void cbFormType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.permissionLevels permission = (Program.permissionLevels)cbFormType.SelectedItem;

            switch (permission)
            {
                case Program.permissionLevels.User:
                    userScheme();
                    break;
                case Program.permissionLevels.TechSupport:
                    techScheme();
                    break;
                case Program.permissionLevels.Admin:
                    adminScheme();
                    break;
                default:
                    break;
            }
        }
    }
}
