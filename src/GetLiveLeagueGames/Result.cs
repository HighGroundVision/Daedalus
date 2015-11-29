using System.Collections.Generic;

namespace HGV.Daedalus.GetLiveLeagueGames
{
    public class Result
    {
        public List<Match> games { get; set; }
        public int status { get; set; }
    }
}
