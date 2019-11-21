using System.Text.Json.Serialization;

namespace SenseClient.ApiModel
{
    public class MonitorInfoState
    {
        [JsonPropertyName("ethernet")]
        public bool EthernetConnected { get; set; }

        [JsonPropertyName("test_result")]
        public bool? TestResult { get; set; }

        [JsonPropertyName("serial")]
        public string SerialNumber { get; set; }

        [JsonPropertyName("emac")]
        public string Emac { get; set; }

        [JsonPropertyName("ndt_enabled")]
        public bool NdtEnabled { get; set; }

        [JsonPropertyName("wifi_strength")]
        public int WifiStrength { get; set; }

        [JsonPropertyName("online")]
        public bool Online { get; set; }

        [JsonPropertyName("ip_address")]
        public string IPAddress { get; set; }
        
        [JsonPropertyName("version")]
        public string FirmwareVersion { get; set; }

        [JsonPropertyName("ssid")]
        public string SSID { get; set; }

        [JsonPropertyName("signal")]
        public int? Signal { get; set; }

        [JsonPropertyName("mac")]
        public string MACAddress { get; set; }
    }
}