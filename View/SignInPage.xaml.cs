using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
namespace Grabby_Two.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignInPage : ContentPage
	{
		public SignInPage ()
		{
			InitializeComponent ();
		}

        private void RememberMecheck_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

        }

        private void TapGestureRecognizer_ForgotPassword(object sender, EventArgs e)
        {

        }

         private void SignInBut_Clicked(object sender, EventArgs e)
        {
      
        }

        private void googlebut_Clicked(object sender, EventArgs e)
        {

           
        }

        private void Facebooksignup_Clicked(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Signup(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }
    }
}