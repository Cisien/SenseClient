#nullable enable
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Web;

namespace SenseClient
{
    public partial class SenseApiClient
    {
        private readonly SenseClientOptions _options;
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions;

        private SenseApiClient(SenseClientOptions options)
        {
            _options = options ?? new SenseClientOptions();
            _client = new HttpClient(_options.Handler, true)
            {
                BaseAddress = new Uri("https://api.sense.com/apiservice/api/v1/")
            };

            _client.DefaultRequestHeaders.UserAgent.Clear();
            var version = GetType().Assembly.GetName().Version.ToString();
            _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue(HttpUtility.UrlEncode("https://github.com/cisien/SenseClient"), version)));
            _serializerOptions = new JsonSerializerOptions();

        }

        /// <summary>
        /// Creates a new instance of <see cref="SenseApiClient"/> and authenticates.
        /// </summary>
        /// <param name="email">Sense.com username</param>
        /// <param name="password">Sense.com password</param>
        /// <param name="options">Optional configuration</param>
        /// <returns></returns>
        public static async Task<SenseApiClient> Create(string email, string password, Action<SenseClientOptions>? options = null)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            if(string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            var clientOptions = new SenseClientOptions();
            if (options != default)
            {
                options(clientOptions);
            }
            var senseClient = new SenseApiClient(clientOptions);
            await senseClient.Authenticate(email, password);

            return senseClient;
        }
    }
}
