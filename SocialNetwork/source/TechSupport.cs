using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork
{
    public sealed class TechSupport : Account, IDisableAcc
    {
        private Database database = Database.getDatabase();

        public TechSupport(String username, String fname, String lname, String password)
            : base(username, fname, lname, password, (int)Program.permissionLevels.TechSupport)
        {}

        public TechSupport(String username, String fname, String lname, String password, bool disabled)
            : base(username, fname, lname, password, (int)Program.permissionLevels.TechSupport, disabled)
        {}

        

        
        
        
        

        
        

        

        
        
        
        

        

        
        
        
        


        
        
        
        

        
        
        
        
        
        
        
        
        

        
        
        
        

        
        
        

        public void changeUserDetails(List<String> array)
        {
            database.changeUserDetails(array);
        }

        
        
        
        
        

        

        
        

        
        
        
        
        

        
        
        
        
        
        
        
        
        

        

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        

        
        
        
        
        
        
        
        
        public void disableAccount(String username) 
        {
            if (database.checkIfUserExists(username))
            {
                database.disableAccount(username);
            }

            
            


        }
        
        public void reEnableAccount(String username) 
        {

            
            
            if (database.checkIfUserExists(username))
            {
                database.reEnableAccount(username);
            }
        }

        public void resetPassword(String username) 
        {
            if (database.checkIfUserExists(username))
            {
                database.resetPassword(username);
            }
        }

        
        public void handleTicket(String representative, Ticket ticket)
        {
            database.handleTicket(representative, ticket);

        }
        public void finishTicket(String representative, Ticket ticket)
        {
            database.finishTicket(representative, ticket);

        }
    }

}