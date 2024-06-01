using Microsoft.Maui.Handlers;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Platform;
using Android.Graphics;
using Grabby_Two.Platforms.Android;

namespace Grabby_Two.Platforms.Android.Custom_Android
{
    public class BorderlessEntryHandler : EntryHandler
    {
        protected override void ConnectHandler(AppCompatEditText nativeView)
        {
            base.ConnectHandler(nativeView);
            SetBorderless(nativeView);
        }

        private void SetBorderless(AppCompatEditText nativeView)
        {
            if (nativeView != null)
            {
                // Remove the underline
                nativeView.Background = null;
                nativeView.SetPadding(0, 0, 0, 0);

                // Change the cursor color to black
                if (nativeView.TextCursorDrawable != null)
                {
                    var cursorDrawable = nativeView.TextCursorDrawable;
                  //  cursorDrawable.SetColorFilter(System.Drawing.Color.Black, PorterDuff.Mode.SrcIn);
                    nativeView.TextCursorDrawable = cursorDrawable;
                }
            }
        }
    }
}
