namespace HGV.Daedalus.Models
{
	public class Profile
	{
		[Newtonsoft.Json.JsonProperty("steamid")]
		public ulong SteamId { get; set; }

		[Newtonsoft.Json.JsonProperty("personaname")]
		public string Persona { get; set; }

		[Newtonsoft.Json.JsonProperty("realname")]
		public string Name { get; set; }

		[Newtonsoft.Json.JsonProperty("profileurl")]
		public string ProfileUrl { get; set; }

		[Newtonsoft.Json.JsonProperty("avatar")]
		public string AvatarSmall { get; set; }

		[Newtonsoft.Json.JsonProperty("avatarmedium")]
		public string AvatarMedium { get; set; }

		[Newtonsoft.Json.JsonProperty("avatarfull")]
		public string AvatarLarge { get; set; }

		[Newtonsoft.Json.JsonProperty("loccountrycode")]
		public string CountryCode { get; set; }

		[Newtonsoft.Json.JsonProperty("locstatecode")]
		public string StateCode { get; set; }
	}
}