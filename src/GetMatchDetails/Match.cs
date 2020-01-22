using System.Collections.Generic;

namespace HGV.Daedalus.GetMatchDetails
{
	public class Match : MatchDetails
	{
		public List<Player> players { get; set; }
	}

	public class MatchDetails
	{
		public string error { get; set; }
		public ulong match_id { get; set; }
		public ulong match_seq_num { get; set; }
		public bool radiant_win { get; set; }
		public int duration { get; set; }
		public long start_time { get; set; }
		public int tower_status_radiant { get; set; }
		public int tower_status_dire { get; set; }
		public int barracks_status_radiant { get; set; }
		public int barracks_status_dire { get; set; }
		public int cluster { get; set; }
		public int first_blood_time { get; set; }
		public int lobby_type { get; set; }
		public int human_players { get; set; }
		public int leagueid { get; set; }
		public int positive_votes { get; set; }
		public int negative_votes { get; set; }
		public int game_mode { get; set; }
		public int engine { get; set; }
    }
}
