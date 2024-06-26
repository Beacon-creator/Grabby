using Grabby_Two.Custom_Render;
using Grabby_Two.ViewModel;
using System;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using System.Windows.Input;
using Grabby_Two.View.TabbedPages.HomeCrew.FashionStores;

namespace Grabby_Two.View.TabbedPages.HomeCrew
{
    public partial class FashionPage : ContentPage
    {
        public ICommand NavigationCommand1 { get; }
        public ICommand NavigationCommand2 { get; }
        // Define more NavigationCommands as needed

        public ICommand RatingCommand1 { get; }
        public ICommand RatingCommand2 { get; }
        // Define more as needed
        public FashionPage()
        {
            InitializeComponent();
            NavigationCommand1 = new Command(() => OnNavigate("FashionStore1"));
            NavigationCommand2 = new Command(() => OnNavigate("ProductDetails1"));
            // Initialize more NavigationCommands as needed

            RatingCommand1 = new Command(() => OnRate("Product1"));
            RatingCommand2 = new Command(() => OnRate("Product2"));
            // Initialize more RatingCommands as needed

            BindingContext = this;
        }

        private async void OnNavigate(string page)
        {
            // Navigate to the specified page
            switch (page)
            {
                case "FashionStore1":
                    await Navigation.PushAsync(new FashionStore1());
                    break;
                case "ProductDetails1":
                    await Navigation.PushAsync(new ProductDetails1());
                    break;
                    // Add more cases as needed
            }
        }

        private void OnRate(string product)
        {
            // Handle rating logic
            DisplayAlert("Rating", $"Rated product: {product}", "OK");
        }

        private async void cart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage());
        }

        private async void search_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }

        private async void back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
