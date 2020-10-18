using Newtonsoft.Json;
using System.Collections.Generic;

namespace HGV.Daedalus.Models
{
    public class MatchHistoryResponse
	{
		[JsonProperty("result")]
		public MatchHistoryResult Result { get; set; }
    }

    public class MatchHistoryResult
	{
		[JsonProperty("matches")]
		public List<MatchHistory> Matches { get; set; }

		[JsonProperty("status")]
		public int Status { get; set; }

		[JsonProperty("num_results")]
		public int Page { get; set; }

		[JsonProperty("total_results")]
		public int TotalResults { get; set; }

		[JsonProperty("results_remaining")]
		public int RemainingResults { get; set; }
	}
}
