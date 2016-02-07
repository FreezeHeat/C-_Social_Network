using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork
{
    sealed class TechSupport : Account, IDisableAcc
    {
        private Database database = Database.getDatabase();
        private long workerID; // מספר עובד

        // בנאים

        //public TechSupport() { }

        public TechSupport(String username, String fname, String lname, String password)
            : base(username, fname, lname, password, (int)Program.permissionLevels.TechSupport)
		{
		}
		
		// מתודות כלליות
		
		public long WorkerID
		{
			get{ return this.workerID;}
		}
		
		public override string ToString()
		{
            return base.ToString() +
            "Worker ID: " + WorkerID + "\n";
		}

        //public void changeDetails(String fname, String lname, String password) // נא לשים לב, עובד לא יכול לשנות את המספר המזהה שלו
        //{
        //    base.changeDetails(fname, lname, password);
        //}

        // מתודות ייחודיות

        //public void ticketMenu() // שליחה לתפריט מתאים
        //{
        //    database.TicketBox.TicketMenu(this);
        //}
        

        public String checkAccess(String username)
        {
            int i = -1;
            i = database.Accounts.FindIndex(account => account.Username == username);

            if (i != -1)
            {
                if (database.Accounts[i].Permission == 0)
                {
                    return null;
                }
            }
            return "Cannot access this user";
        }

        public String getUserDetails(String username)
        {
            String check = checkAccess(username);
            if(check != null) { return check; }

            User user = (User)database.Accounts.Find(account => account.Username == username);
            return user.ToString();
        }

        public String changeUserDetails(String username, String fname, String lname, String password, String maritalStatus, String dob, 
            String city, String info, String status)
        {
            String check = checkAccess(username);
            if (check != null) { return check; }

            User user = (User)database.Accounts.Find(account => account.Username == username);
            user.changeDetails(fname, lname, password, maritalStatus, dob, city, info, status);
            return "Succesful";
        }

        //public String accessUserDetails(String username) // גישה לפרטי חשבון
        //{
            //int i = -1;
            //String choice; // בחירה של מה לעשות כאשר ניגש למשתמש
            //String username;

            //Console.Clear(); //ניקוי מסך

            //Console.WriteLine("Please enter the username you wish to change");
            //username = Console.ReadLine();

            //i = database.Accounts.FindIndex(account => account.Username == username);
            //if (i == -1) 
            //{ 
            //    return ("No such user");
            //}

            //if (database.Accounts[i].Permission == 0)  // שניגש רק למשתמש
            //{
            //    do
            //    {
            //        Console.Write(
            //                      "What do you wish to do?\n" +
            //                      "1) Print User's details\n" +
            //                      "2) Change User's details\n" +
            //                      "3) Exit this menu\n");

            //        choice = Console.ReadLine();

            //        switch (choice) // יכולות התפריט
            //        {
            //            case "1":
            //                Console.WriteLine(database.Accounts[i].ToString());
            //                break;
            //            case "2":
            //                database.Accounts[i].changeDetails(); // ניגש למתודת משתמש לשינוי פרטים
            //                break;
            //            case "3":
            //                return;
            //                break;
            //            default:
            //                Console.WriteLine("Wrong choice");
            //                break;
            //        }
                
            //    } while (true); // לולאה אין סופית, רק שלוחצים 3 יוצאים החוצה
            //}
            //else
            //{
            //    return ("You cannot access this account"); 
            //}
        //}
        
        public String disableAccount(String username) // השבתת חשבון
        {
            String check = checkAccess(username);
            if (check != null) { return check; }

            int i = database.Accounts.FindIndex(account => account.Username == username);
            database.disableAccount(i);
            return "Succesful";
        }

        public String reEnableAccount(String username) // חידוש חשבון מושבת
        {
            String check = checkAccess(username);
            if (check != null) { return check; }

            int i = database.Accounts.FindIndex(account => account.Username == username);
            database.reEnableAccount(i);
            return "Succesful";
        }

        public String resetPassword(String username) // איפוס סיסמא למשתמש
        {
            String check = checkAccess(username);
            if (check != null) { return check; }

            User user = (User)database.Accounts.Find(account => account.Username == username);
            user.Password = "0";
            return "Succesful";
        }
    }
	
}
