using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using StockStream.Model;
using SQLite;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
namespace StockStream
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateGoodPage : ContentPage
    {
        public CreateGoodPage()
        {
            InitializeComponent();
        }
        string selectedImagePath = string.Empty;
        List<Item> items = null;
        private void SelectImage_Clicked(object sender, EventArgs e)
        {
            var awaiter = SelectImage().GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                if (awaiter.GetResult() != string.Empty)
                {
                    selectedImage.Source = ImageSource.FromFile(awaiter.GetResult());
                    selectedImagePath = awaiter.GetResult();
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
                DisplayAlert("Error", err.Message, "OK");
                return string.Empty;
            }
        }
        private void AddItem_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entryName.Text))
            {
                DisplayAlert("Missing", "Missing Item Name", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(entryBrand.Text))
            {
                DisplayAlert("Missing", "Missing Item Brand", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(entryQuantity.Text))
            {
                DisplayAlert("Missing", "Missing Item Quantity", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(entryPrice.Text))
            {
                DisplayAlert("Missing", "Missing Item Price", "OK");
                return;
            }
            if (string.IsNullOrEmpty(selectedImagePath))
            {
                DisplayAlert("Missing", "Missing Item Image", "OK");
                return;
            }
            Item newItem = new Item()
            {
                Name = entryName.Text,
                Brand = entryBrand.Text,
                Quantity = Convert.ToInt32(entryQuantity.Text),
                Price = Convert.ToDouble(entryPrice.Text),
                ImagePath = selectedImagePath,
                SearchCount = 0
                
            };
            Item.CreateItem(newItem);
            DisplayAlert("Success", $"Adding {entryName.Text} Successfully", "OK");
            entryName.Text = string.Empty;
            entryBrand.Text = string.Empty;
            entryQuantity.Text = string.Empty;
            entryPrice.Text = string.Empty;
            selectedImagePath = string.Empty;
            selectedImage = null;
        }

        private void ChooseFile_Clicked(object sender, EventArgs e)
        {
            var awaiter = OnChooseFileButtonClicked().GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                if (awaiter.GetResult() != string.Empty)
                {             
                    entryChooseFile.Text = awaiter.GetResult();
                    string jsonContent = File.ReadAllText(awaiter.GetResult());
                    items = JsonConvert.DeserializeObject<List<Item>>(jsonContent); 
                }
                else
                {
                    DisplayAlert("Error", "Something wrong", "OK");
                }
            });
        }
        async Task<string> OnChooseFileButtonClicked()
        {
            try
            {
                var fileResult = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Pick a file"
                });

                if (fileResult != null)
                {
                    string fileName = fileResult.FileName;
                    string filePath = fileResult.FullPath;
                    if (fileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                    {
                        return filePath;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private void AddFile_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entryChooseFile.Text))
            {
                DisplayAlert("Missing", "Please select file first", "OK");
                return;
            }
            if (items != null)
            {
                foreach (var item in items)
                {
                    Item.CreateItem(item);
                }
                DisplayAlert("Successfully", $"Adding {items.Count} Items Successfully", "OK");
                entryChooseFile.Text = string.Empty;
                items = null;
            }
            
        }
    }
}