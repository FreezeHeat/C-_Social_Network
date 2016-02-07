//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Media;
//using System.IO;

//namespace SocialNetwork
//{
//    sealed class Playlist
//    {
//        public int Playasong() //מתודה כללית
//        {
//        Start: // רשימה של שירים > בדיקת השירים > בדיקה אם קיים > נגינה > אחרת > צא החוצה
//            List<String> songs = new List<String>();///list of the songs->checking the songs->if exist->play->else->break
//            String choise;
//            String song;
            
            
//            songs.Add("angels of clarity");
//            songs.Add("last goodbye");
//            songs.Add("Sorry for everything");
//            Console.WriteLine("hello and welcome to the playlist");
//            Console.WriteLine("here is a list of songs");
//            for (int i = 0; i < songs.Count; i++) // הדפסת השירים
//            {
//                Console.WriteLine("{0} {1}", (i+1) + ")", songs[i]);

//            }
//            Console.WriteLine("if you wish to hear one of our songs\njust press the number of the song and hit the enter button" +
//                "\n" + "or enter 'exit' to exit");
//            do
//            {
//                choise = Console.ReadLine();
//                if (choise == "exit")
//                    goto End;
//                else if (!choise.ToCharArray().All(char.IsDigit)) // בדיקת כל אות אם היא לא ספרה
//                {

//                    Console.WriteLine("bad input");
//                    return 0;
//                }

//                else if (Int32.Parse(choise) < songs.Count+1&& Int32.Parse(choise) > 0) // בדיקת קצה שנייה של בחירת השיר
//                {
//                    song = songs[Convert.ToInt32(choise) - 1];
//                    break;
//                }
//                Console.WriteLine("bad input");
//            }
//            while (true);
//            ;   
            
            



//            Console.Clear();
//            Console.WriteLine("{0} {1}", "the name of the song is ", song);
//            Console.WriteLine("if you wish to exit enter e");


//            SoundPlayer player = new SoundPlayer(Path.GetFullPath("..\\..\\" + song + ".wav")); // מגיע למיקום הפרוייקט בדיסק הקשיח, שם הנגן מחפש שירים
//            String exitbutton = "a";
//            player.PlayLooping();
//            while (exitbutton != "e")
//            {
//                Console.Clear();
//                Console.WriteLine("{0} {1}", "the name of the song is ", song);
//                Console.WriteLine("if you wish to stop the song and exit press e");
//                exitbutton = Console.ReadLine();
//                Console.WriteLine("sorry wrong typing");
//                Console.Clear();

//            }
         
//            player.Stop(); // עצירת הנגן
        
//            goto Start;  // חוזר למעלה לתווית אסמבלר


//        End: Console.Clear();
//            return 0;
//        }
        
//    }
//}
    


