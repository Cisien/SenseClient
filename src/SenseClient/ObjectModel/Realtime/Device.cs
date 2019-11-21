using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ApiDevice = SenseClient.ApiModel.Realtime.Device;

namespace SenseClient.ObjectModel.Realtime
{
    public sealed class Device
    {
        private Device() { }

        internal static Device Create(ApiDevice device)
        {
            return new Device
            {
                Id = device.Id,
                Name = device.Name, 
                Icon = device.Icon,
                Tags = new ReadOnlyDictionary<string, string>(device.Tags),
                Attrs = device.Attrs.ToList().AsReadOnly(),
                Watts = device.Watts,
                Current = device.Current
            };
        }

        public string Id { get; internal set; }
        public string Name { get; internal set; }
        public string Icon { get; internal set; }
        public IReadOnlyDictionary<string, string> Tags { get; internal set; }
        public IReadOnlyCollection<string> Attrs { get; internal set; }
        public float Watts { get; internal set; }
        public int Current { get; internal set; }
    }

}