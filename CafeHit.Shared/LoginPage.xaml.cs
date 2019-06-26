using System;
using System.Net.Http;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using CafeHit.Shared.Extensions;
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

        private async void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.IsEnabled = false;
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/coffeefreedom"))
            {
                request.SetAuth(ViewModel.UserName, ViewModel.Password);
                using (HttpResponseMessage response = await ApiHelper.Client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        PersistenceHelper.Serialize(ViewModel);
                        ViewModel.Reset();
                        Frame.Navigate(typeof(MainPage));
                        return;
                    }

                    ViewModel.IsEnabled = true;
                    await new MessageDialog(await response.Content.ReadAsStringAsync(), "Error").ShowAsync();
                }
            }
        }
    }
}
