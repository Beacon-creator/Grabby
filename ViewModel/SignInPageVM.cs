using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grabby_Two.Model;
using Grabby_Two.Services;
using Grabby_Two.View.TabbedPages;
using Newtonsoft.Json;

namespace Grabby_Two.ViewModel
{
  public partial class SignInPageVM : ObservableObject
    {
        [ObservableProperty]
        private string? _email;

        [ObservableProperty]
        private string? _password;

        //for the signin btton
        //from service folder
        readonly ILoginService loginService = new LoginService();


        [RelayCommand]
        public async void SignIn()
        {
            try
            {

                //checking for internet connection
                if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                {
                    if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
                    {
                        //call the service
                        User user = await loginService.Login(Email, Password);
                        if (user == null)
                        {
                            await Shell.Current.DisplayAlert("Error", "Username/Password is incorrect", "Ok");
                            return;
                        }

                        //calling global variable from app.xaml.us, remove if it contains
                        if (Preferences.ContainsKey(nameof(App.user)))
                        {
                            Preferences.Remove(nameof(App.user));
                        }

                        //save users
                        string userDetails = JsonConvert.SerializeObject(user);

                        //set! so you can access
                        Preferences.Set(nameof(App.user), userDetails);
                        App.user = user;
                        
                        
                        // AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
                        

                        await Shell.Current.GoToAsync(nameof(HomePage));
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "All fields required", "Ok");
                        return;
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "No Internet Access", "Ok");
                    return;
                }

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return;
            }


        }

    }
}
