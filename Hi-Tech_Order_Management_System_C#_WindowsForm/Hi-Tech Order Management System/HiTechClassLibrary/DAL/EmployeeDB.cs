using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using HiTechClassLibrary.BLL;
using System.Xml.Linq;

namespace HiTechClassLibrary.DAL
{
    public static class EmployeeDB
    {   
        public static List<Employee> GetAllRecords()
        {
            List<Employee> listE = new List<Employee>();

            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Employees";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Employee emp;
            while (reader.Read())
            {
                 emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader["EmployeeId"]);
                emp.LastName = reader["LastName"].ToString();
                emp.FirstName = reader["FirstName"].ToString();
                emp.PhoneNumber = reader["PhoneNumber"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.JobID = Convert.ToInt32(reader["JobId"]);
                listE.Add(emp);
            }
            conn.Close();
            return listE;
        }
        
        public static void SaveRecord(Employee emp)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand("spSaveEmployee", conn); //use stored procedure
            cmdInsert.Connection = conn;
            //cmdInsert.CommandText = "INSERT INTO Employees (EmployeeId, LastName, FirstName, PhoneNumber, Email, JobId) VALUES (@EmployeeId, @LastName, @FirstName, @PhoneNumber, @Email, @JobId)";
            cmdInsert.Parameters.AddWithValue("@EmployeeId", emp.EmployeeID);
            cmdInsert.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdInsert.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdInsert.Parameters.AddWithValue("@PhoneNumber", emp.PhoneNumber);
            cmdInsert.Parameters.AddWithValue("@Email", emp.Email);
            cmdInsert.Parameters.AddWithValue("@JobId", emp.JobID);
            cmdInsert.CommandType = System.Data.CommandType.StoredProcedure; //use stored procedure
            conn.Open();
            try
            {
                int i = cmdInsert.ExecuteNonQuery(); //when insert, update, delete, returns the number of rows affected
                if (i == 1)
                {
                    MessageBox.Show("Employee has been saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (SqlException ex) //catch the error message 
            {
                if (ex.Message.Contains("Cannot insert duplicate key in object")) //when the primary key is duplicated
                {
                    MessageBox.Show("Employee ID already exists.", "Duplicate Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Message.Contains("The conflict occurred in database \"HiTechDB\", table \"dbo.Jobs\", column 'JobId'"))
                {
                    MessageBox.Show("Job ID does not exist.", "Job ID does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
            conn.Close();
        }

        public static void DeleteRecord(int employeeID) 
        {
            SqlConnection conn = UtilityDB.ConnectDB();

            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = conn;
            cmdDelete.CommandText = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
            cmdDelete.Parameters.AddWithValue("@EmployeeID", employeeID);
            conn.Open();
            cmdDelete.ExecuteNonQuery();
            MessageBox.Show("Employee has been deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }
        
        public static void UpdateRecord(Employee emp)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = conn;
            cmdUpdate.CommandText = "UPDATE Employees SET LastName = @LastName, FirstName = @FirstName, PhoneNumber = @PhoneNumber, Email = @Email, JobId = @JobId WHERE EmployeeId = @EmployeeId";
            cmdUpdate.Parameters.AddWithValue("@EmployeeId", emp.EmployeeID);
            cmdUpdate.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdUpdate.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdUpdate.Parameters.AddWithValue("@PhoneNumber", emp.PhoneNumber);
            cmdUpdate.Parameters.AddWithValue("@Email", emp.Email);
            cmdUpdate.Parameters.AddWithValue("@JobId", emp.JobID);
            conn.Open();
            try
            {
                int i = cmdUpdate.ExecuteNonQuery(); //when insert, update, delete, returns the number of rows affected
                if (i == 1)
                {
                    MessageBox.Show("Employee has been updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (SqlException ex) //catch the error message 
            {
                
                if (ex.Message.Contains("The conflict occurred in database \"HiTechDB\", table \"dbo.Jobs\", column 'JobId'"))
                {
                    MessageBox.Show("Job ID does not exist.", "Job ID does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
            conn.Close();
        }

        public static List<Employee> SearchRecord(int id)
        {

            List<Employee> listE = new List<Employee>();

            SqlConnection conn = UtilityDB.ConnectDB();

            SqlCommand cmdSearchByID = new SqlCommand();
            cmdSearchByID.Connection = conn;
            conn.Open();
            cmdSearchByID.CommandText = "SELECT * FROM Employees " + "WHERE EmployeeID = @EmployeeID" + " OR JobId = @JobID";
            cmdSearchByID.Parameters.AddWithValue("@EmployeeID", id);
            cmdSearchByID.Parameters.AddWithValue("@JobID", id);
            SqlDataReader reader = cmdSearchByID.ExecuteReader();
            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                emp.LastName = reader["LastName"].ToString();
                emp.FirstName = reader["FirstName"].ToString();               
                emp.PhoneNumber = reader["PhoneNumber"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.JobID = Convert.ToInt32(reader["JobID"]);
                listE.Add(emp);
            }
            conn.Close();
            return listE;
        }

        public static List<Employee> SearchRecord(string name)
        {

            List<Employee> listE = new List<Employee>();

            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchByName = new SqlCommand();
            cmdSearchByName.Connection = conn;
            conn.Open();
            cmdSearchByName.CommandText = "SELECT * FROM Employees " + "WHERE LastName = @LastName" + " OR FirstName = @FirstName";
            cmdSearchByName.Parameters.AddWithValue("@LastName", name);
            cmdSearchByName.Parameters.AddWithValue("@FirstName", name);
            SqlDataReader reader = cmdSearchByName.ExecuteReader();

            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                emp.LastName = reader["LastName"].ToString();
                emp.FirstName = reader["FirstName"].ToString();
                emp.PhoneNumber = reader["PhoneNumber"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.JobID = Convert.ToInt32(reader["JobID"]);

                listE.Add(emp);
            }
            conn.Close();
            return listE;
        }
        public static Employee SearchRecordByEmployeeIdOfUser(int employeeId)
        {
            Employee emp;

            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSearchByEmployeeId = new SqlCommand();
            cmdSearchByEmployeeId.Connection = conn;
            conn.Open();
            cmdSearchByEmployeeId.CommandText = "SELECT * FROM Employees WHERE EmployeeId = @employeeId";
            cmdSearchByEmployeeId.Parameters.AddWithValue("@employeeId", employeeId);
            
            SqlDataReader reader = cmdSearchByEmployeeId.ExecuteReader();

            if (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader["EmployeeId"]);
                emp.LastName = Convert.ToString(reader["LastName"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.PhoneNumber = reader["PhoneNumber"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.JobID = Convert.ToInt32(reader["JobId"]);

                
            }
            else
            {
                emp = null;
            }
            conn.Close();
            return emp;
        }
    }
}
