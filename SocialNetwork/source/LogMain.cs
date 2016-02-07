//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SocialNetwork
//{
//    sealed class LogMain
//    {
//        public enum permissionLevels { User = 0, TechSupport = 1, Admin = 2 }; // מערך למידת הרשאה
//        // לתקן למשהו קיים רק במיין, לא סטאטי ולהשתמש ב - "רף-" וזהו

//        public static void StartUp()
//        {
//            // בסיס נתונים
//            Database database = Database.getDatabase(); // בסיס נתונים
//            Memento backup = null; // ליצירת תמונת מערכת
//            Caretaker backupManager = new Caretaker(); // מנהל גיבוי

//            database.Accounts.Add(new Admin
//                (
//                    "Aviram",
//                    "Aviram",
//                    "Sharabi",
//                    "1234"
//                ));

//            database.Accounts.Add(new TechSupport
//            (
//                "Amar",
//                "Omer",
//                "Regev",
//                "1234"

//            ));
//            database.Accounts.Add(new User
//            (
//                "Noah",
//                "Sharabi",
//                "1234",
//                "Noah.S",
//                "Married with 30 Children",
//                "12/08/2014",
//                "Kefar Sava",
//                "Need more babies!",
//                "I Do Not Know Why"
//            ));

//            database.Accounts.Add(new User
//            (
//                "Asaf",
//                "Yeshayahu",
//                "1234",
//                "Asaf.Y",
//                "Married with 400 Children",
//                "01/01/1999",
//                "Head and Shoulders",
//                "It's all bullshit",
//                "Good evening!"
//            ));

//            database.Accounts.Add(new User
//            (
//                "Nehora",
//                "Messika",
//                "1234",
//                "Nessika",
//                "Married with 365 Children",
//                "12/12/2000",
//                "Somewhere over the rainbow",
//                "Ask",
//                "Let me sleep!"
//            ));

//            //Console.WriteLine();
//            // כניסה לתפריט התחברות
//            //LogMain.loginMenu(ref backup, ref backupManager);
//        }




//        private static void loginMenu(ref Memento backup, ref Caretaker backupManager)
//        {
//            String username = null;
//            String password = null;
//            int index = 0;
//            bool valid = false; // לבדיקת שם משתמש תקין
//            bool exit = false;  // משמש כסמן, להאם כדאי לצאת מן המערכת או להתנתק מהמשתמש ולחזור לתפריט ההתחברות, בעצם חזרה לפה

//            do
//            {
//                int count = 0;
//                do
//                {
//                    start:; // תווית התחלה

//                    Console.WriteLine("Enter -1 if you wish to Exit\n");
//                    Console.WriteLine("Please enter a valid username and password:");
//                    Console.Write("Username: ");
//                    username = Console.ReadLine();

//                    if (username == "-1") // בדיקת קלט, האם המשתמש רוצה לצאת
//                    {
//                        string input;
//                        Console.WriteLine("Are you sure you want to quit?\n"
//                            + "Enter Y - Yes\n" + "Enter N - No");
//                        input = Console.ReadLine();

//                        if (input == "Y" || input == "y")
//                        {
//                            return;
//                        }

//                        else if (input == "N" || input == "n")
//                        {
//                            Console.Clear();
//                            goto start;
//                        }

//                        else
//                        {
//                            Console.Clear();
//                            Console.WriteLine("Incorrect input");
//                            goto start;
//                        }
//                    }

//                    Console.WriteLine();
//                    Console.Write("Password: ");
//                    password = Console.ReadLine();

//                    if (password == "-1") // בדיקת קלט, האם המשתמש רוצה לצאת
//                    {
//                        string input;
//                        Console.WriteLine("Are you sure you want to quit?\n"
//                            + "Enter Y - Yes\n" + "Enter N - No");
//                        input = Console.ReadLine();

//                        if (input == "Y" || input == "y")
//                        {
//                            return;
//                        }

//                        else if (input == "N" || input == "n")
//                        {
//                            Console.Clear();
//                            goto start;
//                        }

