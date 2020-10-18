namespace HGV.Daedalus.Models
{
    public class MatchDetailsResult
	{
        [Newtonsoft.Json.JsonProperty("result")]
        public MatchDetail Result { get; set; }
    }
}
