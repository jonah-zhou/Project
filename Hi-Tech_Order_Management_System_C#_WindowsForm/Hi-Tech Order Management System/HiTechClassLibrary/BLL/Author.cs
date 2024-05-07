using HiTechClassLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTechClassLibrary.BLL
{
    public class Author
    {
        private int authorId;
        private string lastName;
        private string firstName;
        private string email;

        public int AuthorId { get => authorId; set => authorId = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Email { get => email; set => email = value; }

        public SqlCommand GetAllAuthorsCommand()
        {
            return AuthorDB.GetAllRecordsCommand();
        }
        public List<Author> GetAllAuthors()
        {
            return AuthorDB.GetAllRecords();
        }
    }
}
