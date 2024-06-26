using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Grabby_Two.Custom_Render;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Controls;
using Grabby_Two.View.TabbedPages;
using Grabby_Two.View;
using Grabby_Two.ViewModel;



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
                });


            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<SignInPage>();
            builder.Services.AddSingleton<SignInPageVM>();









            //            EntryHandler.Mapper.AppendToMapping("BorderlessEntry", (handler, view) =>
            //            {
            //                if (view is BorderlessEntry)
            //                {
            //#if __ANDROID__
            //                    handler.PlatformView.Background = null;
            //                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);

            //                    // Change the cursor color to black
            //                    if (handler.PlatformView.TextCursorDrawable != null)
            //                    {
            //                        var cursorDrawable = handler.PlatformView.TextCursorDrawable;
            //                        cursorDrawable.SetColorFilter(Android.Graphics.Color.Black, Android.Graphics.PorterDuff.Mode.SrcIn);
            //                        handler.PlatformView.TextCursorDrawable = cursorDrawable;
            //                    }

            //#elif __IOS__ || MACCATALYST
            //                    handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            //                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;

            //                       // Change the cursor color to black
            //                    handler.PlatformView.TintColor = UIKit.UIColor.Black;
            //#endif
            //                }
            //            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
