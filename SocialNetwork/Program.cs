using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialNetwork.source;

namespace SocialNetwork
{
    static class Program
    {

        public enum permissionLevels { User = 0, TechSupport = 1, Admin = 2 }; /* Categorize accounts*/

        public static void StartUp()
        {
            
           
        }
        
        [STAThread]
        static void Main()
        {
            
            
            Database database = Database.getDatabase(); 


            //Create example accounts
            if (database.checkIfUserExists("Aviram") == false)
            {
                database.addAdmin(new Admin("Aviram", "Aviram", "Sharabi", "1234"));
            }

            if (database.checkIfUserExists("Amar") == false)
            {
                database.addTech(new TechSupport("Amar", "Omer", "Regev", "1234"));
            }

            if (database.checkIfUserExists("Noah") == false)
            {
                database.addUser(new User("Noah", "Meir", "Sharabi", "1234", "Single", "12/08/2014", "Kefar Saba", "Need more babies!", "I do not know Why"));
            }

            if (database.checkIfUserExists("Asaf") == false)
            {
                database.addUser(new User("Asaf", "Asaf", "Yeshayahu", "1234", "Married with children", "01/01/1999", "Head and Shoulders", "It''s all bullshit", "Good evening!"));
            }

            if (database.checkIfUserExists("Nehora") == false)
            {
                database.addUser(new User("Nehora", "Nehora", "Messika", "1234", "Married", "12/12/2000", "Somewhere over the rainbow", "Ask", "Let me sleep!"));
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
        }
    }
}
