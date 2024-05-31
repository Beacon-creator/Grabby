using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Grabby_Two.Custom_Render
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailsCard : ContentView
	{

        public static readonly BindableProperty BackgroundImageSourceProperty = BindableProperty.Create(
          nameof(BackgroundImageSource),
          typeof(ImageSource),
          typeof(ItemsCard),
          null);

        public ImageSource BackgroundImageSource
        {
            get { return (ImageSource)GetValue(BackgroundImageSourceProperty); }
            set { SetValue(BackgroundImageSourceProperty, value); }
        }
        public DetailsCard ()
		{
			InitializeComponent ();
            BindingContext = this;
		}
	}
}