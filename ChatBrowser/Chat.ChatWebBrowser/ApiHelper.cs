using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net.Http.Headers;
namespace Chat.ChatWebBrowser
{
    public static class ApiHelper
    {
        public static string URL_BASE = "";
        public static HttpClient apiClient { get;set; }
        public static void InicializeClient()
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };

            var client = new HttpClient(handler);
            apiClient = client;
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
