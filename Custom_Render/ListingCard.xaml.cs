using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using System.Windows.Input;

namespace Grabby_Two.Custom_Render
{
	
	public partial class ListingCard : ContentView
	{
        // Define Commands
        public static readonly BindableProperty NavigationCommandProperty = BindableProperty.Create(
     nameof(NavigationCommand),
     typeof(ICommand),
     typeof(ListingCard),
     null);

        public ICommand NavigationCommand
        {
            get => (ICommand)GetValue(NavigationCommandProperty);
            set => SetValue(NavigationCommandProperty, value);
        }

        public static readonly BindableProperty RatingCommandProperty = BindableProperty.Create(
            nameof(RatingCommand),
            typeof(ICommand),
            typeof(ListingCard),
            null);

        public ICommand RatingCommand
        {
            get => (ICommand)GetValue(RatingCommandProperty);
            set => SetValue(RatingCommandProperty, value);
        }




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
            // Wire up click event handlers
            backgroundImage.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => HandleNavigation()),
            });

            starbut.Clicked += (sender, e) => HandleRating();
        }

        // Handle navigation
        private void HandleNavigation()
        {
            if (NavigationCommand != null && NavigationCommand.CanExecute(null))
                NavigationCommand.Execute(null);
        }

        // Handle rating
        private void HandleRating()
        {
            if (RatingCommand != null && RatingCommand.CanExecute(null))
                RatingCommand.Execute(null);
        }
    }
}

