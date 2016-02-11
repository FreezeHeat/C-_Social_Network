using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace SocialNetwork
{
    sealed class Database
    {
        private string db_Address = "Data Source=SocialNetwork.sqlite;Version=3;foreign keys = ON;"; // חייב לתמוך במפתחות זרים
        private SQLiteConnection m_dbConnection;

        private List<Account> accounts = new List<Account>(); // משתמשים
        private List<Ticket> ticketBox = new List<Ticket>(); // תיבת פניות
        private List<Message> inboxes = new List<Message>(); // תיבות מייל
        private List<Post> postList = new List<Post>(); // פוסטים
        private Caretaker backupManager = new Caretaker(); // מנהל גיבוי
        private static Database database = new Database(); // מופע יחיד

        // בנאי פרטי - שלא תהיה אפשרות לאתחל בחוץ
        private Database()
        {
            if (File.Exists("SocialNetwork.sqlite"))
            {
                m_dbConnection = new SQLiteConnection(db_Address);
                m_dbConnection.Open();
            }
            else { CreateDataBase(); }
        } 

        private void CreateDataBase()
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();

            string sql = "CREATE TABLE Accounts(" +
                         "username TEXT PRIMARY KEY NOT NULL," +
                         "fname TEXT NOT NULL," +
                         "lname TEXT NOT NULL," +
                         "password TEXT NOT NULL," +
                         "permission INTEGER NOT NULL," +
                         "disabled INTEGER NOT NULL" +
                         ");" +
                         "CREATE TABLE Users(" +
                         "username TEXT NOT NULL," +
                         "maritalStatus TEXT NOT NULL," +
                         "dob TEXT NOT NULL," +
                         "city TEXT NOT NULL," +
                         "status TEXT NOT NULL," +
                         "info TEXT NOT NULL," +
                         "FOREIGN KEY(username) REFERENCES Accounts(username) ON UPDATE CASCADE ON DELETE CASCADE" +
                         ");" +
                         "CREATE TABLE TechSupport(" +
                         "username TEXT NOT NULL," +
                         "workerID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                         "FOREIGN KEY(username) REFERENCES Accounts(username) ON UPDATE CASCADE ON DELETE CASCADE" +
                         ");" +
                         "CREATE TABLE Colors(" +
                         "username TEXT NOT NULL,"+
                         "color INTEGER NULL," +
                         "FOREIGN KEY(username) REFERENCES Accounts(username) ON UPDATE CASCADE ON DELETE CASCADE" +
                         ");" +
                         "CREATE TABLE Inboxes(" +
                         "id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                         "username TEXT NOT NULL," +
                         "sender TEXT NOT NULL," +
                         "mail TEXT NOT NULL," +
                         "date TEXT NOT NULL," +
                         "wasRead INTEGER NOT NULL," +
                         "FOREIGN KEY(username) REFERENCES Accounts(username) ON UPDATE CASCADE ON DELETE CASCADE" +
                         ");" +
                         "CREATE TABLE Posts(" +
                         "id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                         "username TEXT NOT NULL," +
                         "content TEXT NOT NULL," +
                         "date TEXT NOT NULL," +
                         "FOREIGN KEY(username) REFERENCES Accounts(username) ON UPDATE CASCADE ON DELETE CASCADE" +
                         ");" +
                         "CREATE TABLE Tickets(" +
                         "id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                         "username TEXT NOT NULL," +
                         "details TEXT NOT NULL," +
                         "representative, INTEGER NULL," +
                         "date TEXT NOT NULL," +
                         "FOREIGN KEY(username) REFERENCES Accounts(username) ON UPDATE CASCADE ON DELETE CASCADE " +
                         "FOREIGN KEY(representative) REFERENCES Accounts(username) ON UPDATE CASCADE ON DELETE CASCADE" +
                         ");";

            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public static Database getDatabase()
        {
            return database;
        }

        public List<Account> Accounts 
        {
            get{ return accounts; }
        }

        public List<Ticket> TicketBox 
        {
            get { return ticketBox; }
        }

        public List<Message> Inboxes
        {
            get { return inboxes; }
        }

        public List<Post> PostList
        {
            get { return postList; }
        }

        public List<Account> getAllAccounts()
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "SELECT * FROM Accounts";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = query.ExecuteReader();
            List<Account> list = new List<Account>();

            while (reader.Read())
            {
                string username = reader["username"].ToString();
                string password = reader["password"].ToString();
                string fname = reader["fname"].ToString();
                string lname = reader["lname"].ToString();
                int permission = (int)reader["permission"];

                if (permission == 0)
                {
                    sql = "SELECT * FROM Users WHERE username LIKE '" + username + "'";
                    query.CommandText = sql;
                    reader = query.ExecuteReader();
                    if (reader.Read())
                    {
                        string maritalStatus = reader["maritalStatus"].ToString();
                        string dob = reader["dob"].ToString();
                        string city = reader["city"].ToString();
                        string info = reader["info"].ToString();
                        string status = reader["status"].ToString();
                        User user = new User(username, fname, lname, password, maritalStatus, dob, city, info, status);
                        list.Add(user);
                    }
                }

                else if (permission == 1)
                {
                    sql = "SELECT * FROM TechSupport WHERE username LIKE '" + username + "'";
                    query.CommandText = sql;
                    reader = query.ExecuteReader();
                    if (reader.Read())
                    {
                        long workerID = (long)reader["workerID"];
                        TechSupport tech = new TechSupport(username, fname, lname, password);
                        list.Add(tech);
                    }
                }

                else
                {
                    Admin admin = new Admin(username, fname, lname, password);
                    list.Add(admin);
                }
            }

            reader.Close();
            return list;
        }

        public List<Post> getAllPosts(String username)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "SELECT * FROM Posts WHERE username LIKE '" + username + "'";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = query.ExecuteReader();
            List<Post> list = new List<Post>();

            while (reader.Read())
            {
                int id = Int32.Parse(reader["id"].ToString());
                string user = reader["username"].ToString();
                string content = reader["content"].ToString();
                Post post = new Post(id, user, content);
                list.Add(post);
            }

            reader.Close();
            return list;
        }

        public List<Ticket> getAllTickets()
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "SELECT * FROM Tickets";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = query.ExecuteReader();
            List<Ticket> tickets = new List<Ticket>();

            while (reader.Read())
            {
                int id = (int)reader["id"];
                String username = reader["username"].ToString();
                String details = reader["details"].ToString();
                String representative = reader["representative"].ToString();
                String date = reader["date"].ToString();
                Ticket ticket = new Ticket(username, details, representative, date);
                tickets.Add(ticket);
            }

            reader.Close();
            return tickets;
        }

        public List<Message> getInbox(String username)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "SELECT * FROM Inboxes WHERE username LIKE '" + username + "'";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = query.ExecuteReader();
            List<Message> inbox = new List<Message>();

            while (reader.Read())
            {
                int id = (int)reader["id"];
                String sender = reader["sender"].ToString();
                String mail = reader["mail"].ToString();
                String date = reader["date"].ToString();
                bool wasRead = (bool)reader["wasRead"];

                Message message = new Message(sender, mail, date);
                inbox.Add(message);
            }

            reader.Close();
            return inbox;
        }

        public Account Login(String AccUsername, String AccPassword)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "SELECT * FROM Accounts WHERE username LIKE '" + AccUsername + "' AND password LIKE '" + AccPassword + "'";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = query.ExecuteReader();

            if (reader.Read())
            {
                string username = reader["username"].ToString();
                string password = reader["password"].ToString();
                string fname = reader["fname"].ToString();
                string lname = reader["lname"].ToString();
                int permission = (int)reader["permission"];

                if(permission == 0)
                {
                    sql = "SELECT * FROM Users WHERE username LIKE '" + AccUsername + "'";
                    query.CommandText = sql;
                    reader = query.ExecuteReader();
                    if (reader.Read())
                    {
                        string maritalStatus = reader["maritalStatus"].ToString();
                        string dob = reader["dob"].ToString();
                        string city = reader["city"].ToString();
                        string info = reader["info"].ToString();
                        string status = reader["status"].ToString();
                        reader.Close();
                        return new User(username, fname, lname, password, maritalStatus, dob, city, info, status);
                    }
                }

                else if (permission == 1)
                {
                    sql = "SELECT * FROM TechSupport WHERE username LIKE '" + AccUsername + "'";
                    query.CommandText = sql;
                    reader = query.ExecuteReader();
                    if (reader.Read())
                    {
                        long workerID = (long)reader["workerID"];
                        reader.Close();
                        return new TechSupport(username, fname, lname, password);
                    }
                }

                else
                {
                    reader.Close();
                    return new Admin(username, fname, lname, password);
                }
            }

            reader.Close();
            return null;
        }

        public void addUser(User user)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "INSERT INTO Accounts(username, fname, lname, password, permission, disabled) VALUES(" +
                         "'" + user.Username + "'," +
                         "'" + user.Fname + "'," +
                         "'" + user.Lname + "'," +
                         "'" + user.Password + "'," +
                         "0," +
                         "0" +
                         ");" +
                         "INSERT INTO Users(username, maritalStatus, dob, city, info, status) VALUES(" +
                         "'" + user.Username + "'," +
                         "'" + user.MaritalStatus + "'," +
                         "'" + user.Dob + "'," +
                         "'" + user.City + "'," +
                         "'" + user.Info + "'," +
                         "'" + user.Status + "'" +
                         ");";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void addTech(TechSupport tech)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "INSERT INTO Accounts(username, fname, lname, password, permission, disabled) VALUES(" +
                         "'" + tech.Username + "'," +
                         "'" + tech.Fname + "'," +
                         "'" + tech.Lname + "'," +
                         "'" + tech.Password + "'," +
                         "1," +
                         "0" +
                         ");" +
                         "INSERT INTO TechSupport(username) VALUES(" +
                         "'" + tech.Username + "'" +
                         ");";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void addAdmin(Admin admin)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "INSERT INTO Accounts(username, fname, lname, password, permission, disabled) VALUES(" +
                         "'" + admin.Username + "'," +
                         "'" + admin.Fname + "'," +
                         "'" + admin.Lname + "'," +
                         "'" + admin.Password + "'," +
                         "2," +
                         "0" +
                         ");";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void disableAccount(String username)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "UPDATE Accounts" +
                         "SET disabled = 1" +
                         "WHERE username LIKE" + "'" + username + "';";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void reEnableAccount(String username)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "UPDATE Accounts" +
                         "SET disabled = 0" +
                         "WHERE username LIKE" + "'" + username + "';";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void deleteAccount(String username)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "DELETE FROM Accounts" +
                         "WHERE username LIKE" + "'" + username + "';";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void AddMessage(Message message, String account)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "INSERT INTO Inboxes(username, sender, mail, wasRead) VALUES(" +
                         "'" + account + "'," +
                         "'" + message.Sender + "'," +
                         "'" + message.Mail + "'," +
                         message.WasRead +
                         ");";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void DeleteMessage(int index)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "DELETE FROM Inboxes" +
                         "WHERE id =" + index + ";";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void AddTicket(Ticket ticket)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "INSERT INTO Tickets(username, representative, date) VALUES(" +
                         "'" + ticket.Username + "'," +
                         "'" + ticket.Representative + "'," +
                         "'" + ticket.Date + "'" +
                         ");";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void RemoveTicket(int index)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "DELETE FROM Tickets" +
                         "WHERE id =" + index + ";";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void AddPost(Post post)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "INSERT INTO Posts(username, content, date) VALUES(" +
                         "'" + post.Source + "'," +
                         "'" + post.Content + "'," +
                         "'" + post.Date + "'," +
                         ");";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void RemovePost(int index)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "DELETE FROM Posts" +
                         "WHERE id =" + index + ";";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public bool checkIfUserExists(String username)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "SELECT * FROM Accounts WHERE username LIKE '" + username + "'";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = query.ExecuteReader();
            List<Account> list = new List<Account>();

            if (reader.Read())
            {
                string dbUser = reader["username"].ToString();
                if (dbUser.Equals(username))
                {
                    reader.Close();
                    return true;
                }
            }

            reader.Close();
            return false;
        }

        public String checkPermission(String username)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "SELECT permission FROM Accounts WHERE username LIKE " + username;
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = query.ExecuteReader();

            if (reader.Read())
            {
                reader.Close();
                return reader["permission"].ToString();
            }

            reader.Close();
            return null;
        }

		
		public void resetPassword(String username)//עמר
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "UPDATE Accounts" +
                         "SET password = 0" +
                         "WHERE username =" + "'" + username + "';";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }
		
		 public void changeUserDetails(List<String> ListDetails)//omer
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();

            string sql = "UPDATE Accounts" +
                            "SET fname ='" + ListDetails[1] + "'" + ",lame='" + ListDetails[2] + "'" + ",password='" + ListDetails[3] + "'"
                            + ",maritalStatus='" + ListDetails[4] + "'" + ",dob='" + ListDetails[5] + "'" + ",city='" + ListDetails[6] + "'"
                            + ",status='" + ListDetails[7] + "'" + ",info='" + ListDetails[8] + "'" + "WHERE username LIKE '" + ListDetails[0];          //לשים יוזר באינדקס 0
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
            
        }
		
        public Memento createMemento()
        {
            //Console.WriteLine("Created a backup of all acounts, and the ticket box");
            return (new Memento(accounts, ticketBox, inboxes, postList));
        }

        public void setMemento(Memento memento)
        {
            //Console.WriteLine("Are you sure you want to restore this backup:");
            //Console.WriteLine("Created in: " + memento.BackupTime.ToString());
            //Console.WriteLine("Enter 'yes' if you wish to continue, anything else will cancel this action");
            //String input = Console.ReadLine();

            //if (input == "yes")
            //{
            accounts.Clear(); // ניקוי הרשימה
            accounts = new List<Account>(memento.Accounts); // יישום גיבוי

            inboxes.Clear();
            inboxes = new List<Message>(memento.Inboxes);

            ticketBox.Clear();
            ticketBox = new List<Ticket>(memento.TicketBox);

            postList.Clear();
            postList = new List<Post>(memento.PostList);


                //Console.WriteLine("Backup is successful!");

            //else { Console.WriteLine("Backup cancelled!"); }
        }
    }
}
