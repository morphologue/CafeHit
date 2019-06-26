using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CafeHit.Shared.Extensions;
using CafeHit.Shared.Helpers;
using CafeHit.Shared.Models;
using Newtonsoft.Json;

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

        private async void OrderButton_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.CanOrder = false;

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/coffeefreedom"))
            {
                LoginViewModel cred = PersistenceHelper.Deserialize<LoginViewModel>();
                request.SetAuth(cred.UserName, cred.Password);
                string body = JsonConvert.SerializeObject(ViewModel.ToModel());
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await ApiHelper.Client.SendAsync(request))
                {
                    ViewModel.CanOrder = true;
                    string message = response.IsSuccessStatusCode ? "Order placed" : await response.Content.ReadAsStringAsync();
                    string title = response.IsSuccessStatusCode ? "Success" : "Error";
                    await new MessageDialog(message, title).ShowAsync();
                }
            }
        }

        private void ViewModel_OnPropertyChanged(object target, PropertyChangedEventArgs e)
        {
            PersistenceHelper.Serialize(ViewModel);
        }
    }
}
