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
using SystemLogin;



namespace Employee_and_User.GUI
{
    public partial class FormEmployeeUser : Form
    {
        int chosenIndex = -1;
        public FormEmployeeUser()
        {
            InitializeComponent();
            textBoxSearch.Enabled = false;
            buttonSave.Enabled = false;
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonSearch.Enabled = false;
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            List<Employee> listE = emp.GetAllEmployees();
            emp.DisplayEmployeeList(listViewEmployees, listE);
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            List<Employee> listP = emp.GetAllEmployees();
            bool checkEmpExist = false;
            foreach (Employee checkEmp in listP)
            {
                if (checkEmp.EmployeeID == Convert.ToInt32(textBoxEmployeeID.Text.Trim()))
                {
                    checkEmpExist = true;
                }
            }
            
            if (checkEmpExist)
            {
                MessageBox.Show("This Employee has already existed", "Inccorrect ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmployeeID.Clear();
                textBoxLastName.Clear();
                return;
            }
            else
            {
                string input = textBoxEmployeeID.Text.Trim();

                if (!Validator.IsValidId(input, 4))
                {
                    MessageBox.Show("Employee ID must be 4-digit number.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxEmployeeID.Clear();
                    textBoxEmployeeID.Focus();
                    textBoxFirstName.Clear();
                    textBoxEmail.Text = "abc@abc.com";
                    textBoxPhoneNumber.Text = "(xxx)xxx-xxxx";
                    return;
                }

                input = textBoxLastName.Text.Trim();
                if (!Validator.IsValidName(input))
                {
                    MessageBox.Show("Last name must be letters only.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxLastName.Clear();
                    textBoxLastName.Focus();
                    return;
                }

                input = textBoxFirstName.Text.Trim();
                if (!Validator.IsValidName(input))
                {
                    MessageBox.Show("First name must be letters only.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxFirstName.Clear();
                    textBoxFirstName.Focus();
                    return;
                }

                input = textBoxPhoneNumber.Text.Trim();
                if (!Validator.IsValidPhoneNumber(input))
                {
                    MessageBox.Show("Phone number format must be (xxx)xxx-xxxx.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPhoneNumber.Text = "(xxx)xxx-xxxx";
                    return;
                }

                input = textBoxEmail.Text.Trim();
                if (!Validator.IsValidEmail(input))
                {
                    MessageBox.Show("Email format is wrong.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxEmail.Text = "abc@abc.com";
                    return;
                }

                int jobID = 0;
                switch (comboBoxJobTitle.SelectedIndex)
                {
                    case 0:
                        jobID = 11111;
                        break;
                    case 1:
                        jobID = 22222;
                        break;
                    case 2:
                        jobID = 33333;
                        break;
                    case 3:
                        jobID = 44444;
                        break;
                    case 4:
                        jobID = 55555;
                        break;
                }



                emp.EmployeeID = Convert.ToInt32(textBoxEmployeeID.Text.Trim());
                emp.LastName = textBoxLastName.Text.Trim();
                emp.FirstName = textBoxFirstName.Text.Trim();
                emp.PhoneNumber = textBoxPhoneNumber.Text.Trim();
                emp.Email = textBoxEmail.Text.Trim();
                emp.JobID = jobID;
                emp.SaveEmployee(emp);
                listViewEmployees.Items.Clear();
                buttonList_Click(sender, e);

                textBoxEmployeeID.Clear();
                textBoxFirstName.Clear();
                textBoxLastName.Clear();
                textBoxPhoneNumber.Text = "(xxx)xxx-xxxx";
                textBoxEmail.Text = "abc@abc.com";
                comboBoxJobTitle.SelectedIndex = -1;
                if (emp.JobID == 11111 || emp.JobID == 22222 || emp.JobID == 33333 || emp.JobID == 44444 || emp.JobID == 55555)
                {
                    MessageBox.Show(" Now enter the password in User Information.", "Creating User Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxEmployeeID.Enabled = false;
                    textBoxFirstName.Enabled = false;
                    textBoxLastName.Enabled = false;
                    comboBoxJobTitle.Enabled = false;
                    textBoxPhoneNumber.Enabled = false;
                    textBoxEmail.Enabled = false;
                    textBoxSearch.Enabled = false;
                    comboBoxSearch.Enabled = false;
                    buttonSave.Enabled = false;
                    buttonClear.Enabled = false;
                    buttonUpdate.Enabled = false;
                    buttonDelete.Enabled = false;
                    //buttonList.Enabled = false;
                    buttonSearch.Enabled = false;

                    textBoxPassword.Enabled = true;
                    textBoxReenterPassword.Enabled = true;

                    buttonSaveUser.Enabled = true;

                    textBoxUserID.Text = Convert.ToString(emp.EmployeeID);

                    buttonClearUser.Enabled = false;
                    buttonUpdateUser.Enabled = false;
                    buttonDeleteUser.Enabled = false;
                    buttonListUser.Enabled = false;
                    buttonSearchUser.Enabled = false;

                    comboBoxSearchUser.Enabled = false;
                    textBoxSearchUser.Enabled = false;
                    listViewEmployees.Items.Clear();
                    listViewUsers.Items.Clear();
                    listViewUsers.Enabled = false;
                    listViewEmployees.Enabled = false;
                }


            }
        }

        private void textBoxEmployeeID_TextChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
            buttonDelete.Enabled = true;
            buttonUpdate.Enabled = true;
        }

        private void textBoxPhoneNumber_Enter(object sender, EventArgs e)
        {
            textBoxPhoneNumber.Clear();
            textBoxPhoneNumber.Focus();
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            textBoxEmail.Clear();
            textBoxEmail.Focus();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.EmployeeID = Convert.ToInt32(textBoxEmployeeID.Text.Trim());
            UserAccount userAccount = new UserAccount();
            userAccount.DeleteUserAccount(emp.EmployeeID);
            emp.DeleteEmployee(emp.EmployeeID);

            listViewEmployees.Items.Clear();
            buttonList_Click(sender, e);
            textBoxEmployeeID.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxPhoneNumber.Text = "(xxx)xxx-xxxx";
            textBoxEmail.Text = "abc@abc.com";
            comboBoxJobTitle.SelectedIndex = -1;
            textBoxEmployeeID.Focus();

        }

        private void listViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jobID = null;
            if (listViewEmployees.SelectedItems.Count > 0)
            {
                textBoxEmployeeID.Text = listViewEmployees.SelectedItems[0].SubItems[0].Text;
                textBoxLastName.Text = listViewEmployees.SelectedItems[0].SubItems[1].Text;
                textBoxFirstName.Text = listViewEmployees.SelectedItems[0].SubItems[2].Text;
                textBoxPhoneNumber.Text = listViewEmployees.SelectedItems[0].SubItems[3].Text;
                textBoxEmail.Text = listViewEmployees.SelectedItems[0].SubItems[4].Text;
                jobID = listViewEmployees.SelectedItems[0].SubItems[5].Text;
                switch (jobID)
                {
                    case "11111":
                        comboBoxJobTitle.SelectedIndex = 0;
                        break;
                    case "22222":
                        comboBoxJobTitle.SelectedIndex = 1;
                        break;
                    case "33333":
                        comboBoxJobTitle.SelectedIndex = 2;
                        break;
                    case "44444":
                        comboBoxJobTitle.SelectedIndex = 3;
                        break;
                    case "55555":
                        comboBoxJobTitle.SelectedIndex = 4;
                        break;
                }
                textBoxEmployeeID.Enabled = false;
                buttonSave.Enabled = false;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int jobID = 0;
            switch (comboBoxJobTitle.SelectedIndex)
            {
                case 0:
                    jobID = 11111;
                    break;
                case 1:
                    jobID = 22222;
                    break;
                case 2:
                    jobID = 33333;
                    break;
                case 3:
                    jobID = 44444;
                    break;
                case 4:
                    jobID = 55555;
                    break;
            }

            Employee emp = new Employee();
            emp.EmployeeID = Convert.ToInt32(textBoxEmployeeID.Text.Trim());
            emp.LastName = textBoxLastName.Text.Trim();
            emp.FirstName = textBoxFirstName.Text.Trim();
            emp.PhoneNumber = textBoxPhoneNumber.Text.Trim();
            emp.Email = textBoxEmail.Text.Trim();
            emp.JobID = jobID;
            emp.UpdateEmployee(emp);

            listViewEmployees.Items.Clear();
            buttonList_Click(sender, e);
            textBoxEmployeeID.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxPhoneNumber.Text = "(xxx)xxx-xxxx";
            textBoxEmail.Text = "abc@abc.com";
            comboBoxJobTitle.SelectedIndex = -1;
            textBoxEmployeeID.Focus();

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxEmployeeID.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxPhoneNumber.Text = "(xxx)xxx-xxxx";
            textBoxEmail.Text = "abc@abc.com";
            comboBoxJobTitle.SelectedIndex = -1;
            textBoxEmployeeID.Focus();
            listViewEmployees.Items.Clear();
            textBoxEmployeeID.Enabled = true;
        }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxSearch.Enabled = true;
            switch (comboBoxSearch.SelectedIndex)
            {
                case 0:
                    labelDisplay.Text = "Please Enter Employee ID";
                    textBoxSearch.Clear();
                    textBoxSearch.Focus();
                    break;
                case 1:
                    labelDisplay.Text = "Please Enter Last Name";
                    textBoxSearch.Clear();
                    textBoxSearch.Focus();
                    break;
                case 2:
                    labelDisplay.Text = "Please Enter First Name";
                    textBoxSearch.Clear();
                    textBoxSearch.Focus();
                    break;
                case 3:
                    labelDisplay.Text = "Please Enter Job ID";
                    textBoxSearch.Clear();
                    textBoxSearch.Focus();
                    break;
            }

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            List<Employee> listV = new List<Employee>();
            bool found = false;

            switch (comboBoxSearch.SelectedIndex)
            {
                case 0:
                    if (!Validator.IsValidId(textBoxSearch.Text, 4))
                    {
                        MessageBox.Show("Employee ID must be 4-digit number.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSearch.Clear();
                        textBoxSearch.Focus();
                        return;
                    }
                    else
                    {
                        listV = emp.SearchEmployee(Convert.ToInt32(textBoxSearch.Text));
                        if (listV.Count > 0)
                        {
                            found = true;
                            emp.DisplayEmployeeList(listViewEmployees, listV);
                        }
                    }
                    break;
                case 1:
                    listV = emp.SearchEmployee(textBoxSearch.Text.Trim());
                    if (listV.Count > 0)
                    {
                        found = true;
                        emp.DisplayEmployeeList(listViewEmployees, listV);
                    }
                    break;
                case 2:
                    listV = emp.SearchEmployee(textBoxSearch.Text.Trim());
                    if (listV.Count > 0)
                    {
                        found = true;
                        emp.DisplayEmployeeList(listViewEmployees, listV);
                    }
                    break;
                case 3:
                    if (!Validator.IsValidId(textBoxSearch.Text, 5))
                    {
                        MessageBox.Show("Job ID must be 5-digit number.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSearch.Clear();
                        textBoxSearch.Focus();
                        return;
                    }
                    else
                    {
                        listV = emp.SearchEmployee(Convert.ToInt32(textBoxSearch.Text));
                        if (listV.Count > 0)
                        {
                            found = true;
                            emp.DisplayEmployeeList(listViewEmployees, listV);
                        }
                    }
                    break;

                default:
                    MessageBox.Show("Please select a search option");
                    break;
            }
            if (found == false)
            {
                MessageBox.Show("Employee with " + this.textBoxSearch.Text + " not found.", "Employee Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxSearch.Text = null;
            textBoxSearch.Focus();
            buttonSearch.Enabled = false;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            buttonSearch.Enabled = true;
        }

        private void buttonSaveUser_Click(object sender, EventArgs e)
        {
            if (Validator.IsValidPassword(textBoxPassword.Text))
            {
                if (Validator.IsValidPassword(textBoxReenterPassword.Text))
                {
                    if (textBoxPassword.Text == textBoxReenterPassword.Text)
                    {
                        UserAccount userAccount = new UserAccount();
                        userAccount.Password = textBoxReenterPassword.Text;
                        userAccount.EmployeeId = Convert.ToInt32(textBoxUserID.Text);
                        userAccount.UserId = Convert.ToInt32(textBoxUserID.Text);
                        userAccount.SaveUserAccount(userAccount);

                        MessageBox.Show("Adding new User successfully!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBoxEmployeeID.Enabled = true;
                        textBoxFirstName.Enabled = true;
                        textBoxLastName.Enabled = true;
                        comboBoxJobTitle.Enabled = true;
                        textBoxPhoneNumber.Enabled = true;
                        textBoxEmail.Enabled = true;
                        textBoxSearch.Enabled = true;
                        comboBoxSearch.Enabled = true;
                        buttonSave.Enabled = true;
                        buttonClear.Enabled = true;
                        buttonUpdate.Enabled = true;
                        buttonDelete.Enabled = true;
                        buttonList.Enabled = true;
                        buttonSearch.Enabled = true;

                        textBoxPassword.Enabled = false;
                        textBoxReenterPassword.Enabled = false;
                        buttonSaveUser.Enabled = false;

                        textBoxUserID.Clear();
                        textBoxPassword.Clear();
                        textBoxReenterPassword.Clear();

                        buttonClearUser.Enabled = true;

                        buttonListUser.Enabled = true;
                        buttonSearchUser.Enabled = true;

                        comboBoxSearchUser.Enabled = true;
                        textBoxSearchUser.Enabled = true;

                        listViewUsers.Enabled = true;
                        listViewEmployees.Enabled = true;

                    }
                    else
                    {
                        textBoxReenterPassword.Clear();
                        textBoxPassword.Clear();
                        MessageBox.Show("The Confirmation Password does not match with the Previous Password. Please enter correctly", "Password Not Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    textBoxReenterPassword.Clear();
                    MessageBox.Show("The Password Format is incorrect. Please only enter digits and letters", "Wrong Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                textBoxPassword.Clear();
                MessageBox.Show("The Password Format is incorrect. Please only enter digits and letters", "Wrong Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void buttonShowOrHide2_Click(object sender, EventArgs e)
        {
            switch (buttonShowOrHide2.Text)
            {
                case "Show":
                    {
                        textBoxReenterPassword.PasswordChar = '\0';
                        buttonShowOrHide2.Text = "Hide";
                        break;
                    }
                case "Hide":
                    {
                        textBoxReenterPassword.PasswordChar = '*';
                        buttonShowOrHide2.Text = "Show";
                        break;
                    }
            }
        }

        private void listViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDeleteUser.Enabled = true;
            buttonUpdateUser.Enabled = true;
            chosenIndex = listViewUsers.FocusedItem.Index;
            UserAccount userAccount = new UserAccount();
            List<UserAccount> listUA = userAccount.GetAllUserAccounts();

            textBoxUserID.Text = Convert.ToString(listUA[chosenIndex].UserId);
            textBoxPassword.Text = listUA[chosenIndex].Password;
            textBoxPassword.Enabled = true;
            textBoxReenterPassword.Enabled = true;
        }

        private void buttonUpdateUser_Click(object sender, EventArgs e)
        {
            if (Validator.IsValidPassword(textBoxPassword.Text))
            {
                if (Validator.IsValidPassword(textBoxReenterPassword.Text))
                {
                    if (textBoxPassword.Text == textBoxReenterPassword.Text)
                    {

                        UserAccount userAccount = new UserAccount();
                        List<UserAccount> listUA = userAccount.GetAllUserAccounts();
                        var asking = MessageBox.Show("Do you want to update the Password of the User you choose?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (asking == DialogResult.Yes)
                        {
                            userAccount = listUA[chosenIndex];
                            userAccount.Password = textBoxPassword.Text;
                            userAccount.UpdateUserAccount(userAccount);
                            MessageBox.Show("Updating the User successfully!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            buttonDeleteUser.Enabled = false;
                            buttonUpdateUser.Enabled = false;
                            textBoxPassword.Clear();
                            textBoxReenterPassword.Clear();
                            textBoxUserID.Clear();
                        }
                    }
                    else
                    {
                        textBoxReenterPassword.Clear();
                        textBoxPassword.Clear();
                        MessageBox.Show("The Confirmation Password does not match with the Previous Password. Please enter correctly", "Password Not Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    textBoxReenterPassword.Clear();
                    MessageBox.Show("The Password Format is incorrect. Please only enter digits and letters", "Wrong Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                textBoxPassword.Clear();
                MessageBox.Show("The Password Format is incorrect. Please only enter digits and letters", "Wrong Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonClearUser_Click(object sender, EventArgs e)
        {
            textBoxUserID.Clear();
            textBoxPassword.Clear();
            textBoxReenterPassword.Clear();
            textBoxSearchUser.Clear();

            listViewUsers.Items.Clear();
            textBoxUserID.Enabled = false;
            textBoxPassword.Enabled = false;
            textBoxReenterPassword.Enabled = false;
            buttonSaveUser.Enabled = false;
            buttonUpdateUser.Enabled = false;
            buttonDeleteUser.Enabled = false;
        }

        private void comboBoxSearchUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxSearch.Enabled = true;
            switch (comboBoxSearchUser.SelectedIndex)
            {
                case 0:
                    labelDisplayUser.Text = "Please Enter User ID";
                    textBoxSearchUser.Clear();
                    textBoxSearchUser.Focus();
                    break;

            }
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            UserAccount userAccount = new UserAccount();
            List<UserAccount> listUA = userAccount.GetAllUserAccounts();
            Employee emp = new Employee();
            var asking = MessageBox.Show("Do you want to delete the User you choose?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (asking == DialogResult.Yes)
            {
                userAccount = listUA[chosenIndex];
                int temp = userAccount.EmployeeId;
                userAccount.DeleteUserAccount(userAccount.UserId);
                emp.DeleteEmployee(temp);
                MessageBox.Show("Deleteting User successfully!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonDeleteUser.Enabled = false;
                buttonUpdateUser.Enabled = false;
                textBoxPassword.Clear();
                textBoxReenterPassword.Clear();
                textBoxUserID.Clear();
            }
        }

        private void buttonListUser_Click(object sender, EventArgs e)
        {
            UserAccount userAccount = new UserAccount();

            userAccount.DisplayUserAccountList(listViewUsers, userAccount.GetAllUserAccounts());
        }

        private void buttonSearchUser_Click(object sender, EventArgs e)
        {
            UserAccount userAccount = new UserAccount();
            List<UserAccount> listUA = new List<UserAccount>();
            bool found = false;

            switch (comboBoxSearchUser.Text)
            {
                case "User ID":
                    if (!Validator.IsValidId(textBoxSearchUser.Text, 4))
                    {
                        MessageBox.Show("User ID must be 4-digit number.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSearchUser.Clear();
                        textBoxSearchUser.Focus();
                        return;
                    }
                    else
                    {
                        listUA = userAccount.SearchUserAccount(Convert.ToInt32(textBoxSearchUser.Text));
                        if (listUA.Count > 0)
                        {
                            found = true;
                            userAccount.DisplayUserAccountList(listViewUsers, listUA);
                        }
                    }
                    break;

                default:
                    MessageBox.Show("Please select a search option");
                    break;
            }
            if (found == false)
            {
                MessageBox.Show("User with " + this.textBoxSearchUser.Text + " not found.", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxSearchUser.Text = null;
            textBoxSearchUser.Focus();

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
