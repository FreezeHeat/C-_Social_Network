//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SocialNetwork
//{
//    sealed class PostList : IBackup
//    {
//        private List<Post> postlist = new List<Post>();
//        private List<Post> backup; // גיבוי
//        private DateTime backupTime; // זמן גיבוי
//        private Database database = Database.getDatabase();

//        public List<Post> Posts
//        {
//            get{ return this.postlist; }
//        }

//        public String BackupTime
//        {
//            get { return this.backup.ToString(); }
//        }

//        public List<Post> Backup
//        {
//            get { return this.backup; }
//        }
//        //public void Mainmenu(int id)
//        //{
//        //    do
//        //    {
//        //        Console.Clear();

//        //        User user = (User)database.Accounts[id];
//        //        String choise;
//        //        Console.WriteLine("                             hello and welcome to post menu");
//        //        Console.WriteLine("1)Create post");
//        //        Console.WriteLine("2)Delete post");
//        //        Console.WriteLine("3)Read post of other users");
//        //        Console.WriteLine("4)Backup your posts");
//        //        Console.WriteLine("5)Restore your posts");
//        //        Console.WriteLine("6)Exit");
//        //        Console.WriteLine();
//        //        Console.WriteLine("please make your choise");


//        //        choise = Console.ReadLine();
//        //        switch (choise)
//        //        {
//        //            case "1":
//        //                Console.Clear();
//        //                CreatePost(id); // יצירת פוסט
//        //                break;
//        //            case "2":
//        //                Console.Clear();
//        //                DeletePost(id, user.posts.postlist.Count - 1); // מחיקת פוסט
//        //                Console.WriteLine("Press any key to continue");
//        //                Console.ReadKey();
//        //                break;
//        //            case "3":
//        //                Console.Clear();
//        //                ReadPost(); // קריאת פוסט
//        //                break;
//        //            case "4":
//        //                Console.Clear();
//        //                createBackup(); // יצירת גיבוי
//        //                Console.WriteLine("Press any key to continue");
//        //                Console.ReadKey();
//        //                break;
//        //            case "5":
//        //                Console.Clear();
//        //                restoreBackup(); // שחזור גיבוי
//        //                Console.WriteLine("Press any key to continue");
//        //                Console.ReadKey();
//        //                break;
//        //            case "6":
//        //                return;
//        //                break;
//        //            default:
//        //                Console.WriteLine("Wrong Choice");
//        //                break;
//        //        }
//        //    }
//        //    while (true); // לולאה אין סופית
//        //}

//        //private void CreatePost(int id, String post) // יצירת פוסט *נערך לטופס
//        //{
//        //    User user = (User)database.Accounts[id];

//        //    user.posts.postlist.Add(new Post(user.Username, post)); // הוספת הפוסט לרשימה

//        //    return;
//        //}

//        //private void DeletePost(int id, int location) // מחיקת פוסט *נערך לטופס
//        //{
//        //    User user = (User)database.Accounts[id];
//            //user.posts.Posts.RemoveAt(location);
//        //}
//        //private void ReadPost()///אין צורך בלוקיישן או במתודה בוליאנית לדעתי כי פתרתי את הבעיה לשיקולך האישי
//        //{
//        //    User user;
//        //    Console.WriteLine("Please enter one or more usernames which you wish to view his\\their posts\n" + "for one person just enter the name and press enter\n" +
//        //        "for more users add ',' after each name i.e: {0}", "Amar,Asaf");
//        //    string choise = Console.ReadLine();
//        //    string[] choises;
//        //    while (true)
//        //    {
            
//        //        if (choise.Contains(','))
//        //        {
//        //            choises = choise.Split(',');
//        //                break;
//        //        }
//        //        else 
//        //        {
//        //            choises = new String[1];
//        //            choises[0] = choise;
//        //            break;
//        //        }
//        //    }
//        //    for (int i = 0; i < choises.Length; i++)// בדיקה האם מכיל ערך אמיתי שקיים והאם הוא משתמש
//        //    {

