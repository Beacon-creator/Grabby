using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using Grabby_Two.Custom_Render;
using Grabby_Two.Droid.Custom_Android;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Handlers;
using Application = Android.App.Application;

namespace Grabby_Two.Droid.Custom_Android
{
    public class BorderlessEntryHandler : EntryHandler
    {
        protected override void ConnectHandler(AndroidX.AppCompat.Widget.AppCompatEditText nativeView)
        {
            base.ConnectHandler(nativeView);
            SetBorderless(nativeView);
        }

        private void SetBorderless(AndroidX.AppCompat.Widget.AppCompatEditText nativeView)
        {
            if (nativeView != null)
            {
                nativeView.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
                nativeView.SetPadding(0, 0, 0, 0);
                nativeView.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}
