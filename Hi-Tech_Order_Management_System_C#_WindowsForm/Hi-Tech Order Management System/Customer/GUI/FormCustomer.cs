using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTechClassLibrary.BLL;
using HiTechClassLibrary.VALIDATION;
using SystemLogin;

namespace CustomerProject.GUI
{
    public partial class FormCustomer : Form
    {
        SqlDataAdapter da;
        DataSet dsHiTechDB;
        DataTable dtCustomer;
        SqlCommandBuilder cmdBuilder;
        public FormCustomer()
        {
            InitializeComponent();
            textBoxSearch.Enabled = false;
            buttonSave.Enabled = false;
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonSearch.Enabled = false;
            comboBoxSearch.Enabled = false;
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            dsHiTechDB = new DataSet();
            dtCustomer = new DataTable("Customers");
            dsHiTechDB.Tables.Add(dtCustomer);

            dtCustomer.Columns.Add("CustomerId", typeof(int));
            dtCustomer.Columns.Add("CustomerName", typeof(string));
            dtCustomer.Columns.Add("StreetName", typeof(string));
            dtCustomer.Columns.Add("Province", typeof(string));
            dtCustomer.Columns.Add("City", typeof(string));
            dtCustomer.Columns.Add("PostalCode", typeof(string));
            dtCustomer.Columns.Add("PhoneNumber", typeof(string));
            dtCustomer.Columns.Add("ContactName", typeof(string));
            dtCustomer.Columns.Add("ContactEmail", typeof(string));
            dtCustomer.Columns.Add("CreditLimit", typeof(int));
            dtCustomer.Columns.Add("Status", typeof(int));

            dtCustomer.PrimaryKey = new DataColumn[] { dtCustomer.Columns["CustomerId"] };
            da = new SqlDataAdapter();
            da.TableMappings.Add("Customers", "Customers");
            cmdBuilder = new SqlCommandBuilder(da);

        }

        private void buttonListDS_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            da.SelectCommand = customer.GetAllCustomersFromTable();
            da.Fill(dsHiTechDB.Tables["Customers"]);
            dataGridViewDS.DataSource = dsHiTechDB.Tables["Customers"];
            comboBoxSearch.Enabled = true;
            buttonSave.Enabled = true;
            buttonDelete.Enabled = true;
            buttonUpdate.Enabled = true;
        }

        private void buttonListDB_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            dataGridViewDS.DataSource = customer.GetAllCustomers();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to exit Application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Thank you!", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxCustomerID.Clear();
            textBoxCustomerID.Enabled = true;
            textBoxCustomerName.Clear();
            textBoxStreetName.Clear();
            textBoxProvince.Clear();
            textBoxCity.Clear();
            textBoxPostalCode.Clear();
            textBoxPhoneNumber.Text = "(xxx)xxx-xxxx";
            textBoxContactName.Clear();
            textBoxContactEmail.Text = "abc@abc.com";
            textBoxCreditLimit.Clear();
            comboBoxStatus.SelectedIndex = -1;
            textBoxSearch.Clear();
            comboBoxSearch.SelectedIndex = -1;

