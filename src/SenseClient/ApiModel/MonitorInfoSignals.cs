using System.Text.Json.Serialization;

namespace SenseClient.ApiModel
{
    public class MonitorInfoSignals
    {

        [JsonPropertyName("progress")]
        public int Progress { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}