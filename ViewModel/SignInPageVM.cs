using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grabby_Two.Model;
using Grabby_Two.Services;
using Grabby_Two.View.TabbedPages;
using Newtonsoft.Json;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Networking;

namespace Grabby_Two.ViewModel
    {
    public partial class SignInPageVM : ObservableObject
        {
        private readonly ILoginService loginService; // Inject the login service
        private readonly IConnectivity connectivity; // Inject the connectivity service

        // Constructor where services like loginService and connectivity are injected
        public SignInPageVM(ILoginService loginService, IConnectivity connectivity)
            {
            this.loginService = loginService;
            this.connectivity = connectivity;
            }

        [ObservableProperty]
        private string? email;

        [ObservableProperty]
        private string? password;

        [RelayCommand]
        public async Task SignInAsync()
            {
            try
                {
                // Check for internet connection first
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                    {
                    await Shell.Current.DisplayAlert("Error", "No Internet Access", "Ok");
                    return;
                    }

                // Ensure both fields are filled
                if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
                    {
                    await Shell.Current.DisplayAlert("Error", "All fields are required", "Ok");
                    return;
                    }

                // Call the login service to authenticate
                User user = await loginService.Login(Email, Password);

                if (user == null)
                    {
                    await Shell.Current.DisplayAlert("Error", "Username/Password is incorrect", "Ok");
                    return;
                    }

                // Save user details to preferences
                if (Preferences.ContainsKey(nameof(App.user)))
                    {
                    Preferences.Remove(nameof(App.user)); // Clear existing user if needed
                    }

                // Serialize and store user details
                string userDetails = JsonConvert.SerializeObject(user);
                Preferences.Set(nameof(App.user), userDetails);
                App.user = user;

                // Navigate to the HomePage
                await Shell.Current.GoToAsync(nameof(HomePage));
                }
            catch (Exception ex)
                {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                }
            }
        }
    }
