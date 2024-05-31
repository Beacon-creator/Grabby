
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Grabby_Two.Custom_Render
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsCard : ContentView
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

        public static readonly BindableProperty ProductNameProperty = BindableProperty.Create(
            nameof(ProductName),
            typeof(string),
            typeof(ItemsCard),
            string.Empty);

        public string ProductName
        {
            get { return (string)GetValue(ProductNameProperty); }
            set { SetValue(ProductNameProperty, value); }
        }

        public static readonly BindableProperty PriceProperty = BindableProperty.Create(
            nameof(Price),
            typeof(string),
            typeof(ItemsCard),
            string.Empty);

        public string Price
        {
            get { return (string)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        public ItemsCard ()
		{
			InitializeComponent ();
            BindingContext = this;
        }
	}
}