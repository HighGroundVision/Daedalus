namespace HGV.Daedalus.GetLiveLeagueGames
{
    public class Scoreboard
    {
        public double duration { get; set; }
        public int roshan_respawn_timer { get; set; }

        public ScoreboardTeam radiant { get; set; }
        public ScoreboardTeam dire { get; set; }
    }
}
