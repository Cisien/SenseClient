using ApiStats = SenseClient.ApiModel.Realtime.Stats;

namespace SenseClient.ObjectModel.Realtime
{
    public sealed class Stats
    {
        private Stats() { }
        internal static Stats Create(ApiStats stats)
        {
            return new Stats
            {
                Brcv = stats.Brcv,
                Mrcv = stats.Mrcv,
                Msnd = stats.Msnd
            };
        }

        public float Brcv { get; set; }
        public float Mrcv { get; set; }
        public float Msnd { get; set; }
    }
}