//                        else
//                        {
//                            Console.Clear();
//                            Console.WriteLine("Incorrect input");
//                            goto start;
//                        }
//                    }

//                    valid = database.Accounts.Exists(account => account.Username == username && account.Password == password); // מחפש אם קיים

//                    if (valid == false)
//                    {
//                        if (++count == 3) // למקרה שמישהו ניסה להתחבר יותר 3 פעמים ללא הצלחה
//                        {
//                            Console.Clear();
//                            Console.WriteLine("Too many attempts!!\n\n");
//                            return;
//                        }

//                        Console.WriteLine("No such user... press any key to continue");
//                        Console.ReadKey();
//                    }
//                } while (valid == false);

//                index = database.Accounts.FindIndex(account => account.Username == username && account.Password == password); // מוציא אינדקס המשתמש

//                if (database.Accounts[index].Disabled == true) // תפריט למשתמש מושבת
//                    exit = disabledMenu(index);


//                else // צומת תפריטים
//                {
//                    Console.Clear(); //ניקוי מסך

//                    switch (database.Accounts[index].Permission) //סוויצ' לפי הרשאה לפי האינדקס של אותו משתמש שנמצא קודם לכן
//                    // כדאי לעשות את ההרשאה כ - ENUM
//                    {
//                        case 0:
//                            exit = userMenu(index); // תפריט למשתמש רגיל
//                            break;
//                        case 1:
//                            exit = techSupportMenu(index); // תפריט למשתמש תמיכה טכנית
//                            break;
//                        case 2:
//                            exit = adminMenu(index, ref backup, ref backupManager); // תפריט  מנהל
//                            break;
//                        default:
//                            Console.WriteLine("Error - account permission unknown"); // מקרה קצה חריג שבו לא הוגדרה הרשאה למשתמש
//                            break;
//                    }
//                }

//            } while (exit == false); // כל עוד המשתמש לא ביקש לצאת מן המערכת, התוכנית תעשה לולאה נוספת

//            Console.Clear();
//            Console.WriteLine("GoodBye!"); // הודעת יציאה מהמערכת
//        }


//        private static bool userMenu(int i) // תפריט המשתמש
//        {
//            String choice;
//            User user = (User)database.Accounts[i];
//            user.yourColors(); // צבעים של המשתמש
//            do
//            {

//                Console.WriteLine("Hello " + user.Fname + " " + user.Lname + ":");
//                Console.Write(
//                                "1) Search For A User \n" +
//                                "2) Read another's details\n" +
//                                "3) Playlist\n" +
//                                "4) Update Your Status\n" +
//                                "5) Update Your Marital Status\n" +
//                                "6) Send Ticket to Tech Support\n" +
//                                "7) Enter Your Inbox\n" +
//                                "8) Print Your Account Details\n" +
//                                "9) Change Your Account Details\n" +
//                                "10) Post something\n" +
//                                "11) Customize Your Window Colors\n" +
//                                "12) Logout\n" +
//                                "0) Delete your Account\n" +
//                                "\nChoice: ");

//                choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1":
//                        Console.Clear();
//                        user.searchUser(); // חיפוש משתמש
//                        break;
//                    case "2":
//                        Console.Clear();
//                        user.getUserDetails();   // הדפס נתונים של משתמש אחר
//                        break;
//                    case "3":
//                        Console.Clear();
//                        user.Playlist();   // פלייליסט
//                        break;
//                    case "4":
//                        Console.Clear();
//                        Console.WriteLine("Enter your new status:");// עדכון סטאטוס
//                        String status;
//                        status = Console.ReadLine();
//                        user.Status = status;
//                        break;
//                    case "5":
//                        Console.Clear();
//                        /* user.maritalStatusUpdate(); */ // עדכון מצב משפחתי
//                        break;
//                    case "6":
//                        Console.Clear();
//                        user.sendTicket(); // שליחת פנייה למשתמש
//                        break;
//                    case "7":
//                        Console.Clear();
//                        user.Inbox(); // תיבת הודעות
//                        break;
//                    case "8":
//                        Console.Clear();
//                        Console.WriteLine(user.ToString()); // ברור מאליו
//                        break;
//                    case "9":
//                        Console.Clear();
//                        user.changeDetails(); // שינוי פרטי משתמש
//                        break;
//                    case "10":
//                        Console.Clear();
//                        user.posts.Mainmenu(database.Accounts.FindIndex(temp => temp.Username == user.Username)); // תפריט פוסטים
//                        break; // יצירת פוסט
//                    case "11":
//                        Console.Clear();
//                        user.changeColors();
//                        break;
//                    case "12": // יציאה לתפריט ההתחברות
//                        Console.Clear();
//                        return false; // למי שלא מבין, נא לעבור על תפריט ההתחברות לעיל
//                        break;
//                    case "0":
//                        Console.Clear();
//                        user.removeOwnAccount(); // מחיקה עצמית של המשתמש
//                        return false;
//                        break;

