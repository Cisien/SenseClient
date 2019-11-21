using ApiMonitorAttributes = SenseClient.ApiModel.MonitorAttributes;

namespace SenseClient.ObjectModel
{
    public sealed class MonitorAttributes
    {
        private MonitorAttributes() { }

        internal static MonitorAttributes Create(ApiMonitorAttributes apiMonAttr)
        {
            return new MonitorAttributes
            {
                Id = apiMonAttr.Id,
                Name = apiMonAttr.Name,
                State = apiMonAttr.State,
                Cost = apiMonAttr.Cost,
                UserSetCost =apiMonAttr.UserSetCost,
                BasementType = apiMonAttr.BasementType,
                CycleStart = apiMonAttr.CycleStart,
                HomeSizeType = apiMonAttr.HomeSizeType,
                NumberOfOccupants = apiMonAttr.NumberOfOccupants,
                OccupancyType = apiMonAttr.OccupancyType,
                PostalCode = apiMonAttr.PostalCode,
                ElectricityCost = apiMonAttr.ElectricityCost
            };
        }

        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string State { get; internal set; }
        public decimal Cost { get; internal set; }
        public bool UserSetCost { get; internal set; }
        public int CycleStart { get; internal set; }
        public string BasementType { get; internal set; }
        public string HomeSizeType { get; internal set; }
        public string HomeType { get; internal set; }
        public string NumberOfOccupants { get; internal set; }
        public string OccupancyType { get; internal set; }
        public string PostalCode { get; internal set; }
        public object ElectricityCost { get; internal set; }

    }
}