using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Final_Project
{
    public class RecentNews
    {
        //only input show recent
        public static void GetRecentNews(List<News> newsList, int displayCount, DateTime currentTime)
        {

            Stack<News> newsStack = new Stack<News>();

            var sortedNews = newsList.OrderBy(news => news.Time);//sort news by time from oldest to newest

            DateTime timeLimit = currentTime.AddHours(-24);
            //long unixTimestamp = timeLimit.ToUnixTimeSeconds();
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long unixTimestamp = (long)(timeLimit.ToUniversalTime() - epoch).TotalSeconds;

            foreach (var newsItem in sortedNews)
            {
                if (newsItem.Time >= unixTimestamp && newsStack.Count < displayCount)
                {
                    newsStack.Push(newsItem);
                }
            }
            Console.WriteLine("----Recent news from the last 24 hours----");
            while (newsStack.Count > 0)
            {
                var newsItem = newsStack.Pop();
                Console.WriteLine(newsItem.ToString());
            }

        }

        //input show recent + keywords
        public static void GetRecentNews(List<News> newsList, int displayCount, string[] keywords, DateTime currentTime)
        {

            Stack<News> newsStack = new Stack<News>();

            var sortedNews = newsList.Where(news => keywords.Any(keyword => news.Keywords.Any(k => k.Contains(keyword)))).OrderBy(news => news.Time);

            DateTime timeLimit = currentTime.AddHours(-24);
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long unixTimestamp = (long)(timeLimit.ToUniversalTime() - epoch).TotalSeconds;

            foreach (var newsItem in sortedNews)
            {
                if (newsItem.Time >= unixTimestamp && newsStack.Count < displayCount)
                {
                    newsStack.Push(newsItem);
                }
            }
            Console.WriteLine("----Recent news from the last 24 hours----");
            while (newsStack.Count > 0)
            {
                var newsItem = newsStack.Pop();
                Console.WriteLine(newsItem.ToString());
            }

        }


        //input show recent + time
        public static void GetRecentNews(List<News> newsList, int displayCount, DateTime currentTime, DateTime specifiedTime)
        {

            Stack<News> newsStack = new Stack<News>();

            var sortedNews = newsList.OrderBy(news => news.Time);//sort news by time from oldest to newest

            DateTime timeLimit = currentTime.AddHours(-24);

            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long unixTimestamp = (long)(timeLimit.ToUniversalTime() - epoch).TotalSeconds;
            long unixTimestamp2 = (long)(specifiedTime.ToUniversalTime() - epoch).TotalSeconds;

            foreach (var newsItem in sortedNews)
            {
                if (newsItem.Time >= unixTimestamp && newsItem.Time < unixTimestamp2 && newsStack.Count < displayCount)
                {
                    newsStack.Push(newsItem);
                }
            }
            Console.WriteLine("----Recent news from the last 24 hours----");
            while (newsStack.Count > 0)
            {
                var newsItem = newsStack.Pop();
                Console.WriteLine(newsItem.ToString());
            }

        }

        //input show recent + keywords + time
        public static void GetRecentNews(List<News> newsList, int displayCount, string[] keywords, DateTime currentTime, DateTime specifiedTime)
        {

            Stack<News> newsStack = new Stack<News>();

            var sortedNews = newsList.Where(news => keywords.Any(keyword => news.Keywords.Any(k => k.Contains(keyword)))).OrderBy(news => news.Time);

            DateTime timeLimit = currentTime.AddHours(-24);

            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long unixTimestamp = (long)(timeLimit.ToUniversalTime() - epoch).TotalSeconds;
            long unixTimestamp2 = (long)(specifiedTime.ToUniversalTime() - epoch).TotalSeconds;

            foreach (var newsItem in sortedNews)
            {
                if (newsItem.Time >= unixTimestamp && newsItem.Time < unixTimestamp2 && newsStack.Count < displayCount)
                {
                    newsStack.Push(newsItem);
                }
            }
            Console.WriteLine("----Recent news from the last 24 hours----");
            while (newsStack.Count > 0)
            {
                var newsItem = newsStack.Pop();
                Console.WriteLine(newsItem.ToString());
            }

        }
    }
}
