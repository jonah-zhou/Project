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
using Employee_and_User.GUI;
using HiTechClassLibrary.BLL;
using CustomerProject.GUI;
using ProjectBook.GUI;
using Order_Management.GUI;
namespace SystemLogin
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserAccount userAccount = new UserAccount();
                UserAccount userAccountLogin = userAccount.GetUserAccountById(Convert.ToInt32(textBoxUserID.Text));
                
                if (userAccountLogin != null)
                {
                    Employee emp = new Employee();

                    Employee employee = emp.SearchEmployeeByEmployeeIdOfUser(userAccountLogin.EmployeeId);
                    if (Validator.IsValidPassword(textBoxPassword.Text))
                    {
                        if (userAccountLogin.Password == textBoxPassword.Text)
                        {
                            MessageBox.Show("Login Successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            switch(employee.JobID)
                            {
                                case 11111:
                                    {
                                        FormEmployeeUser formEmployee = new FormEmployeeUser();
                                        Hide();
                                        formEmployee.ShowDialog();
                                        Close();
                                        break;
                                    }
                                case 22222:
                                    {
                                        
                                        FormCustomer formcustomer = new FormCustomer();
                                        Hide();
                                        formcustomer.ShowDialog();
                                        Close();
                                        break;
                                    }
                                case 33333:
                                    {
                                        
                                        FormAuthorBook formAuthorBook = new FormAuthorBook();
                                        Hide();
                                        formAuthorBook.ShowDialog();
                                        Close();
                                        break;
                                    }
                                case 44444:
                                    {
                                        FormOrder formOrder = new FormOrder();
                                        Hide();
                                        formOrder.ShowDialog();
                                        Close();
                                        break;
                                    }
                                case 55555:
                                    {
                                        MessageBox.Show("Accountant does not have any privilege to access to HiTech system","No access",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Invalid Job ID", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Your password or User ID is incorrect. Please enter again!", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxPassword.Clear();
                        }
                    }
                    else
                    {
                        textBoxPassword.Clear();
                        MessageBox.Show("The Password can only include digits and letters", "Wrong Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    textBoxUserID.Clear();
                    textBoxPassword.Clear();
                    
                    MessageBox.Show("Your User ID is incorrect or does not exist!", "Invalid User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    

                    
                }
            }
            catch (FormatException)
            {
                if (textBoxUserID.Text == "")
                {
                    MessageBox.Show("The User ID cannot be empty. Please enter the User ID!", "Invalid User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    if (!Validator.IsValidId(textBoxUserID.Text, 4))
                    {
                        MessageBox.Show("The Employee ID must be 4 digits", "Wrong Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                textBoxUserID.Clear();
                textBoxPassword.Clear();
            }

        }





        private void buttonShowOrHide_Click(object sender, EventArgs e)
        {
            switch (buttonShowOrHide.Text)
            {
                case "Show":
                    {
                        textBoxPassword.PasswordChar = '\0';
                        buttonShowOrHide.Text = "Hide";
                        break;
                    }
                case "Hide":
                    {
                        textBoxPassword.PasswordChar = '*';
                        buttonShowOrHide.Text = "Show";
                        break;
                    }
            }
        }
    }
}
