using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Bike_Factory.Bus;

namespace Bike_Factory.Client
{
    public partial class LoginForm : Form
    {
        static string txtFilePath = @"../../data/login.txt";

        const int MAX = 2;
        Login[] loginArray = new Login[MAX];
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string user = this.textBoxUserName.Text;
            string password = this.textBoxPassword.Text;

            bool error = false;
            if (File.Exists(txtFilePath))
            {
                StreamReader reader = new StreamReader(txtFilePath);

                string line = null;

                for (int i = 0; i < loginArray.Length && ((line = reader.ReadLine()) != null); i++)
                {
                    Login currentUser = new Login();
                    String[] tokens = line.Split(',');
                    currentUser.User = tokens[0];
                    currentUser.Password = tokens[1];

                    loginArray[i] = currentUser;
                }
                reader.Close();
            }
            else
            {
                MessageBox.Show("Login File NOT FOUND");
            }
            for (int index = 0; index < loginArray.Length; index++)
            {
                if (loginArray[index].User == user && loginArray[index].Password == password)
                {
                    MessageBox.Show("You are Logged in successfully");

                    FormBikeFactory mainForm = new FormBikeFactory();
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();

                    break;
                }
                else
                {
                    error = true;
                }
            }
            if (error)
            {
                MessageBox.Show("Login Error... Try again ");
                this.textBoxUserName.Clear();
                this.textBoxPassword.Clear();
                this.textBoxUserName.Focus();
            }
        }
    }
}