            dataGridViewDS.DataSource = null;
            
        }

        private void buttonUpdateDB_Click(object sender, EventArgs e)
        {
            da.Update(dsHiTechDB.Tables["Customers"]);
            MessageBox.Show("Database has been Updated successfully", "Comfirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            buttonListDB_Click(sender, e);
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            string input = textBoxCustomerID.Text.Trim();

            if (!Validator.IsValidId(input, 6))
            {
                MessageBox.Show("Employee ID must be 6-digit number.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }

            input = textBoxPhoneNumber.Text.Trim();
            if (!Validator.IsValidPhoneNumber(input))
            {
                MessageBox.Show("Phone number format must be (xxx)xxx-xxxx.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPhoneNumber.Text = "(xxx)xxx-xxxx";
                return;
            }

            input = textBoxContactEmail.Text.Trim();
            if (!Validator.IsValidEmail(input))
            {
                MessageBox.Show("Email format is wrong.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContactEmail.Text = "abc@abc.com";
                return;
            }

            int status = 0;
            switch (comboBoxStatus.SelectedIndex)
            {
                case 0:
                    status = 5;
                    break;
                case 1:
                    status = 6;
                    break;                
            }

            DataRow dr = dtCustomer.NewRow();
            dr["CustomerId"] = textBoxCustomerID.Text.Trim();
            dr["CustomerName"] = textBoxCustomerName.Text.Trim();
            dr["StreetName"] = textBoxStreetName.Text.Trim();
            dr["Province"] = textBoxProvince.Text.Trim();
            dr["City"] = textBoxCity.Text.Trim();
            dr["PostalCode"] = textBoxPostalCode.Text.Trim();
            dr["PhoneNumber"] = textBoxPhoneNumber.Text.Trim();
            dr["ContactName"] = textBoxContactName.Text.Trim();
            dr["ContactEmail"] = textBoxContactEmail.Text.Trim();
            dr["CreditLimit"] = textBoxCreditLimit.Text.Trim();
            dr["Status"] = status;
            try
            {
                dtCustomer.Rows.Add(dr);
                MessageBox.Show("New Customer has been added successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ConstraintException)
            {
                MessageBox.Show("Customer ID already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }

            textBoxCustomerID.Clear();
            textBoxCustomerID.Focus();
            textBoxCustomerName.Clear();
            textBoxStreetName.Clear();
            textBoxProvince.Clear();
            textBoxCity.Clear();
            textBoxPostalCode.Clear();
            textBoxPhoneNumber.Text = "(xxx)xxx-xxxx";
            textBoxContactName.Clear();
            textBoxContactEmail.Text = "abc@abc.com";
            textBoxCreditLimit.Clear();
            comboBoxStatus.SelectedIndex = -1;

        }

        private void textBoxPhoneNumber_Enter(object sender, EventArgs e)
        {
            textBoxPhoneNumber.Clear();
            textBoxPhoneNumber.Focus();

        }

        private void textBoxContactEmail_Enter(object sender, EventArgs e)
        {
            textBoxContactEmail.Clear();
            textBoxContactEmail.Focus();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int customerId = Convert.ToInt32(textBoxCustomerID.Text.Trim());
            string input = textBoxPhoneNumber.Text.Trim();
            if (!Validator.IsValidPhoneNumber(input))
            {
                MessageBox.Show("Phone number format must be (xxx)xxx-xxxx.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPhoneNumber.Text = "(xxx)xxx-xxxx";
                return;
            }

            input = textBoxContactEmail.Text.Trim();
            if (!Validator.IsValidEmail(input))
            {
                MessageBox.Show("Email format is wrong.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContactEmail.Text = "abc@abc.com";
                return;
            }


            int status = 0;
            switch (comboBoxStatus.SelectedIndex)
            {
                case 0:
                    status = 5;
                    break;
                case 1:
                    status = 6;
                    break;
            }

            DataRow dr = dtCustomer.Rows.Find(customerId);
            if (dr != null)
            {
                dr["CustomerName"] = textBoxCustomerName.Text.Trim();
                dr["StreetName"] = textBoxStreetName.Text.Trim();
                dr["Province"] = textBoxProvince.Text.Trim();
                dr["City"] = textBoxCity.Text.Trim();
                dr["PostalCode"] = textBoxPostalCode.Text.Trim();
                dr["PhoneNumber"] = textBoxPhoneNumber.Text.Trim();
                dr["ContactName"] = textBoxContactName.Text.Trim();
                dr["ContactEmail"] = textBoxContactEmail.Text.Trim();
                dr["CreditLimit"] = textBoxCreditLimit.Text.Trim();
                dr["Status"] = status;
                MessageBox.Show("Customer has been updated successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Customer ID does not exist", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            int customerId = Convert.ToInt32(textBoxCustomerID.Text.Trim());
            DataRow dr = dtCustomer.Rows.Find(customerId);
            if (dr != null)
            {
                dr.Delete();
                MessageBox.Show("Customer has been deleted successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Customer ID does not exist", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxCustomerID.Clear();
            textBoxCustomerID.Focus();
            textBoxCustomerName.Clear();
            textBoxStreetName.Clear();
            textBoxProvince.Clear();
            textBoxCity.Clear();
            textBoxPostalCode.Clear();
            textBoxPhoneNumber.Text = "(xxx)xxx-xxxx";
            textBoxContactName.Clear();
            textBoxContactEmail.Text = "abc@abc.com";
            textBoxCreditLimit.Clear();
            comboBoxStatus.SelectedIndex = -1;

        }

        private void dataGridViewDS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewDS.Rows[e.RowIndex];
                textBoxCustomerID.Text = row.Cells["CustomerId"].Value.ToString();
                textBoxCustomerName.Text = row.Cells["CustomerName"].Value.ToString();
                textBoxStreetName.Text = row.Cells["StreetName"].Value.ToString();
                textBoxProvince.Text = row.Cells["Province"].Value.ToString();
                textBoxCity.Text = row.Cells["City"].Value.ToString();
                textBoxPostalCode.Text = row.Cells["PostalCode"].Value.ToString();
                textBoxPhoneNumber.Text = row.Cells["PhoneNumber"].Value.ToString();
                textBoxContactName.Text = row.Cells["ContactName"].Value.ToString();
                textBoxContactEmail.Text = row.Cells["ContactEmail"].Value.ToString();
                textBoxCreditLimit.Text = row.Cells["CreditLimit"].Value.ToString();
                string status = row.Cells["Status"].Value.ToString();
                switch (status)
                {
                    case "5":
                        comboBoxStatus.SelectedIndex = 0;
                        break;
                    case "6":
                        comboBoxStatus.SelectedIndex = 1;
                        break;
                }
                textBoxCustomerID.Enabled = false;
                buttonSave.Enabled = false;
            }
        }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxSearch.Enabled = true;
            switch (comboBoxSearch.SelectedIndex)
            {
                case 0:
                    labelDisplay.Text = "Please Enter Customer ID";
                    textBoxSearch.Clear();
                    textBoxSearch.Focus();
                    break;
                case 1:
                    labelDisplay.Text = "Please Enter Customer Name";
                    textBoxSearch.Clear();
                    textBoxSearch.Focus();
                    break;
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            buttonSearch.Enabled = true;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string input = textBoxSearch.Text.Trim();
            string status = null;
            if (comboBoxSearch.SelectedIndex == 0)
            {
                if (!Validator.IsValidId(input, 6))
                {
                    MessageBox.Show("Customer ID must be 6-digital.", "Invalid Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSearch.Clear();
                    textBoxSearch.Focus();
                    return;
                }
                else
                {
                    DataRow dr = dtCustomer.Rows.Find(Convert.ToInt32(input));
                    
                    if (dr != null)
                    {
                        textBoxCustomerID.Text = dr["CustomerId"].ToString();
                        textBoxCustomerName.Text = dr["CustomerName"].ToString();
                        textBoxStreetName.Text = dr["StreetName"].ToString();
                        textBoxProvince.Text = dr["Province"].ToString();
                        textBoxCity.Text = dr["City"].ToString();
                        textBoxPostalCode.Text = dr["PostalCode"].ToString();
                        textBoxPhoneNumber.Text = dr["PhoneNumber"].ToString();
                        textBoxContactName.Text = dr["ContactName"].ToString();
                        textBoxContactEmail.Text = dr["ContactEmail"].ToString();
                        textBoxCreditLimit.Text = dr["CreditLimit"].ToString();
                        status = dr["Status"].ToString();
                        switch (status)
                        {
                            case "5":
                                comboBoxStatus.SelectedIndex = 0;
                                break;
                            case "6":
                                comboBoxStatus.SelectedIndex = 1;
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer ID does not exist", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            else if (comboBoxSearch.SelectedIndex == 1)
            {
                DataRow dr = dtCustomer.Select("CustomerName = '" + input + "'").FirstOrDefault();
                if (dr != null)
                {

                    textBoxCustomerID.Text = dr["CustomerId"].ToString();
                    textBoxCustomerName.Text = dr["CustomerName"].ToString();
                    textBoxStreetName.Text = dr["StreetName"].ToString();
                    textBoxProvince.Text = dr["Province"].ToString();
                    textBoxCity.Text = dr["City"].ToString();
                    textBoxPostalCode.Text = dr["PostalCode"].ToString();
                    textBoxPhoneNumber.Text = dr["PhoneNumber"].ToString();
                    textBoxContactName.Text = dr["ContactName"].ToString();
                    textBoxContactEmail.Text = dr["ContactEmail"].ToString();
                    textBoxCreditLimit.Text = dr["CreditLimit"].ToString();
                    status = dr["Status"].ToString();
                    switch (status)
                    {
                        case "5":
                            comboBoxStatus.SelectedIndex = 0;
                            break;
                        case "6":
                            comboBoxStatus.SelectedIndex = 1;
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Customer Name does not exist", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonToLogin_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to exit Application and go back to Login?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Back to Login!", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FormLogin formLogin = new FormLogin();
                formLogin.ShowDialog();
                this.Close();

            }
        }
    }
}
