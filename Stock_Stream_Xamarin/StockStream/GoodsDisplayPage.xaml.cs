using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using SQLite;
using StockStream.Model;
using static Xamarin.Essentials.Permissions;
using System.IO;

namespace StockStream
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoodsDisplayPage : ContentPage
    {
        public List<Item> Items { get; set; }


        public GoodsDisplayPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetData();
        }


        private async void GetData()
        {
            List<Item> sortedItems;
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Item>();
                Items = conn.Table<Item>().ToList();

                // Sort the items by SearchCount in descending order
                sortedItems = Items.OrderByDescending(item => item.SearchCount).ToList();
            }

            carouselView.ItemsSource = sortedItems;
            goodsListView.ItemsSource = Items;

        }


        private void OnLogoutClicked(object sender, EventArgs e)
        {

            foreach (var page in (App.Current.MainPage as TabbedPage).Children.ToList())
            {
                (App.Current.MainPage as TabbedPage).Children.Remove(page);
            }

            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateGoodPage());
        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            SearchItems(searchBar.Text);
        }

        private void OnSearchButtonClicked(object sender, EventArgs e)
        {
            SearchItems(searchBar.Text);
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchItems(searchBar.Text);
        }

        private void SearchItems(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                goodsListView.ItemsSource = Items;
            }
            else
            {
                var searchResults = Items.Where(p => p.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                goodsListView.ItemsSource = searchResults;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var selectedImage = sender as Image;
            var selectedItem = selectedImage.BindingContext as Item;

            if (selectedItem != null)
            {
                selectedItem.SearchCount++;

                using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
                {
                    conn.Update(selectedItem);
                }

                Navigation.PushAsync(new UpdateGoodsPage(selectedItem));
            }

        }

        private void TextCell_Tapped(object sender, EventArgs e)
        {
            var selectedTextCell = sender as TextCell;
            var selectedItem = selectedTextCell.BindingContext as Item;

            if (selectedItem != null)
            {
                selectedItem.SearchCount++;

                using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
                {
                    conn.Update(selectedItem);
                }

                Navigation.PushAsync(new UpdateGoodsPage(selectedItem));
            }
        }

    }
}
