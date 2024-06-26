using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Diagnostics;
using Grabby_Two.View.TabbedPages.HomeCrew;

namespace Grabby_Two.ViewModel
{
    public class FashionStore1ViewModel : INotifyPropertyChanged
    {
        private int _currentIndex;
        public int CurrentIndex
        {
            get => _currentIndex;
            set
            {
                if (_currentIndex != value)
                {
                    _currentIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand Card1TappedCommand { get; }
        public ICommand Card2TappedCommand { get; }
        public ICommand LikeCommand { get; }
        public ICommand StarCommand { get; }
        public ICommand ActionButtonCommand { get; }

        public FashionStore1ViewModel()
        {
            Card1TappedCommand = new Command(OnCard1Tapped);
            Card2TappedCommand = new Command(OnCard2Tapped);
            LikeCommand = new Command(OnLike);
            StarCommand = new Command(OnStar);
            ActionButtonCommand = new Command(OnActionButton);
        }


        private async void OnCard1Tapped(object obj)
        {
            // Handle navigation to Card 1 details
            Debug.WriteLine("Card 1 tapped");
            await Shell.Current.GoToAsync(nameof(StoreInformation));
        }

        private async void OnCard2Tapped(object obj)
        {
            // Handle navigation to Card 2 details
            Debug.WriteLine("Card 2 tapped");
            await Shell.Current.GoToAsync(nameof(StoreInformation));
        }

        private void OnLike(object obj)
        {
            // Handle like action
            Debug.WriteLine("Liked!");
        }

        private void OnStar(object obj)
        {
            // Handle star action
            Debug.WriteLine("Starred!");
        }

        private void OnActionButton(object obj)
        {
            // Handle action button click
            Debug.WriteLine("Action button clicked!");
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
