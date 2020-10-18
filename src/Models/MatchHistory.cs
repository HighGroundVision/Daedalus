using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace HGV.Daedalus.Models
{
    public class MatchHistory
    {
		[JsonProperty("match_id")]
        public ulong MatchId { get; set; }

		[JsonProperty("match_seq_num")]
        public ulong MatchSequenceNumber { get; set; }

		[Newtonsoft.Json.JsonProperty("start_time")]
		[Newtonsoft.Json.JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime StartDate { get; set; }

		[JsonProperty("lobby_type")]
		public int LobbyType { get; set; }

		[JsonProperty("radiant_team_id")]
		public long RadiantTeamId { get; set; }

		[JsonProperty("dire_team_id")]
		public long DireTeamId { get; set; }

		[JsonProperty("playerplayers_slot")]
		public List<MatchHistoryPlayer> Players { get; set; }
	}
}
