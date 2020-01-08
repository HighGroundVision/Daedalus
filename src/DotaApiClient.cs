using HGV.Daedalus.GetMatchDetails;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HGV.Daedalus
{
	public interface IDotaApiClient
	{
		Task<List<HGV.Daedalus.GetLiveLeagueGames.Match>> GetLiveLeagueGames(uint leagueId = 0, ulong matchId = 0);
		Task<HGV.Daedalus.GetMatchDetails.Match> GetMatchDetails(ulong matchId);
		Task<List<HGV.Daedalus.GetMatchHistory.Match>> GetLastestMatches();
		Task<List<HGV.Daedalus.GetMatchDetails.Match>> GetMatchesInSequence(ulong number);
		Task<List<HGV.Daedalus.GetMatchHistory.Match>> GetMatchHistory(uint accountId);
		Task<List<HGV.Daedalus.GetMatchHistory.Match>> GetMatchHistory(uint accountId, int heroId);
		Task<HGV.Daedalus.GetTeamInfoByTeamID.Team> GetTeamInfoByTeamID(long teamId);
		Task<HGV.Daedalus.GetPlayerSummaries.Player> GetPlayerSummary(ulong steamId);
		Task<List<HGV.Daedalus.GetPlayerSummaries.Player>> GetPlayersSummary(List<ulong> ids);
	}

	public class DotaApiClient : IDotaApiClient
	{
		private readonly string key;

		private readonly HttpClient client;

		public DotaApiClient(ISteamKeyProvider provider, IHttpClientFactory httpClientFactory)
		{
			this.key = provider.GetKey();
			this.client = httpClientFactory.CreateClient();
		}

		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetLiveLeagueGames
		/// </summary>
		public async Task<List<GetLiveLeagueGames.Match>> GetLiveLeagueGames(uint leagueId = 0, ulong matchId = 0)
		{
			string url;
			if (leagueId != 0 && matchId != 0)
				url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetLiveLeagueGames/v0001?key={0}&league_id={1}&match_id={2}", this.key, leagueId, matchId);
			else if(leagueId != 0)
				url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetLiveLeagueGames/v0001?key={0}&league_id={1}", this.key, leagueId);
			else if (matchId != 0)
				url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetLiveLeagueGames/v0001?key={0}&match_id={1}", this.key, matchId);
			else
				url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetLiveLeagueGames/v0001?key={0}", this.key);
			

			var json = await this.client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetLiveLeagueGames.GetLiveLeagueGamesResult>(json);
			return data?.result?.games ?? new List<GetLiveLeagueGames.Match>();
		}


		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetMatchDetails
		/// </summary>
		public async Task<GetMatchDetails.Match> GetMatchDetails(ulong matchId)
		{
			if (matchId == 0)
				throw new ArgumentOutOfRangeException(nameof(matchId));

			var url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/v0001?key={0}&match_id={1}&include_persona_names=1", this.key, matchId);
			var json = await this.client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMatchDetails.GetMatchDetailsResult>(json);
			return data?.result;
		}

        /// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetMatchHistory
		/// </summary>
		public async Task<List<GetMatchHistory.Match>> GetLastestMatches()
        {
            var url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?key={0}", this.key);
            var json = await this.client.GetStringAsync(url);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMatchHistory.GetMatchHistoryResult>(json);
            return data?.result?.matches ?? new List<Daedalus.GetMatchHistory.Match>();
        }

        /// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetMatchHistoryBySequenceNum
		/// </summary>
		public async Task<List<GetMatchDetails.Match>> GetMatchesInSequence(ulong number)
        {
            if (number == 0)
                throw new ArgumentOutOfRangeException(nameof(number));

            var url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetMatchHistoryBySequenceNum/V001/?key={0}&start_at_match_seq_num={1}", this.key, number);
            var json = await this.client.GetStringAsync(url);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMatchHistoryBySequenceNum.GetMatchHistoryBySequenceNumResult>(json);
            return data?.result?.matches ?? new List<Daedalus.GetMatchDetails.Match>();
        }

        /// <summary>
        /// https://wiki.teamfortress.com/wiki/WebAPI/GetMatchHistory
        /// </summary>
        public async Task<List<GetMatchHistory.Match>> GetMatchHistory(uint accountId)
		{
			if (accountId == 0)
				throw new ArgumentOutOfRangeException(nameof(accountId));

			var url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?key={0}&account_id={1}", this.key, accountId);
			var json = await this.client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMatchHistory.GetMatchHistoryResult>(json);
			return data?.result?.matches ?? new List<Daedalus.GetMatchHistory.Match>();
		}

		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetMatchHistory
		/// </summary>
		public async Task<List<GetMatchHistory.Match>> GetMatchHistory(uint accountId, int heroId)
		{
			if (accountId == 0)
				throw new ArgumentOutOfRangeException(nameof(accountId));

			if (heroId == 0)
				throw new ArgumentOutOfRangeException(nameof(heroId));

			var url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?key={0}&account_id={1}&hero_id={2}", this.key, accountId, heroId);
			var json = await this.client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMatchHistory.GetMatchHistoryResult>(json);
			return data?.result?.matches ?? new List<Daedalus.GetMatchHistory.Match>();
		}
		
		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetTeamInfoByTeamID
		/// </summary>
		public async Task<GetTeamInfoByTeamID.Team> GetTeamInfoByTeamID(long teamId)
		{
			var url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetTeamInfoByTeamID/v0001/?key={0}&start_at_team_id={1}&teams_requested=1", this.key, teamId);
			var json = await this.client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetTeamInfoByTeamID.GetTeamInfoByTeamIDResult>(json);
			return data?.result?.teams?.FirstOrDefault();
		}

		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetPlayerSummaries
		/// </summary>
		public async Task<GetPlayerSummaries.Player> GetPlayerSummary(ulong steamId)
		{
			var url = string.Format("http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={0}&steamids={1}", this.key, steamId);
			var json = await this.client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetPlayerSummaries.GetPlayerSummariesResult>(json);
			var player = data?.response?.players?.FirstOrDefault();
			return player;
		}

        /// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetPlayerSummaries
		/// </summary>
		public async Task<List<GetPlayerSummaries.Player>> GetPlayersSummary(List<ulong> ids)
        {
            if (ids.Count > 100)
                throw new ArgumentOutOfRangeException("ids", ids.Count, "Can only process 100 profiles at a time.");

            var url = string.Format("http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={0}&steamids={1}", this.key, String.Join(",", ids.ToArray()));
            var json = await this.client.GetStringAsync(url);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetPlayerSummaries.GetPlayerSummariesResult>(json);
            return data?.response?.players;
        }
	}
}
