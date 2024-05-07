using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Final_Project
{
    internal class Program
    {


        static void Main(string[] args)
        {
            string json = File.ReadAllText("../../files/EXAM_MOCK_DATA.json");
            List<News> anewsList = JsonConvert.DeserializeObject<List<News>>(json);

            //foreach (News anews in newsList)
            //{
            //    Console.WriteLine(anews.ToString());
            //}
            Lru lru = new Lru();
            List<News> newsList = lru.LruCache(anewsList);// fetch only 1000 news from Original list

            int displayCount = 500;
            DateTime currentTime = DateTime.Now;
            Stack<News> prev = new Stack<News>();//for back

            while (true)
            {
                Console.WriteLine("\n******Welcome to News Outlet!******");
                Console.WriteLine("\nPlease Enter your command(SHOW/SELECT/BACK/REFRESH/SET/EXIT): ");
                string[] input = Console.ReadLine().Split(' ');

                if (input[0].ToUpper() == "SHOW")
                {
                    if (input[1].ToLower() == "recent")
                    {
                        if (input.Length > 2 && input[2] == "--keywords" && input.Length > 3)
                        {
                            string[] keywords = input[3].Split(',');
                            if (input.Length > 4 && input[4] == "--time" && input.Length > 5) //show recent --keywords --time
                            {
                                DateTime specifiedTime = DateTime.ParseExact(input[5], "yyyy-M-d:HH:mm:ss", CultureInfo.InvariantCulture);
                                RecentNews.GetRecentNews(newsList, displayCount, keywords, currentTime, specifiedTime);
                            }
                            else //show recent --keywords
                            {
                                RecentNews.GetRecentNews(newsList, displayCount, keywords, currentTime);
                            }
                        }
                        else if (input.Length > 2 && input[2] == "--time" && input.Length > 3) //show recent --time
                        {
                            DateTime specifiedTime = DateTime.ParseExact(input[3], "yyyy-M-d:HH:mm:ss", CultureInfo.InvariantCulture);
                            RecentNews.GetRecentNews(newsList, displayCount, currentTime, specifiedTime);
                        }
                        else if (input.Length == 2) //show recent
                        {
                            RecentNews.GetRecentNews(newsList, displayCount, currentTime);
                        }
                        else
                        {
                            Console.WriteLine("Invalid parameters.");
                        }
                    }
                    else if (input[1].ToLower() == "trending")
                    {
                        if (input.Length > 2 && input[2] == "--keywords" && input.Length > 3)
                        {
                            string[] keywords = input[3].Split(',');
                            if (input.Length > 4 && input[4] == "--time" && input.Length > 5) //show trending --keywords --time
                            {
                                DateTime specifiedTime = DateTime.ParseExact(input[5], "yyyy-M-d:HH:mm:ss", CultureInfo.InvariantCulture);
                                TrendingNews.GetTrendingNews(newsList, displayCount, keywords, specifiedTime);
                            }
                            else
                            {
                                TrendingNews.GetTrendingNews(newsList, displayCount, keywords); //show trending --keywords
                            }
                        }
                        else if (input.Length > 2 && input[2] == "--time" && input.Length > 3) //show trending --time
                        {
                            DateTime specifiedTime = DateTime.ParseExact(input[3], "yyyy-M-d:HH:mm:ss", CultureInfo.InvariantCulture);
                            TrendingNews.GetTrendingNews(newsList, displayCount, specifiedTime);
                        }
                        else if (input.Length == 2) //show trending
                        {
                            TrendingNews.GetTrendingNews(newsList, displayCount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid parameters.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid command.");
                    }
                }
                else if (input[0].ToUpper() == "SELECT")
                {

                    if (input.Length > 1)
                    {
                        int id = int.Parse(input[1]);
                        SelectNews.SelectNewsById(newsList, id, prev);
                    }
                    else
                    {
                        Console.WriteLine("Invalid parameters.");
                    }
                }
                else if (input[0].ToUpper() == "BACK")
                {
                    Back.PrevNews(prev);

                }
                else if (input[0].ToUpper() == "REFRESH")
                {
                    newsList = lru.LruCache(anewsList);
                }
                else if (input[0].ToUpper() == "SET")
                {
                    if (input[1].ToLower() == "time")
                    {
                        currentTime = DateTime.ParseExact(input[2], "yyyy-M-d:HH:mm:ss", CultureInfo.InvariantCulture);
                        Console.WriteLine("current time set to " + currentTime);

                    }
                    else if (input[1].ToLower() == "dispalycount")
                    {
                        displayCount = Convert.ToInt32(input[2]);
                        Console.WriteLine("Display count set to " + displayCount);
                    }
                }
                else if (input[0].ToUpper() == "EXIT")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid command. Please enter again: ");
                }

            }
        }
    }
}
