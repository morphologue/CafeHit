using Windows.UI.Xaml;
using CafeHit.Shared;

namespace CafeHit.Wasm
{
    public class Program
    {
        private static App _app;

        private static int Main(string[] args)
        {
            Application.Start(_ => _app = new App());

            return 0;
        }
    }
}
