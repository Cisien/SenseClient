using System.Text.Json.Serialization;

namespace SenseClient.ApiModel
{
    public class MonitorNotifications
    {
        [JsonPropertyName("new_named_device_push")]
        public bool NewNamedDevicePush { get; set; }
        [JsonPropertyName("new_named_device_email")]
        public bool NewNamedDeviceEmail { get; set; }

        [JsonPropertyName("monitor_offline_push")]
        public bool MonitorOfflinePush { get; set; }
        [JsonPropertyName("monitor_offline_email")]
        public bool MonitorOfflineEmail { get; set; }

        [JsonPropertyName("monitor_monthly_email")]
        public bool MonitorMonthlyEmail { get; set; }
        [JsonPropertyName("always_on_change_push")]
        public bool AlwaysOnChangePush { get; set; }
        [JsonPropertyName("comparison_change_push")]
        public bool ComparisonChangePush { get; set; }
        [JsonPropertyName("new_peak_push")]
        public bool NewPeakPush { get; set; }
        [JsonPropertyName("monthly_change_push")]
        public bool MonthlyChangePush { get; set; }
        [JsonPropertyName("weekly_change_push")]
        public bool WeeklyChangePush { get; set; }
        [JsonPropertyName("daily_change_push")]
        public bool DailyChangePush { get; set; }

    }
}