using Grabby_Two.Custom_Render;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Grabby_Two.Custom_Render
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductCard : ContentView
    {
        public static readonly BindableProperty IconSourceProperty =
            BindableProperty.Create(nameof(IconSource), typeof(ImageSource), typeof(ProductCard), default(ImageSource));

        public static readonly BindableProperty TextNameProperty =
            BindableProperty.Create(nameof(TextName), typeof(string), typeof(ProductCard), string.Empty);

        public static readonly BindableProperty TextPriceProperty =
            BindableProperty.Create(nameof(TextPrice), typeof(string), typeof(ProductCard), string.Empty);

        public static readonly BindableProperty CommandProperty =
         BindableProperty.Create(nameof(Command), typeof(Command), typeof(DesignerCard), null);

        public ImageSource IconSource
        {
            get { return (ImageSource)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

        public string TextName
        {
            get { return (string)GetValue(TextNameProperty); }
            set { SetValue(TextNameProperty, value); }
        }

        public string TextPrice
        {
            get { return (string)GetValue(TextPriceProperty); }
            set { SetValue(TextPriceProperty, value); }
        }

        public Command Command
        {
            get { return (Command)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }


        public ProductCard()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
