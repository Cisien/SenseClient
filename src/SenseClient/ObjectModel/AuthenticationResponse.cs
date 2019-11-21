using System;
using System.Collections.Generic;
using System.Linq;
using ApiAuthenticationResponse = SenseClient.ApiModel.AuthenticationResponse;

namespace SenseClient.ObjectModel
{
    public sealed class AuthenticationResponse
    {
        private AuthenticationResponse()
        {
        }

        internal static AuthenticationResponse Create(ApiAuthenticationResponse apiAuthResponse)
        {
            return new AuthenticationResponse
            {
                Authorized = apiAuthResponse.Authorized,
                AccountId = apiAuthResponse.AccountId,
                UserId = apiAuthResponse.UserId,
                DateCreated = apiAuthResponse.DateCreated,
                PartnerId = apiAuthResponse.PartnerId,
                Monitors = apiAuthResponse.Monitors.Select(a => Monitor.Create(a)).ToList().AsReadOnly(),
                Settings = UserSettings.Create(apiAuthResponse.Settings)
            };
        }
        public bool Authorized { get; internal set; }
        public int AccountId { get; internal set; }
        public int UserId { get; internal set; }
        public string AccessToken { get; internal set; }
        public UserSettings Settings { get; internal set; }
        public IReadOnlyCollection<Monitor> Monitors { get; internal set; } = new List<Monitor>();
        public string BridgeServer { get; internal set; }
        public int? PartnerId { get; internal set; }
        public DateTimeOffset DateCreated { get; internal set; }
    }
}
