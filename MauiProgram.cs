using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Grabby_Two.Custom_Render;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Controls;
using Grabby_Two.View.TabbedPages;
using Grabby_Two.View;
using Grabby_Two.ViewModel;
using Grabby_Two.Model;
using Grabby_Two.View.TabbedPages.HomeCrew;
using Grabby_Two.View.TabbedPages.HomeCrew.FashionStores;
using Grabby_Two.Services;



namespace Grabby_Two
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).UseMauiCommunityToolkit();

            //extensions
            builder.UseMauiApp<App>();
         //   builder.Services.AddHttpClient();

            builder.Services.AddSingleton<StartPage>();
            builder.Services.AddSingleton<SignInPage>();
            builder.Services.AddSingleton<SignUpPage>();
            builder.Services.AddSingleton<HomeScreen>();
            builder.Services.AddSingleton<CodeVerificationSignUpPage>();
            builder.Services.AddSingleton<SearchPage>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<FashionPage>();
            builder.Services.AddSingleton<StoreInformation>();
            builder.Services.AddSingleton<FashionStore1>();
            builder.Services.AddSingleton<ProductDetails1>();


            builder.Services.AddSingleton<SignInPageVM>();
            builder.Services.AddSingleton<SignUpPageViewModel>();


            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddSingleton<HttpClientService>();
            builder.Services.AddSingleton<IAlertService, AlertService>();
            builder.Services.AddSingleton<ILoginService, LoginService>(); 
            builder.Services.AddSingleton<JwtService>();








            EntryHandler.Mapper.AppendToMapping("BorderlessEntry", (handler, view) =>
            {
                if (view is BorderlessEntry)
                    {
#if __ANDROID__
                    handler.PlatformView.Background = null;
                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);

                    // Change the cursor color to black
                    if (handler.PlatformView.TextCursorDrawable != null)
                        {
                        var cursorDrawable = handler.PlatformView.TextCursorDrawable;
                        cursorDrawable.SetColorFilter(Android.Graphics.Color.Black, Android.Graphics.PorterDuff.Mode.SrcIn);
                        handler.PlatformView.TextCursorDrawable = cursorDrawable;
                        }

#elif __IOS__ || MACCATALYST
                                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;

                                   // Change the cursor color to black
                                handler.PlatformView.TintColor = UIKit.UIColor.Black;
#endif
                    }
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();
            ServiceProviderHelper.ServiceProvider = app.Services;

            return builder.Build();
        }
    }
}
