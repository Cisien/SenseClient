using System.Collections.Generic;
using System.Linq;
using ApiMonitorInfoDeviceDetection = SenseClient.ApiModel.MonitorInfoDeviceDetection;

namespace SenseClient.ObjectModel
{
    public sealed class MonitorInfoDeviceDetection
    {
        private MonitorInfoDeviceDetection() { }

        internal static MonitorInfoDeviceDetection Create(ApiMonitorInfoDeviceDetection deviceDetection)
        {
            return new MonitorInfoDeviceDetection
            {
                InProgress = deviceDetection.InProgress.Select(a => DeviceInProgress.Create(a)).ToList().AsReadOnly(),
                Found = deviceDetection.Found.Select(a => DeviceInProgress.Create(a)).ToList().AsReadOnly(),
                NumberDetected = deviceDetection.NumberDetected
            };
        }

        public IReadOnlyList<DeviceInProgress> InProgress { get; internal set; }
        public IReadOnlyList<DeviceInProgress> Found { get; internal set; }
        public int NumberDetected { get; internal set; }

    }
}