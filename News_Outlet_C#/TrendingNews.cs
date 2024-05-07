using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class TrendingNews
    {
        //input show trending + keywords
        public static void GetTrendingNews(List<News> newsList, int displayCount, string[] keywords)
        {

            Stack<News> newsStack = new Stack<News>();
           
            var filteredNews = newsList.Where(news => keywords.Any(keyword => news.Keywords.Any(k => k.Contains(keyword)))).OrderBy(news => news.Hits);

            foreach (var newsItem in filteredNews)
            {
                newsStack.Push(newsItem);
            }
            int count = 0;
            Console.WriteLine("----Trending news from the most hits----");
            while (newsStack.Count > 0 && count < displayCount)
            {
                var newsItem = newsStack.Pop();
                Console.WriteLine(newsItem.ToString());
                count++;

            }           
        }

        //input show trending only
        public static void GetTrendingNews(List<News> newsList, int displayCount)
        {

            Stack<News> newsStack = new Stack<News>();

            var eorderedNews = newsList.OrderBy(news => news.Hits);

            foreach (var newsItem in eorderedNews)
            {
                newsStack.Push(newsItem);
            }
            int count = 0;
            Console.WriteLine("----Trending news from the most hits----");
            while (newsStack.Count > 0 && count < displayCount)
            {
                var newsItem = newsStack.Pop();
                Console.WriteLine(newsItem.ToString());
                count++;

            }
        }

        //input show trending + time
        public static void GetTrendingNews(List<News> newsList, int displayCount, DateTime specifiedTime)
        {

            Stack<News> newsStack = new Stack<News>();

            var filteredNews = newsList.OrderBy(news => news.Hits);

            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long unixTimestamp = (long)(specifiedTime.ToUniversalTime() - epoch).TotalSeconds;

            foreach (var newsItem in filteredNews)
            {
                if(newsItem.Time >= unixTimestamp && newsStack.Count < displayCount)
                {
                    newsStack.Push(newsItem);
                }
            }
            int count = 0;
            Console.WriteLine("----Trending news from the most hits----");
            while (newsStack.Count > 0 && count < displayCount)
            {
                var newsItem = newsStack.Pop();
                Console.WriteLine(newsItem.ToString());
                count++;

            }
        }

        //show trending + keywords + time
        public static void GetTrendingNews(List<News> newsList, int displayCount, string[] keywords, DateTime specifiedTime)
        {

            Stack<News> newsStack = new Stack<News>();

            var filteredNews = newsList.Where(news => keywords.Any(keyword => news.Keywords.Any(k => k.Contains(keyword)))).OrderBy(news => news.Hits);

            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long unixTimestamp = (long)(specifiedTime.ToUniversalTime() - epoch).TotalSeconds;

            foreach (var newsItem in filteredNews)
            {
                if (newsItem.Time >= unixTimestamp && newsStack.Count < displayCount)
                {
                    newsStack.Push(newsItem);
                }
            }
            int count = 0;
            Console.WriteLine("----Trending news from the most hits----");
            while (newsStack.Count > 0 && count < displayCount)
            {
                var newsItem = newsStack.Pop();
                Console.WriteLine(newsItem.ToString());
                count++;

            }
        }
    }
}
