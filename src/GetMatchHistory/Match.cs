using System;
using System.Collections.Generic;

namespace HGV.Daedalus.GetMatchHistory
{
    public class Match
    {
        public long match_id { get; set; }
        public long match_seq_num { get; set; }
		public long start_time { get; set; }
		public int lobby_type { get; set; }
		public long radiant_team_id { get; set; }
		public long dire_team_id { get; set; }

		public List<Player> players { get; set; }

		/*
		"match_id": 1752179909,
		"match_seq_num": 1559376994,
		"start_time": 1440797760,
		"lobby_type": 0,
		"radiant_team_id": 0,
		"dire_team_id": 0,
		*/

	}
}
