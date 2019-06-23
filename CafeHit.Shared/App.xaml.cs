using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CafeHit.Shared
{
    /// <summary>
    /// Application-specific behavior to supplement the default Application class
    /// </summary>
    sealed partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        /// <summary>Handle application launch by an end user.  Other entry points will be used e.g.
        /// when the application is launched to open a specific file.</summary>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (!(Windows.UI.Xaml.Window.Current.Content is Frame rootFrame))
            {
                Windows.UI.Xaml.Window.Current.Content = rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored, navigate to the first page.
                    rootFrame.Navigate(typeof(LoginPage));
                }

                Windows.UI.Xaml.Window.Current.Activate();
            }
        }

        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }
    }
}
