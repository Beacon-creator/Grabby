using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grabby_Two.Model;
using Microsoft.Maui.Controls;
using Newtonsoft.Json.Serialization;

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
                _httpClient.BaseAddress = new Uri("https://aspbackend20240622133116.azurewebsites.net/");
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
                return;

            if (!TermsAccepted)
                {
                await _alertService.ShowAlertAsync("Sign Up Failed", "Please accept the terms and conditions.", "OK");
                return;
                }

            if (string.IsNullOrEmpty(Fullname) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                {
                await _alertService.ShowAlertAsync("Failed", "Please fill in all details.", "OK");
                return;
                }


            // Validate email and password
            if (!IsEmailValid || !IsPasswordValid)
                {
                await _alertService.ShowAlertAsync("Failed", "Check all details.", "OK");
                return;
                }

            IsBusy = true; // Show the spinner

            try
                {
                var signUpModel = new { Email, Password };

                var response = await _httpClient.PostAsJsonAsync("api/signUp", signUpModel);

                if (response.IsSuccessStatusCode)
                    {
                    var token = await response.Content.ReadAsStringAsync();

                    // Save the token (e.g., in SecureStorage) and navigate to the home screen
                    await SecureStorage.SetAsync("auth_token", token);

                    await _alertService.ShowAlertAsync("Successful", "You have successfully signed up.", "OK");

                    await Shell.Current.GoToAsync("///SignInPage");
                    }
                else
                    {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    IsBusy = false;
                    await _alertService.ShowAlertAsync("Sign Up Failed", "Check details and try again", "OK");
                    }
                }
            catch (HttpRequestException httpEx)
                {
                await _alertService.ShowAlertAsync("Connection Error", "Try again later.", "OK");
                }
            catch (Exception ex)
                {
                await _alertService.ShowAlertAsync("Sign Up Failed", "Try again later", "OK");
                }
            finally
                {
                IsBusy = false; // Hide the spinner
                }
            }

        [RelayCommand]
        private async Task SignInAsync()
            {
            await Shell.Current.GoToAsync("///SignInPage");
            }

        [RelayCommand]
        private async Task GoogleSignUp()
            {
            await _alertService.ShowAlertAsync("Failed", "Not available yet", "OK");
            }

        [RelayCommand]
        private async Task MicrosoftSignUp()
            {
            await _alertService.ShowAlertAsync("Failed", "Not available yet", "OK");
            }

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
