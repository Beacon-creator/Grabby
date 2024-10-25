using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grabby_Two.Model;
using System.Threading.Tasks;

namespace Grabby_Two.ViewModel
    {
    public partial class SignUpPageViewModel : ObservableObject
        {
        private readonly IAlertService _alertService;
        private readonly HttpClient _httpClient;

        public SignUpPageViewModel(IAlertService alertService, HttpClient httpClient)
            {
            _alertService = alertService;
            _httpClient = httpClient;

            // Set the base address if it is not already set
            if (_httpClient.BaseAddress == null)
                {
                _httpClient.BaseAddress = new Uri("https://grabbyfanalapi.onrender.com/");
                }
            }

        [ObservableProperty]
        private string? fullname;

        [ObservableProperty]
        private string? email;

        [ObservableProperty]
        private string? password;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private bool termsAccepted;

        [ObservableProperty]
        private bool isEmailValid;

        [ObservableProperty]
        private bool isPasswordValid;

        [ObservableProperty]
        private bool isPopupVisible;

        [RelayCommand]
        private async Task SignUpAsync()
            {
            if (IsBusy)
                {
                Console.WriteLine("Sign up process is already in progress. Exiting...");
                return;
                }

            // Pre-checks (e.g., terms, fields, etc.) remain the same...
            IsBusy = true;
            Console.WriteLine("Sign up process started...");

            try
                {
                var signUpModel = new User
                    {
                    FullName = Fullname,
                    Email = Email,
                    Password = Password
                    };

                Console.WriteLine("Sending sign up request to the server...");
                var response = await _httpClient.PostAsJsonAsync("api/signup", signUpModel);

                if (response.IsSuccessStatusCode)
                    {
                    var result = await response.Content.ReadFromJsonAsync<SignUpResponseModel>();
                    Console.WriteLine("Sign up request was successful.");

                    if (result != null && !string.IsNullOrEmpty(result.VerificationCode))
                        {
                        // Display verification code in an alert (or bind to a property if needed)
                        await _alertService.ShowAlertAsync("Successful", $"You have successfully signed up. Your verification code is: {result.VerificationCode}.", "OK");
                        Console.WriteLine($"Sign up succeeded. Verification code: {result.VerificationCode}");

                        // Optionally, navigate to another page for verification
                        await Shell.Current.GoToAsync("///CodeVerificationSignUpPage");
                        }
                    else
                        {
                        await _alertService.ShowAlertAsync("Sign Up Failed", "Could not retrieve verification code.", "OK");
                        Console.WriteLine("Sign up failed: Verification code was missing.");
                        }
                    }
                else
                    {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Sign up failed: Server responded with error - {errorContent}");
                    await _alertService.ShowAlertAsync("Sign Up Failed", "Check details and try again", "OK");
                    }
                }
            catch (HttpRequestException httpEx)
                {
                Console.WriteLine($"Sign up failed: HTTP request error - {httpEx.Message}");
                await _alertService.ShowAlertAsync("Connection Error", "Check your connection and try again.", "OK");
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Sign up failed: An unexpected error occurred - {ex.Message}");
                await _alertService.ShowAlertAsync("Sign Up Failed", "Something went wrong. Try again later.", "OK");
                }
            finally
                {
                IsBusy = false;
                Console.WriteLine("Sign up process completed.");
                }
            }



        // Navigate to SignIn page
        [RelayCommand]
        private async Task SignInAsync()
            {
            await Shell.Current.GoToAsync("///SignInPage");
            }

        // Placeholder for Google SignUp
        [RelayCommand]
        private async Task GoogleSignUp()
            {
            await _alertService.ShowAlertAsync("Failed", "Not available yet", "OK");
            }

        // Placeholder for Microsoft SignUp
        [RelayCommand]
        private async Task MicrosoftSignUp()
            {
            await _alertService.ShowAlertAsync("Failed", "Not available yet", "OK");
            }

        // Display Terms and Conditions popup
        [RelayCommand]
        private async Task ShowTermsPopup()
            {
            var popup = new Custom_Render.TermsAndConditionsPopup
                {
                BindingContext = this
                };
            Application.Current.MainPage.ShowPopup(popup);
            }
        }
    }
