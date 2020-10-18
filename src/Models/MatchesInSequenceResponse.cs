using System.Collections.Generic;

namespace HGV.Daedalus.Models
{
    public class MatchesInSequenceResponse
    {
		[Newtonsoft.Json.JsonProperty("result")]
		public MatchesInSequenceResult Result { get; set; }
    }

    public class MatchesInSequenceResult
	{
		[Newtonsoft.Json.JsonProperty("matches")]
		public List<MatchDetail> Matches { get; set; }

		[Newtonsoft.Json.JsonProperty("status")]
		public int Status { get; set; }
	}
}
