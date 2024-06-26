using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using Grabby_Two.ViewModel;
namespace Grabby_Two.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignInPage : ContentPage
	{
        private SignInPageVM _viewModel;
        public SignInPage (SignInPageVM vm)
		{
			InitializeComponent ();
            _viewModel = vm;
            BindingContext = _viewModel;
        }

        private void RememberMecheck_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

        }

        private void TapGestureRecognizer_ForgotPassword(object sender, EventArgs e)
        {

        }

         private async void SignInBut_Clicked(object sender, EventArgs e)
        {
          await Navigation.PushAsync(new HomeScreen());
        }

        private async void googlebut_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomeScreen());

        }

        private async void Facebooksignup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomeScreen());
        }

        private void TapGestureRecognizer_Signup(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }
    }
}