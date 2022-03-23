using System.Net.Http;
using System.Net.Http.Headers;
namespace Chat.ChatWebBrowser
{
    public static class ApiHelper
    {
        public static HttpClient apiClient { get;set; }
        public static void InicializeClient()
        {
            apiClient = new HttpClient();
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
