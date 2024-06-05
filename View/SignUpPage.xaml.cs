using Grabby_Two.Model;
using Microsoft.Maui.Controls.Xaml;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Grabby_Two.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public sealed partial class SignUpPage : ContentPage
    {
       
        public SignUpPage()
        {
            InitializeComponent();

        }

        private void TermsAccepted_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

        }
        private void Rules_Tapped(object sender, EventArgs e)
        {

        }     
       
        private  void createAccountbut_Clicked(object sender, EventArgs e)
        {
           


        }
        private void googlebut_Clicked(object sender, EventArgs e)
        {
            
        }
        private  void Facebooksignup_Clicked(object sender, EventArgs e)
        {
            

        }

        private async void TapGestureRecognizer_Signin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignInPage()).ConfigureAwait(false);
        }

   
    }
}