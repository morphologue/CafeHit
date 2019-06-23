using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CafeHit.Shared.Helpers;
using CafeHit.Shared.Models;

namespace CafeHit.Shared
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; }

        public MainPage()
        {
            InitializeComponent();
            ViewModel = PersistenceHelper.Deserialize<MainViewModel>() ?? new MainViewModel();
            ViewModel.PropertyChanged += ViewModel_OnPropertyChanged;
        }

        private void LogoutButton_OnClick(object sender, RoutedEventArgs e)
        {
            PersistenceHelper.Clear<MainViewModel>();
            Frame.Navigate(typeof(LoginPage), true);
        }

        private void OrderButton_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO: Disable the button then actually order.
        }

        private void ViewModel_OnPropertyChanged(object target, PropertyChangedEventArgs e)
        {
            PersistenceHelper.Serialize(ViewModel);
        }
    }
}
