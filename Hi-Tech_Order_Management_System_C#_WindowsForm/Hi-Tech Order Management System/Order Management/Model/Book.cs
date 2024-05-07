//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Order_Management.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.AuthorsBooks = new HashSet<AuthorsBook>();
            this.OrderLines = new HashSet<OrderLine>();
        }
    
        public string ISBN { get; set; }
        public string BookTitle { get; set; }
        public decimal UnitPrice { get; set; }
        public int QOH { get; set; }
        public int PublisherId { get; set; }
        public int CategoryId { get; set; }
        public int Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuthorsBook> AuthorsBooks { get; set; }
        public virtual Category Category { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Status Status1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public override string ToString()
        {
            return $"Book Information:\n+ ISBN: {ISBN}\n+ Book Title: {BookTitle}\n" +
                   $"+ Unit Price: {UnitPrice}\n+ QOH: {QOH}\n+ Publisher ID: {PublisherId}\n+ Category ID: {CategoryId}\n+ Status: {Status}";
        }
        public List<Book> GetAllBooks()
        {
            List<Book> listB = new List<Book>();
            using (HiTechDBEntities1 db = new HiTechDBEntities1())
            {
                var selectAll = (from b in db.Books
                                 select b).ToList();
                Book book;
                foreach (var item in selectAll)
                {
                    book = new Book();
                    book.ISBN = item.ISBN;
                    book.BookTitle = item.BookTitle;
                    book.UnitPrice = item.UnitPrice;
                    book.QOH = item.QOH;
                    book.PublisherId = item.PublisherId;
                    book.CategoryId = item.CategoryId;
                    book.Status = item.Status;

                    listB.Add(book);
                }
            }
            return listB;
        }
    }
}