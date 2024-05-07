using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechClassLibrary.BLL;
namespace HiTechClassLibrary.DAL
{
    public static class AuthorBookDB
    {
        public static SqlCommand GetAllRecordsCommand()
        {
            SqlConnection conn = UtilityDB.GetConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM AuthorsBooks;", conn);
            return cmd;
        }
        public static List<AuthorBook> GetAllRecords()
        {
            List<AuthorBook> listAB = new List<AuthorBook>();
            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM AuthorsBooks;", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader();
            AuthorBook authorBook;
            while (reader.Read())
            {
                authorBook = new AuthorBook();
                authorBook.Isbn = reader["ISBN"].ToString();
                authorBook.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                authorBook.YearPublished = reader["YearPublished"].ToString();
                authorBook.Edition = reader["Edition"].ToString();
                
                listAB.Add(authorBook);
            }
            return listAB;
        }
    }
}
