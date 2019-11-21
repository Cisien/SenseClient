using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SenseClient.ApiModel
{
    public class AuthenticationResponse
    {
        [JsonPropertyName("authorized")]
        public bool Authorized { get; set; }

        [JsonPropertyName("account_id")]
        public int AccountId { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("settings")]
        public UserSettings Settings { get; set; }

        [JsonPropertyName("monitors")]
        public List<Monitor> Monitors { get; set; } = new List<Monitor>();

        [JsonPropertyName("bridge_server")]
        public string BridgeServer { get; set; }

        [JsonPropertyName("partner_id")]
        public int? PartnerId { get; set; }

        [JsonPropertyName("date_created")]
        public DateTimeOffset DateCreated { get; set; }
    }
}
