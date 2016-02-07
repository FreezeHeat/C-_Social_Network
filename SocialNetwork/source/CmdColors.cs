//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SocialNetwork
//{
//    sealed class CmdColors
//    {
//        public void menu() // שינוי צבעים
//        {
//            String text;
//            String background;

//            Console.Clear(); //ניקוי מסך

//            Console.WriteLine("Please choose a text color and then a background color");
//            Console.Write("1) White\n" +
//                            "2) Black\n" +
//                            "3) Blue\n" +
//                            "4) Green\n" +
//                            "5) Red\n" +
//                            "6) Yellow\n" +
//                            "7) Gray\n" +
//                            "8) Magenta\n" +
//                            "9) Cyan\n" +
//                            "10) Reset Colors\n\n" +
//                            "0) Exit Menu\n");

//            Console.Write("\nText: ");
//            text = Console.ReadLine();

//            if (text == "0") return; // בדיקת קצה - אם רוצה לשנות לברירת מחדל או לצאת
//            else if (text == "10")
//            {
//                setColours("7", "2");
//                return;
//            }

//            Console.Write("\nBackground: ");
//            background = Console.ReadLine();
//            if (background == "0") return;// בדיקת קצה - אם רוצה לשנות לברירת מחדל או לצאת
//            else if (background == "10")
//            {
//                setColours("7", "2");
//                return;
//            }
//            Console.WriteLine(); // ירידת שורה

//            setColours(text, background);
//        }

//        private void setColours(String text, String background) // ברירת מחדל זה טקטס לבן ורקע שחור
//        {
//            ConsoleColor [] colors = new ConsoleColor [2];

//            Console.Clear(); //ניקוי מסך

//            if (text == background)
//            {
//                Console.WriteLine("Background and Text can't be of the same color!"); // אסור ששני הצבעים יהיו אותו דבר, אחרת לא יראו כלום
//                return;
//            }


//            else // אם נבחרו צבעים בצורה תקינה
//            {

//                switch (text)
//                {
//                    case "1":
//                        colors[0] = ConsoleColor.White;
//                        break;
//                    case "2":
//                        colors[0] = ConsoleColor.Black;
//                        break;
//                    case "3":
//                        colors[0] = ConsoleColor.Blue;
//                        break;
//                    case "4":
//                        colors[0] = ConsoleColor.Green;
//                        break;
//                    case "5":
//                        colors[0] = ConsoleColor.Red;
//                        break;
//                    case "6":
//                        colors[0] = ConsoleColor.Yellow;
//                        break;
//                    case "7":
//                        colors[0] = ConsoleColor.Gray;
//                        break;
//                    case "8":
//                        colors[0] = ConsoleColor.Magenta;
//                        break;
//                    case "9":
//                        colors[0] = ConsoleColor.Cyan;
//                        break;
//                    default:
//                        break;
//                }

//                switch (background)
//                {
//                    case "1":
//                        colors[1] = ConsoleColor.White;
//                        break;
//                    case "2":
//                        colors[1] = ConsoleColor.Black;
//                        break;
//                    case "3":
//                        colors[1] = ConsoleColor.Blue;
//                        break;
//                    case "4":
//                        colors[1] = ConsoleColor.Green;
//                        break;
//                    case "5":
//                        colors[1] = ConsoleColor.Red;
//                        break;
//                    case "6":
//                        colors[1] = ConsoleColor.Yellow;
//                        break;
//                    case "7":
//                        colors[1] = ConsoleColor.Gray;
//                        break;
//                    case "8":
//                        colors[1] = ConsoleColor.Magenta;
//                        break;
//                    case "9":
//                        colors[1] = ConsoleColor.Cyan;
//                        break;
//                    default:
//                        break;
//                }

//                Console.ForegroundColor = colors[0]; // טקסט
//                Console.BackgroundColor = colors[1]; // רקע
//            }
//        }
//    }
//}
