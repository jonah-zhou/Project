using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTechClassLibrary.DAL;

namespace HiTechClassLibrary.BLL
{
    public class Customer
    {
        private int customerId;
        private string customerName;
        private string streetName;
        private string province;
        private string city;
        private string postalCode;
        private string phoneNumber;
        private string contactName;
        private string contactEmail;
        private int creditLimit;
        private int status;

        public int CustomerID { get => customerId; set => customerId = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string StreetName { get => streetName; set => streetName = value; }
        public string Province { get => province; set => province = value; }
        public string City { get => city; set => city = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string ContactName { get => contactName; set => contactName = value; }
        public string ContactEmail { get => contactEmail; set => contactEmail = value; }
        public int CreditLimit { get => creditLimit; set => creditLimit = value; }
        public int Status { get => status; set => status = value; }

        public List<Customer> GetAllCustomers()
        {
            return CustomerDB.GetAllRecords();
        }

        public SqlCommand GetAllCustomersFromTable()
        {
            return CustomerDB.GetAllRecordsFromTable();
        }

    }
}
