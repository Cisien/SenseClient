using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SenseClient.ApiModel
{
    public class NotificationSettings
    {
        [JsonPropertyName("notifications")]
        public Dictionary<string, MonitorNotifications> Notifications { get; set; }
    }
}