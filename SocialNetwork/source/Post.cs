using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    public sealed class Post
    {
        private int id; 
        private String source; 
        private String content; 
        private DateTime date;  

        public Post (int id, String source, String post)
        {
            this.id = id;
            Source = source;
            Content = post;
            date = DateTime.Now;
        }

        public Post(String source, String post)
        {
            Source = source;
            Content = post;
            date = DateTime.Now;
        }

        public int ID
        {
            get { return this.id; }
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
