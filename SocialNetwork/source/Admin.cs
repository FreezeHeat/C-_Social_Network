using SocialNetwork.source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;



namespace SocialNetwork
{
    public sealed class Admin : Account, IDisableAcc, ICustomizeForm
    {
        private Database database = Database.getDatabase();
        private Color text;
        private Color bg; 
        
        
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

        
        public override string ToString()
        {
            return base.ToString() + "\n";
        }

        public String AddUser(String username, String fname, String lname, String password, String maritalStatus,
            String dob, String city, String info, String status)
        {
            User user = new User(username, fname, lname, password, maritalStatus, dob, city, info, status);
            database.addUser(user);

            return "User was created";
        }
        
        
        public String DeleteAccount(String username)
        {
            database.deleteAccount(username);
            return username + " account was deleted";
        }

        
        public void disableAccount(String username)
        {
            database.disableAccount(username);
        }

        public String reEnableAccount(String username) 
        {
            database.reEnableAccount(username);
            return username + " account is re-enabled";
        }

        
        public String AddAdmin(String username , String firstname , String lastname ,String password )
        {
            Admin admin = new Admin(username, firstname, lastname, password);
            database.addAdmin(admin);
            return "Admin was created";
        }


        
        public String AddTechs(String username, String firstname, String lastname, String password)
        {
            TechSupport tech = new TechSupport(username, firstname, lastname, password);
            database.addTech(tech);
            return "Admin was created";
        }

        public void changeColors(Color text, Color bg) 
        {
            this.text = text;
            this.bg = bg;
            database.changeColors(this.Username, bg.ToArgb(), text.ToArgb());
        }  
    }
}