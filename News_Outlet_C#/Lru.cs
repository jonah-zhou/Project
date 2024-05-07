using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Project
{
    public class Lru
    {

        const int MAX_SIZE = 1000;
        static Queue<int> queue = new Queue<int>(MAX_SIZE);
        static List<News> lruCache = new List<News>();
        int lastProcessedIndex = 0;
        public List<News> LruCache(List<News> newsList)
        {
            int count = 0;
            foreach (News anews in newsList.Skip(lastProcessedIndex))
            {
                if (queue.Count < MAX_SIZE)
                {
                    queue.Enqueue(anews.Id);
                    lruCache.Add(anews);
                }
                else
                {
                    if (queue.Contains(anews.Id)) //if id exsit, no need to add news to cache
                    {
                        queue.Dequeue();
                        queue.Enqueue(anews.Id);
                    }
                    else
                    {
                        int removedNewsId = queue.Dequeue(); //dequeue the first element
                        queue.Enqueue(anews.Id);
                        lruCache.Remove(lruCache.First(n => n.Id == removedNewsId)); // delete news with id equeal to the one dequeued
                        lruCache.Add(anews);
                    }
                }
                count++;
                if (count >= MAX_SIZE) //everytime only load max_size of news
                {
                    lastProcessedIndex += count;
                    break;
                }
            }
            //foreach (News anews in lruCache)
            //{
            //    Console.WriteLine(anews.ToString());
            //}
            return lruCache;
        }
    }
}
