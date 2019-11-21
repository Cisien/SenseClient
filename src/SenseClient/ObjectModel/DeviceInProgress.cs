using ApiDeviceInProgress = SenseClient.ApiModel.DeviceInProgress;

namespace SenseClient.ObjectModel
{
    public sealed class DeviceInProgress
    {
        private DeviceInProgress() { }

        internal static DeviceInProgress Create(ApiDeviceInProgress apiDevInProg)
        {
            return new DeviceInProgress
            {
                Icon = apiDevInProg.Icon,
                Name = apiDevInProg.Name,
                Progress = apiDevInProg.Progress
            };
        }

        public string Icon { get; internal set; }
        public string Name { get; internal set; }
        public int Progress { get; internal set; }
    }
}