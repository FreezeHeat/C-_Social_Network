using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    sealed class Message
    {
        //private String recipient; // המשתמש שמקבל את הודעה
        private int id; // מספר סידורי של ההודעה
        private String sender; // המשתמש ששולח את ההודעה
        private String mail; // ההודעה עצמה
        private DateTime date; // זמן הודעה
        private bool wasRead = false; // האם ההודעה נקראה או לא
        

        // בנאים ומתודות כלליות
        public Message(int id, String sender, String mail)
        {
            this.id = id;
            Sender = sender;
            //Recipient = recipient;
            Mail = mail;
            this.date = DateTime.Now;
        }

        public Message(String sender, String mail)
        {
          
            Sender = sender;
            //Recipient = recipient;
            Mail = mail;
            this.date = DateTime.Now;
        }

        public Message(String sender, String mail, String date)
        {
            Sender = sender;
            //Recipient = recipient;
            Mail = mail;

            String[] values = date.Split('/'); // פיצול המחרוזת והמרתם למספרים
            int day = Int32.Parse(values[0]);
            int month = Int32.Parse(values[1]);
            int year = Int32.Parse(values[2]);

            this.date = new DateTime(year, month, day);
        }

        //public String Recipient
        //{
        //    get { return this.recipient; }
        //    set { this.recipient = value; }
        //}

        public int ID
        {
            get { return this.id; }
        }

        public String Sender
        {
            get { return this.sender; }
            set { this.sender = value; }
        }

        public String Mail
        {
            get { return this.mail; }
            set { this.mail = value; }
        }

        public String Date
        {
            get { return this.date.ToString("dd/MM/yyyy"); }
        }

        public bool WasRead
        {
            get { return this.wasRead; }
            set { this.wasRead = value; }
        }
        //public override string ToString()
        //{
        //    if (wasRead == true) // אם ההודעה נקראה, אז אין צורך בתוספת "חדש" למחרוזת
        //        return Account + " at" + this.date.ToString() + " :\n" + Mail;

        //    else
        //    {
        //        wasRead = true; // בגלל שנקראה ההודעה נגדיר אותה כך
        //        return "**NEW**" + Account + " at " + this.date.ToString() + " :\n" + Mail;  // הוספת התראה להסבת תשומת הלב של המשתמש
        //    }
        //}
    }
}
