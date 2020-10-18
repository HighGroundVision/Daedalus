using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HGV.Daedalus.Models
{
	public class Team
	{
		[JsonProperty("team_id")]
		public uint Id { get; set; }
		
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("tag")]
		public string Tag { get; set; }

		[JsonProperty("time_created")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime CreatedDate { get; set; }

		[JsonProperty("rating")]
		public string Rating { get; set; }

		[JsonProperty("logo")]
		public long TeamLogo { get; set; }

		[JsonProperty("logo_sponsor")]
		public long SponsorLogo { get; set; }

		[JsonProperty("country_code")]
		public string CountryCode { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }
	}
}