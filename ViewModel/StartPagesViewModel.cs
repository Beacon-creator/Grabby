using Grabby_Two.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grabby_Two.View;

namespace Grabby_Two.ViewModels
    {
    public partial class StartPagesViewModel : ObservableObject
        {
        [ObservableProperty]
        private int currentCarouselIndex;

        [ObservableProperty]
        private bool isGetStartedVisible;

        [ObservableProperty]
        private bool areSkipAndNextVisible;

        public ObservableCollection<CarouselItem> CarouselItems { get; }

        public ICommand SkipCommand { get; }
        public ICommand NextCommand { get; }
        public ICommand GetStartedCommand { get; }

        public StartPagesViewModel()
            {
            CarouselItems = new ObservableCollection<CarouselItem>
        {
            new CarouselItem { ImageUrl = "frame1.png", Title = "Easy way to buy", Description = "Browse through a wide range of products and place your orders from the comfort of your home." },
            new CarouselItem { ImageUrl = "frame2.png", Title = "Fast Delivery", Description = "Get your order(s) delivered to you by fast and reliable courier service." },
            new CarouselItem { ImageUrl = "frame3.png", Title = "Order Tracking", Description = "Grabby supports GPS tracking to keep track of your order status for delivery to the accurate address." },
        };

            SkipCommand = new RelayCommand(OnSkip);
            NextCommand = new RelayCommand(OnNext);
            GetStartedCommand = new AsyncRelayCommand(OnGetStartedAsync);

            UpdateButtonVisibility();
            }

        private void OnSkip()
            {
            CurrentCarouselIndex = CarouselItems.Count - 1;
            }

        private void OnNext()
            {
            if (CurrentCarouselIndex < CarouselItems.Count - 1)
                {
                CurrentCarouselIndex++;
                }
            UpdateButtonVisibility();
            }

        private async Task OnGetStartedAsync()
            {
            // Navigate to the main page
            await Shell.Current.GoToAsync(nameof(SignUpPage));
            }

        partial void OnCurrentCarouselIndexChanged(int value)
            {
            UpdateButtonVisibility();
            }

        private void UpdateButtonVisibility()
            {
            IsGetStartedVisible = CurrentCarouselIndex == CarouselItems.Count - 1;
            AreSkipAndNextVisible = !IsGetStartedVisible;
            }
        }

    public class CarouselItem
        {
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        }
    }
