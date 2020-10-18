using System.Collections.Generic;

namespace HGV.Daedalus.Models
{
    public class PlayerSummariesResult
	{
        [Newtonsoft.Json.JsonProperty("response")]
        public PlayerSummariesReponse Response { get; set; }
    }

    public class PlayerSummariesReponse
	{
        [Newtonsoft.Json.JsonProperty("Players")]
		public List<Profile> Profiles { get; set; }
	}
}
