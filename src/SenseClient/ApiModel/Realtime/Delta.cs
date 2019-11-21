using System.Text.Json.Serialization;

namespace SenseClient.ApiModel.Realtime
{
    public class Delta
    {
        [JsonPropertyName("frame")]
        public int Frame { get; set; }

        [JsonPropertyName("channel")]
        public int Channel { get; set; }

        [JsonPropertyName("start_frame")]
        public int StartFrame { get; set; }

        [JsonPropertyName("w")]
        public float Watts { get; set; }
    }

}