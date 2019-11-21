using System.Text.Json.Serialization;

namespace SenseClient.ApiModel
{
    public class MonitorAttributes
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("cost")] 
        public decimal Cost { get; set; }

        [JsonPropertyName("user_set_cost")]
        public bool UserSetCost { get; set; }

        [JsonPropertyName("cycle_start")]
        public int CycleStart { get; set; }

        [JsonPropertyName("basement_type")]
        public string BasementType { get; set; }
        
        [JsonPropertyName("home_size_type")]
        public string HomeSizeType { get; set; }

        [JsonPropertyName("home_type")]
        public string HomeType { get; set; }
        
        [JsonPropertyName("number_of_occupants")]
        public string NumberOfOccupants { get; set; }

        [JsonPropertyName("occupancy_type")]
        public string OccupancyType { get; set; }

        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        [JsonPropertyName("electricity_cost")]
        public object ElectricityCost { get; set; }

    }
}