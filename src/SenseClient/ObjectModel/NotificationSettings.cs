using System.Collections.Generic;
using System.Linq;
using ApiNotificationSettings = SenseClient.ApiModel.NotificationSettings;

namespace SenseClient.ObjectModel
{
    public sealed class NotificationSettings
    {
        internal NotificationSettings() {}

        internal static NotificationSettings Create(ApiNotificationSettings settings)
        {
            return new NotificationSettings
            {
                Notifications = settings.Notifications.ToDictionary(a => a.Key, a => MonitorNotifications.Create(a.Value))
            };
        }

        public Dictionary<string, MonitorNotifications> Notifications { get; internal set; }

    }
}