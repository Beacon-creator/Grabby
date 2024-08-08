using Grabby_Two.Model;
using Grabby_Two.ViewModel;
using Microsoft.Maui.Controls;

namespace Grabby_Two.View
    {
    public sealed partial class SignUpPage : ContentPage
        {

        public SignUpPage()
            {
            InitializeComponent();
            BindingContext = ServiceProviderHelper.GetService<SignUpPageViewModel>();
            }

        }
    }
