using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    public sealed class Ticket
    {
        private String username; 
        private String details; 
        private String representative; 
        private String date; 
        private int id;

        public Ticket(String username, String details)
        {
            Username = username;
            Details = details;
            Representative = null;
            this.date = DateTime.Now.ToShortDateString(); 
        }
        
        public Ticket(int id, String username, String details, String representative, String date)
        {
            Username = username;
            Details = details;
            Representative = representative;
            this.date = date;
            Id = id;
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
            if (this.Representative == null) 
                return "Recived in: " + Date + "\nBy: " + Username + "\tHandled by: none\n" + "Details: " + Details; 
            else 
            {
                return "Recived in: " + Date + "\nBy: " + Username + "\tHandled by: " + Representative + "\n" + "Details: " + Details;
            }
        }
    }
}
