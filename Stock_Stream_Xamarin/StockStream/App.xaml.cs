using SQLite;
using StockStream.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace StockStream
{
    public partial class App : Application
    {
        public static string databaseLocation = string.Empty;
        public App()
        {
            InitializeComponent();         
            MainPage = new NavigationPage(new LoginPage());

        }
        public App(string databaseLocation)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
            App.databaseLocation = databaseLocation;

            string defaultUsername = "admin";
            string defaultPassword = "123";

            using (SQLiteConnection conn = new SQLiteConnection(databaseLocation))
            {
                conn.CreateTable<Account>();

                var existingUser = conn.Table<Account>().FirstOrDefault(u => u.Username == defaultUsername);
                if (existingUser == null)
                {
                    var newUser = new Account
                    {
                        Username = defaultUsername,
                        Password = defaultPassword
                    };

                    conn.Insert(newUser);
                }
            }

        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
