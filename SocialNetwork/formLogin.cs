using SocialNetwork.source;
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
    public partial class formLogin : Form {

        private Home parent;
        private bool close = true;
        private Database database = Database.getDatabase();
        private int count = 0;

        public formLogin(Home parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void LogMain_Load(object sender, EventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (close) // אם רוצים לחזור לחלון הבית
            {
                parent.Show();
            }
        }

        private void formLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Return)
            {
                login();
            }
        }

        private void login()
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;

            // בדיקה שהמשתמש שהוקלד אכן קיים במסד הנתונים


            // לא קיים המשתמש
            if (database.checkIfUserExists(username) == false)
            {
                MessageBox.Show("Wrong Account Details");
                if (count++ == 3)
                { // סכום את מספר הנסיונות הכושלים
                    MessageBox.Show("Too many attempts");
                    this.Close();
                }
            }
            else
            {
                // התחברות
                Account account = database.Login(username, password);

                if (account == null)
                {
                    MessageBox.Show("Wrong account details");
                }

                else
                {
                    // אם המשתמש מושבת
                    if (account.Disabled == true)
                    {
                        //this.closeSwitch(false);
                        //formDisabled disabled = new formDisabled(index, parent);
                        MessageBox.Show("Disabled");
                    }
                    else {
                        switch (account.Permission) //סוויצ' לפי הרשאה לפי האינדקס של אותו משתמש שנמצא קודם לכן
                        {
                            case 0:
                                close = false;
                                this.Close();
                                formUser user = new formUser(account, parent); // תפריט למשתמש רגיל
                                user.Show();
                                break;
                            case 1:
                                close = false;
                                this.Close();
                                formTechSupport tech = new formTechSupport(account, parent); // תפריט למשתמש תמיכה טכנית change omer
                                tech.Show();
                                break;
                            case 2:
                                close = false;
                                this.Close();
                                formAdmin admin = new formAdmin(account, parent); // תפריט  מנהל
                                admin.Show();
                                break;
                            default:
                                MessageBox.Show("Error - account permission unknown"); // מקרה קצה חריג שבו לא הוגדרה הרשאה למשתמש
                                close = false;
                                this.Close();
                                break;
                        }
                    }
                }
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Return)
            {
                login();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Return)
            {
                login();
            }
        }
    }
}
