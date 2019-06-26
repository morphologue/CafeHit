using System;
using System.Net.Http;
using System.Text;

namespace CafeHit.Shared.Extensions
{
    public static class HttpRequestMessageExtensions
    {
        public static void SetAuth(this HttpRequestMessage request, string userName, string password)
        {
            string usernamePassword = $"{userName}:{password}";
            request.Headers.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes(usernamePassword))}");
        }
    }
}
