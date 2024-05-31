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
	public partial class ListingCard : ContentView
	{
        public static readonly BindableProperty BackgroundImageSourceProperty = BindableProperty.Create(
            nameof(BackgroundImageSource),
            typeof(string),
            typeof(ListingCard),
            null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                ((ListingCard)bindable).backgroundImage.Source = (string)newValue;
            });

        public string BackgroundImageSource
        {
            get { return (string)GetValue(BackgroundImageSourceProperty); }
            set { SetValue(BackgroundImageSourceProperty, value); }
        }

        public static readonly BindableProperty ProductNameProperty = BindableProperty.Create(
            nameof(ProductName),
            typeof(string),
            typeof(ListingCard),
            null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                ((ListingCard)bindable).productName.Text = (string)newValue;
            });

        public string ProductName
        {
            get { return (string)GetValue(ProductNameProperty); }
            set { SetValue(ProductNameProperty, value); }
        }

        public static readonly BindableProperty RatingTextProperty = BindableProperty.Create(
            nameof(RatingText),
            typeof(string),
            typeof(ListingCard),
            null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                ((ListingCard)bindable).ratingText.Text = (string)newValue;
            });

        public string RatingText
        {
            get { return (string)GetValue(RatingTextProperty); }
            set { SetValue(RatingTextProperty, value); }
        }

        public ListingCard()
        {
            InitializeComponent();
        }
    }
}

