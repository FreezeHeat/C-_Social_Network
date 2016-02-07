//using SocialNetwork.source;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SocialNetwork
//{
//    sealed class Inbox : IBackup
//    {
//        private List<Message> inbox = new List<Message>();
//        private List<Message> backup; // גיבוי של התיבה
//        private Database database = Database.getDatabase();
//        private DateTime backupTime;


//        public List<Message> InboxList
//        {
//            get{ return this.inbox; }
//        }
//        // מתודות ייחודיות

//        //public void printList()
//        //{
//        //    Console.Clear(); //ניקוי מסך

//        //    if (inbox.Count <= 0)
//        //    {
//        //        Console.WriteLine("Inbox is empty");
//        //        return;
//        //    }
//        //    for (int i = 0; i < inbox.Count; i++)
//        //    {
//        //        Console.WriteLine( (i+1) + ") " + inbox[i].ToString());
//        //    }
//        //}

//        public void sendMessage(String sender, String recipient, String message) // קבלת הודעה
//        {
//            inbox.Add(new Message(sender, recipient, message));
//        }

//        public String checkSender(String sender)
//        {
//            String check = StringChecks.anyWhiteSpace(sender);
//            return check;
//        }

//        public String checkRecipient(String recipient)
//        {
//            String check = StringChecks.anyWhiteSpace(recipient);
//            return check;
//        }

//        public String checkMessage(String message)
//        {
//            String check = StringChecks.isVarChar(message);
//            return check;
//        }

//        //public void sendMessage(String username, String destinationUsername) // שליחת הודעה - נא לשים לב הוסף שינוי בגישה למערך במיין
//        //{
//        //    if(destinationUsername.Any(Char.IsWhiteSpace) == true)
//        //    {
//        //        Console.WriteLine("No whitespaces allowed");
//        //        return;
//        //    }
//        //    Console.WriteLine("Please enter your message: ");
//        //    String message = Console.ReadLine();
//        //    if(message.All(Char.IsWhiteSpace) == true)
//        //    {
//        //        Console.WriteLine("Whitespaces only aren't allowed");
//        //        return;
//        //    }

//        //    for (int i = 0; i < database.Accounts.Count; i++)
//        //    {
//        //        if (database.Accounts[i].Username.Equals(destinationUsername)) // מעבר לבדיקה שקיים המשתמש
//        //        {
//        //            database.Accounts[i].inbox.getMessage(username, message); // שימוש חוזר בקוד, שימוש במתודה קיימת
//        //            return;
//        //        }
//        //    }

//        //    Console.WriteLine("The user doesn't exist in the database");  // במקרה ולא נמצא המשתמש
//        //}
        
//        public String deleteMessage(int index)
//        {
//            //int number;

//            //Console.Clear(); //ניקוי מסך

//            //printList(); // הדפסת הרשימה לפני הצעת המחיקה
//            //if (inbox.Count <= 0) // אם הרשימה ריקה, תצא
//            //    return;

//            //Console.WriteLine("Please enter the message's number you wish to delete");
//            //number = Int32.Parse(Console.ReadLine());

//            //if (number < (inbox.Count + 1) && number > 0) // סגירת הטווח החוקי של הרשימה
//            //    inbox.RemoveAt(number-1); // אנשים לא סופרים מאפס
//            //else
//            //    Console.WriteLine("No such message\n");

//            InboxList.RemoveAt(index);
//        }

//        public String createBackup() // יצירת גיבוי
//        {
//            if(this.inbox.Count == 0) // אם אין מה לגבות
//            {
//                return "Inbox is empty, nothing to backup";
//            }

//            if(this.backup != null) // אם הגיבוי לא ריק
//                this.backup.Clear(); // מנקה את הרשימה

//            this.backup = new List<Message>(this.inbox); // גיבוי הרשימה
//            this.backupTime = DateTime.Now; // רישום זמן גיבוי

//            return "Backup was created!";
//        }

//        public String restoreBackup() // שחזור גיבוי
//        {
//            if(this.backup == null) // משתמש מנסה לשחזר כאשר אין גיבוי בכלל
//            {
//                return "There's no restore point... you must have a backup to restore to";
//            }

//            this.inbox.Clear(); // ניקוי רשימה
//            this.inbox = new List<Message>(this.backup); // שחזור גיבוי
//            return "Backup successful!";
//        }
//    }
//}
