using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace Grabby.ViewModel
    {
    public partial class CodeVerificationSignUpPageVM : ObservableObject
        {
        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string? _email;

        [ObservableProperty]
        private string? _verificationCode;

        [ObservableProperty]
        private bool _isEmailValid;

        private readonly HttpClient _httpClient;

        public CodeVerificationSignUpPageVM(HttpClient httpClient)
            {
            _httpClient = httpClient ?? new HttpClient();
            _isEmailValid = false;

            // Set base address if needed
            if (_httpClient.BaseAddress == null)
                {
                _httpClient.BaseAddress = new Uri("https://grabbyfanalapi.onrender.com/");
                }
            }

        [RelayCommand]
        private void ValidateEmail(string email)
            {
            IsEmailValid = IsValidEmail(email);
            }

        private bool IsValidEmail(string email)
            {
            return email.Contains("@") && email.Contains(".");
            }

        [RelayCommand]
        public async Task VerifyCode()
            {
            if (string.IsNullOrEmpty(VerificationCode))
                {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter the verification code.", "OK");
                return;
                }

            IsBusy = true;

            try
                {
                var verificationData = new
                    {
                    email = Email,
                    code = VerificationCode
                    };

                var response = await _httpClient.PostAsJsonAsync("api/signup/verify-email", verificationData);
                if (response.IsSuccessStatusCode)
                    {
                    await Application.Current.MainPage.DisplayAlert("Success", "Verification successful.", "OK");

                    // Navigate to SignInPage after successful verification
                    await Shell.Current.GoToAsync("//SignInPage");
                    }
                else
                    {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid or expired verification code.", "OK");
                    Console.WriteLine($"Error: {errorContent}");
                    }
                }
            catch (Exception ex)
                {
                await Application.Current.MainPage.DisplayAlert("Error", "Verification failed. Please try again later.", "OK");
                Console.WriteLine($"Exception: {ex.Message}");
                }
            finally
                {
                IsBusy = false;
                }
            }
        }
    }
