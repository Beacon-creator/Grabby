using Grabby_Two.View.TabbedPages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Grabby_Two.ViewModel
{
    public class TitleBarVM : BaseViewModel
    {
        private INavigation _navigation;
        public ICommand SearchCommand { get; }
        public ICommand CartCommand { get; }
        public ICommand BackCommand { get; }

        public TitleBarVM(INavigation navigation)
        {
            _navigation = navigation;
            // Define your commands
            SearchCommand = new Command(OnSearch);
            CartCommand = new Command(OnCart);
            BackCommand = new Command(OnBack);
        }

        private async void OnSearch()
        {
            // Navigate to the search page
            await Application.Current.MainPage.DisplayAlert("Info", "Search command executed", "OK");
           // await Application.Current.MainPage.Navigation.PushAsync(new SearchPage());
        }

        private async void OnCart()
        {
            // Navigate to the cart page
            await Application.Current.MainPage.DisplayAlert("Info", "Cart command executed", "OK");
           // await Application.Current.MainPage.Navigation.PushAsync(new CartPage());
        }

        private async void OnBack()
        {
            
                await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
