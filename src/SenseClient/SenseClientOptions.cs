using System.Net.Http;

namespace SenseClient
{
    public class SenseClientOptions
    {
        public HttpMessageHandler Handler { get; set; } = new HttpClientHandler();
        public int RateLimit { get; set; } = 30;
    }
}