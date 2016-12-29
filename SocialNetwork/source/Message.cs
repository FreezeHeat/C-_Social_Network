using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    public sealed class Message
    {
        
        private int id; 
        private String sender; 
        private String mail; 
        private DateTime date; 
        private bool wasRead = false; 

        public Message(String sender, String mail)
        {
          
            Sender = sender;
            
            Mail = mail;
            this.date = DateTime.Now;
        }

        public Message(int id, String sender, String mail, String date)
        {
            this.id = id;
            Sender = sender;
            
            Mail = mail;

            String[] values = date.Split('/'); 
            int day = Int32.Parse(values[0]);
            int month = Int32.Parse(values[1]);
            int year = Int32.Parse(values[2]);

            this.date = new DateTime(year, month, day);
        }

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
    }
}
