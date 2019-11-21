using ApiMonitorNotifications = SenseClient.ApiModel.MonitorNotifications;

namespace SenseClient.ObjectModel
{
    public class MonitorNotifications
    {
        private MonitorNotifications() { }
        internal static MonitorNotifications Create(ApiMonitorNotifications apiMonNot)
        {
            return new MonitorNotifications
            {
                NewNamedDevicePush = apiMonNot.NewNamedDevicePush,
                NewNamedDeviceEmail = apiMonNot.NewNamedDeviceEmail,
                MonitorOfflineEmail = apiMonNot.MonitorOfflineEmail,
                MonitorOfflinePush = apiMonNot.MonitorOfflinePush,
                MonitorMonthlyEmail = apiMonNot.MonitorMonthlyEmail,
                MonthlyChangePush = apiMonNot.MonthlyChangePush,
                AlwaysOnChangePush = apiMonNot.AlwaysOnChangePush,
                ComparisonChangePush = apiMonNot.ComparisonChangePush,
                NewPeakPush = apiMonNot.NewPeakPush,
                WeeklyChangePush = apiMonNot.WeeklyChangePush,
                DailyChangePush = apiMonNot.DailyChangePush
            };
        }

        public bool NewNamedDevicePush { get; internal set; }
        public bool NewNamedDeviceEmail { get; internal set; }
        public bool MonitorOfflinePush { get; internal set; }
        public bool MonitorOfflineEmail { get; internal set; }
        public bool MonitorMonthlyEmail { get; internal set; }
        public bool AlwaysOnChangePush { get; internal set; }

        public bool ComparisonChangePush { get; internal set; }
        public bool NewPeakPush { get; internal set; }
        public bool MonthlyChangePush { get; internal set; }

        public bool WeeklyChangePush { get; internal set; }
        public bool DailyChangePush { get; internal set; }

    }
}