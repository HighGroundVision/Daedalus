using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HGV.Daedalus.GetLeagueListing
{
	public class League
	{
		public string name { get; set; }
		public long leagueid { get; set; }
		public string description { get; set; }
		public string tournament_url { get; set; }
		public long itemdef { get; set; }

		public string icon_name { get; set; }
		public string logo_url { get; set; }

		public DateTime? creation_date { get; set; }
		public string tier { get; set; }
		public string location { get; set; }
	}
}