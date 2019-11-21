using System.Text.Json.Serialization;

namespace SenseClient.ApiModel
{
    public class DeviceInProgress
    {
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("progress")]
        public int Progress { get; set; }
    }
}