using HiTechClassLibrary.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTechClassLibrary.DAL
{
    public static class BookDB
    {
        public static SqlCommand GetAllRecordsCommand()
        {
            SqlConnection conn = UtilityDB.GetConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Books;",conn);
            return cmd;
        }
        public static List<Book> GetAllRecords()
        {
            List<Book> listB = new List<Book>();
            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Books;", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader();
            Book book;
            while (reader.Read())
            {
                book = new Book();
                book.Isbn = reader["ISBN"].ToString();
                book.BookTitle = reader["BookTitle"].ToString();
                book.UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                book.Qoh = Convert.ToInt32(reader["QOH"]);
                book.PublisherId = Convert.ToInt32(reader["PublisherId"]);
                book.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                book.Status = Convert.ToInt32(reader["Status"]);
                listB.Add(book);
            }
            return listB;
        }
    }
}
