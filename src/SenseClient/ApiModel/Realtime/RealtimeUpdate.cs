using System.Text.Json.Serialization;

namespace SenseClient.ApiModel.Realtime
{
    public class RealtimeUpdate
    {
        [JsonPropertyName("payload")]
        public Payload Payload { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}