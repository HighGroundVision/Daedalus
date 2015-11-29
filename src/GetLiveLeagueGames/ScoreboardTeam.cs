using Newtonsoft.Json;
using System.Collections.Generic;

namespace HGV.Daedalus.GetLiveLeagueGames
{
    public class ScoreboardTeam
    {
        public int score { get; set; }
        public int tower_state { get; set; }
        public int barracks_state { get; set; }

        public List<HeroChoice> picks { get; set; }
        public List<HeroChoice> bans { get; set; }

        public List<Player> players { get; set; }

        [JsonConverter(typeof(AbilityDataConverter))]
        public Dictionary<int, List<Ability>> abilities { get; set; }
    }
}
