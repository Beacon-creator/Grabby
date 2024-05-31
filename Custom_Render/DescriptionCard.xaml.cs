
using System;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Grabby_Two.Custom_Render
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DescriptionCard : ContentView
    {// Bindable properties
        public static readonly BindableProperty MerchantNameProperty =
            BindableProperty.Create(nameof(MerchantName), typeof(string), typeof(DescriptionCard), string.Empty);

        public static readonly BindableProperty ProductNameProperty =
            BindableProperty.Create(nameof(ProductName), typeof(string), typeof(DescriptionCard), string.Empty);

        public static readonly BindableProperty RatingProperty =
            BindableProperty.Create(nameof(Rating), typeof(double), typeof(DescriptionCard), 0.0);

        public static readonly BindableProperty ProductPriceProperty =
            BindableProperty.Create(nameof(ProductPrice), typeof(string), typeof(DescriptionCard), string.Empty);

        // Properties
        public string MerchantName
        {
            get => (string)GetValue(MerchantNameProperty);
            set => SetValue(MerchantNameProperty, value);
        }

        public string ProductName
        {
            get => (string)GetValue(ProductNameProperty);
            set => SetValue(ProductNameProperty, value);
        }

        public double Rating
        {
            get => (double)GetValue(RatingProperty);
            set => SetValue(RatingProperty, value);
        }

        public string ProductPrice
        {
            get => (string)GetValue(ProductPriceProperty);
            set => SetValue(ProductPriceProperty, value);
        }

        // Constructor
        public DescriptionCard()
        {
            InitializeComponent();
            BindingContext = this;
        }

        // Event handler for the size labels clicked event
        private void OnSizeLabelClicked(object sender, EventArgs e)
        {
            // Add your logic here when a size label is clicked
        }

        private void OnSmallClicked(object sender, EventArgs e)
        {

        }
    }
}