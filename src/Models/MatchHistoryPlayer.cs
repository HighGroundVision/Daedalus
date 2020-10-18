using Newtonsoft.Json;

namespace HGV.Daedalus.Models
{
    public class MatchHistoryPlayer
    {
        [JsonProperty("player_slot")]
        public int Slot { get; set; }

        [JsonProperty("account_id")]
        public ulong AccountId { get; set; }

        [JsonProperty("hero_id")]
        public int HeroId { get; set; }
    }

}
