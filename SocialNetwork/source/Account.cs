using SocialNetwork.source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SocialNetwork
{
    abstract class Account // חשבון
    {
        private Database database = Database.getDatabase();
        private String fname; // שם פרטי
        private String lname; // שם משפחה
        private String username;// שם משתמש 
        private String password; // סיסמא
        private int permission; // מידת הרשאה
        private bool disabled = false; // אם מושבת או לא
        private List<Message> inbox = new List<Message>();  // תיבת הודעות

        //בנאים

        public Account(String username, String fname, String lname, String password, int permission)
        {
            Username = username;
            Fname = fname;
            Lname = lname;
            Password = password;
            Permission = permission;
        }


        // מתודות כלליות

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

        public List<Message> Inbox
        {
            get { return inbox; }
            set { this.inbox = value; }
        }

        public override string ToString()
        {
            return "Username: " + Username + "\n" +
                    "First Name: " + Fname + "\n" +
                    "Last Name: " + Lname + "\n" +
                    "Permission: " + Permission + "\n";
        }

        // שינוי פרטים

        public virtual String changeDetails(String fname, String lname, String password ) // למי שלא הבין וירטואל זה בשביל שיהיה ניתן להוריש ולדרוס את המתודה במחלקות שירשו
        {
            Fname = fname;
            Lname = lname;
            Password = password;
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
            int i = database.Accounts.FindIndex(x => x.Username.Equals(recipient));

            if(i < 0)
            {
                return "No such account";
            }

            Message msg = new Message(this.Username, recipient, message);
            database.Inboxes.Add(msg);
            return "Success";
        }

        public String deleteMessage(int index)
        { 
            database.Inboxes.RemoveAt(index);
            return "Message deleted";
        }

        //public virtual login(String username, String password)
        //{
        //    int i = database.Login(username, password);
        //    if(i >= 0) { return i; }
        //    return -1;
        //}


        // מתודות ייחודיות

        //public void Inbox(String choice)
        //{
            //Console.Clear(); //ניקוי מסך

            //Console.Write("What do you wish to do?\n" +
            //              "1) List Inbox\n" +
            //              "2) Send message\n" +
            //              "3) Delete message\n" +
            //              "4) Backup your inbox\n" +
            //              "5) Restore your inbox\n" +
            //              "6) Exit to Menu\n" +
            //              "\nChoice: ");

            //choice = Console.ReadLine();

        //    switch (choice)
        //    {
        //        case "1":
        //            Console.Clear();
        //            inbox.printList(); // מדפיס את כל ההודעות
        //            break;
        //        case "2":
        //            Console.Clear();
        //            inbox.sendMessage(this.Username); // שולח הודעה למשתמש מסויים
        //            break;
        //        case "3":
        //            Console.Clear();
        //            inbox.deleteMessage(); // מוחק הודעה מהתיבה
        //            break;
        //        case "4":
        //            Console.Clear();
        //            Console.WriteLine("Remember: You can only have one copy of a backup at a time");
        //            this.inbox.createBackup();
        //            break;
        //        case "5":
        //            Console.Clear();
        //            this.inbox.restoreBackup();
        //            break;
        //        case "6":
        //            return;
        //            break;
        //        default:
        //            Console.WriteLine("Wrong Choice");
        //            break;
        //    }
        //}

        //public virtual bool detailsCheckNull() // בדיקת תקינות
        //{
        //    if (this.Fname == null || this.Lname == null || this.Password == null || this.Username == null)
        //        return true;
        //    else
        //        return false;
        //}
    }
}
