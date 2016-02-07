using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.source
{
    class StringChecks
    {
        public static bool isEmpty(String str)
        {
            if(str == null)
            {
                return true;
            }

            return false;
        }

        public static String isLettersAndWhiteSpace(String str)
        {
            if (isEmpty(str) == true)
            {
                return "String is empty";
            }

            if(str.Any(Char.IsDigit) == true)
            {
                return "No digits allowed";
            }

            if (str.Any(Char.IsLetter) == false)
            {
                return "You must enter letters";
            }
            return null;
        }

        public static String isVarChar(String varchar) // לשימוש של מחרוזות שמכילות מספרים, רווחים ואותיות
        {
            if(isEmpty(varchar) == true)
            {
                return "String is empty";
            }

            if(varchar.Any(Char.IsLetterOrDigit) == false)
            {
                return "Must contain at letters or digits";
            }

            return null;
        }

        public static String anyWhiteSpace(String str) // לשימוש עם משתמשים וסיסמאות
        {
            if (isEmpty(str) == true)
            {
                return "String is empty";
            }

            if (str.Any(Char.IsWhiteSpace) == true)
            {
                return "No whitespaces allowed";
            }

            return null;
        }
    }
}
