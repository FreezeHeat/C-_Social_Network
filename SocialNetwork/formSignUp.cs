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
            cbFormType.SelectedItem = Program.permissionLevels.User;
            this.userScheme();
        }

        public formSignUp(formAccount formParent, Account account)
        {
            InitializeComponent();
            this.formParent = formParent;
            this.adminScheme();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            resetValidLables(); // להחביא ליבלים

            bool valid = true; // לבדיקה
            Program.permissionLevels permission = (Program.permissionLevels)cbFormType.SelectedItem;

            switch (permission)
            {
                case Program.permissionLevels.User:
                    valid = checkIfUsernameExists();
                    valid = checkUsername();
                    valid = checkPassword();
                    valid = checkPasswordsMatch();
                    valid = checkFname();
                    valid = checkLname();
                    valid = checkDate();
                    valid = checkCity();
                    valid = checkMaritalStatus();
                    valid = checkInfo();
                    break;
                case Program.permissionLevels.TechSupport:
                    valid = checkIfUsernameExists();
                    valid = checkUsername();
                    valid = checkPassword();
                    valid = checkPasswordsMatch();
                    valid = checkFname();
                    valid = checkLname();
                    break;
                case Program.permissionLevels.Admin:
                    valid = checkIfUsernameExists();
                    valid = checkUsername();
                    valid = checkPassword();
                    valid = checkPasswordsMatch();
                    valid = checkFname();
                    valid = checkLname();
                    break;
                default:
                    MessageBox.Show("Exceptional Exception - permission unknown - exiting program");
                    return;
                    break;
            }

            if (valid) // מידע תקין
            {
                switch (permission)
                {
                    case Program.permissionLevels.User:
                        User user = new User(txtUsername.Text, txtFname.Text, txtLname.Text, txtPassword.Text,
                            cbMaritalStatus.SelectedText, txtDob.Text, txtCity.Text, txtInfo.Text, "");
                        this.database.addUser(user);//neora
                        break;
                    case Program.permissionLevels.TechSupport:
                        TechSupport tech = new TechSupport(txtUsername.Text, txtFname.Text, txtLname.Text, txtPassword.Text);
                        this.database.addTech(tech);//neora
                        break;
                    case Program.permissionLevels.Admin:
                        Admin admin = new Admin(txtUsername.Text, txtFname.Text, txtLname.Text, txtPassword.Text);
                        this.database.addAdmin(admin);//neora
                        break;
                    default:
                        MessageBox.Show("Exceptional Exception - permission unknown - exiting program");
                        return;
                        break;
                }

                MessageBox.Show("Succesful!");
                this.Close();
                formParent.Show();//neora


            }
        }

        private void formSignUp_Load(object sender, EventArgs e)
        {
            resetValidLables(); // לאתחל לייבלים
            cbMaritalStatus.Items.AddRange(maritalStatuses); // אתחול גרידים

            cbFormType.Items.Add(Program.permissionLevels.User);
            cbFormType.Items.Add(Program.permissionLevels.TechSupport);
            cbFormType.Items.Add(Program.permissionLevels.Admin);
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
            labValidUsername.Text = ""; // להחזיר למצב סרק
            labValidInfo.Text = "";

            labValidDob.ForeColor = Color.Red; // כולם בצבע אדום
            labValidConfirmPassword.ForeColor = Color.Red;
            labValidPassword.ForeColor = Color.Red;
            labValidCity.ForeColor = Color.Red;
            labValidFname.ForeColor = Color.Red;
            labValidLname.ForeColor = Color.Red;
            labValidMaritalStatus.ForeColor = Color.Red;
            labValidUsername.ForeColor = Color.Red;
            labValidInfo.ForeColor = Color.Red;
        }

        public void userScheme() // מראה את כל הפקדים של המשתמש
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

        public void techScheme() // מראה את כל הפקדים של נציג פניות
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

        public void adminScheme() // פקדים של מנהל
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
            if (database.Accounts.Exists(acc => acc.Username.Equals(txtUsername.Text))) // אותו משתמש
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
                if (txtUsername.Text.Any(Char.IsWhiteSpace) == true) // מינוס אחד או רווחים
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
                if (txtFname.Text.Any(Char.IsDigit) == true) // אם יש מספרים
                {
                    labValidFname.Text = "Can't enter digits inside a name";
                    return false;
                }
                else if (txtFname.Text.Any(Char.IsLetter) == false) // אם אין אותיות
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
                if (txtLname.Text.Any(Char.IsDigit) == true) // אם יש מספרים
                {
                    labValidLname.Text = "Can't enter digits inside a name";
                    return false;
                }
                else if (txtLname.Text.Any(Char.IsLetter) == false) // אם אין אותיות
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
            // בדיקת תאריך
            if (Regex.IsMatch(txtDob.Text, @"^(\d{2})/(\d{2})/(\d{4})$") == true) // מתאים לפורמט
            {
                String[] values = txtDob.Text.Split('/'); // פיצול המחרוזת והמרתם למספרים
                int day = Int32.Parse(values[0]);
                int month = Int32.Parse(values[1]);
                int year = Int32.Parse(values[2]);

                bool validDate = true;

                DateTime temp = DateTime.Now; // תאריך עזר, לבדיקת מקרי קצה

                if (year > temp.Year || year < (temp.Year - 120)) // אם השנה היא מעל השנה הנוכחית או שהאדם מעל גיל 120
                {
                    labValidDob.Text += "Invalid Year ";
                    validDate = false;
                }
                if (month > 12 || month < 1) // חודש חוקי
                {
                    labValidDob.Text += "Invalid Month ";
                    validDate = false;
                }
                if (validDate && (day < 1 || day > DateTime.DaysInMonth(year, month))) // יום חוקי לאותה שנה וחודש
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
                if (txtPassword.Text.Any(Char.IsWhiteSpace) == true) // מינוס אחד או רווחים
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
                if (txtCity.Text.Any(Char.IsDigit) == true) // אם יש מספרים
                {
                    labValidCity.Text = "Can't enter digits";
                    return false;
                }
                else if (txtLname.Text.Any(Char.IsLetter) == false) // אם אין אותיות
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
                if (txtInfo.Text.Any(Char.IsLetter) == false) // אם אין אותיות
                {
                    labValidInfo.Text = "You must enter text";
                    return false;
                }
            }

            return true;
        }

        private bool checkPasswordsMatch()
        {
            if (txtPassword.Text != txtConfirmPassword.Text) // סיסמאות שונות
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
