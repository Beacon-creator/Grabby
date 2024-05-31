using Grabby_Two.Custom_Render;
using Grabby_Two.ViewModel;
using System;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Grabby_Two.View.TabbedPages.HomeCrew
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FashionPage : ContentPage
    {
        public FashionPage()
        {
            InitializeComponent();

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
