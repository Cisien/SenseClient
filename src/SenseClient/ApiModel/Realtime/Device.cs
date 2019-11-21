using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SenseClient.ApiModel.Realtime
{
    public class Device
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("tags")]
        public Dictionary<string, string> Tags { get; set; } = new Dictionary<string, string>();

        [JsonPropertyName("attrs")]
        public string[] Attrs { get; set; }

        [JsonPropertyName("w")]
        public float Watts { get; set; }

        [JsonPropertyName("c")]
        public int Current { get; set; }
    }

}