using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using Grabby_Two.ViewModel;
using System.Windows.Input;

namespace Grabby_Two.View.TabbedPages.HomeCrew.FashionStores
{

	public partial class FashionStore1 : ContentPage
	{

        public ICommand ImageTapped1 { get; }
        public ICommand ImageTapped2 { get; }
        // Define more NavigationCommands as needed
        public ICommand LikeCommand1 { get; }
        public ICommand LikeCommand2 { get; }
        public ICommand StarCommand1 { get; }
        public ICommand StarCommand2 { get; }


        public FashionStore1ViewModel ViewModel { get; set; }
        public FashionStore1 ()
		{
			InitializeComponent ();
            ImageTapped1 = new Command(() => OnNavigate("StoreInformation"));
            ImageTapped2 = new Command(() => OnNavigate("CartPage"));



            LikeCommand1 = new Command(() => OnLike("Product1"));
            LikeCommand2 = new Command(() => OnLike("Product2"));



            StarCommand1 = new Command(() => OnStar("Product1"));
            StarCommand2 = new Command(() => OnStar("Product2"));
        }

        private async void OnNavigate(string page)
        {
            // Navigate to the specified page
            switch (page)
            {
                case "StoreInformation":
                    await Navigation.PushAsync(new StoreInformation());
                    break;
                case "CartPage":
                    await Navigation.PushAsync(new CartPage());
                    break;
                    // Add more cases as needed
            }
        }

        private void OnLike(string product)
        {
            // Handle rating logic
            DisplayAlert("Rating", $"Rated product: {product}", "OK");
        }


        private void OnStar(string product)
        {
            // Handle rating logic
            DisplayAlert("Rating", $"Rated product: {product}", "OK");
        }

        private void OnMerchantCardsScrollViewScrolled(object sender, ScrolledEventArgs e)
        {
            var scrollView = (ScrollView)sender;
            var stackLayout = (StackLayout)scrollView.Content;
            var cardWidth = stackLayout.Children[0].Width;

            if (cardWidth > 0)
            {
                int currentIndex = (int)Math.Round(e.ScrollX / cardWidth);
                ViewModel.CurrentIndex = currentIndex;
            }
        }
        private void OnActionButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnLabelClicked(object sender, EventArgs e)
        {

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