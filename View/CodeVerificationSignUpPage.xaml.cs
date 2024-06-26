using Grabby_Two.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using Grabby_Two.ViewModel;

namespace Grabby_Two.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CodeVerificationSignUpPage : ContentPage
	{
       
   
        
        public CodeVerificationSignUpPage ()
		{
			InitializeComponent ();

        }

        private bool IsValidEmail(string email)
        {
            // Implement email validation logic as needed
            // You can use regular expressions or other methods
            // This is a simple example, consider using more robust validation
            return email.Contains("@") && email.Contains(".");
        }

        private string GenerateVerificationCode()
        {
            // Implement code generation logic as needed
            // You can use random numbers or other methods
            // This is a simple example, consider using a more secure method
            return new Random().Next(1000, 9999).ToString();
        }

        private void requestcode_Clicked(object sender, EventArgs e)
        {
           


        }

    
        private void ValidateEmail(object sender, TextChangedEventArgs e)
        {

        }

        private async void verifybut_Clicked(object sender, EventArgs e)
        {
            var signInPageViewModel = new SignInPageVM(); // Assuming you have a parameterless constructor
            await Navigation.PushAsync(new SignInPage(signInPageViewModel)).ConfigureAwait(false);
        }
    }
}