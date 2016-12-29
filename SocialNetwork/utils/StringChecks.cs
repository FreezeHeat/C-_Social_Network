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
            if(str == null || str == "")
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

        public static String isVarChar(String varchar) 
        {
            if(isEmpty(varchar) == true)
            {
                return "String is empty";
            }

            if(varchar.Any(Char.IsLetterOrDigit) == false)
            {
                return "Must contain letters or digits";
            }

            return null;
        }

        public static String anyWhiteSpace(String str) 
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

        public static String doubleApostrophy(String str)
        {
            String fixedString = "";

            foreach(char x in str)
            {
                fixedString += x;

                if (x == '\'')
                {
                    fixedString += "'";
                }
            }

            return fixedString;
        }
    }
}
