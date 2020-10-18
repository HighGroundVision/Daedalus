using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HGV.Daedalus.Models;

namespace HGV.Daedalus
{
	public interface IDotaApiClient
	{
		Task<List<MatchDetail>> GetMatchesInSequence(ulong number);
		Task<MatchDetail> GetMatchDetails(ulong matchId);
		Task<List<MatchHistory>> GetLastestMatches();
		Task<List<MatchHistory>> GetMatchHistory(uint accountId, long? start_at_match_id = null);
		Task<List<MatchHistory>> GetMatchHistory(uint accountId, int heroId, long? start_at_match_id = null);
		Task<Team> GetTeamInfo(long teamId);
		Task<Profile> GetPlayerSummary(ulong steamId);
		Task<List<Profile>> GetPlayersSummary(List<ulong> ids);
		Task<List<Friend>> GetFriendsList(ulong steamId);
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
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetMatchHistoryBySequenceNum
		/// </summary>
		public async Task<List<MatchDetail>> GetMatchesInSequence(ulong number)
        {
            if (number == 0)
                throw new ArgumentOutOfRangeException(nameof(number));

            var url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetMatchHistoryBySequenceNum/V001/?key={0}&start_at_match_seq_num={1}", this.key, number);
            var json = await this.client.GetStringAsync(url);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<MatchesInSequenceResponse>(json);
            return data?.Result?.Matches ?? new List<MatchDetail>();
        }

		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetMatchDetails
		/// </summary>
		public async Task<MatchDetail> GetMatchDetails(ulong matchId)
		{
			if (matchId == 0)
				throw new ArgumentOutOfRangeException(nameof(matchId));

			var url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/v0001?key={0}&match_id={1}&include_persona_names=1", this.key, matchId);
			var json = await this.client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<MatchDetailsResult>(json);
			return data?.Result;
		}

        /// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetMatchHistory
		/// </summary>
		public async Task<List<MatchHistory>> GetLastestMatches()
        {
            var url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?key={0}", this.key);
            var json = await this.client.GetStringAsync(url);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<MatchHistoryResponse>(json);
            return data?.Result?.Matches ?? new List<MatchHistory>();
        }

        /// <summary>
        /// https://wiki.teamfortress.com/wiki/WebAPI/GetMatchHistory
        /// </summary>
        public async Task<List<MatchHistory>> GetMatchHistory(uint accountId, long? start_at_match_id = null)
		{
			if (accountId == 0)
				throw new ArgumentOutOfRangeException(nameof(accountId));

			var url = start_at_match_id.HasValue ? 
				string.Format("https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?key={0}&account_id={1}&start_at_match_id={2}", this.key, accountId, start_at_match_id): 
				string.Format("https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?key={0}&account_id={1}", this.key, accountId);
			var json = await this.client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<MatchHistoryResponse>(json);
			return data?.Result?.Matches ?? new List<MatchHistory>();
		}

		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetMatchHistory
		/// </summary>
		public async Task<List<MatchHistory>> GetMatchHistory(uint accountId, int heroId, long? start_at_match_id = null)
		{
			if (accountId == 0)
				throw new ArgumentOutOfRangeException(nameof(accountId));

			if (heroId == 0)
				throw new ArgumentOutOfRangeException(nameof(heroId));

			var url = start_at_match_id.HasValue ? 
				string.Format("https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?key={0}&account_id={1}&hero_id={2}&start_at_match_id={3}", this.key, accountId, heroId, start_at_match_id): 
				string.Format("https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?key={0}&account_id={1}&hero_id={2}", this.key, accountId, heroId);

			var json = await this.client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<MatchHistoryResponse>(json);
			return data?.Result?.Matches ?? new List<MatchHistory>();
		}
		
		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetTeamInfoByTeamID
		/// </summary>
		public async Task<Team> GetTeamInfo(long teamId)
		{
			var url = string.Format("https://api.steampowered.com/IDOTA2Match_570/GetTeamInfoByTeamID/v0001/?key={0}&start_at_team_id={1}&teams_requested=1", this.key, teamId);
			var json = await this.client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<GetTeamInfoResponse>(json);
			return data?.Result?.Teams?.FirstOrDefault();
		}

		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetPlayerSummaries
		/// </summary>
		public async Task<Profile> GetPlayerSummary(ulong steamId)
		{
			var url = string.Format("http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={0}&steamids={1}", this.key, steamId);
			var json = await this.client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<PlayerSummariesResult>(json);
			var player = data?.Response?.Profiles?.FirstOrDefault();
			return player;
		}

        /// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetPlayerSummaries
		/// </summary>
		public async Task<List<Profile>> GetPlayersSummary(List<ulong> ids)
        {
            if (ids.Count > 100)
                throw new ArgumentOutOfRangeException("ids", ids.Count, "Can only process 100 profiles at a time.");

            var url = string.Format("http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={0}&steamids={1}", this.key, String.Join(",", ids.ToArray()));
            var json = await this.client.GetStringAsync(url);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<PlayerSummariesResult>(json);
            return data?.Response?.Profiles;
        }

		/// <summary>
		/// https://wiki.teamfortress.com/wiki/WebAPI/GetFriendList
		/// </summary>
		public async Task<List<Models.Friend>> GetFriendsList(ulong steamId)
		{
			var url = string.Format("http://api.steampowered.com/ISteamUser/GetFriendList/v0001/?key={0}&steamid={1}", this.key, steamId);
			var json = await this.client.GetStringAsync(url);
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.FriendsListReponse>(json);
			return data?.FriendsList?.Friends;
		}
	}
}
