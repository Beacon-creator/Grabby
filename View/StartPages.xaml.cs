using Grabby_Two.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Grabby_Two.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPages : ContentPage
    {

        private int currentCarouselIndex = 0;

        private int clickCount = 0;

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
                new CarouselItem { ImageUrl = "Fram1e.png", Title = "Easy wasy to buy", Description = "Browse through a wide range of products and place your orders from the comfort of your home." },
                new CarouselItem { ImageUrl = "Fram2e.png", Title = "Fast Delivery", Description = "Get your order(s) delivered to you by fast and reliable courier service." },
              new CarouselItem { ImageUrl = "Fram3e.png", Title = "Order Tracking", Description = "Grabby supports GPS tracking to keep track of your order status for delivery to the accurate address" },
            };

            carouselView.ItemsSource = CarouselItems;
            indicatorView.ItemsSource = CarouselItems;
            carouselView.PositionChanged += OnIndicatorChanged;
        }

        private async void OnSkipClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new GetStartedPage());

        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            clickCount++;

            if (clickCount % 2 == 0) // Check if the click count is even (third click)
            {
                // Navigate to a new page
                Navigation.PushAsync(new GetStartedPage());
            }
            else
            {
                // Handle the first click (move to the next carousel item)
                currentCarouselIndex++;
                if (currentCarouselIndex >= CarouselItems.Count)
                {
                    // You can handle the end of the carousel here
                    // For example, navigate to another page
                    currentCarouselIndex = 0;
                }

                carouselView.Position = currentCarouselIndex;
            }
        }

        private void OnIndicatorChanged(object sender, EventArgs e)
        {
            // Handle indicator position change
            // Update the current carousel index
            currentCarouselIndex = carouselView.Position;
        }


        public class CarouselItem
        {
            public string? ImageUrl { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }
        }

        private void OnCarouselPositionChanged(object sender, PositionChangedEventArgs e)
        {
            // Handle indicator position change
            indicatorView.Position = e.CurrentPosition;
        }

    }
}