using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HGV.Daedalus
{
	public class DotaApi : IDisposable
	{
		private string SteamApiKey { get; set; }

		private HttpClient Client { get; set; }

		public DotaApi(string key)
		{
			if (string.IsNullOrWhiteSpace(key))
				throw new ArgumentNullException(nameof(key));

			this.SteamApiKey = key;

			this.Client = new HttpClient();
		}

		public void Dispose()
		{
			this.Client.Dispose();
		}

		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetLeagueListing
		/// </summary>
		public async Task<List<GetLeagueListing.League>> GetLeagueListing(string lang = "en")
		{
			var url = string.Format("http://api.steampowered.com/IDOTA2Match_570/GetLeagueListing/v1/?key={0}&language={1}", this.SteamApiKey, lang);
			var json = await this.Client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetLeagueListing.GetLeagueListingResult>(json);
			return data?.result?.leagues ?? new List<GetLeagueListing.League>();
		}

		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetLiveLeagueGames
		/// </summary>
		public async Task<List<GetLiveLeagueGames.Match>> GetLiveLeagueGames()
		{
			var url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetLiveLeagueGames/v0001?key={0}", this.SteamApiKey);
			var json = await this.Client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetLiveLeagueGames.GetLiveLeagueGamesResult>(json);
			return data?.result?.games ?? new List<GetLiveLeagueGames.Match>();
		}

		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetMatchDetails
		/// </summary>
		public async Task<GetMatchDetails.Match> GetMatchDetails(long matchId)
		{
			var url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/v0001?key={0}&match_id={1}", this.SteamApiKey, matchId);
			var json = await this.Client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMatchDetails.GetMatchDetailsResult>(json);
			return data?.result;
		}

		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetMatchHistory
		/// </summary>
		public async Task<List<GetMatchHistory.Match>> GetMatchHistory(long accountId)
		{
			var url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?key={0}&account_id={1}", this.SteamApiKey, accountId);
			var json = await this.Client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMatchHistory.GetMatchHistoryResult>(json);
			return data?.matches ?? new List<Daedalus.GetMatchHistory.Match>();
		}

		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetMatchHistory
		/// </summary>
		public async Task<List<GetMatchHistory.Match>> GetMatchHistory(long accountId, int heroId)
		{
			var url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?key={0}&account_id={1}&hero_id={2}", this.SteamApiKey, accountId, heroId);
			var json = await this.Client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMatchHistory.GetMatchHistoryResult>(json);
			return data?.matches ?? new List<Daedalus.GetMatchHistory.Match>();
		}

		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetScheduledLeagueGames
		/// </summary>
		public async Task<string> GetScheduledLeagueGames()
		{
			var url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetScheduledLeagueGames/v0001/?key={0}", this.SteamApiKey);
			var json = await this.Client.GetStringAsync(url);
			return json;
		}
		
		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetTeamInfoByTeamID
		/// </summary>
		public async Task<GetTeamInfoByTeamID.Team> GetTeamInfoByTeamID(long teamId)
		{
			var url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetTeamInfoByTeamID/v0001/?key={0}&start_at_team_id={1}&teams_requested=1", this.SteamApiKey, teamId);
			var json = await this.Client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetTeamInfoByTeamID.GetTeamInfoByTeamIDResult>(json);
			return data?.result?.teams?.FirstOrDefault();
		}

		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetPlayerSummaries
		/// </summary>
		public async Task<GetPlayerSummaries.Player> GetPlayerSummaries(string steamId)
		{
			var url = string.Format("http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={0}&steamids={1}", this.SteamApiKey, steamId);
			var json = await this.Client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetPlayerSummaries.GetPlayerSummariesResult>(json);
			var player = data?.response?.players?.FirstOrDefault();
			return player;
		}

		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetHeroes
		/// </summary>
		public async Task<string> GetHeroes()
		{
			var url = string.Format("https://api.steampowered.com/IEconDOTA2_570/GetHeroes/v1/?key={0}", this.SteamApiKey);
			var json = await this.Client.GetStringAsync(url);
			return json;
		}
	}
}
