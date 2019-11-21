using ApiMonitorInfo = SenseClient.ApiModel.MonitorInfo;

namespace SenseClient.ObjectModel
{
    public sealed class MonitorInfo
    {
        private MonitorInfo() { }

        internal static MonitorInfo Create(ApiMonitorInfo apiMonInfo)
        {
            return new MonitorInfo { 
                Signals = MonitorInfoSignals.Create(apiMonInfo.Signals),
                DeviceDetection = MonitorInfoDeviceDetection.Create(apiMonInfo.DeviceDetection),
                MonitorInfoState = MonitorInfoState.Create(apiMonInfo.MonitorInfoState)
            };
        }

        public MonitorInfoSignals Signals { get; internal set; }
        public MonitorInfoDeviceDetection DeviceDetection { get; internal set; }
        public MonitorInfoState MonitorInfoState { get; internal set; }
    }
}