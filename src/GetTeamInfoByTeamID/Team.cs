using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HGV.Daedalus.GetTeamInfoByTeamID
{
	public class Team
	{
		public uint team_id { get; set; }
		public string name { get; set; }
		public string tag { get; set; }
		public long time_created { get; set; }
		public string rating { get; set; }
		public long logo { get; set; }
		public long logo_sponsor { get; set; }
		public string country_code { get; set; }
		public string url { get; set; }
	}
}