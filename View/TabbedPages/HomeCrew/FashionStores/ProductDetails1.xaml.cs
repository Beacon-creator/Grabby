using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Grabby_Two.View.TabbedPages.HomeCrew.FashionStores
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetails1 : ContentPage
	{
		public ProductDetails1 ()
		{
			InitializeComponent ();
		}

        private void OnSmallClicked(object sender, EventArgs e)
        {

        }

        private void AddtoCartClicked(object sender, EventArgs e)
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