//                    default:
//                        Console.WriteLine("Wrong Choice");
//                        break;
//                }
//                Console.WriteLine("Press any key to continue");
//                Console.ReadKey(); // הקפאת מסך לפני ניקוי
//                Console.Clear(); //ניקוי מסך
//            } while (true); // זוהי לולאה אין סופית
//        }
//        private static bool disabledMenu(int i) // תפריט משתמש מושבת
//        {
//            String choice;
//            User user = (User)database.Accounts[i];

//            do
//            {
//                Console.Clear(); //ניקוי מסך

//                Console.WriteLine("Hello " + database.Accounts[i].Fname + " " + database.Accounts[i].Lname + ":");
//                Console.WriteLine("\nYour account is disabled, so you have limited options...");
//                Console.Write(
//                                "1) Send Ticket\n" +
//                                "2) Print Your Details\n" +
//                                "3) Enter Your Inbox\n" +
//                                "4) Logout\n" +
//                                "\nChoice: ");
//                choice = Console.ReadLine();
//                switch (choice)
//                {
//                    case "1":
//                        Console.Clear();
//                        user.sendTicket(); // שליחת פנייה
//                        break;
//                    case "2":
//                        Console.Clear();
//                        Console.WriteLine(database.Accounts[i].ToString());
//                        break;
//                    case "3":
//                        Console.Clear();
//                        database.Accounts[i].Inbox(); // תיבת הודעות
//                        break;
//                    case "4":
//                        Console.Clear();
//                        return false;
//                        break;
//                    default:
//                        Console.WriteLine("Wrong Choice");
//                        break;
//                }
//                Console.WriteLine("Press any key to continue");
//                Console.ReadKey(); // הקפאת מסך לפני ניקוי
//                Console.Clear(); //ניקוי מסך
//            } while (true);
//        }



//        private static bool adminMenu(int i, ref Memento backup, ref Caretaker backupManager) // תפריט מנהל
//        {
//            String choice;
//            Admin admin = (Admin)database.Accounts[i];
//            Database database = Database.getDatabase(); // גישה למסד הנתונים
//            admin.yourColors(); // צבעים של המנהל
//            do
//            {

//                Console.Clear(); //ניקוי מסך
//                Console.WriteLine("Hello " + admin.Fname + " " + admin.Lname + ":");
//                Console.WriteLine("\nWhat would you like to do today?");
//                Console.Write(
//                                "1) Add User\n" +
//                                "2) Add Support Technician\n" +
//                                "3) Add Admin\n" +
//                                "4) Delete Account\n" +
//                                "5) Disable Account\n" +
//                                "6) Print Your Account Details\n" +
//                                "7) Change Your Account Details\n" +
//                                "8) Enter Your Inbox\n" +
//                                "9) Print All Accounts\n" +
//                                "10) Customize Your Window Colors\n" +
//                                "11) Backup this system(accounts and tickets)\n" +
//                                "12) Restore system from a backup(accounts and tickets)\n" +
//                                "13) Logout\n" +
//                                "\nChoice: ");