//        //        if (database.Accounts.Exists(temp => temp.Username.Equals(choises[i]))&& database.Accounts[(database.Accounts.FindIndex(temp => temp.Username.Equals(choises[i])))].Permission==0)
//        //        {
//        //            user = (User)database.Accounts[database.Accounts.FindIndex(temp => temp.Username.Equals(choises[i]))];
//        //        }
//        //        else
//        //        {
//        //            Console.WriteLine("one or more parameters dosent exist");
//        //            break;
//        //        }
//        //        if (user.posts.postlist.Count > 0)//אם כמות האובייקטים ברשימת הפוסטים גדולה מ0  תכנס
//        //        {
//        //            int post = user.posts.postlist.Count - 1;
//        //            while (post!= -1)//כניסה ללולאה של הדפסה לפי האיבר במערך
//        //            {

//        //                Console.WriteLine("we found {0} and here is the post", choises[i]);
//        //                Console.WriteLine("");
//        //                Console.WriteLine("{0}", user.posts.postlist[post]);
//        //                Console.WriteLine("");
//        //                if (post - 1 != -1)// כל עוד יש איברים ברשימת הפוסטים של האיבר במערך תמשיך
//        //                {
//        //                    while (true)
//        //                    {
//        //                        Console.WriteLine("do you want to go to the next post?(yes/no)");
//        //                        String choise2 = Console.ReadLine();
//        //                        if (choise2 == "no")
//        //                        {
//        //                            post = post - user.posts.postlist.Count;
//        //                            break;
//        //                        }
//        //                        else if (choise2 == "yes")
//        //                        {
//        //                            post = post - 1;
//        //                            break;
//        //                        }
//        //                        else
//        //                            Console.WriteLine("worng choise");
//        //                    }

//        //                }
//        //                else
//        //                {
//        //                    Console.WriteLine("end of posts");
//        //                    Console.WriteLine("when you wish to exit press e");
//        //                    while (true)
//        //                    {
//        //                        String choise2 = Console.ReadLine();
//        //                        if (choise2 == "e")
//        //                        {
//        //                            post -= 1;
//        //                            break;
//        //                        }
//        //                        else
//        //                            Console.WriteLine("worng choise");

//        //                    }


//        //                }
//        //            }
//        //        }
//        //        else
//        //        {
//        //            Console.WriteLine("end of posts");
//        //            Console.WriteLine("when you wish to exit press e");
//        //            while (true)
//        //            {
//        //                String choise2 = Console.ReadLine();
//        //                if (choise2 == "e")
//        //                {
                            
//        //                    break;
//        //                }
//        //                else
//        //                    Console.WriteLine("worng choise");

//        //            }



//        //        }
               
//        //    }
//        //        return;
//        //}

//        public void createBackup() // יצירת גיבוי
//        {
//            //if (this.postlist.Count == 0) // אם אין מה לגבות
//            //{
//            //    return;
//            //}

//            //if (this.backup != null) // אם הגיבוי לא ריק
//            //    this.backup.Clear(); // מנקה את הרשימה

//            this.backup = new List<Post>(this.postlist); // גיבוי הרשימה
//            this.backupTime = DateTime.Now; // רישום זמן גיבוי
//        }

//        public void restoreBackup() // שחזור גיבוי
//        {
//            //if (this.backup == null) // משתמש מנסה לשחזר כאשר אין גיבוי בכלל
//            //{
//            //    Console.WriteLine("There's no restore point... you must have a backup to restore to");
//            //    return;
//            //}

//            //Console.WriteLine("Are you sure you want to restore to previous state:");
//            //Console.WriteLine("Created in: " + this.backupTime.ToString());
//            //Console.WriteLine("Enter 'yes' if you wish to continue, anything else will cancel this action");
//            //String input = Console.ReadLine();

//            //if (input == "yes")
//            //{
//                this.postlist.Clear(); // ניקוי רשימה
//                this.postlist = new List<Post>(this.backup); // שחזור גיבוי
//                //Console.WriteLine("Backup successful!");
//            //}
//            //else { Console.WriteLine("Backup cancelled!"); }
//        }
//    }
//}

