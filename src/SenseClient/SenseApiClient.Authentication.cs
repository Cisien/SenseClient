#nullable enable
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using ApiAuthenticationResponse = SenseClient.ApiModel.AuthenticationResponse;
using System.Net.Http.Headers;
using SenseClient.ObjectModel;

namespace SenseClient
{
    public partial class SenseApiClient
    {
        private ApiAuthenticationResponse? _authResult;

        public AuthenticationResponse? Account {get; internal set;}

        private async Task Authenticate(string email, string password)
        {
            var authParameters = new Dictionary<string, string>()
            {
                ["email"] = email,
                ["password"] = password
            };

            var content = new FormUrlEncodedContent(authParameters);
            var authResponse = await _client.PostAsync("authenticate", content);
            var body = await authResponse.Content.ReadAsStringAsync();
            
            if (!authResponse.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"{authResponse.StatusCode}: Unable to authenticate with the sense api. {body}");
            }

            var authResult = JsonSerializer.Deserialize<ApiAuthenticationResponse>(body, _serializerOptions);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
            Account = AuthenticationResponse.Create(authResult);
            _authResult = authResult;
        }
    }
}
