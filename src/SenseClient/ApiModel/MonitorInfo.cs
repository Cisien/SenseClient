using System.Text.Json.Serialization;

namespace SenseClient.ApiModel
{
    public class MonitorInfo
    {
        [JsonPropertyName("signals")]
        public MonitorInfoSignals Signals { get; set; }
        
        [JsonPropertyName("device_detection")]
        public MonitorInfoDeviceDetection DeviceDetection { get; set; }

        [JsonPropertyName("monitor_info")] 
        public MonitorInfoState MonitorInfoState { get; set; }
    }
}