using HGV.Daedalus.Converters;
using Newtonsoft.Json;
using System;

namespace HGV.Daedalus.Models
{
    public class AbilityUpgrade
    {
        [JsonProperty("ability")]
        public int AbilityId { get; set; }

        [JsonProperty("level")]
        public int AbilityLevel { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(UnixTimeSpanConverter))]
        public TimeSpan TimeAquired { get; set; }
    }
}
