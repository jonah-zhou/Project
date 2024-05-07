using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    internal class Back
    {

        // in the stack go back to the prev news
        public static void PrevNews(Stack<News> prev)
        {
            if (prev.Count < 2)
            {
                Console.WriteLine("No more previous news.");
            }
            else
            {
                prev.Pop();
                News previous = prev.Peek(); // Get the previous news item without removing it
                Console.WriteLine("Back to previous news: Id: " + previous.Id + "\nContent: " + previous.Content + "\nHits" + previous.Hits);
            }
        }
    }
}
