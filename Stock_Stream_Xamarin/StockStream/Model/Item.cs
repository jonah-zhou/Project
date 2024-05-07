using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockStream.Model
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public int SearchCount { get; set; }

        public static void CreateItem (Item item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Item>();
                conn.Insert(item);
            }
        }
    }
}
