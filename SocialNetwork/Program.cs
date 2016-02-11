using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialNetwork.source;

namespace SocialNetwork
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        

        public enum permissionLevels { User = 0, TechSupport = 1, Admin = 2 }; // מערך למידת הרשאה
        // לתקן למשהו קיים רק במיין, לא סטאטי ולהשתמש ב - "רף-" וזהו

        public static void StartUp()
        {
            // בסיס נתונים
           
        }

        // מאתחל ממשק גרפי
        [STAThread]
        static void Main()
        {
            Memento backup = null; // ליצירת תמונת מערכת
            Caretaker backupManager = new Caretaker(); // מנהל גיבוי
            Database database = Database.getDatabase(); // בסיס נתונים

            if (database.checkIfUserExists("Aviram") == false)
            {
                database.addAdmin(new Admin("Aviram", "Aviram", "Sharabi", "1234"));
            }
            //database.Accounts.Add(new Admin
            //    (
            //        "Aviram",
            //        "Aviram",
            //        "Sharabi",
            //        "1234"
            //    ));

            if (database.checkIfUserExists("Amar") == false)
            {
                database.addTech(new TechSupport("Amar", "Omer", "Regev", "1234"));
            }

            //database.Accounts.Add(new TechSupport
            //(
            //    "Amar",
            //    "Omer",
            //    "Regev",
            //    "1234"
            //));

            if (database.checkIfUserExists("Noah") == false)
            {
                database.addUser(new User("Noah", "Meir", "Sharabi", "1234", "Married with 30 children", "12/08/2014", "Kefar Saba", "Need more babies!", "I do not know Why"));
            }
            //database.Accounts.Add(new User
            //(
            //    "Noah",
            //    "Meir",
            //    "Sharabi",
            //    "1234",
            //    "Married with 30 Children",
            //    "12/08/2014",
            //    "Kefar Sava",
            //    "Need more babies!",
            //    "I Do Not Know Why"
            //));

            if (database.checkIfUserExists("Asaf") == false)
            {
                database.addUser(new User("Asaf", "Asaf", "Yeshayahu", "1234", "Married with 400 children", "01/01/1999", "Head and Shoulders", "It''s all bullshit", "Good evening!"));
            }
            //database.Accounts.Add(new User
            //(
            //    "Asaf",
            //    "Asaf",
            //    "Yeshayahu",
            //    "1234",
            //    "Married with 400 Children",
            //    "01/01/1999",
            //    "Head and Shoulders",
            //    "It's all bullshit",
            //    "Good evening!"
            //));

            if (database.checkIfUserExists("Nehora") == false)
            {
                database.addUser(new User("Nehora", "Nehora", "Messika", "1234", "Married with 365 Children", "12/12/2000", "Somewhere over the rainbow", "Ask", "Let me sleep!"));
            }
            //database.Accounts.Add(new User
            //(
            //    "Nehora",
            //    "Nehora",
            //    "Messika",
            //    "1234",
            //    "Married with 365 Children",
            //    "12/12/2000",
            //    "Somewhere over the rainbow",
            //    "Ask",
            //    "Let me sleep!"
            //));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
        }
    }
}
