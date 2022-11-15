using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    sealed class Memento 
    {
        private List<Account> accounts; 
        private List<Ticket> ticketBox; 
        private List<Message> inboxes; 
        private List<Post> postList; 
        private DateTime backupTime; 


        public Memento(List<Account> accounts, List<Ticket> ticketBox, List<Message> inboxes, List<Post> postList)
        {
            this.accounts = new List<Account>(accounts);
            this.ticketBox = new List<Ticket>(ticketBox);
            this.inboxes = new List<Message>(inboxes);
            this.postList = new List<Post>(postList);
            backupTime = DateTime.Now;
        }

        public List<Account> Accounts
        {
            get { return accounts; }
        }

        public List<Ticket> TicketBox
        {
            get { return ticketBox; }
        }

        public List<Message> Inboxes {
            get { return inboxes; }
        }

        public List<Post> PostList
        {
            get { return postList; }
        }

        public DateTime BackupTime
        {
            get { return this.backupTime; }
        }

    }
}
