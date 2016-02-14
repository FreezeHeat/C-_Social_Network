using SocialNetwork.source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

// Nehora

namespace SocialNetwork
{
    public sealed class Admin : Account, IDisableAcc, ICustomizeForm
    {
        private Database database = Database.getDatabase();
        private Color text;// צבע טקסט
        private Color bg; // צבע רקע
        
        //בנאי מלא כולל שדות האב 
        public Admin(String username, String fname, String lname, String password)
            : base(username, fname, lname, password, (int)Program.permissionLevels.Admin)
        {
            int[] colors = database.getColors(Username);
            if (colors != null)
            {
                BG = Color.FromArgb(colors[0]);
                Text = Color.FromArgb(colors[1]);
            }
        }

        public Admin(String username, String fname, String lname, String password, bool disabled)
            : base(username, fname, lname, password, (int)Program.permissionLevels.Admin, disabled)
        {
            int[] colors = database.getColors(Username);
            if (colors != null)
            {
                BG = Color.FromArgb(colors[0]);
                Text = Color.FromArgb(colors[1]);
            }
        }

        public Color BG
        {
            get { return this.bg; }
            set { this.bg = value; }
        }

        public Color Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        // מתודות כלליות
        public override string ToString()
        {
            return base.ToString() + "\n";
        }

        //public override String changeDetails(String fname, String lname, String password) // שינוי פרטים
        //{
        //    base.changeDetails(fname, lname, password);
        //    return "Details were changed";
        //}

        // מתודות ייחודיות

        // הוספת חשבון
        public String AddUser(String username, String fname, String lname, String password, String maritalStatus,
            String dob, String city, String info, String status)
        {
            User user = new User(username, fname, lname, password, maritalStatus, dob, city, info, status);
            database.addUser(user);

            return "User was created";
        }
        
        // מחיקת חשבון 
        public String DeleteAccount(String username)
        {
            database.deleteAccount(username);
            return username + " account was deleted";
        }

        //השבתת חשבון 
        public void disableAccount(String username)
        {
            database.disableAccount(username);
        }

        public String reEnableAccount(String username) // חידוש חשבון מושבת
        {
            database.reEnableAccount(username);
            return username + " account is re-enabled";
        }

        //הוספת חשבון מנהל 
        public String AddAdmin(String username , String firstname , String lastname ,String password )
        {
            Admin admin = new Admin(username, firstname, lastname, password);
            database.addAdmin(admin);
            return "Admin was created";
        }


        //הוספת חשבון נציג טכני
        public String AddTechs(String username, String firstname, String lastname, String password)
        {
            TechSupport tech = new TechSupport(username, firstname, lastname, password);
            database.addTech(tech);
            return "Admin was created";
        }

        public void changeColors(Color text, Color bg) // שינוי צבעים
        {
            this.text = text;
            this.bg = bg;
            database.changeColors(this.Username, bg.ToArgb(), text.ToArgb());
        }

        public Color[] yourColors() // קביעת צבעים בכל התחברות
        {
            Color[] colors = new Color[] { this.text, this.bg };
            return colors;
        }
    }
}