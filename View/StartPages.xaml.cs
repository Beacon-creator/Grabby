using Grabby_Two.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Grabby_Two.View
{
    public partial class StartPages : ContentPage, INotifyPropertyChanged
    {
        private int currentCarouselIndex;
        public int CurrentCarouselIndex
        {
            get => currentCarouselIndex;
            set
            {
                if (currentCarouselIndex != value)
                {
                    currentCarouselIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<CarouselItem> CarouselItems { get; set; }
        public ICommand ButtonClickCommand { get; }

        public StartPages()
        {
            InitializeComponent();

            // Set the binding context
            BindingContext = this;

            // Initialize the CarouselItems collection with your data
            CarouselItems = new ObservableCollection<CarouselItem>
            {
                new CarouselItem { ImageUrl = "frame1.png", Title = "Easy way to buy", Description = "Browse through a wide range of products and place your orders from the comfort of your home." },
                new CarouselItem { ImageUrl = "frame2.png", Title = "Fast Delivery", Description = "Get your order(s) delivered to you by fast and reliable courier service." },
                new CarouselItem { ImageUrl = "frame3.png", Title = "Order Tracking", Description = "Grabby supports GPS tracking to keep track of your order status for delivery to the accurate address." },
            };

            carouselView.ItemsSource = CarouselItems;
            indicatorView.ItemsSource = CarouselItems;
        }

        private async void OnSkipClicked(object sender, EventArgs e)
        {
            CurrentCarouselIndex = CarouselItems.Count - 1;
            carouselView.Position = CurrentCarouselIndex;
            ShowGetStartedButton();
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            if (CurrentCarouselIndex < CarouselItems.Count - 1)
            {
                CurrentCarouselIndex++;
                carouselView.Position = CurrentCarouselIndex;
            }
            else
            {
                ShowGetStartedButton();
            }
        }

        private async void OnGetStartedClicked(object sender, EventArgs e)
        {
            // Handle get started action, like navigating to the main page
            await Navigation.PushAsync(new SignUpPage());
        }

        private void OnCarouselPositionChanged(object sender, PositionChangedEventArgs e)
        {
            CurrentCarouselIndex = e.CurrentPosition;

            if (CurrentCarouselIndex == CarouselItems.Count - 1)
            {
                ShowGetStartedButton();
            }
            else
            {
                ShowNavigationButtons();
            }
        }

        private void ShowGetStartedButton()
        {
            indicatorStack.IsVisible = false;
            buttonStack.IsVisible = false;
            getStartedButton.IsVisible = true;
        }

        private void ShowNavigationButtons()
        {
            indicatorStack.IsVisible = true;
            buttonStack.IsVisible = true;
            getStartedButton.IsVisible = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class CarouselItem
        {
            public string ImageUrl { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }
    }
}
