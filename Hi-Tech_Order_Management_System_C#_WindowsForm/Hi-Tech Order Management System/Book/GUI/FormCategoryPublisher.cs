using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTechClassLibrary.VALIDATION;
using HiTechClassLibrary.BLL;
using System.Collections;

namespace ProjectBook.GUI
{
    public partial class FormCategoryPublisher : Form
    {
        int indexPublisher = -1;
        int indexCategory = -1;
        List<Publisher> listGeneralPublisher = new List<Publisher>();
        List<Category> listGeneralCategory = new List<Category>();
        public FormCategoryPublisher()
        {
            InitializeComponent();
        }

        private void buttonSavePublisher_Click(object sender, EventArgs e)
        {

            Publisher publisher = new Publisher();
            if (textBoxPublisherId.Text.Length > 0)
            {
                if (Validator.IsValidId(textBoxPublisherId.Text.Trim(), textBoxPublisherId.Text.Length))
                {
                    bool checkExist = false;
                    List<Publisher> listP = publisher.GetAllPublishers();
                    foreach (Publisher currentP in listP)
                    {
                        if (currentP.PublisherId == Convert.ToInt32(textBoxPublisherId.Text.Trim()))
                        {
                            checkExist = true;
                            break;
                        }
                    }
                    if (checkExist)
                    {
                        MessageBox.Show("Publisher has already existed", "Duplicated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxPublisherId.Clear();
                        return;
                    }
                    else
                    {
                        publisher.PublisherId = Convert.ToInt32(textBoxPublisherId.Text.Trim());
                    }
                }
                else
                {
                    MessageBox.Show("Publisher ID must be digits", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxPublisherId.Clear();
                    return;
                }
            }
            else
            {
                MessageBox.Show("The Publisher ID must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPublisherId.Clear();
                textBoxPublisherId.Focus();
                return;
            }

            if (textBoxPublisherName.Text.Length > 0)
            {
                if (Validator.IsValidName(textBoxPublisherName.Text.Trim()))
                {
                    publisher.PublisherName = textBoxPublisherName.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Publisher Name only contains letters", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxPublisherName.Clear();
                    textBoxPublisherName.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("The Publisher Name must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPublisherName.Clear();
                textBoxPublisherName.Focus();
                return;
            }

            if (textBoxWebAddress.Text.Length > 0)
            {
                if (Validator.IsValidWebsite(textBoxWebAddress.Text.Trim()))
                {
                    publisher.WebAddress = textBoxWebAddress.Text.Trim();
                }
                else
                {
                    MessageBox.Show("The Web Address must be https:// abc.com/ ", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxWebAddress.Text = "https://abc.com/";
                    textBoxWebAddress.Focus();
                }

            }
            else
            {
                MessageBox.Show("The Web Address must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxWebAddress.Text = "https://abc.com/";
                textBoxWebAddress.Focus();
                return;
            }

            publisher.SavePublisher(publisher);
            MessageBox.Show("Adding a new Publisher successfully", "Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxWebAddress.Text = "https://abc.com/";
            textBoxPublisherName.Clear();
            textBoxPublisherId.Clear();
            textBoxPublisherId.Focus();
            listViewPublisher.Items.Clear();
        }

        private void buttonUpdatePublisher_Click(object sender, EventArgs e)
        {

            Publisher publisher = new Publisher();
            if (textBoxPublisherId.Text.Trim().Length > 0)
            {
                publisher.PublisherId = Convert.ToInt32(textBoxPublisherId.Text.Trim());
            }
            else
            {
                MessageBox.Show("Please select a Publisher before updating", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxPublisherName.Text.Length > 0)
            {
                if (Validator.IsValidName(textBoxPublisherName.Text.Trim()))
                {
                    publisher.PublisherName = textBoxPublisherName.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Publisher Name only contains letters", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxPublisherName.Clear();
                    textBoxPublisherName.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("The Publisher Name must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBoxPublisherName.Focus();
                return;
            }

            if (textBoxWebAddress.Text.Length > 0)
            {
                if (Validator.IsValidWebsite(textBoxWebAddress.Text.Trim()))
                {
                    publisher.WebAddress = textBoxWebAddress.Text.Trim();
                }
                else
                {
                    MessageBox.Show("The Web Address must be https://abc.com/ ", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxWebAddress.Text = "https://abc.com/";
                    textBoxWebAddress.Focus();
                }

            }
            else
            {
                MessageBox.Show("The Web Address must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBoxWebAddress.Focus();
                textBoxWebAddress.Text = "https://abc.com/";
                return;
            }

            publisher.UpdatePublisher(publisher);
            MessageBox.Show("Publisher has been updated successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxWebAddress.Text = "https://abc.com/";
            textBoxPublisherName.Clear();
            textBoxPublisherId.Clear();
            textBoxPublisherId.Focus();
            textBoxPublisherId.Enabled = true;
            buttonSavePublisher.Enabled = true;
            listViewPublisher.Items.Clear();
            buttonDeletePublisher.Enabled = false;
            buttonUpdatePublisher.Enabled = false;
        }

        private void listViewPublisher_SelectedIndexChanged(object sender, EventArgs e)
        {

            indexPublisher = listViewPublisher.FocusedItem.Index;

            if (indexPublisher >= 0)
            {
                textBoxPublisherId.Text = Convert.ToString(listGeneralPublisher[indexPublisher].PublisherId);
                textBoxPublisherName.Text = listGeneralPublisher[indexPublisher].PublisherName;
                textBoxWebAddress.Text = listGeneralPublisher[indexPublisher].WebAddress;
                textBoxPublisherId.Enabled = false;
                buttonSavePublisher.Enabled = false;
                buttonUpdatePublisher.Enabled = true;
                buttonDeletePublisher.Enabled = true;
            }           
        }

        private void listViewCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexCategory = listViewCategory.FocusedItem.Index;
            if (indexCategory >= 0)
            {
                
                textBoxCategoryId.Text = Convert.ToString(listGeneralCategory[indexCategory].CategoryId);
                textBoxCategoryName.Text = listGeneralCategory[indexCategory].CategoryName;
                buttonSaveCategory.Enabled = false;
                textBoxCategoryId.Enabled = false;
                buttonDeleteCategory.Enabled = true;
                buttonUpdateCategory.Enabled = true;               
            }

        }

        private void buttonListPublisher_Click(object sender, EventArgs e)
        {
            listGeneralPublisher.Clear();
            Publisher publisher = new Publisher();
            listGeneralPublisher = publisher.GetAllPublishers();
            DisplayListPublisher(listGeneralPublisher, listViewPublisher);
        }

        private void buttonDeletePublisher_Click(object sender, EventArgs e)
        {
            Publisher publisher = new Publisher();
            if (textBoxPublisherId.Text.Trim().Length > 0)
            {
                publisher.PublisherId = Convert.ToInt32(textBoxPublisherId.Text.Trim());
            }
            else
            {
                MessageBox.Show("Please select a Publisher before deleting", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            publisher.PublisherId = Convert.ToInt32(textBoxPublisherId.Text.Trim());
            publisher.PublisherName = textBoxPublisherName.Text.Trim();
            publisher.WebAddress = textBoxWebAddress.Text.Trim();

            var asking = MessageBox.Show("Do you want to delete the Publisher you choose?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (asking == DialogResult.Yes)
            {
                publisher.DeletePublisher(publisher);
                MessageBox.Show("Delete Publisher successfully", "Delete Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxWebAddress.Text = "https://abc.com/";
            textBoxPublisherName.Clear();
            textBoxPublisherId.Clear();
            textBoxPublisherId.Focus();
            textBoxPublisherId.Enabled = true;
            buttonSavePublisher.Enabled = true;
            listViewPublisher.Items.Clear();
            buttonDeletePublisher.Enabled = false;
            buttonUpdatePublisher.Enabled = false;
        }

        private void buttonSearchPublisher_Click(object sender, EventArgs e)
        {
            listGeneralPublisher.Clear();
            switch (comboBoxSearchPublisher.Text)
            {
                case "Publisher ID":
                    {
                        if (textBoxSearchPublisher.Text.Length > 0)
                        {
                            if (Validator.IsValidId(textBoxSearchPublisher.Text.Trim(), textBoxSearchPublisher.Text.Trim().Length))
                            {
                                Publisher publisher = new Publisher();
                                listGeneralPublisher = publisher.GetPublishersBySearch(textBoxSearchPublisher.Text.Trim(), "PublisherId");
                                DisplayListPublisher(listGeneralPublisher, listViewPublisher);
                            }
                            else
                            {
                                MessageBox.Show("Publisher ID must be digits", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxSearchPublisher.Clear();
                                break;
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Please insert Publisher ID to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        break;
                    }
                case "Publisher Name":
                    {
                        if (textBoxSearchPublisher.Text.Length > 0)
                        {
                            if (Validator.IsValidName(textBoxSearchPublisher.Text.Trim()))
                            {
                                Publisher publisher = new Publisher();
                                listGeneralPublisher = publisher.GetPublishersBySearch(textBoxSearchPublisher.Text.Trim(), "PublisherName");
                                DisplayListPublisher(listGeneralPublisher, listViewPublisher);
                            }
                            else
                            {
                                MessageBox.Show("Publisher Name must contain only letters", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxSearchPublisher.Clear();
                                break;
                            }                            
                        }
                        else
                        {
                            MessageBox.Show("Please insert Publisher Name to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
                case "Web Address":
                    {
                        if (textBoxSearchPublisher.Text.Length > 0)
                        {
                            if (Validator.IsValidWebsite(textBoxSearchPublisher.Text.Trim()))
                            {
                                Publisher publisher = new Publisher();
                                listGeneralPublisher = publisher.GetPublishersBySearch(textBoxSearchPublisher.Text.Trim(), "WebAddress");
                                DisplayListPublisher(listGeneralPublisher, listViewPublisher);
                            }
                            else
                            {
                                MessageBox.Show("The Web Address must be https://abc.com/ ", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxSearchPublisher.Clear();
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please insert Web Address to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Please select option to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }

        }

        private void buttonClearPublisher_Click(object sender, EventArgs e)
        {
            listViewPublisher.Items.Clear();
            textBoxPublisherName.Clear();
            textBoxPublisherId.Clear();
            textBoxWebAddress.Text = "https://abc.com/";
            textBoxSearchPublisher.Clear();
            textBoxPublisherId.Focus();
            textBoxPublisherId.Enabled = true;
            indexPublisher = -1;
            labelMessagePublisher.Text = "Message";
            buttonSaveCategory.Enabled = true;
            listGeneralPublisher.Clear();
            buttonDeletePublisher.Enabled = false;
            buttonUpdatePublisher.Enabled = false;
        }

        private void buttonSaveCategory_Click(object sender, EventArgs e)
        {

            Category category = new Category();
            if (textBoxCategoryId.Text.Length > 0)
            {
                if (Validator.IsValidId(textBoxCategoryId.Text.Trim(), textBoxCategoryId.Text.Trim().Length))
                {
                    bool checkExist = false;
                    List<Category> listC = category.GetAllCategories();
                    foreach (Category currentC in listC)
                    {
                        if (currentC.CategoryId == Convert.ToInt32(textBoxCategoryId.Text.Trim()))
                        {
                            checkExist = true;
                            break;
                        }
                    }
                    if (checkExist)
                    {
                        MessageBox.Show("Category has already existed", "Duplicated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxCategoryId.Clear();
                        return;
                    }
                    else
                    {
                        category.CategoryId = Convert.ToInt32(textBoxCategoryId.Text.Trim());
                    }
                }
                else
                {
                    MessageBox.Show("Category ID must be digits", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxCategoryId.Clear();
                    return;
                }
            }
            else
            {
                MessageBox.Show("The Category ID must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCategoryId.Focus();
                return;
            }

            if (textBoxCategoryName.Text.Length > 0)
            {
                if (Validator.IsValidName(textBoxCategoryName.Text))
                {
                    category.CategoryName = textBoxCategoryName.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Category Name must contain only letters", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxCategoryName.Clear();
                    return;
                }
            }
            else
            {
                MessageBox.Show("The Category Name must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCategoryName.Focus();
                return;
            }

            category.SaveCategory(category);
            MessageBox.Show("Adding a new category successfully", "Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxCategoryName.Clear();
            textBoxCategoryId.Clear();
            textBoxCategoryId.Focus();
            listViewCategory.Items.Clear();
        }

        private void buttonUpdateCategory_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            if (textBoxCategoryId.Text.Trim().Length > 0)
            {
                category.CategoryId = Convert.ToInt32(textBoxCategoryId.Text.Trim());
            }
            else
            {
                MessageBox.Show("Please select a Category before updating", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }         
            if (textBoxCategoryName.Text.Length > 0)
            {
                if (Validator.IsValidName(textBoxCategoryName.Text))
                {
                    category.CategoryName = textBoxCategoryName.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Category Name must contain only letters", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxCategoryName.Clear();
                    return;
                }
            }
            else
            {
                MessageBox.Show("The Category Name must be inserted", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCategoryName.Focus();
                return;
            }


            category.UpdateCategory(category);
            MessageBox.Show("Category has been updated successfully.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBoxCategoryName.Clear();
            textBoxCategoryId.Clear();
            textBoxCategoryId.Focus();
            textBoxCategoryId.Enabled = true;
            buttonSaveCategory.Enabled = true;
            listViewCategory.Items.Clear();
            buttonDeleteCategory.Enabled = false;
            buttonUpdateCategory.Enabled = false;
        }

        private void buttonListCategory_Click(object sender, EventArgs e)
        {
            listGeneralCategory.Clear();
            Category category = new Category();
            listGeneralCategory = category.GetAllCategories();
            DisplayListCategory(listGeneralCategory, listViewCategory);
        }

        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            if (textBoxCategoryId.Text.Trim().Length > 0)
            {
                category.CategoryId = Convert.ToInt32(textBoxCategoryId.Text.Trim());
            }
            else
            {
                MessageBox.Show("Please select a Category before updating", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            category.CategoryName = textBoxCategoryName.Text.Trim();
            var asking = MessageBox.Show("Do you want to delete the Category you choose?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (asking == DialogResult.Yes)
            {
                category.DeleteCategory(category);
                MessageBox.Show("Delete Category successfully", "Delete Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            textBoxCategoryName.Clear();
            textBoxCategoryId.Clear();
            textBoxCategoryId.Focus();
            textBoxCategoryId.Enabled = true;
            buttonDeleteCategory.Enabled = false;
            buttonUpdateCategory.Enabled = false;
            listViewCategory.Items.Clear();
        }

        private void buttonSearchCategory_Click(object sender, EventArgs e)
        {
            listGeneralCategory.Clear();
            switch (comboBoxSearchCategory.Text)
            {
                case "Category ID":
                    {                       
                        if (textBoxSearchCategory.Text.Length > 0)
                        {
                            if (Validator.IsValidId(textBoxSearchCategory.Text.Trim(), textBoxSearchCategory.Text.Trim().Length))
                            {
                                Category category = new Category();
                                listGeneralCategory = category.GetCategoriesBySearch(textBoxSearchCategory.Text.Trim(), "CategoryId");
                                DisplayListCategory(listGeneralCategory, listViewCategory);
                            }
                            else
                            {
                                MessageBox.Show("Category ID must be digits", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxSearchCategory.Clear();
                                break;
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Please insert Category ID to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                       
                        break;
                    }
                case "Category Name":
                    {
                                  
                        if (textBoxSearchCategory.Text.Trim().Length > 0)
                        {
                            if (Validator.IsValidName(textBoxSearchCategory.Text.Trim()))
                            {
                                Category category = new Category();
                                listGeneralCategory = category.GetCategoriesBySearch(textBoxSearchCategory.Text.Trim(), "CategoryName");
                                DisplayListCategory(listGeneralCategory, listViewCategory);
                            }
                            else
                            {
                                MessageBox.Show("Category Name must contain only letters", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxSearchCategory.Clear();
                                break;
                            }                            
                        }
                        else
                        {
                            MessageBox.Show("Please insert Category Name to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Please select the option first before searching", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
            }
            
            
        }
        private void buttonClearCategory_Click(object sender, EventArgs e)
        {
            listViewCategory.Items.Clear();
            textBoxCategoryName.Clear();
            textBoxCategoryId.Clear();
            textBoxSearchCategory.Clear();
            textBoxCategoryId.Focus();
            textBoxCategoryId.Enabled = true;
            indexCategory = -1;
            buttonDeleteCategory.Enabled = false;
            buttonUpdateCategory.Enabled = false;
            buttonSaveCategory.Enabled = true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void DisplayListPublisher(List<Publisher> listP, ListView listV)
        {
            listV.Items.Clear();
            foreach (Publisher currentPublisher in listP)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(currentPublisher.PublisherId));
                item.SubItems.Add(currentPublisher.PublisherName);
                item.SubItems.Add(currentPublisher.WebAddress);
                listV.Items.Add(item);
            }
        }
        private void DisplayListCategory(List<Category> listC, ListView listV)
        {
            listV.Items.Clear();
            foreach (Category currentCategory in listC)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(currentCategory.CategoryId));
                item.SubItems.Add(currentCategory.CategoryName);
                listV.Items.Add(item);
            }
        }
        private void comboBoxSearchPublisher_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSearchPublisher.Text)
            {
                case "Publisher ID":
                    {
                        labelMessagePublisher.Text = "Insert Publisher ID";
                        break;
                    }
                case "Publisher Name":
                    {
                        labelMessagePublisher.Text = "Insert Publisher Name";
                        break;
                    }
                case "Web Address":
                    {
                        labelMessagePublisher.Text = "Insert Web Address";
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Please select option to search", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }

        private void comboBoxSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSearchCategory.Text)
            {
                case "Category ID":
                    {
                        labelMessageCategory.Text = "Insert Category ID";
                        break;
                    }
                case "Category Name":
                    {
                        labelMessageCategory.Text = "Insert Category Name";
                        break;
                    }
            }
        }
    }
}
