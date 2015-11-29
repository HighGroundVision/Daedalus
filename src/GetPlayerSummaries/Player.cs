namespace HGV.Daedalus.GetPlayerSummaries
{
	public class Player
	{
		public long steamid { get; set; }
		public string personaname { get; set; }
		public string realname { get; set; }

		public string profileurl { get; set; }

		public string avatar { get; set; }
		public string avatarmedium { get; set; }
		public string avatarfull { get; set; }

		public string loccountrycode { get; set; }
		public string locstatecode { get; set; }
	}
}