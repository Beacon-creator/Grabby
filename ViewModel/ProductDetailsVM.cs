using Grabby_Two.View.TabbedPages.HomeCrew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Grabby_Two.ViewModel
{
    public class ProductDetailsVM : BaseViewModel
    {
        public ICommand NavigateCommand { get; }

        public ProductDetailsVM()
        {
            NavigateCommand = new Command(OnNavigate);
        }

        private async void OnNavigate()
        {
            // Your navigation logic here
            await Application.Current.MainPage.Navigation.PushAsync(new StoreInformation());
        }
    }
}