using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SenseClient.ApiModel
{
    public class Monitor
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("serial_number")]
        public string SerialNumber { get; set; }

        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("solar_connected")]
        public bool SolarConnected { get; set; }

        [JsonPropertyName("solar_configured")]
        public bool SolarConfigured { get; set; }

        [JsonPropertyName("online")]
        public bool Online { get; set; }

        [JsonPropertyName("attributes")]
        public MonitorAttributes Attributes { get; set; }

        [JsonPropertyName("signal_check_completed_time")]
        public DateTimeOffset SignalCheckCompletedTime { get; set; }

        [JsonPropertyName("data_sharing")]
        public List<object> DataSharing { get; set; } = new List<object>();

        [JsonPropertyName("ethernet_supported")]
        public bool EthernetSupported { get; set; }
    }
}