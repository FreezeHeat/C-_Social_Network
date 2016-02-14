using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork
{
    public sealed class TechSupport : Account, IDisableAcc//שיניתי לציבורי עמר 
    {
        private Database database = Database.getDatabase();
        private long workerID; // מספר עובד
        private List<Ticket> tickets;

        // בנאים

        //public TechSupport() { }

        public TechSupport(String username, String fname, String lname, String password)
            : base(username, fname, lname, password, (int)Program.permissionLevels.TechSupport)
        {
        }

        public TechSupport(String username, String fname, String lname, String password, bool disabled)
            : base(username, fname, lname, password, (int)Program.permissionLevels.TechSupport, disabled)
        {
        }

        // מתודות כלליות

        public long WorkerID
        {
            get { return this.workerID; }
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


        public String checkAccess(String username)//check it out
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

        public String getUserDetails(String username)//check it out
        {
            String check = checkAccess(username);
            if (check != null) { return check; }

            User user = (User)database.Accounts.Find(account => account.Username == username);
            return user.ToString();
        }

        public void changeUserDetails(List<String> array)//omer
        {
            database.changeUserDetails(array);
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
        //neora
        public void disableAccount(String username) // השבתת חשבון
        {
            if (database.checkIfUserExists(username))
            {
                database.disableAccount(username);
            }

            //int i = database.Accounts.FindIndex(account => account.Username == username);
            //database.disableAccount(i);


        }
        //neora
        public void reEnableAccount(String username) // חידוש חשבון מושבת
        {

            // int i = database.Accounts.FindIndex(account => account.Username == username);
            //database.reEnableAccount(i);
            if (database.checkIfUserExists(username))
            {
                database.reEnableAccount(username);
            }
        }

        public void resetPassword(String username) // איפוס סיסמא למשתמש//עמר
        {
            if (database.checkIfUserExists(username))
            {
                database.resetPassword(username);
            }
        }

        //omer 13.2
        public void handleTicket(String representative, Ticket ticket)
        {
            database.handleTicket(representative, ticket);

        }
        public void finishTicket(String representative, Ticket ticket)
        {
            database.finishTicket(representative, ticket);

        }
    }

}