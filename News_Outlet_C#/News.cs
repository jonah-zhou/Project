using System;

namespace Final_Project
{
    public class News
    {
        private int id;
        private long time;
        private string content;
        private string[] keywords;
        private int hits;
        public News() { }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public long Time
        {
            get { return time; }
            set { time = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public string[] Keywords
        {
            get { return keywords; }
            set { keywords = value; }
        }

        public int Hits
        {
            get { return hits; }
            set { hits = value; }
        }

        public override string ToString()
        {
            //return $"ID: {Id} || Time: {DateTrans(Time)} || Content: {Content} || Keywords: {string.Join(", ",Keywords)} || Hits: {Hits}";
            return $"ID: {Id} || Time: {DateTrans(Time)} || Keywords: {string.Join(", ", Keywords)} || Hits: {Hits}";
        }

        public DateTime DateTrans(long time)
        {
            DateTime dateTime = new DateTime(1970, 1, 1).AddSeconds(time).ToLocalTime();
            return dateTime;
        }

    }
}
