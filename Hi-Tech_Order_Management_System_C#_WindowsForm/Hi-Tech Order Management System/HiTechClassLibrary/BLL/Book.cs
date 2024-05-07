using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechClassLibrary.DAL;

namespace HiTechClassLibrary.BLL
{
    public class Book
    {
        private string isbn;
        private string bookTitle;
        private double unitPrice;
        private int qoh;
        private int publisherId;
        private int categoryId;
        private int status;

        public string Isbn { get => isbn; set => isbn = value; }
        public string BookTitle { get => bookTitle; set => bookTitle = value; }
        public double UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int Qoh { get => qoh; set => qoh = value; }
        public int PublisherId { get => publisherId; set => publisherId = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public int Status { get => status; set => status = value; }
        public SqlCommand GetAllBooksCommand()
        {
            return BookDB.GetAllRecordsCommand();
        }
        public List<Book> GetAllBooks()
        {
            return BookDB.GetAllRecords();
        }
    }
}
