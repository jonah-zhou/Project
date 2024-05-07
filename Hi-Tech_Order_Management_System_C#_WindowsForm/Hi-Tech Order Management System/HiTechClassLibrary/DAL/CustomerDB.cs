using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using HiTechClassLibrary.BLL;

namespace HiTechClassLibrary.DAL
{
    public static class CustomerDB
    {

        public static List<Customer> GetAllRecords()
        {
            List<Customer> ListC = new List<Customer>();

            using (SqlConnection connection = UtilityDB.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                Customer c;
                while (reader.Read())
                {
                    c = new Customer();
                    c.CustomerID = reader.GetInt32(0);
                    c.CustomerName = reader.GetString(1);
                    c.StreetName = reader.GetString(2);
                    c.Province = reader.GetString(3);
                    c.City = reader.GetString(4);
                    c.PostalCode = reader.GetString(5);
                    c.PhoneNumber = reader.GetString(6);
                    c.ContactName = reader.GetString(7);
                    c.ContactEmail = reader.GetString(8);
                    c.CreditLimit = reader.GetInt32(9);
                    c.Status = reader.GetInt32(10);
                    ListC.Add(c);
                }
            }
            return ListC;
        }

        public static SqlCommand GetAllRecordsFromTable()
        {
            SqlCommand sqlcom = new SqlCommand("SELECT * FROM Customers", UtilityDB.GetConnection());
            return sqlcom;
        }
    }
}
