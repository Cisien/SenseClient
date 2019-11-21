using System.Text.Json.Serialization;

namespace SenseClient.ApiModel.Realtime
{
    public class Payload
    {
        [JsonPropertyName("voltage")]
        public float[] Voltage { get; set; }

        [JsonPropertyName("frame")]
        public int Frame { get; set; }

        [JsonPropertyName("devices")]
        public Device[] Devices { get; set; }

        [JsonPropertyName("deltas")]
        public Delta[] Deltas { get; set; }

        [JsonPropertyName("channels")]
        public float[] Channels { get; set; }

        [JsonPropertyName("hz")]
        public float Frequency { get; set; }

        [JsonPropertyName("w")]
        public float Watts { get; set; }

        [JsonPropertyName("c")]
        public int Current { get; set; }

        [JsonPropertyName("_stats")]
        public Stats Stats { get; set; }

        [JsonPropertyName("epoch")]
        public int Epoch { get; set; }
    }

}