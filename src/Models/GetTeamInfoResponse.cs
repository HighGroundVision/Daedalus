using Newtonsoft.Json;
using System.Collections.Generic;

namespace HGV.Daedalus.Models
{
    public class GetTeamInfoResponse
	{
        [JsonProperty("result")]
        public GetTeamInfoResult Result { get; set; }
    }

    public class GetTeamInfoResult
    {
        [JsonProperty("teams")]
        public List<Team> Teams { get; set; }

        [JsonProperty("status")]
		public int Status { get; set; }
    }
}
