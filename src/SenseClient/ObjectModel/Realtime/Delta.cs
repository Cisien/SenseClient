using ApiDelta = SenseClient.ApiModel.Realtime.Delta;

namespace SenseClient.ObjectModel.Realtime
{
    public sealed class Delta
    {
        private Delta() { }

        internal static Delta Create(ApiDelta delta)
        {
            return new Delta
            {
                Frame = delta.Frame,
                Channel = delta.Channel,
                StartFrame = delta.StartFrame,
                Watts = delta.Watts
            };
        }

        public int Frame { get; internal set; }
        public int Channel { get; internal set; }
        public int StartFrame { get; internal set; }
        public float Watts { get; internal set; }
    }
}