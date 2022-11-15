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
        private string db_Address = "Data Source=SocialNetwork.sqlite; Version=3; foreign keys=true;"; 
        private SQLiteConnection m_dbConnection;

        
        
        
        
        private static Database database = new Database(); 

        
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
                         "bgColor INTEGER NULL," +
                         "fgColor INTEGER NULL," +
                         "FOREIGN KEY(username) REFERENCES Accounts(username) ON UPDATE CASCADE ON DELETE CASCADE" +
                         ");" +
                         "CREATE TABLE Inboxes(" +
                         "id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                         "username TEXT NOT NULL," +
                         "sender TEXT NOT NULL," +
                         "mail TEXT NOT NULL," +
                         "date TEXT NOT NULL," +
                         "wasRead INTEGER NOT NULL," +
                         "FOREIGN KEY(username) REFERENCES Accounts(username) ON UPDATE CASCADE" +
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
                         "representative, TEXT NULL," +
                         "date TEXT NOT NULL," +
                         "FOREIGN KEY(username) REFERENCES Accounts(username) ON UPDATE CASCADE ON DELETE CASCADE " +
                         ");";

            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public static Database getDatabase()
        {
            return database;
        }
        
        public List<Account> getAllAccounts()
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "SELECT * FROM Accounts";

            
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);

            
            SQLiteCommand querySpecific = new SQLiteCommand(sql, m_dbConnection);

            
            SQLiteDataReader reader = query.ExecuteReader();

            
            SQLiteDataReader readerSpecific;

            List<Account> list = new List<Account>();

            while (reader.Read())
            {
                string username = reader["username"].ToString();
                string password = reader["password"].ToString();
                string fname = reader["fname"].ToString();
                string lname = reader["lname"].ToString();
                int permission = Int32.Parse(reader["permission"].ToString());
                bool disabled = ( (reader["disabled"].ToString() == "1") ? true : false );

                if (permission == 0)
                {

                    sql = "SELECT * FROM Users WHERE username LIKE '" + username + "'";
                    querySpecific.CommandText = sql;
                    readerSpecific = querySpecific.ExecuteReader();
                    if (readerSpecific.Read())
                    {
                        string maritalStatus = readerSpecific["maritalStatus"].ToString();
                        string dob = readerSpecific["dob"].ToString();
                        string city = readerSpecific["city"].ToString();
                        string info = readerSpecific["info"].ToString();
                        string status = readerSpecific["status"].ToString();
                        User user = new User(username, fname, lname, password, disabled, maritalStatus, dob, city, info, status);
                        list.Add(user);
                    }
                    readerSpecific.Close();
                }

                else if (permission == 1)
                {

                    sql = "SELECT * FROM TechSupport WHERE username LIKE '" + username + "'";
                    querySpecific.CommandText = sql;
                    readerSpecific = querySpecific.ExecuteReader();
                    if (readerSpecific.Read())
                    {
                        String workerID = readerSpecific["workerID"].ToString();
                        TechSupport tech = new TechSupport(username, fname, lname, password, disabled);
                        list.Add(tech);
                    }
                    readerSpecific.Close();
                }

                else
                {
                    Admin admin = new Admin(username, fname, lname, password, disabled);
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
                int id = Int32.Parse(reader["id"].ToString());
                String username = reader["username"].ToString();
                String details = reader["details"].ToString();
                String representative = reader["representative"].ToString();
                String date = reader["date"].ToString();
                Ticket ticket = new Ticket(id, username, details, representative, date);
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
                int id = Int32.Parse(reader["id"].ToString());
                String sender = reader["sender"].ToString();
                String mail = reader["mail"].ToString();
                String date = reader["date"].ToString();
                bool wasRead = (Int32.Parse(reader["wasRead"].ToString()) == 1) ? true : false ;

                Message message = new Message(id, sender, mail, date);
                inbox.Add(message);
            }

            reader.Close();
            return inbox;
        }

        public User getUser(String user)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "SELECT * FROM Accounts WHERE username LIKE '" + user + "';";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                string username = reader["username"].ToString();
                string password = reader["password"].ToString();
                string fname = reader["fname"].ToString();
                string lname = reader["lname"].ToString();
                int permission = Int32.Parse(reader["permission"].ToString());

                if (permission == 0)
                {
                    reader.Close();
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
                        User userDetails = new User(username, fname, lname, password, maritalStatus, dob, city, info, status);
                        reader.Close();
                        return userDetails;
                    }
                }

                else
                {
                    reader.Close();
                    return null;
                }
            }

            reader.Close();
            return null;
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
                int permission = Int32.Parse(reader["permission"].ToString());
                bool disabled = (Int32.Parse(reader["disabled"].ToString()) == 1) ? true : false;


                if (permission == 0)
                {
                    reader.Close();
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
                        User temp = new User(username, fname, lname, password, maritalStatus, dob, city, info, status);
                        temp.Disabled = disabled;
                        return temp;
                    }
                }

                else if (permission == 1)
                {
                    reader.Close();
                    sql = "SELECT * FROM TechSupport WHERE username LIKE '" + AccUsername + "'";
                    query.CommandText = sql;
                    reader = query.ExecuteReader();
                    if (reader.Read())
                    {
                        long workerID = (long)reader["workerID"];
                        reader.Close();
                        TechSupport temp = new TechSupport(username, fname, lname, password);
                        temp.Disabled = disabled;
                        return temp;
                    }
                }

                else
                {
                    reader.Close();
                    Admin temp = new Admin(username, fname, lname, password);
                    temp.Disabled = disabled;
                    return temp;

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
                         ");" +
                         "INSERT INTO Colors(username, bgColor, fgColor) VALUES(" +
                         "'" + user.Username + "', " +
                         "0, " +
                         "0" +
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
                         ");" +
                         "INSERT INTO Colors(username, bgColor, fgColor) VALUES(" +
                         "'" + admin.Username + "', " +
                         "0, " +
                         "0" +
                         ");";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void disableAccount(String username)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "UPDATE Accounts " +
                         "SET disabled = 1 " +
                         "WHERE username LIKE " + "'" + username + "';";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void reEnableAccount(String username)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "UPDATE Accounts " +
                         "SET disabled = 0 " +
                         "WHERE username LIKE " + "'" + username + "';";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void deleteAccount(String username)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "DELETE FROM Accounts " +
                         "WHERE username LIKE " + "'" + username + "';";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void AddMessage(Message message, String account)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "INSERT INTO Inboxes(username, sender, mail, date, wasRead) VALUES(" +
                         "'" + account + "'," +
                         "'" + message.Sender + "', " +
                         "'" + message.Mail + "', " +
                         "'" + message.Date + "', "+
                         ((message.WasRead == true)? 1:0) +
                         ");";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void DeleteMessage(int index)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "DELETE FROM Inboxes " +
                         "WHERE id = " + index + ";";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void AddTicket(Ticket ticket)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "INSERT INTO Tickets(username, details, representative, date) VALUES(" +
                         "'" + ticket.Username + "'," +
                         "'" + ticket.Details + "', " +
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
            string sql = "DELETE FROM Tickets " +
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
                         "'" + post.Date + "'" +
                         ");";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void RemovePost(int index)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "DELETE FROM Posts " +
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
            string sql = "SELECT permission FROM Accounts WHERE username LIKE '" + username + "'";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = query.ExecuteReader();

            if (reader.Read())
            {
               String permission = reader["permission"].ToString();
               reader.Close();
               return permission;
            }

            reader.Close();
            return null;
        }

		
		public void resetPassword(String username)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "UPDATE Accounts " +
                         "SET password = 0 " +
                         "WHERE username =" + "'" + username + "';";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }
		
		 public void changeUserDetails(List<String> ListDetails)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            
            string sql =    "UPDATE Users " +
                            "SET maritalStatus='" + ListDetails[1] + "'" +  
                            ",dob='" + ListDetails[2] + "'" +
                            ",city='" + ListDetails[3] + "'" +
                            ",status='" + ListDetails[4] + "'" +
                            ",info='" + ListDetails[5] + "'" + 
                            " WHERE username LIKE '" + ListDetails[0] + "'"; 
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void changeDetails(List<String> ListDetails)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();

            string sql = "UPDATE Accounts " +
                         "SET fname ='" + ListDetails[1] + "'" +
                         ",lname='" + ListDetails[2] + "'" +
                         ",password='" + ListDetails[3] + "'" +
                         " WHERE username LIKE '" + ListDetails[0] + "' ;";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public void changeColors(String username, int bgColor, int fgColor)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();

            string sql = "UPDATE Colors " +
                         "SET bgColor = " + bgColor + " ," +
                         "fgColor = " + fgColor + " " +
                         "WHERE username LIKE '" + username + "' ;";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        public int [] getColors(String username)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "SELECT * FROM Colors WHERE username LIKE '" + username + "'";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = query.ExecuteReader();

            if (reader.Read())
            {
                int [] colors = new int[2];
                colors[0] = (reader["bgColor"].ToString() == null) ? 0 : Int32.Parse(reader["bgColor"].ToString());
                colors[1] = (reader["fgColor"].ToString() == null) ? 0 : Int32.Parse(reader["fgColor"].ToString());
                reader.Close();
                return colors;
            }

            reader.Close();
            return null;
        }

        public void updateUserStatus(String username, String status)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();

            string sql = "UPDATE Users " +
                         "SET Status = '" + status + "' " +
                         "WHERE username LIKE '" + username + "' ;";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteNonQuery();
        }

        
        public void handleTicket(String representative, Ticket ticket)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "UPDATE Tickets " +
                         "SET representative ='" + representative + "'" +
                         "WHERE id = " + ticket.Id + " ;";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteReader();
        }
        
        public void finishTicket(String representative, Ticket ticket)
        {
            m_dbConnection = new SQLiteConnection(db_Address);
            m_dbConnection.Open();
            string sql = "DELETE from Tickets " +
                         "WHERE id = " + ticket.Id + " ;";
            SQLiteCommand query = new SQLiteCommand(sql, m_dbConnection);
            query.ExecuteReader();
        }

        
        
        
        
        

        
        
        
        
        
        

        
        
        
        

        
        

        
        

        
        


        

        
        
    }
}
