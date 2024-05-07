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
    public static class CategoryDB
    {
        public static SqlCommand GetAllRecordsCommand()
        {
            SqlConnection conn = UtilityDB.GetConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Categories;", conn);
            return cmd;
        }
        public static void SaveRecord(Category category)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Categories " +
                                                  "VALUES (@categoryId, @categoryName)", conn);
            cmdInsert.Parameters.AddWithValue("@categoryId", category.CategoryId);
            cmdInsert.Parameters.AddWithValue("@categoryName", category.CategoryName);
            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }
        public static void UpdateRecord(Category category)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdUpdate = new SqlCommand("UPDATE Categories SET  CategoryName = @categoryName WHERE CategoryId = @categoryId;", conn);

            cmdUpdate.Parameters.AddWithValue("@categoryId", category.CategoryId);
            cmdUpdate.Parameters.AddWithValue("@categoryName", category.CategoryName);
           
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
        }
        public static List<Category> GetAllRecords()
        {
            List<Category> listC = new List<Category>();
            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Categories;", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader();
            Category category;
            while (reader.Read())
            {
                category = new Category();
                category.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                category.CategoryName = reader["CategoryName"].ToString();
                
                listC.Add(category);
            }
            conn.Close();
            return listC;
        }
        public static void DeleteRecord(Category category)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdDelete = new SqlCommand("DELETE FROM Categories WHERE CategoryId = @categoryId;", conn);

            cmdDelete.Parameters.AddWithValue("@categoryId", category.CategoryId);
            cmdDelete.ExecuteNonQuery();
            conn.Close();
        }
        public static List<Category> GetRecordsBySearch(string search, string type)
        {

            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Categories WHERE "+ type +" = @search;", conn);
            cmdSelect.Parameters.AddWithValue("@search", search);
            SqlDataReader reader = cmdSelect.ExecuteReader();
            Category category;
            List <Category> listC = new List<Category>();   
            while (reader.Read())
            {
                category = new Category();
                category.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                category.CategoryName = reader["CategoryName"].ToString();
                listC.Add((category));

            }           
            conn.Close();
            return listC;

        }
    }
}
