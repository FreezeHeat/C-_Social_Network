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
        private Database database = Database.getDatabase(); 
        private String maritalStatus; 
        private int age = -1; 
        private DateTime dob; 
        private String city; 
        private String status; 
        private String info; 
        private Color text;
        private Color bg ; 

        
        public User(String username, String fname, String lname, String password,
                    String maritalStatus, String dob, String city, String info, String status)
                    : base(username, fname, lname, password, (int)Program.permissionLevels.User) 
        {
            MaritalStatus = maritalStatus;
            Dob = dob;
            City = city;
            Info = info;
            Status = status;

            int [] colors = database.getColors(Username);
            if (colors != null)
            {
                BG = Color.FromArgb(colors[0]);
                Text = Color.FromArgb(colors[1]);
            }
        }

        public User(String username, String fname, String lname, String password, bool disabled,
                    String maritalStatus, String dob, String city, String info, String status)
                    : base(username, fname, lname, password, (int)Program.permissionLevels.User, disabled) 
        {
            MaritalStatus = maritalStatus;
            Dob = dob;
            City = city;
            Info = info;
            Status = status;

            int[] colors = database.getColors(Username);
            if (colors != null)
            {
                BG = Color.FromArgb(colors[0]);
                Text = Color.FromArgb(colors[1]);
            }
        }


        
        

        public String MaritalStatus
        {
            get { return this.maritalStatus; }
            set { this.maritalStatus = value; }
        }

        public int Age 
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public String Dob 
        {
            get { return this.dob.ToString("dd/MM/yyyy"); } /* Return in this date format*/
            set
            {
                String[] values = value.Split('/'); /* Split and cast into numbers*/
                int day = Int32.Parse(values[0]);
                int month = Int32.Parse(values[1]);
                int year = Int32.Parse(values[2]);

                DateTime temp = DateTime.Now; /* Auxiliary date check (year)*/
                this.dob = new DateTime(year, month, day);
                this.Age = temp.Year - this.dob.Year; 
            }
        }

        public String City 
        {
            get { return this.city; }
            set { this.city = value; }
        }

        public String Status 
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public String Info 
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

        public override string ToString() 
        {
            return base.ToString() + 
                    "Marital Status: " + MaritalStatus + "\r\n" +
                    "Age: " + Age + "\r\n" +
                    "Date Of Birth: " + Dob + "\r\n" +
                    "City: " + City + "\r\n" +
                    "Info: " + Info + "\r\n" +
                    "Status: " + Status + "\r\n";    
        }

        public String changeDetails(String fname, String lname, String password, String maritalStatus, String dob,
            String city, String info, String status)  
        {
            base.changeDetails(fname, lname, password);
            MaritalStatus = maritalStatus;
            Dob = dob;
            City = city;
            Info = info;
            Status = status;
            List<String> list = new List<String>()
            {   StringChecks.doubleApostrophy(Username),
                StringChecks.doubleApostrophy(MaritalStatus),
                StringChecks.doubleApostrophy(Dob),
                StringChecks.doubleApostrophy(City),
                StringChecks.doubleApostrophy(Status),
                StringChecks.doubleApostrophy(Info) };
            database.changeUserDetails(list);

            return "Details were changed";
        }

        public String checkDob(String str)
        {
            if (Regex.IsMatch(str, @"^(\d{2})/(\d{2})/(\d{4})$") == false) //Regex to check DOB
            {
                return ("Incorrect date format");
                
            }

            String[] values = str.Split('/'); 
            int day = Int32.Parse(values[0]);
            int month = Int32.Parse(values[1]);
            int year = Int32.Parse(values[2]);

            DateTime temp = DateTime.Now; 

            if (year > temp.Year || year < (temp.Year - 120)) /* If year is over the current one and age is over 120 */
            {
                return ("Invalid, Valid year range is: " + (temp.Year - 120) + " - " + temp.Year);
                
            }

            if (month > 12 || month < 1) /* Legal month */
            {
                return ("Invalid, Month range is between 01-12");
               
            }

            if (day < 1 || day > DateTime.DaysInMonth(year, month)) /* Legal day and month */
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

        public String checkTicket(String str)
        {
            String check = StringChecks.isVarChar(str);
            return check;
        }

        public String checkPost(String str)
        {
            String check = StringChecks.isLettersAndWhiteSpace(str);
            return check;
        }


        // Special methods

        public String[] searchUser(String search)
        {
            String str = "";
            List<Account> accounts = database.getAllAccounts();

            foreach(Account i in accounts)
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
            /* If user exists and if he's a regular user*/
            if (database.checkIfUserExists(username) == true && database.checkPermission(username) == "0")
            {
                User user = database.getUser(username);
                return user.ToString();
            }
            return "No such user";
        }

        public String removeOwnAccount() 
        {
            database.deleteAccount(this.Username);
            return "Your account was deleted";
        }

        public String updateStatus(String status)
        {
            String str = StringChecks.doubleApostrophy(status);
            database.updateUserStatus(Username, str);
            return "Success";
        }
        public String addPost(Post post)
        {
            String str = StringChecks.doubleApostrophy(post.Content);
            post.Content = str;
            database.AddPost(post);
            return "Success";
        }

        public String removePost(int id)
        {
            database.RemovePost(id);
            return "Success";
        }

        public String sendTicket(String message) 
        {

            String check = StringChecks.isVarChar(message);
            if (check == null)
            {
                String str = StringChecks.doubleApostrophy(message);
                Ticket ticket = new Ticket(this.Username, str);
                database.AddTicket(ticket);
                return "Ticket was sent";
            }
            else
            {
                return check;
            }
        }

        public void changeColors(Color text, Color bg) 
        {
            this.text = text;
            this.bg = bg;
            database.changeColors(this.Username, bg.ToArgb(), text.ToArgb());
        }
    }
}
