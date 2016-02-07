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

        public formLogin(Home parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int count = 0;
            String username = txtUsername.Text;
            String password = txtPassword.Text;

            // בדיקה שהמשתמש שהוקלד אכן קיים במסד הנתונים
            int index = database.Accounts.FindIndex(x => x.Username.Equals(username) && x.Password.Equals(password));
            
           // לא קיים המשתמש
            if (index < 0)
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
                // אם המשתמש מושבת
                if (database.Accounts[index].Disabled == true)
                {
                    //this.closeSwitch(false);
                    //formDisabled disabled = new formDisabled(index, parent);
                }

                switch (database.Accounts[index].Permission) //סוויצ' לפי הרשאה לפי האינדקס של אותו משתמש שנמצא קודם לכן
                {
                    case 0:
                        close = false;
                        this.Close();
                        formUser user = new formUser(index, parent); // תפריט למשתמש רגיל
                        user.Show();
                        break;
                    case 1:
                        close = false;
                        this.Close();
                        formTechSupport tech = new formTechSupport(index, parent); // תפריט למשתמש תמיכה טכנית
                        tech.Show();
                        break;
                    case 2:
                        close = false;
                        this.Close();
                        formAdmin admin = new formAdmin(index, parent); // תפריט  מנהל
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
    }
}
