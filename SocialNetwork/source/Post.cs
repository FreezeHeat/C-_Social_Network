using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    sealed class Post
    {
        private String source; // מפיץ הפוסט
        private String content; // תוכן הפוסט
        private DateTime date;  // תאריך הפצה

        public Post (String source, String post)
        {
            Source = source;
            Content = post;
            date = DateTime.Now;
        }

        public String Source
        {
            get { return this.source; }
            set { this.source = value; }
        }

        public String Content
        {
            get { return this.content; }
            set { this.content = value; }
        }

        public String Date
        {
            get { return date.ToString("dd/MM/yyyy"); }
        }

        public override string ToString()
        {
            return this.source + " " + this.date.ToString() + "\r\n\r\n" + this.content;
        }

    }
}
