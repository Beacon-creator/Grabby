using System;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using System.Windows.Input;


namespace Grabby_Two.Custom_Render
{
    public partial class FullCard : ContentView
    {
        // Bindable properties
        public static readonly BindableProperty BackgroundImageSourceProperty =
            BindableProperty.Create(
                nameof(BackgroundImageSource), 
                typeof(String), 
                typeof(FullCard),
                null,
                     propertyChanged: (bindable, oldValue, newValue) =>
                     {
                         ((FullCard)bindable).productImage.Source = (string)newValue;
                     });

        public static readonly BindableProperty ProductNameProperty =
            BindableProperty.Create(nameof(ProductName), typeof(string), typeof(FullCard));

        public static readonly BindableProperty PriceProperty =
            BindableProperty.Create(nameof(Price), typeof(string), typeof(FullCard));

        public static readonly BindableProperty RatingProperty =
            BindableProperty.Create(nameof(Rating), typeof(double), typeof(FullCard));

        public static readonly BindableProperty ButtonTextColorProperty =
            BindableProperty.Create(nameof(ButtonTextColor), typeof(Color), typeof(FullCard), Colors.Black);

        public static readonly BindableProperty ButtonBackgroundColorProperty =
            BindableProperty.Create(nameof(ButtonBackgroundColor), typeof(Color), typeof(FullCard), Colors.Gray);

        public static readonly BindableProperty ButtonTextProperty =
            BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(FullCard), "Action");

        // Properties
        public ImageSource BackgroundImageSource
        {
            get { return (string)GetValue(BackgroundImageSourceProperty); }
            set { SetValue(BackgroundImageSourceProperty, value); }
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

        public double Rating
        {
            get => (double)GetValue(RatingProperty);
            set => SetValue(RatingProperty, value);
        }

        public Color ButtonTextColor
        {
            get => (Color)GetValue(ButtonTextColorProperty);
            set => SetValue(ButtonTextColorProperty, value);
        }

        public Color ButtonBackgroundColor
        {
            get => (Color)GetValue(ButtonBackgroundColorProperty);
            set => SetValue(ButtonBackgroundColorProperty, value);
        }

        public string ButtonText
        {
            get => (string)GetValue(ButtonTextProperty);
            set => SetValue(ButtonTextProperty, value);
        }


        // Commands

        public static readonly BindableProperty ImageTappedCommandProperty = BindableProperty.Create(
nameof(ImageTappedCommand),
typeof(ICommand),
typeof(FullCard),
null);
        public ICommand ImageTappedCommand
        {
            get => (ICommand)GetValue(ImageTappedCommandProperty);
            set => SetValue(ImageTappedCommandProperty, value);
        }

        public static readonly BindableProperty LikeCommandProperty = BindableProperty.Create(
nameof(LikeCommand),
typeof(ICommand),
typeof(FullCard),
null);

        public ICommand LikeCommand
        {
            get => (ICommand)GetValue(LikeCommandProperty);
            set => SetValue(LikeCommandProperty, value);
        }



        private void HandleImageNavigation()
        {
            if (ImageTappedCommand != null && ImageTappedCommand.CanExecute(null))
                ImageTappedCommand.Execute(null);
        }



        public static readonly BindableProperty StarCommandProperty = BindableProperty.Create(
nameof(StarCommand),
typeof(ICommand),
typeof(FullCard),
null);

        public ICommand StarCommand
        {
            get => (ICommand)GetValue(StarCommandProperty);
            set => SetValue(StarCommandProperty, value);
        }


        // Constructor
        public FullCard()
        {
            InitializeComponent();
            BindingContext = this;

            // Wire up click event handlers
            productImage.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => HandleImageNavigation()),
            });

            starbut.Clicked += (sender, e) => HandleStar();

            starbut.Clicked += (sender, e) => HandleLike();
        }

        private void HandleStar()
        {
            if (StarCommand != null && StarCommand.CanExecute(null))
                StarCommand.Execute(null);
        }

        private void HandleLike()
        {
            if (LikeCommand != null && LikeCommand.CanExecute(null))
                LikeCommand.Execute(null);
        }

        // Event handler for the actionButton Clicked event
        private void OnActionButtonClicked(object sender, EventArgs e)
        {
            // Add your logic here when the actionButton is clicked
        }
    }
}
