using HiTechClassLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTechClassLibrary.BLL
{
    public class AuthorBook
    {
        private int authorId;
        private string isbn;
        private string yearPublished;
        private string edition;

        public int AuthorId { get => authorId; set => authorId = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public string YearPublished { get => yearPublished; set => yearPublished = value; }
        public string Edition { get => edition; set => edition = value; }

        public SqlCommand GetAllAuthorsBooksCommand()
        {
            return AuthorBookDB.GetAllRecordsCommand();
        }
        public List<AuthorBook> GetAllAuthorsBooks()
        {
            return AuthorBookDB.GetAllRecords();
        }
    }
}
