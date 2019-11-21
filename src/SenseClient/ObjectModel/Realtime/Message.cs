using System;
using System.Collections.Generic;
using System.Linq;
using ApiPayload = SenseClient.ApiModel.Realtime.Payload;

namespace SenseClient.ObjectModel.Realtime
{
    public sealed class Message
    {
        private Message() { }

        internal static Message Create(ApiPayload payload)
        {
            return new Message
            {
                VoltageA = payload.Voltage.First(),
                VoltageB = payload.Voltage.Skip(1).FirstOrDefault(),
                Frame = payload.Frame,
                Devices = payload.Devices.Select(a => Device.Create(a)).ToList().AsReadOnly(),
                Deltas = payload.Deltas.Select(a => Delta.Create(a)).ToList().AsReadOnly(),
                Channels =payload.Channels.ToList().AsReadOnly(),
                Frequency = payload.Frequency,
                Watts = payload.Watts,
                Current = payload.Current,
                Stats = Stats.Create(payload.Stats),
                SampleTime = DateTimeOffset.FromUnixTimeSeconds(payload.Epoch)
            };
        }

        public float VoltageA { get; set; }
        public float VoltageB { get; set; }
        public int Frame { get; set; }
        public IReadOnlyCollection<Device> Devices { get; set; }
        public IReadOnlyCollection<Delta> Deltas { get; set; }
        public IReadOnlyCollection<float> Channels { get; set; }
        public float Frequency { get; set; }
        public float Watts { get; set; }
        public int Current { get; set; }
        public Stats Stats { get; set; }
        public DateTimeOffset SampleTime { get; set; }
    }

}