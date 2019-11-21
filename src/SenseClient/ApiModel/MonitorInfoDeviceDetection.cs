using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SenseClient.ApiModel
{
    public class MonitorInfoDeviceDetection
    {
        [JsonPropertyName("in_progress")]
        public List<DeviceInProgress> InProgress { get; set; } = new List<DeviceInProgress>();
        [JsonPropertyName("found")]
        public List<DeviceInProgress> Found { get; set; } = new List<DeviceInProgress>();

        [JsonPropertyName("num_detected")]
        public int NumberDetected { get; set; }
    }
}