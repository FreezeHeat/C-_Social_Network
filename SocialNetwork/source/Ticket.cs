using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    public sealed class Ticket
    {//omer 13.2
        private String username; // שם משתמש ששלח את הפנייה
        private String details; // הפנייה עצמה
        private String representative; // נציג תמיכה שמטפל בפנייה
        private String date; // תאריך פנייה
        private int id;

        public Ticket(String username, String details)
        {
            Username = username;
            Details = details;
            Representative = null;
            this.date = DateTime.Now.ToShortDateString(); // מכניס את התאריך והזמן בה נשלחה הפנייה
        }
        //omer 13.2
        public Ticket(int id, String username, String details, String representative, String date)
        {
            Username = username;
            Details = details;
            Representative = representative;
            this.date = date;
            Id = id;
            //String[] values = date.Split('/'); // פיצול המחרוזת והמרתם למספרים
            //int day = Int32.Parse(values[0]);
            //int month = Int32.Parse(values[1]);
            //int year = Int32.Parse(values[2]);

            //this.date = new DateTime(year, month, day);
        }

        //omer 13.2
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public String Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public String Details
        {
            get { return this.details; }
            set { this.details = value; }
        }

        public String Representative
        {
            get { return this.representative; }
            set { this.representative = value; }
        }

        public String Date
        {
            get { return this.date; }
        }

        public override string ToString()
        {
            if (this.Representative == null) // אם לא בטיפול
                return "Recived in: " + Date + "\nBy: " + Username + "\tHandled by: none\n" + "Details: " + Details; // פרטי פנייה
            else // אם כן בטיפול
            {
                return "Recived in: " + Date + "\nBy: " + Username + "\tHandled by: " + Representative + "\n" + "Details: " + Details;
            }
        }
    }
}
