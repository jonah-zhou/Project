using HiTechClassLibrary.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTechClassLibrary.DAL
{
    public static class AuthorDB
    {
        public static SqlCommand GetAllRecordsCommand()
        {
            SqlConnection conn = UtilityDB.GetConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Authors;", conn);
            return cmd;
        }
        public static List<Author> GetAllRecords()
        {
            List<Author> listA = new List<Author>();
            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Authors;", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader();
            Author author;
            while (reader.Read())
            {
                author = new Author();
                author.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                author.FirstName = reader["FirstName"].ToString();
                author.LastName = reader["LastName"].ToString();
                author.Email = reader["Email"].ToString();
                listA.Add(author);
            }
            return listA;
        }
    }
}
