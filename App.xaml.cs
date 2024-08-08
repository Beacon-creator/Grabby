using Grabby_Two.Custom_Render;
using Grabby_Two.Model;
using Grabby_Two.View;
using Grabby_Two.View.TabbedPages;
using Grabby_Two.View.TabbedPages.HomeCrew;
using Grabby_Two.View.TabbedPages.HomeCrew.FashionStores;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Grabby_Two
{
    public partial class App : Application
    {

        public static User user;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

           // MainPage = new NavigationPage(new StartPage());

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
            {
#if __ANDROID__
                if (handler.PlatformView != null)
                {
                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                 
                }
#elif __IOS__
                if (handler.PlatformView != null)
                {
                    handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
                }
#endif
            });
        }
    }
}
