using ApiMonitorInfoSignals = SenseClient.ApiModel.MonitorInfoSignals;

namespace SenseClient.ObjectModel
{
    public sealed class MonitorInfoSignals
    {
        private MonitorInfoSignals() { }

        internal static MonitorInfoSignals Create(ApiMonitorInfoSignals signals)
        {
            return new MonitorInfoSignals
            {
                Progress = signals.Progress,
                Status = signals.Status
            };
        }

        public int Progress { get; internal set; }
        public string Status { get; internal set; }

    }
}