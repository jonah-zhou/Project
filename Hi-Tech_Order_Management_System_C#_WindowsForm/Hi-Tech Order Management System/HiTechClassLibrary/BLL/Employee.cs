using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTechClassLibrary.DAL;

namespace HiTechClassLibrary.BLL
{
    public class Employee
    {
        private int employeeId;
        private string lastName;
        private string firstName;
        private string phoneNumber;
        private string email;
        private int jobId;

        public int EmployeeID { get => employeeId; set => employeeId = value; }

        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        public string Email { get => email; set => email = value; }
        public int JobID { get => jobId; set => jobId = value; }

        public List<Employee> GetAllEmployees()
        {
            return EmployeeDB.GetAllRecords();
        }

        public void DisplayEmployeeList(ListView listV, List<Employee> listE)
        {
            listV.Items.Clear();
            foreach (Employee emp in listE)
            {
                ListViewItem item = new ListViewItem(emp.EmployeeID.ToString());
                item.SubItems.Add(emp.LastName);
                item.SubItems.Add(emp.FirstName);
                item.SubItems.Add(emp.PhoneNumber);
                item.SubItems.Add(emp.Email);
                item.SubItems.Add(emp.JobID.ToString());
                listV.Items.Add(item);
            }
        }

        public void SaveEmployee(Employee emp)
        {
            EmployeeDB.SaveRecord(emp);
        }

        public void DeleteEmployee(int employeeID)
        {
            EmployeeDB.DeleteRecord(employeeID);
        }

        public void UpdateEmployee(Employee emp)
        {
            EmployeeDB.UpdateRecord(emp);
        }
        
        public List<Employee> SearchEmployee(int id)
        {
            return EmployeeDB.SearchRecord(id);
        }

        public List<Employee> SearchEmployee(string name)
        {
            return EmployeeDB.SearchRecord(name);
        }
        public Employee SearchEmployeeByEmployeeIdOfUser(int employeeId)
        {
            return EmployeeDB.SearchRecordByEmployeeIdOfUser(employeeId);
        }
    }
}