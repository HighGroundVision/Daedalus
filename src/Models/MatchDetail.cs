using HGV.Daedalus.Converters;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace HGV.Daedalus.Models
{
	public class MatchDetail : MatchSummary
	{
		[Newtonsoft.Json.JsonProperty("error")]
		public string Error { get; set; }

		[Newtonsoft.Json.JsonProperty("tower_status_radiant")]
		public int TowerStatusRadiant { get; set; }

		[Newtonsoft.Json.JsonProperty("tower_status_dire")]
		public int TowerStatusDire { get; set; }

		[Newtonsoft.Json.JsonProperty("barracks_status_radiant")]
		public int BarracksStatusRadiant { get; set; }

		[Newtonsoft.Json.JsonProperty("barracks_status_dire")]
		public int BarracksStatusDire { get; set; }

		[Newtonsoft.Json.JsonProperty("first_blood_time")]
		[Newtonsoft.Json.JsonConverter(typeof(UnixTimeSpanConverter))]
		public TimeSpan FirstBloodTime { get; set; }

		[Newtonsoft.Json.JsonProperty("lobby_type")]
		public int LobbyType { get; set; }

		[Newtonsoft.Json.JsonProperty("human_players")]
		public int NumberOfHumanPlayers { get; set; }

		[Newtonsoft.Json.JsonProperty("positive_votes")]
		public int PositiveVotes { get; set; }

		[Newtonsoft.Json.JsonProperty("negative_votes")]
		public int NegativeVotes { get; set; }
		
		[Newtonsoft.Json.JsonProperty("engine")]
		public int Engine { get; set; }

		[Newtonsoft.Json.JsonProperty("players")]
		public List<MatchDetailPlayer> Players { get; set; }
    }

	public class MatchSummary
	{
		[Newtonsoft.Json.JsonProperty("match_id")]
		public ulong MatchId { get; set; }

		[Newtonsoft.Json.JsonProperty("match_seq_num")]
		public ulong MatchSequenceNumber { get; set; }
		
		[Newtonsoft.Json.JsonProperty("radiant_win")]
		public bool RadiantWon { get; set; }

		[Newtonsoft.Json.JsonProperty("dire_win")]
		public bool DireWon => !RadiantWon;

		[Newtonsoft.Json.JsonProperty("duration")]
		[Newtonsoft.Json.JsonConverter(typeof(UnixTimeSpanConverter))]
		public TimeSpan Duration { get; set; }

		[Newtonsoft.Json.JsonProperty("start_time")]
		[Newtonsoft.Json.JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime StartDate { get; set; }

		[Newtonsoft.Json.JsonProperty("cluster")]
		public int Cluster { get; set; }

		[Newtonsoft.Json.JsonProperty("game_mode")]
		public int Mode { get; set; }

		[Newtonsoft.Json.JsonProperty("leagueid")]
		public int LeagueId { get; set; }
	}
}
