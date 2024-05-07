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
    public static class UserAccountDB
    {
        public static UserAccount GetRecordById(int id)
        {
            UserAccount userAccount;
            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM UserAccounts WHERE UserId = @userId;", conn);
            cmdSelect.Parameters.AddWithValue("@userId", id);
            SqlDataReader reader = cmdSelect.ExecuteReader();
            if (reader.Read())
            {
                userAccount = new UserAccount();
                userAccount.UserId = Convert.ToInt32(reader["UserId"]);
                userAccount.Password = reader["Password"].ToString();
                userAccount.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
            }
            else
            {
                userAccount = null;
            }
            conn.Close();
            return userAccount;
        }
        public static void SaveRecord(UserAccount userAccount)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdSave = new SqlCommand("INSERT INTO UserAccounts VALUES (@userId,@password,@employeeId);", conn);
            cmdSave.Parameters.AddWithValue("@userId", userAccount.UserId);
            cmdSave.Parameters.AddWithValue("@password", userAccount.Password);
            cmdSave.Parameters.AddWithValue("@employeeId", userAccount.EmployeeId);
            cmdSave.ExecuteNonQuery();
            conn.Close();
        }
        public static List<UserAccount> GetAllRecords()
        {
            UserAccount userAccount;
            List<UserAccount> listUA = new List<UserAccount>();
            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM UserAccounts;", conn);

            SqlDataReader reader = cmdSelect.ExecuteReader();
            while (reader.Read())
            {
                userAccount = new UserAccount();
                userAccount.UserId = Convert.ToInt32(reader["UserId"]);
                userAccount.Password = reader["Password"].ToString();
                userAccount.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                listUA.Add(userAccount);
            }

            conn.Close();
            return listUA;
        }
        public static void UpdateRecord(UserAccount userAccount)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            conn.Open();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = conn;
            cmdUpdate.CommandText = "UPDATE UserAccounts SET Password = @password WHERE UserId = @userId";
            cmdUpdate.Parameters.AddWithValue("@password", userAccount.Password);
            cmdUpdate.Parameters.AddWithValue("@userId", userAccount.UserId);
            cmdUpdate.ExecuteNonQuery(); //when insert, update, delete, returns the number of rows affected
            conn.Close();
        }
        public static void DeleteRecord(int userId)
        {
            SqlConnection conn = UtilityDB.ConnectDB();

            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = conn;
            cmdDelete.CommandText = "DELETE FROM UserAccounts WHERE UserId = @UserId";
            cmdDelete.Parameters.AddWithValue("@UserId", userId);
            conn.Open();
            cmdDelete.ExecuteNonQuery();
            conn.Close();
        }
        public static List<UserAccount> SearchRecord(int id)
        {

            List<UserAccount> listUA = new List<UserAccount>();

            SqlConnection conn = UtilityDB.ConnectDB();

            SqlCommand cmdSearchByID = new SqlCommand();
            cmdSearchByID.Connection = conn;
            conn.Open();
            cmdSearchByID.CommandText = "SELECT * FROM UserAccounts " + "WHERE UserId = @userId";
            cmdSearchByID.Parameters.AddWithValue("@userId", id);
            
            SqlDataReader reader = cmdSearchByID.ExecuteReader();
            UserAccount userAccount;
            while (reader.Read())
            {
                userAccount= new UserAccount();
                userAccount.UserId = Convert.ToInt32(reader["UserId"]);
                userAccount.Password = reader["Password"].ToString();
                userAccount.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                listUA.Add(userAccount);
            }
            conn.Close();
            return listUA;
        }
    }
}
