using SenseClient.Internal;
using System;
using ApiMonitor = SenseClient.ApiModel.Monitor;

namespace SenseClient.ObjectModel
{
    public sealed class Monitor
    {
        private Monitor() { }

        internal static Monitor Create(ApiMonitor apiMonitor)
        {
            return new Monitor
            {
                Id = apiMonitor.Id,
                SerialNumber = apiMonitor.SerialNumber,
                TimeZone = TimezoneMap.GetTimeZoneInfo(apiMonitor.TimeZone),
                SolarConfigured = apiMonitor.SolarConfigured,
                SolarConnected = apiMonitor.SolarConnected,
                Online =apiMonitor.Online,
                Attributes = MonitorAttributes.Create(apiMonitor.Attributes),
                SignalCheckCompletedTime = apiMonitor.SignalCheckCompletedTime,
                EthernetSupported = apiMonitor.EthernetSupported
            };
        }

        public int Id { get; internal set; }
        public string SerialNumber { get; internal set; }
        public TimeZoneInfo TimeZone { get; internal set; }
        public bool SolarConnected { get; internal set; }
        public bool SolarConfigured { get; internal set; }
        public bool Online { get; internal set; }
        public MonitorAttributes Attributes { get; internal set; }
        public DateTimeOffset SignalCheckCompletedTime { get; internal set; }
        public bool EthernetSupported { get; internal set; }
    }
}