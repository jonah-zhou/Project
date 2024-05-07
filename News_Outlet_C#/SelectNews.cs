using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Final_Project
{
    internal class SelectNews
    {
        public static void SelectNewsById(List<News> newsList, int id, Stack<News> prev)
        {
            News selectedNews = newsList.FirstOrDefault(n => n.Id == id);
            //check the id exsit or not
            if (selectedNews == null)
            {
                Console.WriteLine("News ID does not exsit.");
            }
            else
            {
                //print the selected news and hits+1
                Console.WriteLine("Id: " + selectedNews.Id + "\nContent: " + selectedNews.Content + "\nHits" + selectedNews.Hits);
                selectedNews.Hits++;

                // put the selected news in th stack
                prev.Push(selectedNews);

                //write back hits to json
                string json = File.ReadAllText("../../files/EXAM_MOCK_DATA.json");
                List<News> updated = JsonConvert.DeserializeObject<List<News>>(json);
                int index = updated.FindIndex(n => n.Id == selectedNews.Id);
                updated[index] = selectedNews;
                string updatedJson = JsonConvert.SerializeObject(updated, Formatting.Indented);
                File.WriteAllText("../../files/EXAM_MOCK_DATA.json", updatedJson);

            }
        }
    }
}
