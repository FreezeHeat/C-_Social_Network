//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SocialNetwork
//{
//    sealed class TicketBox
//    {
//        private List<Ticket> ticketBox = new List<Ticket>();
		
//        public List<Ticket> getTicketBox
//        {
//            get { return this.ticketBox; }
//        }
        
//        private void printTickets() // הדפסת כל הפניות
//        {
//            if (ticketBox.Count <= 0)
//            {
//                Console.WriteLine("No tickets in the list");
//                return;
//            }

//            foreach (Ticket ticket in ticketBox)
//                Console.WriteLine(ticket.ToString());
//            Console.WriteLine();
//        }

//        private void printTickets(String representative) // הדפסת פניות לפי נציג תמיכה
//        {
//            if (ticketBox.Exists(temp => temp.Representative == representative) == false || ticketBox.Count <= 0)
//            {
//                Console.WriteLine("No tickets in the list of which you handle");
//                return;
//            }

//            foreach (Ticket ticket in ticketBox)
//                if (ticket.Representative == representative)
//                    Console.WriteLine(ticket.ToString());
//        }

//        private void printOpenTickets() // הדפס פניות שאינן בטיפול
//        {
//            if (ticketBox.Exists(temp => temp.Representative == null) == false || ticketBox.Count <= 0)
//            {
//                Console.WriteLine("No open tickets in the list");
//                return;
//            }

//            foreach (Ticket ticket in ticketBox)
//                if (ticket.Representative == null)
//                    Console.WriteLine(ticket.ToString());

//        }

//        private void handleTicket(String representative)
//        {
//            String ticketID;

//            Console.Clear(); //ניקוי מסך

//            printOpenTickets(); // הדפסה של כל הפניות שלא בטיפול

//            Console.Write("\nWhich ticket do you wish to handle?\n" +
//                              "Ticket ID: ");
//            ticketID = Console.ReadLine(); // קלט

//            int index = ticketBox.FindIndex(id => id.TicketID == Int32.Parse(ticketID)); // אם נמצאה הפנייה, יקבל את האינדקס, אם לא, יקבל מינוס אחד

//            if (index != -1) // אם נמצא הכרטיס ברשימה
//            {
//                ticketBox[index].Representative = representative; // השמה
//                return;
//            }
//            // אם הכרטיס לא נמצא
//            Console.WriteLine("\nNo such ticket was found\n");



//        }

//        private void finishTicket(String representative) // מחיקת פנייה שהסתיימה 
//        {
//            String ticketID;

//            Console.Clear(); //ניקוי מסך
        
//            Console.WriteLine("Tickets that are handled by you:");
//            printTickets(representative);
//            Console.WriteLine("Please enter the ID of the finished ticket:");
//            Console.Write("Ticket ID: ");
//            ticketID = Console.ReadLine();

//            int index = ticketBox.FindIndex(id => id.TicketID == Int32.Parse(ticketID)); // אם נמצאה הפנייה, יקבל את האינדקס, אם לא, יקבל מינוס אחד

//            if (index != -1) // אם נמצא הכרטיס ברשימה
//                if (ticketBox[index].Representative == representative) // אם הכרטיס שרוצים למחוק שייך לאותו נציג
//                    ticketBox.RemoveAt(index);       

//            else // אם הכרטיס לא שייך לנציג או שלא נמצא
//                Console.WriteLine("\nNo such ticket was found");
//        }




//        private void userMenu(String representative) // תפריט משתמש רגיל
//        {
//            Console.Clear(); //ניקוי מסך

//            String details; // פרטי הפנייה
//            Console.WriteLine("Please write your ticket:");
//            details = Console.ReadLine();

//            ticketBox.Add(new Ticket(representative, details, ticketBox.Count + 1)); // הוספת הפנייה לרשימה לפי מספרה ברשימה
//        }



//        private void techSupportMenu(String representative) // תפריט תמיכה טכנית
//        {
//            String choice;
//            do
//            {
//                Console.Clear(); //ניקוי מסך

//                Console.Write("What would you like to do?\n" +
//                              "1) List All Tickets\n" +
//                              "2) List Available Tickets\n" +
//                              "3) List your Tickets\n" +
//                              "4) Handle a ticket\n" +
//                              "5) Finish a ticket\n" +
//                              "6) Exit this menu\n\n" +
//                              "Choice: ");

//                choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1":
//                        Console.Clear();
//                        printTickets(); // הדפסת כל הפניות
//                        Console.WriteLine("Press any key to continue");
//                        Console.ReadKey();
//                        break;
//                    case "2":
//                        Console.Clear();
//                        printOpenTickets(); // הדפס את כל הפניות שלא בטיפול
//                        Console.WriteLine("Press any key to continue");
//                        Console.ReadKey();
//                        break;
//                    case "3":
//                        Console.Clear();
//                        printTickets(representative); // הדפסת הפניות בהם הנציג מטפל
//                        Console.WriteLine("Press any key to continue");
//                        Console.ReadKey();
//                        break;
//                    case "4":
//                        Console.Clear();
//                        handleTicket(representative); // הגדרת פנייה מסויימת כמטופלת ע"י נציג זה
//                        break;
//                    case "5":
//                        Console.Clear();
//                        finishTicket(representative); // סיום פנייה, בעצם מחיקתה מן הרשימה
//                        break;
//                    case "6":
//                        return;
//                        break;
//                    default:
//                        Console.WriteLine("Wrong Choice");
//                        break;
//                }

//            } while (true); // לולאה אין סופית
//        }
//        public void TicketMenu(Account representative) // קבלת פניה - לא תקין
//        {
//            switch (representative.Permission)
//            {
//                case 0:
//                    userMenu(representative.Username);
//                    break;
//                case 1:
//                    techSupportMenu(representative.Username); // תפריט של נציגי שירות
//                    break;
//                default:
//                    Console.WriteLine("Error - account permission unknown");
//                    break;
//            } 
//        }

//        public TicketBox Clone() // משמש לגיבוי
//        {
//            TicketBox clone = new TicketBox();
//            clone.ticketBox = new List<Ticket>(this.ticketBox);
//            return clone;
//        }
//    }
//}
