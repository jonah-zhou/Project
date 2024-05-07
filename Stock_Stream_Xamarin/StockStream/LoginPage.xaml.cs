using SQLite;
using StockStream.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace StockStream
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            
        }
        private void buttonLogin_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entryUsername.Text))
            {
                DisplayAlert("Missing!!!", "Missing username", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(entryPassword.Text))
            {
                DisplayAlert("Missing!!!", "Missing password", "OK");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Account>();
                var listOfAccounts = conn.Table<Account>().ToList();
                bool isExistingAccount = false;
                
                foreach (var account in listOfAccounts) 
                {
                    if (account.Username == entryUsername.Text)
                    {
                        isExistingAccount = true;
                        if (account.Password == entryPassword.Text)
                        {
                            App.Current.MainPage = new TabbedPage
                            {
                                Children =
                                {
                                    new NavigationPage(new GoodsDisplayPage()) { Title = "Goods" },
                                    new NavigationPage(new UpdateAccountPage()) { Title = "Account" }
                                }
                            };
                        }
                        else
                        {
                            DisplayAlert("Invalid!!!", "Incorrect Password", "OK");
                            return;
                        }
                    }
                }
                if (!isExistingAccount) 
                {
                    DisplayAlert("Invalid!!!", "Invalid Account", "OK");
                    return;
                }
            }
                
        }
    }
}