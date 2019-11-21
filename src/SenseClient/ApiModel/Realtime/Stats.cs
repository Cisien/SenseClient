using System.Text.Json.Serialization;

namespace SenseClient.ApiModel.Realtime
{
    public class Stats
    {

        [JsonPropertyName("brcv")]
        public float Brcv { get; set; }

        [JsonPropertyName("mrcv")]
        public float Mrcv { get; set; }

        [JsonPropertyName("msnd")]
        public float Msnd { get; set; }
    }

}