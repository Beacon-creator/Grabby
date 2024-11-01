using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grabby_Two.Model;
using Grabby_Two.Services;


namespace Grabby_Two.ViewModel
    {
    public partial class SignInPageVM : ObservableObject
        {
        private readonly HttpClient _httpClient;
        private readonly IAlertService _alertService;
        


        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private bool rememberMe;

        public SignInPageVM(HttpClient httpClient, IAlertService alertService)
            {
            _httpClient = httpClient ?? new HttpClient();
            _alertService = alertService;
            _httpClient.BaseAddress = new Uri("https://grabbyfanalapi.onrender.com/");
            }

        [RelayCommand]
        private async Task SignInAsync()
            {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                {
                await _alertService.ShowAlertAsync("Error", "Please enter both email and password.", "OK");
                return;
                }

            IsBusy = true;

            try
                {
                var loginData = new { email = Email, password = Password };
                var response = await _httpClient.PostAsJsonAsync("api/login", loginData);

                if (response.IsSuccessStatusCode)
                    {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var tokenObject = JsonSerializer.Deserialize<TokenResponse>(jsonResponse);

                    if (tokenObject != null && !string.IsNullOrEmpty(tokenObject.Token))
                        {
                        var token = tokenObject.Token;

                        // Save the token securely
                        await SecureStorage.SetAsync("auth_token", token);

                        // Extract email from token using JwtService
                        var email = JwtService.GetEmailFromToken(token);

                        if (email != null)
                            {
                            await _alertService.ShowAlertAsync("Login Successful", "You have successfully signed in.", "OK");

                            // Navigate to the home screen
                            var appShell = (AppShell)Application.Current.MainPage;
                            await appShell.NavigateToHomeScreen(email);
                            }
                        else
                            {
                            await _alertService.ShowAlertAsync("Login Failed", "Email not found in token.", "OK");
                            }
                        }
                    else
                        {
                        await _alertService.ShowAlertAsync("Login Failed", "Invalid token received.", "OK");
                        }
                    }
                else
                    {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    await _alertService.ShowAlertAsync("Login Failed", "Invalid credentials, please try again.", "OK");
                    System.Diagnostics.Debug.WriteLine($"Error Response: {errorContent}");
                    }
                }
            catch (HttpRequestException)
                {
                await _alertService.ShowAlertAsync("Login Failed", "A connection error occurred", "OK");
                }
            catch (Exception ex)
                {
                System.Diagnostics.Debug.WriteLine($"Error: {ex}");
                await _alertService.ShowAlertAsync("Login Failed", "An unexpected error occurred, please try again.", "OK");
                }
            finally
                {
                IsBusy = false;
                }
            }


        [RelayCommand]
        private async Task SignInWithGoogleAsync()
            {
            await _alertService.ShowAlertAsync("Google Sign-In", "Google Sign-In not implemented yet.", "OK");
            }

        [RelayCommand]
        private async Task SignInWithFacebookAsync()
            {
            await _alertService.ShowAlertAsync("Facebook Sign-In", "Facebook Sign-In not implemented yet.", "OK");
            }

        [RelayCommand]
        private async Task NavigateToForgotPasswordAsync()
            {
            await Shell.Current.GoToAsync("//ForgotPasswordPage");
            }

        [RelayCommand]
        private async Task NavigateToSignUpAsync()
            {
            await Shell.Current.GoToAsync("//SignUpPage");
            }

        private class TokenResponse
            {
            [JsonPropertyName("token")]
            public string? Token { get; set; }
            }
        }
    }
