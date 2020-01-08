using System;
using System.Collections.Generic;

namespace HGV.Daedalus.GetLiveLeagueGames
{
    public class Match
    {
        public ulong lobby_id { get; set; }
        public ulong match_id { get; set; }
        public int spectators { get; set; }
        public uint league_id { get; set; }
        public float stream_delay_s { get; set; }
        public int radiant_series_wins { get; set; }
        public int dire_series_wins { get; set; }
        public int series_type { get; set; }
        public int league_series_id { get; set; }
        public int league_game_id { get; set; }
        public int league_tier { get; set; }

        public MatchTeam dire_team { get; set; }
        public MatchTeam radiant_team { get; set; }

        public Scoreboard scoreboard { get; set; }
    }

    public class MatchComparer : IEqualityComparer<Match>
    {

        public bool Equals(Match x, Match y)
        {
            //Check whether the objects are the same object.  
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether the products' properties are equal.  
            return x != null && y != null && x.match_id.Equals(y.match_id);
        }

        public int GetHashCode(Match obj)
        {
            //Calculate the hash code for the product.
            return obj.match_id.GetHashCode();
        }
    }
}
