using SocialNetwork.source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SocialNetwork
{
    public sealed class User : Account, ICustomizeForm
    {
        private Database database = Database.getDatabase(); // מסד נתונים
        private String maritalStatus; // סטאטוס משפחתי
        private int age = -1; // גיל
        private DateTime dob; // תאריך לידה
        private String city; // עיר מגורים
        private String status; // סטאטוס כללי של החשבון
        private String info; // מידע כללי
        private Color text;// צבע טקסט
        private Color bg ; // צבע רקע

        // בנאי מלא כולל שדות האב
        public User(String username, String fname, String lname, String password,
                    String maritalStatus, String dob, String city, String info, String status)
                    : base(username, fname, lname, password, (int)Program.permissionLevels.User) // שדות אב שיורשים
        {
            MaritalStatus = maritalStatus;
            Dob = dob;
            City = city;
            Info = info;
            Status = status;
        }


        // מתודות כלליות
        // get, set, הדפסת פרטים

        public String MaritalStatus //סטאטוס משפחתי 
        {
            get { return this.maritalStatus; }
            set { this.maritalStatus = value; }
        }

        public int Age // גיל
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public String Dob // תאריך לידה
        {
            get { return this.dob.ToString("dd/MM/yyyy"); } // מחזיר תאריך בפורמט
            set
            {
                String[] values = value.Split('/'); // פיצול המחרוזת והמרתם למספרים
                int day = Int32.Parse(values[0]);
                int month = Int32.Parse(values[1]);
                int year = Int32.Parse(values[2]);

                DateTime temp = DateTime.Now; // תאריך עזר, לבדיקת מקרי קצה
                this.dob = new DateTime(year, month, day);
                this.Age = temp.Year - this.dob.Year; // הגיל הוא, השנה של עכשיו פחות השנה שהוקלדה 
            }
        }

        public String City // עיר מגורים
        {
            get { return this.city; }
            set { this.city = value; }
        }

        public String Status // סטאטוס
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public String Info // מידע כללי
        {
            get { return this.info; }
            set { this.info = value; }
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

        public override string ToString() // הדפסת פרטים
        {
            return base.ToString() + // הדפסה של המתודה של האב
                    "Marital Status: " + MaritalStatus + "\r\n" +
                    "Age: " + Age + "\r\n" +
                    "Date Of Birth: " + Dob + "\r\n" +
                    "City: " + City + "\r\n" +
                    "Info: " + Info + "\r\n" +
                    "Status: " + Status + "\r\n";    
        }

        public void changeDetails(String fname, String lname, String password, String maritalStatus, String dob,
            String city, String info, String status)  // שינוי פרטים
        {
            base.changeDetails(fname, lname, password);
            MaritalStatus = maritalStatus;
            Dob = dob;
            City = city;
            Info = info;
            Status = status;
        }

        public String checkDob(String str)
        {
            if (Regex.IsMatch(str, @"^(\d{2})/(\d{2})/(\d{4})$") == false) // לא מתאים לפורמט
            {
                return ("Incorrect date format");
                
            }

            String[] values = str.Split('/'); // פיצול המחרוזת והמרתם למספרים
            int day = Int32.Parse(values[0]);
            int month = Int32.Parse(values[1]);
            int year = Int32.Parse(values[2]);

            DateTime temp = DateTime.Now; // תאריך עזר, לבדיקת מקרי קצה

            if (year > temp.Year || year < (temp.Year - 120)) // אם השנה היא מעל השנה הנוכחית או שהאדם מעל גיל 120
            {
                return ("Invalid, Valid year range is: " + (temp.Year - 120) + " - " + temp.Year);
                
            }

            if (month > 12 || month < 1) // חודש חוקי
            {
                return ("Invalid, Month range is between 01-12");
               
            }

            if (day < 1 || day > DateTime.DaysInMonth(year, month)) // יום חוקי לאותה שנה וחודש
            {
                return ("Invalid, Valid day range in " + month + "\\" + year + "is: 1 - " + DateTime.DaysInMonth(year, month));
               
            }

            return null;
        }

        public String checkCity(String str)
        {
            String check = StringChecks.isVarChar(str);
            return check;
        }

        public String checkInfo(String str)
        {
            String check = StringChecks.isVarChar(str);
            return check;
        }

        public String checkText(Color textColor)
        {
            if(textColor == this.bg)
            {
                return "Background and Text Colors must differ";
            }
            return null;
        }

        public String checkBG(Color bgColor)
        {
            if (bgColor == this.text)
            {
                return "Background and Text Colors must differ";
            }
            return null;
        }

        public String checkTicket(String str)
        {
            String check = StringChecks.isVarChar(str);
            return check;
        }


        //מתודות ייחודיות

        //מתודת חיפוש אנשים
        public String[] searchUser(String search)
        {
            String str = "";

            foreach(Account i in database.Accounts)
            {
                if (i.Username.Contains(search))
                {
                    str += i.Username + ",";
                }
            }

            return str.Split(',');
        }

        public String getUserDetails(String username)
        {
            int index = database.Accounts.FindIndex(temp => temp.Username.Equals(username)); // מציאת מיקום המשתמש ברשימה

            if (index >= 0 && database.Accounts[index].Permission.Equals(0)) // בדיקה האם הוא בכלל נמצא ואם כן האם הוא משתמש רגיל
            {
                return database.Accounts[index].ToString();
            }

            return "Failed";
        }

        public String removeOwnAccount() // מתודת מחיקת חשבון אישי
        {
            database.deleteAccount(this.Username);
            return "Your account was deleted";
        }

        //public void Playlist() // פלייליסט 
        //{
        //    Playlist play = new Playlist();
        //    play.Playasong();
        //}

        //public void maritalStatusUpdate() // תפריט עדכון מצב משפחתי
        //{
        //    String choice;

        //    Console.Clear(); //ניקוי מסך

        //    Console.WriteLine("What is your current status?");
        //    Console.Write(
        //                  "1) Single\n" +
        //                  "2) Married\n" +
        //                  "Choice: ");
        //    choice = Console.ReadLine();

        //    switch (choice)
        //    {
        //        case "1":
        //            this.maritalStatus = "Single";
        //            return;
        //            break;

        //        case "2":
        //            Console.Write("How many children?\nChildren: ");
        //            String numChildren = Console.ReadLine();
        //            if (numChildren.All(Char.IsDigit) == false || Int32.Parse(numChildren) < 0) // האם יש ספרות, או שהקלט קטן מאפס
        //            {
        //                Console.WriteLine("Input must be equal or above '0' and must contain only digits");
        //                this.maritalStatus = null;
        //                return;
        //            }
        //            //תנאי מקוצר, מה להציג אם יש או אין ילדים
        //            this.maritalStatus = (Int32.Parse(numChildren) > 0) ? "Married with " + numChildren + " children" : "Married";
        //            break;

        //        default: Console.WriteLine("Wrong input...\n");
        //            break;
        //    }
        //}

        public String sendTicket(String message) // שליחת פנייה
        {
            Ticket ticket = new Ticket(this.Username, message);
            database.AddTicket(ticket);
            return "Ticket was sent";
        }

        public void changeColors(Color text, Color bg) // שינוי צבעים
        {
            this.text = text;
            this.bg = bg;
        }

        public Color[] yourColors() // קביעת צבעים בכל התחברות
        {
            Color[] colors = new Color [] { this.text, this.bg };
            return colors;
        }

        //public override bool detailsCheckNull() // בדיקת תקינות
        //{
        //    if (this.Fname == null || this.Lname == null || this.Password == null || this.Username == null ||
        //        this.MaritalStatus == null || this.Age == 0 || this.Dob.ToString() == "01/01/0001" || this.City == null)
        //    {
        //        return true;
        //    }

        //    else
        //        return false;
        //}
    }
}
