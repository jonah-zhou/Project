using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using StockStream.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StockStream
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpdateAccountPage : ContentPage
	{
		public UpdateAccountPage ()
		{
			InitializeComponent ();
            ToolbarItems.Add(new ToolbarItem { Text = "Log out", Command = new Command(OnLogoutClicked) });
            ToolbarItems.Add(new ToolbarItem { Text = "Add", Command = new Command(OnAddClicked) });
        }

        private void OnLogoutClicked()
        {
            foreach (var page in (App.Current.MainPage as TabbedPage).Children.ToList())
            {
                (App.Current.MainPage as TabbedPage).Children.Remove(page);
            }

            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

        private void OnAddClicked()
        {
            Navigation.PushAsync(new MainPage());
        }

        private void buttonUpdate_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(oldPassword.Text))
            {
                DisplayAlert("Missing!!!", "Missing old password", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(newPassword.Text))
            {
                DisplayAlert("Missing!!!", "Missing new password", "OK");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
               
                var listOfAccounts = conn.Table<Account>().ToList();
                bool isExistingAccount = false;

                foreach (var account in listOfAccounts)
                {
                    if (account.Username == "admin")
                    {
                        isExistingAccount = true;
                        if (account.Password == oldPassword.Text)
                        {
                            account.Password = newPassword.Text;
                            conn.Update(account);
                            oldPassword.Text = string.Empty;
                            newPassword.Text = string.Empty;
                            DisplayAlert("Success!!!", "Password updated", "OK");
                            return;
                        }
                        else
                        {
                            oldPassword.Text = string.Empty;
                            newPassword.Text = string.Empty;
                            DisplayAlert("Invalid!!!", "Incorrect old Password", "OK");
                            return;
                        }
                    }
                }

                if (!isExistingAccount)
                {
                    DisplayAlert("Invalid!!!", "Account does not exist", "OK");
                    return;
                }
            }

        }
    }
}