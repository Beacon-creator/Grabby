using Grabby_Two.Model;
using Grabby_Two.ViewModel;
using Grabby_Two.ViewModels;

namespace Grabby_Two.View;

public partial class StartPage : ContentPage
    {
    private StartPagesViewModel ViewModel => BindingContext as StartPagesViewModel;
    public StartPage()
	{
		InitializeComponent();

        BindingContext = new StartPagesViewModel();
        }


    private void OnCarouselPositionChanged(object sender, PositionChangedEventArgs e)
        {
        // Update the ViewModel's CurrentCarouselIndex when the position changes
        if (ViewModel != null)
            {
            ViewModel.CurrentCarouselIndex = e.CurrentPosition;
            }
        }
}
