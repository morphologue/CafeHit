using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using CafeHit.Shared.Helpers;
using CafeHit.Shared.Models;

namespace CafeHit.Shared
{
    public sealed partial class LoginPage : Page
    {
        public LoginViewModel ViewModel { get; }

        public LoginPage()
        {
            InitializeComponent();
            ViewModel = new LoginViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (true.Equals(e.Parameter))
            {
                PersistenceHelper.Clear<LoginViewModel>();
                return;
            }

            LoginViewModel vm = PersistenceHelper.Deserialize<LoginViewModel>();
            if (vm != null && vm.IsValid)
            {
                Frame.Navigate(typeof(MainPage));
            }
        }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            // Disable the button.
            var userName = ViewModel.UserName;
            var password = ViewModel.Password;
            ViewModel.Reset();

            // TODO: Call API

            PersistenceHelper.Serialize(ViewModel);
            Frame.Navigate(typeof(MainPage));
        }
    }
}
