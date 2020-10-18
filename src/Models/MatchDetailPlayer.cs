using HGV.Daedalus.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace HGV.Daedalus.Models
{
    public class MatchDetailPlayer
	{
		[JsonProperty("player_slot")]
		public int Slot { get; set; }

		[JsonProperty("account_id")]
		public uint AccountId { get; set; }

		[JsonProperty("persona")]
        public string Persona { get; set; }

		[JsonProperty("hero_id")]
        public int HeroId { get; set; }

		[JsonProperty("kills")]
		public int Kills { get; set; }

		[JsonProperty("deaths")]
		public int Deaths { get; set; }

		[JsonProperty("assists")]
		public int Assists { get; set; }

		[JsonProperty("last_hits")]
		public int LastHits { get; set; }

		[JsonProperty("denies")]
		public int Denies { get; set; }

		[JsonProperty("gold")]
		public int Gold { get; set; }

		[JsonProperty("level")]
		public int Level { get; set; }

		[JsonProperty("gold_per_min")]
		public int GPM { get; set; }

		[JsonProperty("xp_per_min")]
		public int XPM { get; set; }

		[JsonProperty("item_0")]
		public int Item0 { get; set; }

		[JsonProperty("item_1")]
		public int Item1 { get; set; }

		[JsonProperty("item_2")]
		public int Item2 { get; set; }

		[JsonProperty("item_3")]
		public int Item3 { get; set; }

		[JsonProperty("item_4")]
		public int Item4 { get; set; }

		[JsonProperty("item_5")]
		public int Item5 { get; set; }

		[JsonProperty("backpack_0")]
        public int Backpack0 { get; set; }

		[JsonProperty("backpack_1")]
        public int Backpack1 { get; set; }

		[JsonProperty("backpack_2")]
        public int Backpack2 { get; set; }

		[JsonProperty("item_neutral")]
		public int NeutralItem { get; set; }

		[JsonProperty("items")]
		public List<int> Items => 
			new List<int>() { 
				Item0, Item1, Item2, Item3, Item4, Item5, Backpack0, Backpack1, Backpack2, NeutralItem 
			}.Where(x => x != 0).ToList();

		[JsonProperty("gold_spent")]
		public int GoldSpent { get; set; }

		[JsonProperty("hero_damage")]
		public int HeroDamage { get; set; }

		[JsonProperty("tower_damage")]
		public int TowerDamage { get; set; }

		[JsonProperty("hero_healing")]
		public int HeroHealing { get; set; }

		[JsonProperty("leaver_status")]
		[JsonConverter(typeof(LeaverStatusConverter))]
        public LeaverStatus LeaverStatus { get; set; }

		[JsonProperty("abandoned")]
        public bool Abandoned => 
			LeaverStatus == LeaverStatus.DISCONNECTED_TOO_LONG ||
			LeaverStatus == LeaverStatus.ABANDONED ||
			LeaverStatus == LeaverStatus.AFK;

		[JsonProperty("ability_upgrades")]
        public List<AbilityUpgrade> AbilityUpgrades { get; set; }

		[JsonProperty("abilities")]
        public List<int> Abilities => AbilityUpgrades.Select(_ => _.AbilityId).Distinct().ToList();
    }

	public enum LeaverStatus : int
    {
		/// <summary>
		/// finished match, no abandon.
		/// </summary>
		None = 0,

		/// <summary>
		/// player DC, no abandon.
		/// </summary>
		DISCONNECTED = 1,

		/// <summary>
		/// player DC > 5min, abandoned.
		/// </summary>
		DISCONNECTED_TOO_LONG = 2,

		/// <summary>
		///  player DC, clicked leave, abandoned.
		/// </summary>
		ABANDONED = 3,

		/// <summary>
		///  player AFK, abandoned.
		/// </summary>
		AFK = 4,

		/// <summary>
		///   player never connected, no abandon.
		/// </summary>
		NEVER_CONNECTED = 5,

		/// <summary>
		///  player took too long to connect, no abandon.
		/// </summary>
		NEVER_CONNECTED_TOO_LONG = 6,
    }
}