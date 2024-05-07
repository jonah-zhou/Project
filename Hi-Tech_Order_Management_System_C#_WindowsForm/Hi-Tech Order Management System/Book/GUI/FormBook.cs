using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTechClassLibrary.BLL;
using HiTechClassLibrary.VALIDATION;


namespace ProjectBook.GUI
{
    public partial class FormBook : Form
    {
        SqlDataAdapter da;
        SqlDataAdapter daAuthor;
        SqlDataAdapter daAuthorBook;
        SqlCommandBuilder cmdBuilder;
        SqlCommandBuilder cmdBuilderAuthor;
        SqlCommandBuilder cmdBuilderAuthorBook;
        DataSet dsHiTech;
        DataTable dtBooks;
        DataTable dtAuthors;
        DataTable dtCategories;
        DataTable dtPublishers;
        DataTable dtAuthorsBooks;
        int indexBook = -1;
        int indexAuthor = -1;
        List<Book> listGeneralBook = new List<Book>();
        List<Author> listGeneralAuthor = new List<Author>();
        public FormBook()
        {
            InitializeComponent();
        }

        private void buttonListDSBook_Click(object sender, EventArgs e)
        {
            listGeneralBook.Clear();
            Book currentBook;
            foreach (DataRow dr in dtBooks.Rows)
            {
                currentBook = new Book();
                currentBook.Isbn = Convert.ToString(dr["ISBN"]);
                currentBook.BookTitle = Convert.ToString(dr["BookTitle"]);
                currentBook.UnitPrice = Convert.ToDouble(dr["UnitPrice"]);
                currentBook.Qoh = Convert.ToInt32(dr["QOH"]);
                currentBook.PublisherId = Convert.ToInt32(dr["PublisherId"]);
                currentBook.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                currentBook.Status = Convert.ToInt32(dr["Status"]);
                listGeneralBook.Add(currentBook);
            }
            DisplayListBook(listGeneralBook, dataGridViewDSBook);
        }
        private void DisplayListBook(List<Book> listB, DataGridView dataGridView)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = listB;
        }
        private void DisplayListAuthor(List<Author> listA, DataGridView dataGridView)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = listA;
        }
        private void buttonSaveBook_Click(object sender, EventArgs e)
        {

            DataRow newRow = dtBooks.NewRow();
            if (textBoxISBN.Text.Trim().Length > 0)
            {
                if (textBoxISBN.Text.Trim().Length <= 15)
                {
                    bool checkBookExist = false;
                    foreach (DataRow dr in dtBooks.Rows)
                    {
                        if (Convert.ToString(dr["ISBN"]) == textBoxISBN.Text.Trim())
                        {
                            checkBookExist = true;
                        }
                    }
                    if (checkBookExist)
                    {
                        MessageBox.Show("This Book has already existed please create another one", "Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxISBN.Clear();
                        textBoxISBN.Focus();
                        return;
                    }
                    else
                    {
                        newRow["ISBN"] = textBoxISBN.Text.Trim();
                    }
                }
                else
                {
                    MessageBox.Show("ISBN has maximum 15 characters", "Invalid ISBN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxISBN.Clear();
                    textBoxISBN.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("ISBN must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxISBN.Focus();
                return;
            }
            if (textBoxBookTitle.Text.Trim().Length > 0)
            {
                newRow["BookTitle"] = textBoxBookTitle.Text.Trim();
            }
            else
            {
                MessageBox.Show("Book Title must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxBookTitle.Focus();
                return;
            }

            if (textBoxUnitPrice.Text.Trim().Length > 0)
            {
                if (Validator.IsDecimalNumber(textBoxUnitPrice.Text.Trim()))
                {
                    newRow["UnitPrice"] = Convert.ToDouble(textBoxUnitPrice.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Unit Price must be decimal or integer number", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxUnitPrice.Clear();
                    textBoxUnitPrice.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Unit Price must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxUnitPrice.Focus();
                return;
            }
            if (textBoxQOH.Text.Trim().Length > 0)
            {
                if (Validator.IsNumber(textBoxQOH.Text.Trim()))
                {
                    newRow["QOH"] = Convert.ToInt32(textBoxQOH.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Quantity On Hand must contain only digit numbers", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxQOH.Clear();
                    textBoxQOH.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Quantity on Hand must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxQOH.Focus();
                return;
            }
            if (comboBoxPublisher.Text.Length > 0)
            {
                int publisherId = -1;
                foreach (DataRow dr in dtPublishers.Rows)
                {
                    if (Convert.ToString(dr["PublisherName"]) == comboBoxPublisher.Text)
                    {
                        publisherId = Convert.ToInt32(dr["PublisherId"]);
                        break;
                    }
                }
                if (publisherId != -1)
                {
                    newRow["PublisherId"] = publisherId;
                }
            }
            else
            {
                MessageBox.Show("Publisher must be selected", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxPublisher.Focus();
                return;
            }
            if (comboBoxCategory.Text.Length > 0)
            {
                int categoryId = -1;
                foreach (DataRow dr in dtCategories.Rows)
                {
                    if (Convert.ToString(dr["CategoryName"]) == comboBoxCategory.Text)
                    {
                        categoryId = Convert.ToInt32(dr["CategoryId"]);
                        break;
                    }
                }
                if (categoryId != -1)
                {
                    newRow["CategoryId"] = categoryId;
                }
            }
            else
            {
                MessageBox.Show("Category must be selected", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxPublisher.Focus();
                return;
            }
            switch (comboBoxStatus.Text)
            {

                case "In Stock":
                    {
                        newRow["Status"] = 8;
                        break;
                    }
                case "Out of Stock":
                    {
                        newRow["Status"] = 9;
                        break;
                    }
                case "New Arrival":
                    {
                        newRow["Status"] = 10;
                        break;
                    }
                case "Bestseller":
                    {
                        newRow["Status"] = 11;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Status must choose", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
            }
            if (Convert.ToInt32(newRow["QOH"]) == 0)
            {
                newRow["Status"] = 9;
            }
            dtBooks.Rows.Add(newRow);
            MessageBox.Show("Adding a new book successfully", "Adding Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxISBN.Clear();
            textBoxISBN.Focus();
            textBoxBookTitle.Clear();
            textBoxUnitPrice.Clear();
            textBoxQOH.Clear();
            comboBoxPublisher.Text = "";
            comboBoxCategory.Text = "";
            comboBoxStatus.Text = "";
            textBoxSearchBook.Clear();
            dataGridViewDSBook.DataSource = null;

        }

        private void FormBook_Load(object sender, EventArgs e)
        {
            dsHiTech = new DataSet("HiTechDB");

            dtCategories = new DataTable("Categories");
            dtCategories.Columns.Add("CategoryId", typeof(int));
            dtCategories.Columns.Add("CategoryName", typeof(string));
            dtCategories.Columns["CategoryId"].AllowDBNull = false;
            dtCategories.Columns["CategoryName"].AllowDBNull = false;
            dtCategories.PrimaryKey = new DataColumn[] { dtCategories.Columns["CategoryId"] };
            dsHiTech.Tables.Add(dtCategories);

            dtPublishers = new DataTable("Publishers");
            dtPublishers.Columns.Add("PublisherId", typeof(int));
            dtPublishers.Columns.Add("PublisherName", typeof(string));
            dtPublishers.Columns.Add("WebAddress", typeof(string));
            dtPublishers.Columns["PublisherId"].AllowDBNull = false;
            dtPublishers.Columns["PublisherName"].AllowDBNull = false;
            dtPublishers.Columns["WebAddress"].AllowDBNull = false;
            dtPublishers.PrimaryKey = new DataColumn[] { dtPublishers.Columns["PublisherId"] };
            dsHiTech.Tables.Add(dtPublishers);

            dtBooks = new DataTable("Books");
            dtBooks.Columns.Add("ISBN", typeof(string));
            dtBooks.Columns.Add("BookTitle", typeof(string));
            dtBooks.Columns.Add("UnitPrice", typeof(double));
            dtBooks.Columns.Add("QOH", typeof(int));
            dtBooks.Columns.Add("PublisherId", typeof(int));
            dtBooks.Columns.Add("CategoryId", typeof(int));
            dtBooks.Columns.Add("Status", typeof(int));
            dtBooks.Columns["ISBN"].AllowDBNull = false;
            dtBooks.Columns["BookTitle"].AllowDBNull = false;
            dtBooks.Columns["UnitPrice"].AllowDBNull = false;
            dtBooks.Columns["QOH"].AllowDBNull = false;
            dtBooks.Columns["PublisherId"].AllowDBNull = false;
            dtBooks.Columns["CategoryId"].AllowDBNull = false;
            dtBooks.Columns["Status"].AllowDBNull = false;
            dtBooks.PrimaryKey = new DataColumn[] { dtBooks.Columns["ISBN"] };
            dsHiTech.Tables.Add(dtBooks);

            ForeignKeyConstraint drBtoP = new ForeignKeyConstraint("FK_Books_Publishers", dtPublishers.Columns["PublisherId"], dtBooks.Columns["PublisherId"]);
            ForeignKeyConstraint drBtoC = new ForeignKeyConstraint("FK_Books_Categories", dtCategories.Columns["CategoryId"], dtBooks.Columns["CategoryId"]);
            //DataRelation drBtoP = new DataRelation("FK_Books_Publishers", dtPublishers.Columns["PublisherId"], dtBooks.Columns["PublisherId"]);
            //DataRelation drBtoC = new DataRelation("FK_Books_Categories", dtCategories.Columns["CategoryId"], dtBooks.Columns["CategoryId"]);


            drBtoP.DeleteRule = Rule.Cascade;
            drBtoC.DeleteRule = Rule.Cascade;
            drBtoP.UpdateRule = Rule.Cascade;
            drBtoC.UpdateRule = Rule.Cascade;
            drBtoP.AcceptRejectRule = AcceptRejectRule.None;
            drBtoC.AcceptRejectRule = AcceptRejectRule.None;
            dsHiTech.Tables["Books"].Constraints.Add(drBtoP);
            dsHiTech.Tables["Books"].Constraints.Add(drBtoC);
            dsHiTech.EnforceConstraints = true;

            dtAuthors = new DataTable("Authors");
            dtAuthors.Columns.Add("AuthorId", typeof(int));
            dtAuthors.Columns.Add("LastName", typeof(string));
            dtAuthors.Columns.Add("FirstName", typeof(string));
            dtAuthors.Columns.Add("Email", typeof(string));
            dtAuthors.Columns["AuthorId"].AllowDBNull = false;
            dtAuthors.Columns["FirstName"].AllowDBNull = false;
            dtAuthors.Columns["LastName"].AllowDBNull = false;
            dtAuthors.Columns["Email"].AllowDBNull = false;
            dtAuthors.PrimaryKey = new DataColumn[] { dtAuthors.Columns["AuthorId"] };
            dsHiTech.Tables.Add(dtAuthors);

            dtAuthorsBooks = new DataTable("AuthorsBooks");
            dtAuthorsBooks.Columns.Add("AuthorId", typeof(int));
            dtAuthorsBooks.Columns.Add("ISBN", typeof(string));
            dtAuthorsBooks.Columns.Add("YearPublished", typeof(string));
            dtAuthorsBooks.Columns.Add("Edition", typeof(string));
            dtAuthorsBooks.Columns["AuthorId"].AllowDBNull = false;
            dtAuthorsBooks.Columns["ISBN"].AllowDBNull = false;
            dtAuthorsBooks.Columns["YearPublished"].AllowDBNull = false;
            dtAuthorsBooks.Columns["Edition"].AllowDBNull = false;
            dtAuthorsBooks.PrimaryKey = new DataColumn[] { dtAuthorsBooks.Columns["AuthorId"], dtAuthorsBooks.Columns["ISBN"] };
            dsHiTech.Tables.Add(dtAuthorsBooks);

            //DataRelation drABtoA = new DataRelation("FK_AuthorsBooks_Authors", dtAuthors.Columns["AuthorId"], dtAuthorsBooks.Columns["AuthorId"]);
            //DataRelation drABtoB = new DataRelation("FK_AuthorsBooks_Books", dtBooks.Columns["ISBN"], dtAuthorsBooks.Columns["ISBN"]);
            //dsHiTech.Relations.Add(drABtoA);
            //dsHiTech.Relations.Add(drABtoB);


            ForeignKeyConstraint drABtoA = new ForeignKeyConstraint("FK_AuthorsBooks_Authors", dtAuthors.Columns["AuthorId"], dtAuthorsBooks.Columns["AuthorId"]);
            ForeignKeyConstraint drABtoB = new ForeignKeyConstraint("FK_AuthorsBooks_Books", dtBooks.Columns["ISBN"], dtAuthorsBooks.Columns["ISBN"]);
            drABtoA.DeleteRule = Rule.Cascade;
            drABtoB.DeleteRule = Rule.Cascade;
            drABtoA.UpdateRule = Rule.Cascade;
            drABtoB.UpdateRule = Rule.Cascade;
            drABtoA.AcceptRejectRule = AcceptRejectRule.None;
            drABtoB.AcceptRejectRule = AcceptRejectRule.None;
            dsHiTech.Tables["AuthorsBooks"].Constraints.Add(drABtoA);
            dsHiTech.Tables["AuthorsBooks"].Constraints.Add(drABtoB);
            dsHiTech.EnforceConstraints = true;


            da = new SqlDataAdapter();
            daAuthor = new SqlDataAdapter();
            daAuthorBook = new SqlDataAdapter();
            da.TableMappings.Add("Categories", "Categories");
            da.TableMappings.Add("Publishers", "Publishers");
            da.TableMappings.Add("Books", "Books");

            daAuthor.TableMappings.Add("Authors", "Authors");
            daAuthorBook.TableMappings.Add("AuthorsBooks", "AuthorsBooks");

            //da.TableMappings.Add("Authors", "Authors");
            //da.TableMappings.Add("AuthorsBooks", "AuthorsBooks");

            cmdBuilder = new SqlCommandBuilder(da);

            cmdBuilderAuthor = new SqlCommandBuilder(daAuthor);
            cmdBuilderAuthorBook = new SqlCommandBuilder(daAuthorBook);

            Publisher publisher = new Publisher();
            da.SelectCommand = publisher.GetAllPublishersCommand();
            da.Fill(dsHiTech, "Publishers");

            Category category = new Category();

            da.SelectCommand = category.GetAllCategoriesCommand();
            da.Fill(dsHiTech, "Categories");

            Book book = new Book();
            da.SelectCommand = book.GetAllBooksCommand();
            da.Fill(dsHiTech, "Books");
            foreach (DataRow dr in dtBooks.Rows)
            {
                if (Convert.ToInt32(dr["QOH"]) == 0)
                {
                    dr["Status"] = 9;
                }
            }
            da.Update(dtBooks);
            Author author = new Author();
            daAuthor.SelectCommand = author.GetAllAuthorsCommand();
            daAuthor.Fill(dsHiTech, "Authors");

            //da.SelectCommand = author.GetAllAuthorsCommand();
            //da.Fill(dsHiTech, "Authors");

            AuthorBook authorsBooks = new AuthorBook();
            daAuthorBook.SelectCommand = authorsBooks.GetAllAuthorsBooksCommand();
            daAuthorBook.Fill(dsHiTech, "AuthorsBooks");

            //da.SelectCommand = authorsBooks.GetAllAuthorsBooksCommand();
            //da.Fill(dsHiTech, "AuthorsBooks");


            foreach (DataRow dr in dtPublishers.Rows)
            {
                comboBoxPublisher.Items.Add(dr["PublisherName"]);
            }
            comboBoxPublisher.Items.Add("Create a new Publisher");

            foreach (DataRow dr in dtCategories.Rows)
            {
                comboBoxCategory.Items.Add(dr["CategoryName"]);
            }
            comboBoxCategory.Items.Add("Create a new Category");
        }
        private void buttonUpdateBook_Click(object sender, EventArgs e)
        {
            if (textBoxISBN.Text.Length > 0)
            {
                foreach (DataRow drBook in dtBooks.Rows)
                {
                    if (Convert.ToString(drBook["ISBN"]) == listGeneralBook[indexBook].Isbn)
                    {
                        drBook["ISBN"] = textBoxISBN.Text.Trim();

                        if (textBoxBookTitle.Text.Trim().Length > 0)
                        {
                            drBook["BookTitle"] = textBoxBookTitle.Text.Trim();
                        }
                        else
                        {
                            MessageBox.Show("Book Title must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxBookTitle.Focus();
                            return;
                        }

                        if (textBoxUnitPrice.Text.Trim().Length > 0)
                        {
                            drBook["UnitPrice"] = Convert.ToDouble(textBoxUnitPrice.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("Unit Price must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxUnitPrice.Focus();
                            return;
                        }
                        if (textBoxQOH.Text.Trim().Length > 0)
                        {
                            drBook["QOH"] = Convert.ToInt32(textBoxQOH.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("Quantity on Hand must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxQOH.Focus();
                            return;
                        }
                        if (comboBoxPublisher.Text.Length > 0)
                        {
                            int publisherId = -1;
                            foreach (DataRow dr in dtPublishers.Rows)
                            {
                                if (Convert.ToString(dr["PublisherName"]) == comboBoxPublisher.Text)
                                {
                                    publisherId = Convert.ToInt32(dr["PublisherId"]);
                                    break;
                                }
                            }
                            if (publisherId != -1)
                            {
                                drBook["PublisherId"] = publisherId;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Publisher must be selected", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            comboBoxPublisher.Focus();
                            return;
                        }

                        if (comboBoxCategory.Text.Length > 0)
                        {
                            int categoryId = -1;
                            foreach (DataRow dr in dtCategories.Rows)
                            {
                                if (Convert.ToString(dr["CategoryName"]) == comboBoxCategory.Text)
                                {
                                    categoryId = Convert.ToInt32(dr["CategoryId"]);
                                    break;
                                }
                            }
                            if (categoryId != -1)
                            {
                                drBook["CategoryId"] = categoryId;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Category must be selected", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            comboBoxPublisher.Focus();
                            return;
                        }
                        switch (comboBoxStatus.Text)
                        {
                            case "In Stock":
                                {
                                    drBook["Status"] = 8;
                                    break;
                                }
                            case "Out of Stock":
                                {
                                    drBook["Status"] = 9;
                                    break;
                                }
                            case "New Arrival":
                                {
                                    drBook["Status"] = 10;
                                    break;
                                }
                            case "Bestseller":
                                {
                                    drBook["Status"] = 11;
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("Status must choose", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                        }
                        if (Convert.ToInt32(drBook["QOH"]) == 0)
                        {
                            drBook["Status"] = 9;
                        }
                        MessageBox.Show("Updating a new book successfully", "Updating Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxISBN.Clear();
                        textBoxISBN.Focus();
                        textBoxBookTitle.Clear();
                        textBoxUnitPrice.Clear();
                        textBoxQOH.Clear();
                        comboBoxPublisher.Text = "";
                        comboBoxCategory.Text = "";
                        comboBoxStatus.Text = "";
                        textBoxISBN.Enabled = true;
                        buttonSaveBook.Enabled = true;
                        indexBook = -1;
                        dataGridViewDSBook.DataSource = null;
                        break;
                    }
                }

            }
            else
            {
                MessageBox.Show("Please choose the Book to update first", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void buttonDeleteBook_Click(object sender, EventArgs e)
        {
            if (textBoxISBN.Text.Length > 0)
            {
                var asking = MessageBox.Show("Do you want to delete the book you choose?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (asking == DialogResult.Yes)
                {
                    
                    //List<DataRow> listRowToDelete = new List<DataRow>();
                    //foreach (DataRow dr in dtAuthorsBooks.Rows)
                    //{
                    //    if (Convert.ToString(dr["ISBN"]) == listGeneralBook[indexBook].Isbn)
                    //    {
                    //        listRowToDelete.Add(dr);
                    //    }
                    //}
                    //foreach (DataRow dr in listRowToDelete)
                    //{
                    //    dtAuthorsBooks.Rows.Remove(dr);
                    //}

                    DataRow drDelete = dtBooks.Rows.Find(textBoxISBN.Text);
                    DeleteRowCascading(drDelete);
                    drDelete.Delete();
                    drDelete.AcceptChanges();
                    MessageBox.Show($"Delete the Book successfully!", "Delete successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                else
                {
                    MessageBox.Show("The deleting process has been stopped", "Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                textBoxBookTitle.Clear();
                textBoxUnitPrice.Clear();
                textBoxQOH.Clear();
                comboBoxPublisher.Text = "";
                comboBoxCategory.Text = "";
                comboBoxStatus.Text = "";
                textBoxISBN.Enabled = true;
                buttonSaveBook.Enabled = true;
                dataGridViewDSBook.DataSource = null;
                textBoxSearchBook.Clear();
            }
            else
            {
                MessageBox.Show("Please choose the Book to delete first", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void buttonClearBook_Click(object sender, EventArgs e)
        {
            textBoxISBN.Clear();
            textBoxISBN.Focus();
            textBoxBookTitle.Clear();
            textBoxUnitPrice.Clear();
            textBoxQOH.Clear();
            comboBoxPublisher.Text = "";
            comboBoxCategory.Text = "";
            comboBoxStatus.Text = "";
            textBoxISBN.Enabled = true;
            buttonSaveBook.Enabled = true;
            indexBook = -1;
            textBoxSearchBook.Clear();
            listGeneralBook.Clear();
            dataGridViewDSBook.DataSource = null;
        }

        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            switch (comboBoxSearchBook.Text)
            {
                case "ISBN":
                    {
                        if (textBoxSearchBook.Text.Trim().Length > 0)
                        {
                            if (textBoxSearchBook.Text.Trim().Length <= 15)
                            {
                                bool checkBookExist = false;
                                Book searchBook;
                                listGeneralBook.Clear();
                                foreach (DataRow dr in dtBooks.Rows)
                                {
                                    if (Convert.ToString(dr["ISBN"]) == textBoxSearchBook.Text.Trim())
                                    {
                                        checkBookExist = true;
                                        searchBook = new Book();
                                        searchBook.Isbn = Convert.ToString(dr["ISBN"]);
                                        searchBook.BookTitle = Convert.ToString(dr["BookTitle"]);
                                        searchBook.UnitPrice = Convert.ToDouble(dr["UnitPrice"]);
                                        searchBook.Qoh = Convert.ToInt32(dr["QOH"]);
                                        searchBook.PublisherId = Convert.ToInt32(dr["PublisherId"]);
                                        searchBook.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                                        searchBook.Status = Convert.ToInt32(dr["Status"]);
                                        listGeneralBook.Add(searchBook);
                                    }

                                }
                                if (checkBookExist)
                                {
                                    MessageBox.Show($"Finding the Book Successfully", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    DisplayListBook(listGeneralBook, dataGridViewDSBook);
                                }
                                else
                                {
                                    MessageBox.Show("The Book you search does not exist", "Does not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    textBoxSearchBook.Clear();
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("The ISBN must have maximum 15 characters for searching", "Invalid format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxSearchBook.Clear();
                                break;

                            }
                        }
                        else
                        {
                            MessageBox.Show("Please insert ISBN to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    }
                case "Book Title":
                    {
                        if (textBoxSearchBook.Text.Trim().Length > 0)
                        {
                            bool checkBookExist = false;
                            Book searchBook;
                            listGeneralBook.Clear();
                            foreach (DataRow dr in dtBooks.Rows)
                            {
                                if (Convert.ToString(dr["BookTitle"]) == textBoxSearchBook.Text.Trim())
                                {
                                    checkBookExist = true;
                                    searchBook = new Book();
                                    searchBook.Isbn = Convert.ToString(dr["ISBN"]);
                                    searchBook.BookTitle = Convert.ToString(dr["BookTitle"]);
                                    searchBook.UnitPrice = Convert.ToDouble(dr["UnitPrice"]);
                                    searchBook.Qoh = Convert.ToInt32(dr["QOH"]);
                                    searchBook.PublisherId = Convert.ToInt32(dr["PublisherId"]);
                                    searchBook.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                                    searchBook.Status = Convert.ToInt32(dr["Status"]);
                                    listGeneralBook.Add(searchBook);
                                }

                            }
                            if (checkBookExist)
                            {
                                MessageBox.Show($"Finding Books with Book Title Successfully", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                DisplayListBook(listGeneralBook, dataGridViewDSBook);
                            }
                            else
                            {
                                MessageBox.Show("The Book you search does not exist", "Does not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxSearchBook.Clear();
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please insert Book Title to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    }
                case "Unit Price":
                    {
                        if (textBoxSearchBook.Text.Trim().Length > 0)
                        {
                            if (Validator.IsDecimalNumber(textBoxSearchBook.Text.Trim()))
                            {
                                bool checkBookExist = false;
                                Book searchBook;
                                listGeneralBook.Clear();
                                foreach (DataRow dr in dtBooks.Rows)
                                {
                                    if (Convert.ToString(dr["UnitPrice"]) == textBoxSearchBook.Text.Trim())
                                    {
                                        checkBookExist = true;
                                        searchBook = new Book();
                                        searchBook.Isbn = Convert.ToString(dr["ISBN"]);
                                        searchBook.BookTitle = Convert.ToString(dr["BookTitle"]);
                                        searchBook.UnitPrice = Convert.ToDouble(dr["UnitPrice"]);
                                        searchBook.Qoh = Convert.ToInt32(dr["QOH"]);
                                        searchBook.PublisherId = Convert.ToInt32(dr["PublisherId"]);
                                        searchBook.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                                        searchBook.Status = Convert.ToInt32(dr["Status"]);
                                        listGeneralBook.Add(searchBook);
                                    }

                                }
                                if (checkBookExist)
                                {
                                    MessageBox.Show($"Finding Books with Unit Price Successfully", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    DisplayListBook(listGeneralBook, dataGridViewDSBook);
                                }
                                else
                                {
                                    MessageBox.Show("The Book you search does not exist", "Does not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    textBoxSearchBook.Clear();
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please insert decimal or integer number to search", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxSearchBook.Clear();
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please insert Unit Price to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                    }
                case "Quantity On Hand":
                    {

                        if (textBoxSearchBook.Text.Trim().Length > 0)
                        {
                            if (Validator.IsNumber(textBoxSearchBook.Text.Trim()))
                            {
                                bool checkBookExist = false;
                                Book searchBook;
                                listGeneralBook.Clear();
                                foreach (DataRow dr in dtBooks.Rows)
                                {
                                    if (Convert.ToString(dr["QOH"]) == textBoxSearchBook.Text.Trim())
                                    {
                                        checkBookExist = true;
                                        searchBook = new Book();
                                        searchBook.Isbn = Convert.ToString(dr["ISBN"]);
                                        searchBook.BookTitle = Convert.ToString(dr["BookTitle"]);
                                        searchBook.UnitPrice = Convert.ToDouble(dr["UnitPrice"]);
                                        searchBook.Qoh = Convert.ToInt32(dr["QOH"]);
                                        searchBook.PublisherId = Convert.ToInt32(dr["PublisherId"]);
                                        searchBook.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                                        searchBook.Status = Convert.ToInt32(dr["Status"]);
                                        listGeneralBook.Add(searchBook);
                                    }
                                }
                                if (checkBookExist)
                                {
                                    MessageBox.Show($"Finding Books with Quanitity On Hand Successfully", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    DisplayListBook(listGeneralBook, dataGridViewDSBook);
                                }
                                else
                                {
                                    MessageBox.Show("The Book you search does not exist", "Does not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    textBoxSearchBook.Clear();
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please insert integer number to search", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxSearchBook.Clear();
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please insert Unit Price to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Please select the option to search first", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
            }
            textBoxISBN.Clear();
            textBoxSearchBook.Focus();
            textBoxBookTitle.Clear();
            textBoxUnitPrice.Clear();
            textBoxQOH.Clear();
            comboBoxPublisher.Text = "";
            comboBoxCategory.Text = "";
            comboBoxStatus.Text = "";
            textBoxSearchBook.Clear();

        }
        #region CRUD
        private void buttonSaveAuthor_Click(object sender, EventArgs e)
        {
            DataRow newRow = dtAuthors.NewRow();
            if (textBoxAuthorId.Text.Trim().Length > 0)
            {
                if (Validator.IsNumber(textBoxAuthorId.Text))
                {
                    bool checkAuthorExist = false;
                    foreach (DataRow dr in dtAuthors.Rows)
                    {
                        if (Convert.ToString(dr["AuthorId"]) == textBoxAuthorId.Text.Trim())
                        {
                            checkAuthorExist = true;
                        }
                    }
                    if (checkAuthorExist)
                    {
                        MessageBox.Show("This Author has already existed please create another one", "Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxAuthorId.Clear();
                        textBoxAuthorId.Focus();
                        return;
                    }
                    else
                    {
                        newRow["AuthorId"] = textBoxAuthorId.Text.Trim();
                    }
                }
                else
                {
                    MessageBox.Show("The Author ID must be digits ", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxAuthorId.Clear();
                    textBoxAuthorId.Focus();
                    return;
                }

            }
            else
            {
                MessageBox.Show("Author ID must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxAuthorId.Focus();
                return;
            }
            if (textBoxFirstName.Text.Trim().Length > 0)
            {
                if (Validator.IsValidName(textBoxFirstName.Text.Trim()))
                {
                    newRow["FirstName"] = textBoxFirstName.Text.Trim();
                }
                else
                {
                    MessageBox.Show("The Author Name must include letters only", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxFirstName.Clear();
                    textBoxFirstName.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("First Name must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxFirstName.Focus();
                return;
            }

            if (textBoxLastName.Text.Trim().Length > 0)
            {
                if (Validator.IsValidName(textBoxLastName.Text.Trim()))
                {
                    newRow["LastName"] = Convert.ToString(textBoxLastName.Text.Trim());
                }
                else
                {
                    MessageBox.Show("The Author Name must include letters only", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxLastName.Clear();
                    textBoxLastName.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Last Name must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLastName.Focus();
                return;
            }
            if (textBoxEmail.Text.Trim().Length > 0)
            {
                if (Validator.IsValidEmail(textBoxEmail.Text.Trim()))
                {
                    newRow["Email"] = Convert.ToString(textBoxEmail.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Email format is wrong. It must be abc@abc.com", "Wrong Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxEmail.Text = "abc@abc.com";
                    textBoxEmail.Focus();
                    return;
                }

            }
            else
            {
                MessageBox.Show("Email must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                textBoxEmail.Text = "abc@abc.com";
                return;
            }

            dtAuthors.Rows.Add(newRow);
            MessageBox.Show("Adding a new author successfully", "Adding Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxAuthorId.Clear();
            textBoxAuthorId.Focus();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxEmail.Text = "abc@abc.com";
            textBoxSearchAuthor.Clear();
            dataGridViewDSAuthor.DataSource = null;

        }

        private void buttonUpdateAuthor_Click(object sender, EventArgs e)
        {
            if (textBoxAuthorId.Text.Length > 0)
            {
                foreach (DataRow drAuthor in dtAuthors.Rows)
                {
                    if (Convert.ToInt32(drAuthor["AuthorId"]) == listGeneralAuthor[indexAuthor].AuthorId)
                    {
                        drAuthor["AuthorId"] = textBoxAuthorId.Text.Trim();

                        if (textBoxFirstName.Text.Trim().Length > 0)
                        {
                            if (Validator.IsValidName(textBoxFirstName.Text.Trim()))
                            {
                                drAuthor["FirstName"] = textBoxFirstName.Text.Trim();
                            }
                            else
                            {
                                MessageBox.Show("The Author Name must include letters only", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxFirstName.Clear();
                                textBoxFirstName.Focus();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("First Name must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxFirstName.Focus();
                            return;
                        }

                        if (textBoxLastName.Text.Trim().Length > 0)
                        {
                            if (Validator.IsValidName(textBoxLastName.Text.Trim()))
                            {
                                drAuthor["LastName"] = textBoxLastName.Text.Trim();
                            }
                            else
                            {
                                MessageBox.Show("The Author Name must include letters only", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxLastName.Clear();
                                textBoxLastName.Focus();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Last Name must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxLastName.Focus();
                            return;
                        }
                        if (textBoxEmail.Text.Trim().Length > 0)
                        {
                            if (Validator.IsValidEmail(textBoxEmail.Text.Trim()))
                            {
                                drAuthor["Email"] = textBoxEmail.Text.Trim();

                            }
                            else
                            {

                                MessageBox.Show("Email format is wrong. It must be abc@abc.com", "Wrong Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxEmail.Text = "abc@abc.com";
                                textBoxEmail.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxEmail.Focus();
                            textBoxEmail.Text = "abc@abc.com";
                            return;
                        }
                        MessageBox.Show("Updating a new author successfully", "Updating Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxAuthorId.Clear();
                        textBoxAuthorId.Focus();
                        textBoxFirstName.Clear();
                        textBoxLastName.Clear();
                        textBoxEmail.Text = "abc@abc.com";
                        textBoxAuthorId.Enabled = true;
                        buttonSaveAuthor.Enabled = true;
                        indexAuthor = -1;
                        dataGridViewDSAuthor.DataSource = null;
                        break;
                    }
                }

            }
            else
            {
                MessageBox.Show("Please choose the Author to delete first", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDeleteAuthor_Click(object sender, EventArgs e)
        {
            if (textBoxAuthorId.Text.Length > 0)
            {
                var asking = MessageBox.Show("Do you want to delete the author you choose?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (asking == DialogResult.Yes)
                {
                    //List<DataRow> listRowToDelete = new List<DataRow>();
                    //foreach (DataRow dr in dtAuthorsBooks.Rows)
                    //{
                    //    if (Convert.ToInt32(dr["AuthorId"]) == listGeneralAuthor[indexAuthor].AuthorId)
                    //    {
                    //        listRowToDelete.Add(dr);
                    //    }
                    //}
                    //foreach (DataRow dr in listRowToDelete)
                    //{
                    //    dtAuthorsBooks.Rows.Remove(dr);
                    //}

                    //DataRow drDelete = dtAuthors.Rows.Find(Convert.ToInt32(textBoxAuthorId.Text));
                    //drDelete.Delete();
                    //drDelete.AcceptChanges();

                    foreach (DataRow drDelete in dtAuthors.Rows)
                    {
                        if (Convert.ToString(drDelete["AuthorId"]) == textBoxAuthorId.Text)
                        {
                            DeleteRowCascading(drDelete);
                            drDelete.Delete();
                            
                            drDelete.AcceptChanges();
                            MessageBox.Show($"Delete the Author successfully!", "Delete successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The deleting process has been stopped", "Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                textBoxAuthorId.Clear();
                textBoxAuthorId.Focus();
                textBoxFirstName.Clear();
                textBoxLastName.Clear();
                textBoxEmail.Text = "abc@abc.com";
                textBoxAuthorId.Enabled = true;
                buttonSaveAuthor.Enabled = true;
                dataGridViewDSAuthor.DataSource = null;
                textBoxSearchAuthor.Clear();
            }
            else
            {
                MessageBox.Show("Please choose the Author to delete first", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonClearAuthor_Click(object sender, EventArgs e)
        {
            textBoxAuthorId.Clear();
            textBoxAuthorId.Focus();
            textBoxLastName.Clear();
            textBoxEmail.Text = "abc@abc.com";
            textBoxFirstName.Clear();
            buttonSaveAuthor.Enabled = true;
            textBoxAuthorId.Enabled = true;
            textBoxSearchAuthor.Clear();
            indexAuthor = -1;
            listGeneralAuthor.Clear();
            dataGridViewDSAuthor.DataSource = null;
        }


        private void buttonListDSAuthor_Click(object sender, EventArgs e)
        {
            listGeneralAuthor.Clear();
            Author currentAuthor;
            foreach (DataRow dr in dtAuthors.Rows)
            {
                currentAuthor = new Author();
                currentAuthor.AuthorId = Convert.ToInt32(dr["AuthorId"]);
                currentAuthor.FirstName = Convert.ToString(dr["FirstName"]);
                currentAuthor.LastName = Convert.ToString(dr["LastName"]);
                currentAuthor.Email = Convert.ToString(dr["Email"]);
                listGeneralAuthor.Add(currentAuthor);
            }
            DisplayListAuthor(listGeneralAuthor, dataGridViewDSAuthor);
        }

        private void buttonUpdateDBBook_Click(object sender, EventArgs e)
        {
            daAuthorBook.Update(dsHiTech, "AuthorsBooks");
            da.Update(dsHiTech, "Books");
            daAuthor.Update(dsHiTech, "Authors");

            //da.Update(dtAuthorsBooks);
            //da.Update(dtBooks);
            //da.Update(dtAuthors);
            MessageBox.Show("Books in Database has been updated successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        #endregion
        private void buttonSearchAuthor_Click(object sender, EventArgs e)
        {
            switch (comboBoxSearchAuthor.Text)
            {
                case "Author ID":
                    {
                        if (textBoxSearchAuthor.Text.Trim().Length > 0)
                        {
                            if (Validator.IsNumber(textBoxSearchAuthor.Text.Trim()))
                            {
                                bool checkAuthorExist = false;
                                Author searchAuthor;
                                listGeneralAuthor.Clear();
                                foreach (DataRow dr in dtAuthors.Rows)
                                {
                                    if (Convert.ToString(dr["AuthorId"]) == textBoxSearchAuthor.Text.Trim())
                                    {
                                        checkAuthorExist = true;
                                        searchAuthor = new Author();
                                        searchAuthor.AuthorId = Convert.ToInt32(dr["AuthorId"]);
                                        searchAuthor.FirstName = Convert.ToString(dr["FirstName"]);
                                        searchAuthor.LastName = Convert.ToString(dr["LastName"]);
                                        searchAuthor.Email = Convert.ToString(dr["Email"]);
                                        listGeneralAuthor.Add(searchAuthor);
                                    }
                                }
                                if (checkAuthorExist)
                                {
                                    MessageBox.Show($"Finding the Author Successfully", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    DisplayListAuthor(listGeneralAuthor, dataGridViewDSAuthor);
                                }
                                else
                                {
                                    MessageBox.Show("The Author you search does not exist", "Does not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    textBoxSearchAuthor.Clear();
                                    textBoxSearchAuthor.Focus();
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("The Author ID to search must be digits", "Invalid format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxSearchAuthor.Clear();
                                textBoxSearchAuthor.Focus();
                                break;

                            }
                        }
                        else
                        {
                            MessageBox.Show("Please insert Author ID to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    }
                case "First Name":
                    {
                        if (textBoxSearchAuthor.Text.Trim().Length > 0)
                        {
                            if (Validator.IsValidName(textBoxSearchAuthor.Text.Trim()))
                            {
                                bool checkAuthorExist = false;
                                Author searchAuthor;
                                listGeneralAuthor.Clear();
                                foreach (DataRow dr in dtAuthors.Rows)
                                {

                                    if (Convert.ToString(dr["FirstName"]) == textBoxSearchAuthor.Text.Trim())
                                    {

                                        checkAuthorExist = true;
                                        searchAuthor = new Author();
                                        searchAuthor.AuthorId = Convert.ToInt32(dr["AuthorId"]);
                                        searchAuthor.LastName = Convert.ToString(dr["LastName"]);
                                        searchAuthor.FirstName = Convert.ToString(dr["FirstName"]);
                                        searchAuthor.Email = Convert.ToString(dr["Email"]);
                                        listGeneralAuthor.Add(searchAuthor);
                                    }

                                }
                                if (checkAuthorExist)
                                {
                                    MessageBox.Show($"Finding Author with First Name Successfully", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    DisplayListAuthor(listGeneralAuthor, dataGridViewDSAuthor);
                                }
                                else
                                {
                                    MessageBox.Show("The Author you search does not exist", "Does not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    textBoxSearchAuthor.Clear();
                                    textBoxSearchAuthor.Focus();
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("The Author First Name only contains letters", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxSearchAuthor.Clear();
                                textBoxSearchAuthor.Focus();
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please insert First Name of Author to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    }
                case "Last Name":
                    {
                        if (textBoxSearchAuthor.Text.Trim().Length > 0)
                        {
                            if (Validator.IsValidName(textBoxSearchAuthor.Text.Trim()))
                            {
                                bool checkAuthorExist = false;
                                Author searchAuthor;
                                listGeneralAuthor.Clear();
                                foreach (DataRow dr in dtAuthors.Rows)
                                {
                                    if (Convert.ToString(dr["LastName"]) == textBoxSearchAuthor.Text.Trim())
                                    {

                                        checkAuthorExist = true;
                                        searchAuthor = new Author();
                                        searchAuthor.AuthorId = Convert.ToInt32(dr["AuthorId"]);
                                        searchAuthor.FirstName = Convert.ToString(dr["FirstName"]);
                                        searchAuthor.LastName = Convert.ToString(dr["LastName"]);
                                        searchAuthor.Email = Convert.ToString(dr["Email"]);
                                        listGeneralAuthor.Add(searchAuthor);
                                    }

                                }
                                if (checkAuthorExist)
                                {
                                    MessageBox.Show($"Finding Author with Last Name Successfully", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    DisplayListAuthor(listGeneralAuthor, dataGridViewDSAuthor);
                                }
                                else
                                {
                                    MessageBox.Show("The Author you search does not exist", "Does not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    textBoxSearchAuthor.Clear();
                                    textBoxSearchAuthor.Focus();
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("The Author Last Name only contains letters", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxSearchAuthor.Clear();
                                textBoxSearchAuthor.Focus();
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please insert Last Name of Author to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                    }
                case "Email":
                    {
                        if (textBoxSearchAuthor.Text.Trim().Length > 0)
                        {
                            if (Validator.IsValidEmail(textBoxSearchAuthor.Text.Trim()))
                            {
                                bool checkAuthorExist = false;
                                Author searchAuthor;
                                listGeneralAuthor.Clear();
                                foreach (DataRow dr in dtAuthors.Rows)
                                {
                                    if (Convert.ToString(dr["Email"]) == textBoxSearchAuthor.Text.Trim())
                                    {
                                        checkAuthorExist = true;
                                        searchAuthor = new Author();
                                        searchAuthor.AuthorId = Convert.ToInt32(dr["AuthorId"]);
                                        searchAuthor.FirstName = Convert.ToString(dr["FirstName"]);
                                        searchAuthor.LastName = Convert.ToString(dr["LastName"]);
                                        searchAuthor.Email = Convert.ToString(dr["Email"]);
                                        listGeneralAuthor.Add(searchAuthor);
                                    }

                                }
                                if (checkAuthorExist)
                                {
                                    MessageBox.Show($"Finding Author with Email Successfully", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    DisplayListAuthor(listGeneralAuthor, dataGridViewDSAuthor);
                                }
                                else
                                {
                                    MessageBox.Show("The Author you search does not exist", "Does not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    textBoxSearchAuthor.Clear();
                                    textBoxSearchAuthor.Focus();
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("The Email should be in format: abc@abc.com", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxSearchAuthor.Clear();
                                textBoxSearchAuthor.Focus();
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please insert Email of Author to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Please select the option to search first", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
            }
            textBoxAuthorId.Clear();
            textBoxSearchAuthor.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxEmail.Clear();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridViewDSBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexBook = dataGridViewDSBook.CurrentRow.Index;
            //indexBook = e.RowIndex;
            if (indexBook >= 0)
            {
                textBoxISBN.Enabled = false;
                textBoxISBN.Text = listGeneralBook[indexBook].Isbn;
                textBoxBookTitle.Text = listGeneralBook[indexBook].BookTitle;

                textBoxUnitPrice.Text = Convert.ToString(listGeneralBook[indexBook].UnitPrice);
                textBoxQOH.Text = Convert.ToString(listGeneralBook[indexBook].Qoh);
                buttonSaveBook.Enabled = false;
                foreach (DataRow dr in dtPublishers.Rows)
                {
                    if (Convert.ToInt32(dr["PublisherId"]) == Convert.ToInt32(listGeneralBook[indexBook].PublisherId))
                    {
                        comboBoxPublisher.Text = Convert.ToString(dr["PublisherName"]);
                        break;
                    }
                }
                foreach (DataRow dr in dtCategories.Rows)
                {
                    if (Convert.ToInt32(dr["CategoryId"]) == Convert.ToInt32(listGeneralBook[indexBook].CategoryId))
                    {
                        comboBoxCategory.Text = Convert.ToString(dr["CategoryName"]);
                        break;
                    }
                }
                switch (listGeneralBook[indexBook].Status)
                {
                    case 8:
                        {
                            comboBoxStatus.Text = "In Stock";
                            break;
                        }
                    case 9:
                        {
                            comboBoxStatus.Text = "Out of Stock";
                            break;
                        }
                    case 10:
                        {
                            comboBoxStatus.Text = "New Arrival";
                            break;
                        }
                    case 11:
                        {
                            comboBoxStatus.Text = "Bestseller";
                            break;
                        }
                }
            }
        }

        private void dataGridViewDSAuthor_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            indexAuthor = dataGridViewDSAuthor.CurrentRow.Index;
            if (indexAuthor >= 0)
            {
                textBoxAuthorId.Enabled = false;
                textBoxAuthorId.Text = Convert.ToString(listGeneralAuthor[indexAuthor].AuthorId);
                textBoxFirstName.Text = listGeneralAuthor[indexAuthor].FirstName;
                textBoxLastName.Text = listGeneralAuthor[indexAuthor].LastName;
                textBoxEmail.Text = listGeneralAuthor[indexAuthor].Email;
                buttonSaveAuthor.Enabled = false;
            }
        }

        

        

        private void comboBoxPublisher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPublisher.Text == "Create a new Publisher")
            {
                var asking = MessageBox.Show("Do you want to create a new Publisher?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (asking == DialogResult.Yes)
                {
                    FormCategoryPublisher newForm = new FormCategoryPublisher();
                    Hide();
                    newForm.ShowDialog();
                    Show();
                    comboBoxPublisher.SelectedIndex = 0;
                }
            }
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCategory.Text == "Create a new Category")
            {
                var asking = MessageBox.Show("Do you want to create a new Category?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (asking == DialogResult.Yes)
                {
                    FormCategoryPublisher newForm = new FormCategoryPublisher();
                    Hide();
                    newForm.ShowDialog();
                    Show();
                    comboBoxCategory.SelectedIndex = 0;
                }
            }
        }

       
        public void DeleteRowCascading(DataRow row)
        {
            foreach (DataRelation rel in row.Table.ChildRelations)
            {
                foreach (DataRow cRow in row.GetChildRows(rel))
                {
                    DeleteRowCascading(cRow);
                }
            }              

            row.Delete();
        }
    }
}
