using System.Collections.Generic;

namespace HGV.Daedalus.GetMatchHistory
{
    public class GetMatchHistoryResult
	{
		public List<Match> matches { get; set; }

		public int status { get; set; }
		public int num_results { get; set; }
		public int total_results { get; set; }
		public int results_remaining { get; set; }
	}
}
