using System;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Grabby_Two.Custom_Render
{
    
    public partial class MerchantCard : ContentView
    {
        public static readonly BindableProperty IsActiveProperty =
        BindableProperty.Create(nameof(IsActive), typeof(bool), typeof(MerchantCard), false);

        public bool IsActive
        {
            get => (bool)GetValue(IsActiveProperty);
            set => SetValue(IsActiveProperty, value);
        }
        public MerchantCard()
        {
            InitializeComponent();
            BindingContext = this;
            ActionButtonClicked += (sender, args) => { };
        }

        public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(
           nameof(BackgroundColor),
           typeof(Color),
           typeof(MerchantCard),
           null);

        public Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty IconSourceProperty =
                  BindableProperty.Create(nameof(IconSource), typeof(ImageSource), typeof(ProductCard), default(ImageSource));


        public ImageSource IconSource
        {
            get { return (ImageSource)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }


        public static readonly BindableProperty LabelTextProperty =
              BindableProperty.Create(nameof(LabelText), typeof(string), typeof(MerchantCard), string.Empty);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }



        public static readonly BindableProperty LabelColorProperty = BindableProperty.Create(
            nameof(LabelColor),
            typeof(Color),
            typeof(MerchantCard),
            null);

        public Color LabelColor
        {
            get { return (Color)GetValue(LabelColorProperty); }
            set { SetValue(LabelColorProperty, value); }
        }


        public static readonly BindableProperty ButtonTextProperty =
        BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(MerchantCard), string.Empty);


        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }


        public static readonly BindableProperty ButtonBackgroundColorProperty = BindableProperty.Create(
        nameof(ButtonBackgroundColor),
        typeof(Color),
        typeof(MerchantCard),
        null);

        public Color ButtonBackgroundColor
        {
            get { return (Color)GetValue(ButtonBackgroundColorProperty); }
            set { SetValue(ButtonBackgroundColorProperty, value); }
        }


        public static readonly BindableProperty ButtonTextColorProperty = BindableProperty.Create(
            nameof(ButtonTextColor),
            typeof(Color),
            typeof(MerchantCard),
            null);

        public Color ButtonTextColor
        {
            get { return (Color)GetValue(ButtonTextColorProperty); }
            set { SetValue(ButtonTextColorProperty, value); }
        }

        public event EventHandler? ActionButtonClicked;


        private void OnActionButtonClicked(object sender, EventArgs e)
        {
            ActionButtonClicked?.Invoke(sender, e);
        }
    }
}

