using System.Net.Http.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grabby_Two.Model;
using System.Threading.Tasks;

namespace Grabby_Two.ViewModel
    {
    public partial class EmailVerificationPageVM : ObservableObject
        {
        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string? email;

        [ObservableProperty]
        private string codeEntryOne;

        [ObservableProperty]
        private string codeEntryTwo;

        [ObservableProperty]
        private string codeEntryThree;

        [ObservableProperty]
        private string codeEntryFour;

        [ObservableProperty]
        private string codeEntryFive;

        [ObservableProperty]
        private string codeEntrySix;

        private readonly HttpClient _httpClient;
        private readonly IAlertService _alertService;

        public EmailVerificationPageVM(HttpClient httpClient, IAlertService alertService)
            {
            _httpClient = httpClient ?? new HttpClient();
            _alertService = alertService;
            _httpClient.BaseAddress ??= new Uri("https://grabbyfanalapi.onrender.com/");
            }

        [RelayCommand]
        public async Task VerifyCodeCommand()
            {
            IsBusy = true;
            var verificationCode = $"{CodeEntryOne}{CodeEntryTwo}{CodeEntryThree}{CodeEntryFour}{CodeEntryFive}{CodeEntrySix}";

            if (verificationCode.Length != 6)
                {
                await _alertService.ShowAlertAsync("Error", "Please enter the complete 6-digit code.", "OK");
                IsBusy = false;
                return;
                }

            var verificationData = new
                {
                email = Email,
                code = verificationCode
                };

            try
                {
                var response = await _httpClient.PostAsJsonAsync("api/signup/verify-email", verificationData);
                if (response.IsSuccessStatusCode)
                    {
                    await _alertService.ShowAlertAsync("Success", "Verification successful.", "OK");
                    await Shell.Current.GoToAsync("//SignInPage");
                    }
                else
                    {
                    await _alertService.ShowAlertAsync("Error", "Invalid or expired verification code.", "OK");
                    }
                }
            catch (Exception ex)
                {
                await _alertService.ShowAlertAsync("Error", "Verification failed. Please try again later.", "OK");
                }
            finally
                {
                IsBusy = false;
                }
            }
        }
    }
