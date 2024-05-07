using StockStream.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using SQLite;

namespace StockStream
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateGoodsPage : ContentPage
    {
        public UpdateGoodsPage(Item selectedItem)
        {
            InitializeComponent();
            BindingContext = selectedItem;
            selectedImagePath = selectedItem.ImagePath;
        }

        string selectedImagePath = string.Empty;
        private void SelectImage_Clicked(object sender, EventArgs e)
        {
            var awaited = SelectImage().GetAwaiter();
            awaited.OnCompleted(() =>
            {
                if (awaited.GetResult() != string.Empty)
                {
                    selectedImage.Source = ImageSource.FromFile(awaited.GetResult());
                    selectedImagePath = awaited.GetResult();
                }
                else
                {
                    DisplayAlert("Error", "Something wrong", "OK");
                }
            });
        }
        async Task<string> SelectImage()
        {

            try
            {
                var result = await MediaPicker.PickPhotoAsync();
                if (result != null)
                {
                    return result.FullPath;
                }
                return string.Empty;
            }
            catch (Exception err)
            {
                _ = DisplayAlert("Error", err.Message, "OK");
                return string.Empty;
            }
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entryName.Text) || string.IsNullOrWhiteSpace(entryBrand.Text) || string.IsNullOrWhiteSpace(entryPrice.Text) || string.IsNullOrWhiteSpace(entryQuantity.Text))
            {
                DisplayAlert("Error", "Please fill all fields", "OK");
            }
            else
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
                {
                    conn.CreateTable<Item>();
                    var item = (Item)BindingContext;
                    item.Name = entryName.Text;
                    item.Brand = entryBrand.Text;
                    item.Price = Convert.ToDouble(entryPrice.Text);
                    item.Quantity = Convert.ToInt32(entryQuantity.Text);
                    item.ImagePath = selectedImagePath;
                    conn.Update(item);
                    DisplayAlert("Success", $"{entryName.Text} Updated", "OK");
                    Navigation.PopAsync();
                }
            }
            

        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Delete", "Are you sure you want to delete this item?", "Yes", "No");
            if (answer)
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
                {
                    conn.CreateTable<Item>();
                    conn.Delete((Item)BindingContext);
                    await DisplayAlert("Success", $"{entryName.Text} Deleted", "OK");
                    await Navigation.PopAsync();
                }
            }
            
        }
    }
}