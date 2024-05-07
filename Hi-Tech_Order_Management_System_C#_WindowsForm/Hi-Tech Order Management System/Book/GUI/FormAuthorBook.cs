using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using HiTechClassLibrary.BLL;
using HiTechClassLibrary.VALIDATION;
using System.Security.Cryptography;
using System.Collections;
using SystemLogin;

namespace ProjectBook.GUI
{
    public partial class FormAuthorBook : Form
    {
        DataSet dsHiTech;
        DataTable dtBooks;
        DataTable dtAuthors;
        DataTable dtCategories;
        DataTable dtPublishers;
        DataTable dtAuthorsBooks;
        SqlDataAdapter da;
        SqlCommandBuilder commandBuilder;
        int indexAuthorBook = -1;

        List<AuthorBook> listGeneralAuthorBook = new List<AuthorBook>();
        public FormAuthorBook()
        {
            InitializeComponent();
        }

        private void bookAndAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBook formBook = new FormBook();
            Hide();
            formBook.ShowDialog();
            Close();
        }

        private void categoryAndPublisherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCategoryPublisher formCategoryPublisher = new FormCategoryPublisher();
            Hide();
            formCategoryPublisher.ShowDialog();
            Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            Hide();
            login.ShowDialog();
            Close();
        }

        private void FormAuthorBook_Load(object sender, EventArgs e)
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
            DataRelation drCtoB = new DataRelation("FK_Books_Categories", dtCategories.Columns["CategoryId"], dtBooks.Columns["CategoryId"]);
            DataRelation drPtoB = new DataRelation("FK_Books_Publishers", dtPublishers.Columns["PublisherId"], dtBooks.Columns["PublisherId"]);
            dsHiTech.Relations.Add(drCtoB);
            dsHiTech.Relations.Add(drPtoB);

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
            DataRelation drABtoA = new DataRelation("FK_AuthorsBooks_Authors", dtAuthors.Columns["AuthorId"], dtAuthorsBooks.Columns["AuthorId"]);
            DataRelation drABtoB = new DataRelation("FK_AuthorsBooks_Books", dtBooks.Columns["ISBN"], dtAuthorsBooks.Columns["ISBN"]);
            dsHiTech.Relations.Add(drABtoA);
            dsHiTech.Relations.Add(drABtoB);

            da = new SqlDataAdapter();
            da.TableMappings.Add("Categories", "Categories");
            da.TableMappings.Add("Publishers", "Publishers");
            da.TableMappings.Add("Books", "Books");
            da.TableMappings.Add("Authors", "Authors");
            da.TableMappings.Add("AuthorsBooks", "AuthorsBooks");
            commandBuilder = new SqlCommandBuilder(da);

            Publisher publisher = new Publisher();
            da.SelectCommand = publisher.GetAllPublishersCommand();
            da.Fill(dsHiTech, "Publishers");

            Category category = new Category();

            da.SelectCommand = category.GetAllCategoriesCommand();
            da.Fill(dsHiTech, "Categories");

            Book book = new Book();
            da.SelectCommand = book.GetAllBooksCommand();
            da.Fill(dsHiTech, "Books");

            Author author = new Author();
            da.SelectCommand = author.GetAllAuthorsCommand();
            da.Fill(dsHiTech, "Authors");

            AuthorBook authorsBooks = new AuthorBook();
            da.SelectCommand = authorsBooks.GetAllAuthorsBooksCommand();
            da.Fill(dsHiTech, "AuthorsBooks");

            comboBoxBook.Items.Clear();
            foreach (DataRow drBook in dtBooks.Rows)
            {
                comboBoxBook.Items.Add(drBook["BookTitle"]);
            }
            comboBoxBook.Items.Add("Create a new Book");

            comboBoxAuthor.Items.Clear();
            foreach (DataRow drAuthor in dtAuthors.Rows)
            {
                comboBoxAuthor.Items.Add(drAuthor["FirstName"]);
            }
            comboBoxAuthor.Items.Add("Create a new Author");
        }

        private void buttonSaveAuthorBook_Click(object sender, EventArgs e)
        {

            DataRow newRow = dtAuthorsBooks.NewRow();
            if (comboBoxBook.Text.Length > 0)
            {
                foreach (DataRow drBook in dtBooks.Rows)
                {
                    if (Convert.ToString(drBook["BookTitle"]) == comboBoxBook.Text)
                    {
                        newRow["ISBN"] = drBook["ISBN"];
                        break;
                    }
                }

            }
            else
            {
                MessageBox.Show("Book Title must be selected", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxBook.Focus();
                return;
            }

            if (comboBoxAuthor.Text.Length > 0)
            {
                foreach (DataRow drAuthor in dtAuthors.Rows)
                {
                    if (Convert.ToString(drAuthor["FirstName"]) == comboBoxAuthor.Text)
                    {
                        newRow["AuthorId"] = drAuthor["AuthorId"];
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Author ID must be selected", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxAuthor.Focus(); ;
                return;
            }
            foreach (DataRow drAuthorBook in dtAuthorsBooks.Rows)
            {
                if (Convert.ToString(drAuthorBook["AuthorId"]) == Convert.ToString(newRow["AuthorId"]) && Convert.ToString(drAuthorBook["ISBN"]) == Convert.ToString(newRow["ISBN"]))
                {
                    MessageBox.Show("This Book has already assigned to this Author already", "Duplicated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxAuthor.Text = " ";
                    comboBoxBook.Text = " ";
                    comboBoxBook.Focus();
                    textBoxEdition.Clear();
                    textBoxYearPublished.Clear();
                    return;
                }
            }
            if (textBoxYearPublished.Text.Trim().Length > 0)
            {
                if (Validator.IsValidYearPublished(textBoxYearPublished.Text.Trim()))
                {
                    newRow["YearPublished"] = textBoxYearPublished.Text.Trim();
                }
                else
                {
                    MessageBox.Show("This Year is invalid year ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxYearPublished.Focus();
                    textBoxYearPublished.Clear();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Published Year must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxYearPublished.Focus(); ;
                return;
            }
            if (textBoxEdition.Text.Trim().Length > 0)
            {
                newRow["Edition"] = textBoxEdition.Text.Trim();
            }
            else
            {
                MessageBox.Show("Edition must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEdition.Focus(); ;
                return;
            }
            dtAuthorsBooks.Rows.Add(newRow);
            MessageBox.Show("Adding a new row successfully", "Adding Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            comboBoxAuthor.Text = "";
            comboBoxBook.Focus();
            comboBoxBook.Text = "";
            textBoxEdition.Clear();
            textBoxYearPublished.Clear();
            indexAuthorBook = -1;

            dataGridViewDSAuthorBook.Visible = true;
            dataGridViewInformation.Visible = false;
            dataGridViewDSAuthorBook.DataSource = null;
        }

        

        private void buttonUpdateAuthorBook_Click(object sender, EventArgs e)
        {
            if (comboBoxBook.Text.Length>0)
            {
                string isbn ="";
                int authorId = -1 ;
                foreach (DataRow drBook in dtBooks.Rows)
                {
                    if (Convert.ToString(drBook["BookTitle"]) == comboBoxBook.Text)
                    {
                        isbn = Convert.ToString(drBook["ISBN"]);
                        break;
                    }
                }
                foreach (DataRow drAuthor in dtAuthors.Rows)
                {
                    if (Convert.ToString(drAuthor["FirstName"]) == comboBoxAuthor.Text)
                    {
                        authorId = Convert.ToInt32(drAuthor["AuthorId"]);
                        break;
                    }
                }
                foreach (DataRow dr in dtAuthorsBooks.Rows)
                {
                    if (Convert.ToInt32(dr["AuthorId"]) == authorId && Convert.ToString(dr["ISBN"]) == isbn)
                    {
                        if (textBoxYearPublished.Text.Trim().Length > 0)
                        {
                            if (Validator.IsValidYearPublished(textBoxYearPublished.Text.Trim()))
                            {
                                dr["YearPublished"] = textBoxYearPublished.Text.Trim();
                            }
                            else
                            {
                                MessageBox.Show("This Year is invalid year ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxYearPublished.Focus();
                                textBoxYearPublished.Clear();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Published Year must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxYearPublished.Focus(); ;
                            return;
                        }
                        if (textBoxEdition.Text.Trim().Length > 0)
                        {
                            dr["Edition"] = textBoxEdition.Text.Trim();
                        }
                        else
                        {
                            MessageBox.Show("Edition must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxEdition.Focus(); ;
                            return;
                        }
                        MessageBox.Show("Updating successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        comboBoxBook.Text = "";
                        comboBoxBook.Focus();
                        comboBoxAuthor.Text = "";
                        textBoxYearPublished.Clear();
                        textBoxEdition.Clear();
                        indexAuthorBook = -1;

                        comboBoxBook.Enabled = true;
                        comboBoxAuthor.Enabled = true;
                        buttonSaveAuthorBook.Enabled = true;
                        dataGridViewDSAuthorBook.Enabled = true;

                        dataGridViewDSAuthorBook.Visible = true;
                        dataGridViewInformation.Visible = false;
                        dataGridViewDSAuthorBook.DataSource = null;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Please select Book Edition to update first", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void buttonDeleteAuthorBook_Click(object sender, EventArgs e)
        {
            if (comboBoxBook.Text.Length>0)
            {
                var asking = MessageBox.Show("Do you want to delete the Book Edition you choose?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (asking == DialogResult.Yes)
                {
                    DataRow drDelete = dtAuthorsBooks.Rows[indexAuthorBook];
                    foreach (DataRow dr in dtAuthorsBooks.Rows)
                    {
                        if (Convert.ToString(dr["ISBN"]) == listGeneralAuthorBook[indexAuthorBook].Isbn && Convert.ToInt32(dr["AuthorId"]) == listGeneralAuthorBook[indexAuthorBook].AuthorId)
                        {
                            drDelete.Delete();
                            drDelete.AcceptChanges();
                            MessageBox.Show($"Delete the Book Edition successfully!", "Delete successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }                    
                }

                else
                {
                    MessageBox.Show("The deleting process has been stopped", "Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                comboBoxBook.Text = "";
                comboBoxBook.Focus();
                comboBoxAuthor.Text = "";
                textBoxYearPublished.Clear();
                textBoxEdition.Clear();
                indexAuthorBook = -1;

                comboBoxBook.Enabled = true;
                comboBoxAuthor.Enabled = true;
                buttonSaveAuthorBook.Enabled = true;
                dataGridViewDSAuthorBook.Visible = true;
                dataGridViewInformation.Visible = false;
                dataGridViewDSAuthorBook.DataSource = null;
            }
            else
            {
                MessageBox.Show("Please choose the row to delete first", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxBook.Text = "";
            comboBoxBook.Focus();
            comboBoxAuthor.Text = "";
            textBoxYearPublished.Clear();
            textBoxEdition.Clear();
            indexAuthorBook = -1;
            textBoxSearch.Clear();
            comboBoxBook.Enabled = true;
            comboBoxAuthor.Enabled = true;
            buttonSaveAuthorBook.Enabled = true;
            comboBoxSearch.Text = "";
            labelDisplay.Text = "Message";
            dataGridViewDSAuthorBook.Enabled = true;
            dataGridViewDSAuthorBook.Visible = true;
            dataGridViewInformation.Visible = false;
            dataGridViewInformation.DataSource = null;
            dataGridViewDSAuthorBook.DataSource = null;


        }

        private void buttonUpdateDB_Click(object sender, EventArgs e)
        {
            da.Update(dtAuthorsBooks);
            MessageBox.Show("Database has been updated successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSearch.Text)
            {
                case "Book Title":
                    {
                        comboBoxSearchOption.Visible = true;
                        textBoxSearch.Visible = false;
                        comboBoxSearchOption.Items.Clear();
                        foreach (DataRow drBook in dtBooks.Rows)
                        {
                            comboBoxSearchOption.Items.Add(drBook["BookTitle"]);
                        }
                        labelDisplay.Text = "Select Book Title";
                        break;
                    }
                case "Author First Name":
                    {
                        comboBoxSearchOption.Visible = true;
                        textBoxSearch.Visible = false;

                        comboBoxSearchOption.Items.Clear();
                        foreach (DataRow drAuthor in dtAuthors.Rows)
                        {
                            comboBoxSearchOption.Items.Add(drAuthor["FirstName"]);
                        }
                        labelDisplay.Text = "Select Author First Name";
                        break;
                    }
                case "Year Published":
                    {
                        comboBoxSearchOption.Visible = false;
                        textBoxSearch.Visible = true;
                        labelDisplay.Text = "Enter Year Published";
                        break;
                    }
                case "Edition":
                    {
                        comboBoxSearchOption.Visible = false;
                        textBoxSearch.Visible = true;
                        labelDisplay.Text = "Enter Edition";
                        break;
                    }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            labelInformation.Text = "Information of Book Edition";
            dataGridViewDSAuthorBook.Visible = true;
            dataGridViewInformation.Visible = false;
            switch (comboBoxSearch.Text)
            {
                case "Book Title":
                    {
                       
                        if (comboBoxSearchOption.Text.Length > 0)
                        {
                            AuthorBook authorBook;
                            bool checkExist = false;

                            foreach (DataRow drBook in dtBooks.Rows)
                            {
                                if (Convert.ToString(drBook["BookTitle"]) == comboBoxSearchOption.Text)
                                {
                                    listGeneralAuthorBook.Clear();
                                    checkExist = true;
                                    foreach (DataRow drAuthorBook in dtAuthorsBooks.Rows)
                                    {
                                        if (Convert.ToString(drAuthorBook["ISBN"]) == Convert.ToString(drBook["ISBN"]))
                                        {
                                            authorBook = new AuthorBook();
                                            authorBook.Isbn = Convert.ToString(drAuthorBook["ISBN"]);
                                            authorBook.AuthorId = Convert.ToInt32(drAuthorBook["AuthorId"]);
                                            authorBook.YearPublished = Convert.ToString(drAuthorBook["YearPublished"]);
                                            authorBook.Edition = Convert.ToString(drAuthorBook["Edition"]);
                                            listGeneralAuthorBook.Add(authorBook);
                                        }
                                    }

                                    break;
                                }
                            }

                            if (!checkExist)
                            {
                                MessageBox.Show("The Edition you search does not exist", "Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select Book Title to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    }
                case "Author First Name":
                    {
                        

                        if (comboBoxSearchOption.Text.Length > 0)
                        {
                            bool checkExist = false;

                            AuthorBook authorBook;
                            foreach (DataRow drAuthor in dtAuthors.Rows)
                            {
                                if (Convert.ToString(drAuthor["FirstName"]) == comboBoxSearchOption.Text)
                                {
                                    checkExist = true;
                                    listGeneralAuthorBook.Clear();
                                    foreach (DataRow drAuthorBook in dtAuthorsBooks.Rows)
                                    {
                                        if (Convert.ToString(drAuthorBook["AuthorId"]) == Convert.ToString(drAuthor["AuthorId"]))
                                        {
                                            authorBook = new AuthorBook();
                                            authorBook.Isbn = Convert.ToString(drAuthorBook["ISBN"]);
                                            authorBook.AuthorId = Convert.ToInt32(drAuthorBook["AuthorId"]);
                                            authorBook.YearPublished = Convert.ToString(drAuthorBook["YearPublished"]);
                                            authorBook.Edition = Convert.ToString(drAuthorBook["Edition"]);
                                            listGeneralAuthorBook.Add(authorBook);
                                        }
                                    }
                                    break;
                                }
                            }
                            if (!checkExist)
                            {
                                MessageBox.Show("The Author you search does not exist", "Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select Author Name to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        break;
                    }
                case "Edition":
                    {
                        
                        if (textBoxSearch.Text.Length > 0)
                        {
                            bool checkExist = false;
                            AuthorBook authorBook;
                            listGeneralAuthorBook.Clear();
                            foreach (DataRow drEdition in dtAuthorsBooks.Rows)
                            {
                                if (Convert.ToString(drEdition["Edition"]) == textBoxSearch.Text.Trim())
                                {
                                    checkExist = true;                                 
                                    authorBook = new AuthorBook();
                                    authorBook.Isbn = Convert.ToString(drEdition["ISBN"]);
                                    authorBook.AuthorId = Convert.ToInt32(drEdition["AuthorId"]);
                                    authorBook.YearPublished = Convert.ToString(drEdition["YearPublished"]);
                                    authorBook.Edition = Convert.ToString(drEdition["Edition"]);
                                    listGeneralAuthorBook.Add(authorBook);                                  
                                }
                            }
                            if (!checkExist)
                            {
                                MessageBox.Show("The Edition you search does not exist", "Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter Edition to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        break;
                    }
                case "Year Published":
                    {
                        
                        if (textBoxSearch.Text.Length > 0)
                        {
                            bool checkExist = false;
                            AuthorBook authorBook;
                            listGeneralAuthorBook.Clear();
                            foreach (DataRow drEdition in dtAuthorsBooks.Rows)
                            {
                                if (Convert.ToString(drEdition["YearPublished"]) == textBoxSearch.Text.Trim())
                                {
                                    checkExist = true;
                                    authorBook = new AuthorBook();
                                    authorBook.Isbn = Convert.ToString(drEdition["ISBN"]);
                                    authorBook.AuthorId = Convert.ToInt32(drEdition["AuthorId"]);
                                    authorBook.YearPublished = Convert.ToString(drEdition["YearPublished"]);
                                    authorBook.Edition = Convert.ToString(drEdition["Edition"]);
                                    listGeneralAuthorBook.Add(authorBook);
                                }
                            }
                            if (!checkExist)
                            {
                                MessageBox.Show("The Year Published you search does not exist", "Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter Year Published to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        break;
                    }
                default:
                    {
                        listGeneralAuthorBook.Clear();
                        MessageBox.Show("Please choose the option first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
            dataGridViewDSAuthorBook.DataSource = null;
            dataGridViewDSAuthorBook.DataSource = listGeneralAuthorBook;
            
            
        }

        private void buttonListDSAuthorBook_Click(object sender, EventArgs e)
        {
            labelInformation.Text = "Information of Book Edition";
            listGeneralAuthorBook.Clear();
            AuthorBook authorBook;
            foreach (DataRow dr in dtAuthorsBooks.Rows)
            {
                authorBook = new AuthorBook();
                authorBook.Isbn = Convert.ToString(dr["ISBN"]);
                authorBook.AuthorId = Convert.ToInt32(dr["AuthorId"]);
                authorBook.YearPublished = Convert.ToString(dr["YearPublished"]);
                authorBook.Edition = Convert.ToString(dr["Edition"]);
                listGeneralAuthorBook.Add(authorBook);
            }
            
            dataGridViewDSAuthorBook.Visible= true;
            dataGridViewInformation.Visible= false;
            dataGridViewDSAuthorBook.DataSource = null;
            dataGridViewDSAuthorBook.DataSource = listGeneralAuthorBook;
        }



        private void buttonGetBook_Click(object sender, EventArgs e)
        {
            labelInformation.Text = "Information of Author belongs to the Book";
            List<Author> listA = new List<Author>();
            foreach (DataRow drBook in dtBooks.Rows)
            {
                if (Convert.ToString(drBook["BookTitle"]) == comboBoxBook.Text)
                {
                    foreach (DataRow drAuthorBook in dtAuthorsBooks.Rows)
                    {
                        if (Convert.ToString(drBook["ISBN"]) == Convert.ToString(drAuthorBook["ISBN"]))
                        {
                            foreach (DataRow drAuthor in dtAuthors.Rows)
                            {
                                Author author;
                                if (Convert.ToInt32(drAuthor["AuthorId"]) == Convert.ToInt32(drAuthorBook["AuthorId"]))
                                {

                                    author = new Author();
                                    author.AuthorId = Convert.ToInt32(drAuthor["AuthorId"]);
                                    author.FirstName = Convert.ToString(drAuthor["FirstName"]);
                                    author.LastName = Convert.ToString(drAuthor["LastName"]);
                                    author.Email = Convert.ToString(drAuthor["Email"]);
                                    listA.Add(author);
                                }

                            }
                        }
                    }

                }
            }

            dataGridViewDSAuthorBook.Visible = false;
            dataGridViewInformation.Visible = true;
            dataGridViewInformation.DataSource = null;
            dataGridViewInformation.DataSource = listA;

        }

        private void buttonGetAuthor_Click(object sender, EventArgs e)
        {
            labelInformation.Text = "Information of Book belongs to the Author";
            List<Book> listB = new List<Book>();
            foreach (DataRow drAuthor in dtAuthors.Rows)
            {
                if (Convert.ToString(drAuthor["FirstName"]) == comboBoxAuthor.Text)
                {
                    foreach (DataRow drAuthorBook in dtAuthorsBooks.Rows)
                    {
                        if (Convert.ToInt32(drAuthor["AuthorId"]) == Convert.ToInt32(drAuthorBook["AuthorId"]))
                        {
                            foreach (DataRow drBook in dtBooks.Rows)
                            {
                                Book book;
                                if (Convert.ToString(drBook["ISBN"]) == Convert.ToString(drAuthorBook["ISBN"]))
                                {
                                    book = new Book();
                                    book.Isbn = Convert.ToString(drBook["ISBN"]);
                                    book.BookTitle = Convert.ToString(drBook["BookTitle"]);
                                    book.UnitPrice = Convert.ToDouble(drBook["UnitPrice"]);
                                    book.Qoh = Convert.ToInt32(drBook["QOH"]);
                                    book.PublisherId = Convert.ToInt32(drBook["PublisherId"]);
                                    book.CategoryId = Convert.ToInt32(drBook["CategoryId"]);
                                    book.Status = Convert.ToInt32(drBook["Status"]);
                                    listB.Add(book);
                                }

                            }
                        }
                    }

                }
            }

            dataGridViewDSAuthorBook.Visible = false;
            dataGridViewInformation.Visible = true;
            dataGridViewInformation.DataSource = null;
            dataGridViewInformation.DataSource = listB;
        }

        private void comboBoxBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBook.Text == "Create a new Book")
            {
                var asking = MessageBox.Show("Do you want to create a new Book?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (asking == DialogResult.Yes)
                {
                    FormBook newForm = new FormBook();
                    Hide();
                    newForm.ShowDialog();
                    Show();
                    comboBoxBook.SelectedIndex = 0;
                }
            }
        }

        private void comboBoxAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAuthor.Text == "Create a new Author")
            {
                var asking = MessageBox.Show("Do you want to create a new Author?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (asking == DialogResult.Yes)
                {
                    FormBook newForm = new FormBook();
                    Hide();
                    newForm.ShowDialog();
                    Show();
                    comboBoxAuthor.SelectedIndex = 0;
                }
            }
        }

        private void dataGridViewDSAuthorBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexAuthorBook = dataGridViewDSAuthorBook.CurrentRow.Index;
            if (indexAuthorBook >= 0)
            {
                comboBoxBook.Enabled = false;
                foreach (DataRow drBook in dtBooks.Rows)
                {
                    if (Convert.ToString(drBook["ISBN"]) == Convert.ToString(listGeneralAuthorBook[indexAuthorBook].Isbn))
                    {
                        comboBoxBook.Text = Convert.ToString(drBook["BookTitle"]);
                    }
                }
                foreach (DataRow drAuthor in dtAuthors.Rows)
                {
                    if (Convert.ToString(drAuthor["AuthorId"]) == Convert.ToString(listGeneralAuthorBook[indexAuthorBook].AuthorId))
                    {
                        comboBoxAuthor.Text = Convert.ToString(drAuthor["FirstName"]);
                    }
                }
                comboBoxAuthor.Enabled = false;
                textBoxYearPublished.Text = Convert.ToString(listGeneralAuthorBook[indexAuthorBook].YearPublished);
                textBoxEdition.Text = Convert.ToString(listGeneralAuthorBook[indexAuthorBook].Edition);

                buttonSaveAuthorBook.Enabled = false;
            }
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
           Close();
        }
    }
}

