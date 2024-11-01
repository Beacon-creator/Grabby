
using Grabby_Two.View;
using Grabby_Two.View.TabbedPages;

namespace Grabby_Two
    {
    public partial class AppShell : Shell
        {
        public AppShell()
            {
            InitializeComponent();

            Routing.RegisterRoute("AccountPageMain", typeof(View.TabbedPages.AccountPageMain));
            Routing.RegisterRoute("CartPageMain", typeof(View.TabbedPages.CartPageMain));
            Routing.RegisterRoute("HomePage", typeof(View.TabbedPages.HomePage));
            Routing.RegisterRoute("SearchPage", typeof(View.TabbedPages.SearchPage));


            Routing.RegisterRoute("FashionPage", typeof(View.TabbedPages.HomeCrew.FashionPage));
            Routing.RegisterRoute("StoreInformation", typeof(View.TabbedPages.HomeCrew.StoreInformation));

            Routing.RegisterRoute("FashionStore1", typeof(View.TabbedPages.HomeCrew.FashionStores.FashionStore1));
            Routing.RegisterRoute("ProductDetails1", typeof(View.TabbedPages.HomeCrew.FashionStores.ProductDetails1));


            Routing.RegisterRoute(nameof(StartPage), typeof(StartPage));
            Routing.RegisterRoute(nameof(SignInPage), typeof(SignInPage));
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));



            Routing.RegisterRoute(nameof(HomeScreen), typeof(View.HomeScreen));
            Routing.RegisterRoute(nameof(EmailVerificationPage), typeof(View.EmailVerificationPage));
            Routing.RegisterRoute(nameof(AccountPage), typeof(View.AccountPage));
            Routing.RegisterRoute(nameof(CartPage), typeof(View.CartPage));

            }

        public async Task NavigateToHomeScreen(string email)
            {
            // Set the TabBar to visibleemail
            MainTabBar.IsVisible = true;



            await Shell.Current.GoToAsync($"///HomePage?name={email}");
            }
        public async Task NavigateToHome()
            {
            // Set the TabBar to visible
          //  MainTabBar.IsVisible = true;

            // Navigate to the HomePage tab
            await Shell.Current.GoToAsync("///HomePage");


            }

        public async Task NavigateToLoginPage()
            {
            // Set the TabBar to hidden
          //  MainTabBar.IsVisible = false;
            // Navigate to the SignInPage
            await GoToAsync(nameof(SignInPage));
            }

        public async Task NavigateToQRscreen()
            {
            // Set the TabBar to visible
          //  QRcodeTabbar.IsVisible = true;

            // Navigate to the HomePage tab
            await Shell.Current.GoToAsync("///CardscanPage");

            }


        }
    }
