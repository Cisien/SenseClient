using System.Text.Json.Serialization;

namespace SenseClient.ApiModel
{
    public class UserSettings
    {
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("settings")]
        public NotificationSettings Settings { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }
    }
}