//                choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1":
//                        Console.Clear();
//                        admin.AddUser(); // הוספת משתמש
//                        break;
//                    case "2":
//                        Console.Clear();
//                        admin.AddTechs(); // הוספת תמיכה טכנית
//                        break;
//                    case "3":
//                        Console.Clear();
//                        admin.AddAdmin(); // הוספת מנהל
//                        break;
//                    case "4":
//                        Console.Clear();
//                        admin.DeleteAccount(); // מחיקת משתמש
//                        break;
//                    case "5":
//                        Console.Clear();
//                        admin.disableAccount(); // השבתת משתמש
//                        break;
//                    case "6":
//                        Console.Clear();
//                        Console.WriteLine(admin.ToString());
//                        break;
//                    case "7":
//                        Console.Clear();
//                        admin.changeDetails();
//                        break;
//                    case "8":
//                        Console.Clear();
//                        admin.Inbox(); // תיבת הודעות
//                        break;
//                    case "9":
//                        Console.Clear();
//                        foreach (Account acc in database.Accounts) { Console.WriteLine(acc.ToString()); } // הדפסת כל המשתמשים בתכנית
//                        break;
//                    case "10":
//                        Console.Clear();
//                        admin.changeColors(); // התאמה אישית של צבעי החלון
//                        break;
//                    case "11":
//                        Console.Clear();
//                        backupManager.Momento = database.createMemento();
//                        break;
//                    case "12":
//                        Console.Clear();
//                        database.setMemento(backupManager.Momento);
//                        break;
//                    case "13":
//                        Console.Clear();
//                        return false;
//                        break;
//                    default:
//                        Console.WriteLine("Wrong Choice");
//                        break;
//                }
//                Console.WriteLine("Press any key to continue");
//                Console.ReadKey(); // הקפאת מסך לפני ניקוי
//                Console.Clear(); //ניקוי מסך
//            } while (true);
//        }



//        private static bool techSupportMenu(int i) // תפריט תמיכה טכנית
//        {
//            String choice;
//            TechSupport techSupport = (TechSupport)database.Accounts[i];

//            do
//            {
//                Console.Clear(); //ניקוי מסך

//                Console.WriteLine("Hello " + techSupport.Fname + " " + techSupport.Lname + ":");
//                Console.WriteLine("\nWhat would you like to do today?");
//                Console.Write(
//                                "1) Access Account's Details\n" +
//                                "2) Reset Account's password\n" +
//                                "3) Re-Enable Account\n" +
//                                "4) Disable Account\n" +
//                                "5) Tickets Menu\n" +
//                                "6) Print Your Details\n" +
//                                "7) Change Your Details\n" +
//                                "8) Enter Your Inbox\n" +
//                                "9) Logout\n" +
//                                "\nChoice: ");

//                choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1":
//                        Console.Clear();
//                        techSupport.accessUserDetails(); // גישה ושינוי פרטי משתמש
//                        break;
//                    case "2":
//                        Console.Clear();
//                        techSupport.resetPassword(); // איפוס סיסמא למשתמש
//                        break;
//                    case "3":
//                        Console.Clear();
//                        techSupport.reEnableAccount(); // הפעלת משתמש מחדש (לאחר השבתה) שיוכל לחזור לעצמו
//                        break;
//                    case "4":
//                        Console.Clear();
//                        techSupport.disableAccount(); // השבתת משתמש
//                        break;
//                    case "5":
//                        Console.Clear();
//                        techSupport.ticketMenu(); // תפריט של פניות
//                        break;
//                    case "6":
//                        Console.Clear();
//                        Console.WriteLine(techSupport.ToString());
//                        break;
//                    case "7":
//                        Console.Clear();
//                        techSupport.changeDetails();
//                        break;
//                    case "8":
//                        Console.Clear();
//                        techSupport.Inbox(); // תיבת הודעות
//                        break;
//                    case "9":
//                        Console.Clear();
//                        return false;
//                        break;
//                    default:
//                        Console.WriteLine("Wrong Choice");
//                        break;
//                }
//                Console.WriteLine("Press any key to continue");
//                Console.ReadKey(); // הקפאת מסך לפני ניקוי
//                Console.Clear(); //ניקוי מסך
//            } while (true);
//        }
//    }
//}
