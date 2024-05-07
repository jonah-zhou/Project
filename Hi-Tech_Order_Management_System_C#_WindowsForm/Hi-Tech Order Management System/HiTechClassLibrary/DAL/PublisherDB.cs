using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTechClassLibrary.BLL;
namespace HiTechClassLibrary.DAL
{
    public static class PublisherDB
    {
        public static SqlCommand GetAllRecordsCommand()
        {
            SqlConnection conn = UtilityDB.GetConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Publishers;", conn);
            return cmd;
        }
        public static void SaveRecord(Publisher publisher)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Publishers " +
                                                  "VALUES (@publisherId, @publisherName, @webAddress)", conn);
            cmdInsert.Parameters.AddWithValue("@publisherId", publisher.PublisherId);
            cmdInsert.Parameters.AddWithValue("@publisherName", publisher.PublisherName);
            cmdInsert.Parameters.AddWithValue("@webAddress", publisher.WebAddress);
            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }
        public static void UpdateRecord(Publisher publisher)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdUpdate = new SqlCommand("UPDATE Publishers SET  PublisherName = @publisherName, WebAddress = @webAddress WHERE PublisherId = @publisherId;",conn);
                                                  
            cmdUpdate.Parameters.AddWithValue("@publisherId", publisher.PublisherId);
            cmdUpdate.Parameters.AddWithValue("@publisherName", publisher.PublisherName);
            cmdUpdate.Parameters.AddWithValue("@webAddress", publisher.WebAddress);
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
        }
        public static List<Publisher> GetAllRecords()
        {
            List<Publisher> listP = new List<Publisher>();
            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Publishers;",conn);
            SqlDataReader reader  = cmdSelectAll.ExecuteReader();
            Publisher publisher;
            while (reader.Read())
            {
                publisher = new Publisher();
                publisher.PublisherId = Convert.ToInt32(reader["PublisherId"]);
                publisher.PublisherName = reader["PublisherName"].ToString();
                publisher.WebAddress = reader["WebAddress"].ToString();
                listP.Add(publisher);
            }
            return listP;
        }
        public static void DeleteRecord(Publisher publisher)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdDelete = new SqlCommand("DELETE FROM Publishers WHERE PublisherId = @publisherId;", conn);

            cmdDelete.Parameters.AddWithValue("@publisherId", publisher.PublisherId);
            cmdDelete.ExecuteNonQuery();
            conn.Close();
        }
        public static List<Publisher> GetRecordsBySearch(string search, string type)
        {
            
            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Publishers WHERE "+ type +" = @search;", conn);
            cmdSelect.Parameters.AddWithValue("@search", search);
            SqlDataReader reader = cmdSelect.ExecuteReader();
            Publisher publisher;
            List<Publisher> listP = new List<Publisher>();
            while (reader.Read())
            {
                publisher = new Publisher();
                publisher.PublisherId = Convert.ToInt32(reader["PublisherId"]);
                publisher.PublisherName = reader["PublisherName"].ToString();
                publisher.WebAddress = reader["WebAddress"].ToString();
                listP.Add(publisher);
            }
            conn.Close();
            return listP;
        }
    }
}
