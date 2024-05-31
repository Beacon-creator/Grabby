// TitleBar.xaml.cs
using Grabby_Two.View.TabbedPages;
using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Grabby_Two.Custom_Render
{
    public partial class TitleBar : ContentView
    {
        public TitleBar()
        {
            InitializeComponent();
        }
        public INavigation Navigation { get; set; }
        // Bindable properties for commands
        public static readonly BindableProperty SearchCommandProperty =
            BindableProperty.Create(nameof(SearchCommand), typeof(ICommand), typeof(TitleBar));

        public static readonly BindableProperty CartCommandProperty =
            BindableProperty.Create(nameof(CartCommand), typeof(ICommand), typeof(TitleBar));

        public static readonly BindableProperty BackCommandProperty =
            BindableProperty.Create(nameof(BackCommand), typeof(ICommand), typeof(TitleBar));

        // Commands for navigation
        public ICommand SearchCommand
        {
            get => (ICommand)GetValue(SearchCommandProperty);
            set => SetValue(SearchCommandProperty, value);
        }

        public ICommand CartCommand
        {
            get => (ICommand)GetValue(CartCommandProperty);
            set => SetValue(CartCommandProperty, value);
        }

        public ICommand BackCommand
        {
            get => (ICommand)GetValue(BackCommandProperty);
            set => SetValue(BackCommandProperty, value);
        }

        // Bindable property for the title
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(TitleBar));

        // Title property
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }


       

        // Event handlers for navigation buttons
        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            if (BackCommand != null && BackCommand.CanExecute(null))
                await Navigation.PopAsync();
        }

        private  void OnSearchButtonClicked(object sender, EventArgs e)
        {
            if (SearchCommand != null && SearchCommand.CanExecute(null))
                SearchCommand.Execute(null);
        }

        private  void OnCartButtonClicked(object sender, EventArgs e)
        {
            if (CartCommand != null && CartCommand.CanExecute(null))
                CartCommand.Execute(null);
        }
    }
}
