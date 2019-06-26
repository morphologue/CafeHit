using System;
using System.Net.Http;

namespace CafeHit.Shared.Helpers
{
    public static class ApiHelper
    {
        public static HttpClient Client { get; } = new HttpClient
        {
            BaseAddress = new Uri("https://gavin-tech.com")
        };
    }
}
