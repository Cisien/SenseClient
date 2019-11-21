using ApiMonitorInfoState = SenseClient.ApiModel.MonitorInfoState;

namespace SenseClient.ObjectModel
{
    public sealed class MonitorInfoState
    {
        private MonitorInfoState() { }

        internal static MonitorInfoState Create(ApiMonitorInfoState monitorInfoState)
        {
            return new MonitorInfoState
            {
                EthernetConnected = monitorInfoState.EthernetConnected,
                TestResult = monitorInfoState.TestResult,
                SerialNumber = monitorInfoState.SerialNumber,
                Emac = monitorInfoState.Emac,
                NdtEnabled = monitorInfoState.NdtEnabled,
                WifiStrength = monitorInfoState.WifiStrength,
                Online = monitorInfoState.Online,
                IPAddress = monitorInfoState.IPAddress,
                FirmwareVersion = monitorInfoState.FirmwareVersion,
                SSID = monitorInfoState.SSID,
                Signal = monitorInfoState.Signal,
                MACAddress = monitorInfoState.MACAddress
            };
        }

        public bool EthernetConnected { get; internal set; }
        public bool? TestResult { get; internal set; }
        public string SerialNumber { get; internal set; }
        public string Emac { get; internal set; }
        public bool NdtEnabled { get; internal set; }
        public int WifiStrength { get; internal set; }
        public bool Online { get; internal set; }
        public string IPAddress { get; internal set; }
        public string FirmwareVersion { get; internal set; }
        public string SSID { get; internal set; }
        public int? Signal { get; internal set; }
        public string MACAddress { get; internal set; }
    }
}