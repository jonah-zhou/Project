using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace HiTechClassLibrary.DAL
{
    public static class UtilityDB
    {
        public static SqlConnection ConnectDB() //for conncected mode
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=JONAH-DELL\\SQLEXPRESS;database=HiTechDB;user=sa;password=3851545";

            // Add my String
            //conn.ConnectionString = @"server=MSI\SQLEXPRESS;database=HiTechDB;user=sa;password=johnkid123";
            //conn.ConnectionString = @"server=DESKTOP-2I68Q1F\SQLEXPRESS;database=HiTechDB;user=sa;password=johnkid123";

            return conn;
        }

        public static SqlConnection GetConnection() //for disconnected mode
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            connection.Open();
            return connection;
        }
    }
}
