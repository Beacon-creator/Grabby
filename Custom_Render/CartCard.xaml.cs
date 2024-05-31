using System;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Grabby_Two.Custom_Render
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartCard : ContentView
    {
        // Bindable properties
        public static readonly BindableProperty BackgroundImageSourceProperty =
            BindableProperty.Create(nameof(BackgroundImageSource), typeof(ImageSource), typeof(CartCard));

        public static readonly BindableProperty ProductNameProperty =
            BindableProperty.Create(nameof(ProductName), typeof(string), typeof(CartCard));

        public static readonly BindableProperty PriceProperty =
            BindableProperty.Create(nameof(Price), typeof(string), typeof(CartCard));

        public static readonly BindableProperty SizeTextProperty =
            BindableProperty.Create(nameof(SizeText), typeof(string), typeof(CartCard));

        public static readonly BindableProperty QuantityProperty =
            BindableProperty.Create(nameof(Quantity), typeof(int), typeof(CartCard), 0);

        // Properties
        public ImageSource BackgroundImageSource
        {
            get => (ImageSource)GetValue(BackgroundImageSourceProperty);
            set => SetValue(BackgroundImageSourceProperty, value);
        }

        public string ProductName
        {
            get => (string)GetValue(ProductNameProperty);
            set => SetValue(ProductNameProperty, value);
        }

        public string Price
        {
            get => (string)GetValue(PriceProperty);
            set => SetValue(PriceProperty, value);
        }

        public string SizeText
        {
            get => (string)GetValue(SizeTextProperty);
            set => SetValue(SizeTextProperty, value);
        }

        public int Quantity
        {
            get => (int)GetValue(QuantityProperty);
            set => SetValue(QuantityProperty, value);
        }

        public CartCard()
        {
            InitializeComponent();
            BindingContext = this;
        }

        // Event handlers
        private void OnDeleteLabelClicked(object sender, EventArgs e)
        {
            // Add your logic here when the delete label is clicked
        }

        private void OnDecrementClicked(object sender, EventArgs e)
        {
            // Decrease the quantity
            Quantity = Math.Max(0, Quantity - 1);
        }

        private void OnIncrementClicked(object sender, EventArgs e)
        {
            // Increase the quantity
            Quantity += 1;
        }
    }
}
