using SocialNetwork.source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SocialNetwork
{
    public abstract class Account 
    {
        private Database database = Database.getDatabase();
        private String fname; 
        private String lname; 
        private String username;
        private String password; 
        private int permission;
        private bool disabled = false;

        public Account(String username, String fname, String lname, String password, int permission)
        {
            Username = username;
            Fname = fname;
            Lname = lname;
            Password = password;
            Permission = permission;
            Disabled = false;
        }

        public Account(String username, String fname, String lname, String password, int permission, bool disabled)
        {
            Username = username;
            Fname = fname;
            Lname = lname;
            Password = password;
            Permission = permission;
            Disabled = disabled;
        }       

        public String Fname
        {
            get { return this.fname; }
            set { this.fname = value; }
        }

        public String Lname
        {
            get { return this.lname; }
            set { this.lname = value; }
        }

        public String Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public String Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public int Permission
        {
            get { return this.permission; }
            set { this.permission = value; }
        }

        public bool Disabled
        {
            get { return this.disabled; }
            set { this.disabled = value; }
        }

        
        
        
        
        

        public override string ToString()
        {
            return "Username: " + Username + "\n" +
                    "First Name: " + Fname + "\n" +
                    "Last Name: " + Lname + "\n" +
                    "Permission: " + Permission + "\n";
        }

        

        public virtual String changeDetails(String fname, String lname, String password ) 
        {
            
            Fname = StringChecks.doubleApostrophy(fname);
            Lname = StringChecks.doubleApostrophy(lname);
            Password = StringChecks.doubleApostrophy(password);
            List<String> list = new List<String>() { Username, fname, lname, password };

            
            
            database.changeDetails(list);

            return "Details were changed";
        }

        public String checkUsername(String str)
        {
            String check = StringChecks.anyWhiteSpace(str);
            return check;
        }

        public String checkFname(String str)
        {
            String check = StringChecks.anyWhiteSpace(str);
            return check;
        }

        public String checkLname(String str)
        {
            String check = StringChecks.anyWhiteSpace(str);
            return check;
        }

        public String checkPassword(String str)
        {
            String check = StringChecks.anyWhiteSpace(str);
            return check;
        }

        public String checkRecipient(String str)
        {
            String check = StringChecks.anyWhiteSpace(str);
            return check;
        }

        public String checkMessage(String str)
        {
            String check = StringChecks.isLettersAndWhiteSpace(str);
            return check;
        }

        public String sendMessage(String recipient, String message)
        {
            

            if(database.checkIfUserExists(StringChecks.doubleApostrophy(recipient)) == false)
            {
                return "No such account";
            }

            String str = StringChecks.doubleApostrophy(message);
            Message msg = new Message(this.Username, str);
            database.AddMessage(msg, recipient);
            return "Success";
        }

        public String deleteMessage(int index)
        {
            database.DeleteMessage(index);
            return "Message deleted";
        }
    }
}
