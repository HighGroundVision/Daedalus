using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace HGV.Daedalus.Test
{
    [TestClass]
    public class DotaApiClientTests
    {
        [TestInitialize]
        public void LoadEnvironment()
        {
            dotenv.net.DotEnv.Config();
        }

        [TestMethod]
        public async Task GetLiveLeagueGames()
        {
            var provider = new MoqSteamKeyProvider();
            var factory = new MoqHttpClientFactory();
            var client = new DotaApiClient(provider, factory);

            var collection = await client.GetLiveLeagueGames();
            Assert.IsTrue(collection.Count > 0);
        }

        [TestMethod]
        public async Task GetLiveLeagueGamesByMatch()
        {
            var provider = new MoqSteamKeyProvider();
            var factory = new MoqHttpClientFactory();
            var client = new DotaApiClient(provider, factory);

            var collection = await client.GetLiveLeagueGames();
            Assert.IsTrue(collection.Count > 0);

            var match = collection.FirstOrDefault();
            Assert.IsNotNull(match);

            var results = await client.GetLiveLeagueGames(matchId: match.match_id);
            Assert.IsTrue(results.Count > 0);
        }

        [TestMethod]
        public async Task GetLiveLeagueGamesByLeague()
        {
            var provider = new MoqSteamKeyProvider();
            var factory = new MoqHttpClientFactory();
            var client = new DotaApiClient(provider, factory);

            var collection = await client.GetLiveLeagueGames();
            Assert.IsTrue(collection.Count > 0);

            var match = collection.FirstOrDefault();
            Assert.IsNotNull(match);

            var results = await client.GetLiveLeagueGames(leagueId: match.league_id);
            Assert.IsTrue(results.Count > 0);
        }

        [TestMethod]
        public async Task GetMatchDetails()
        {
            var provider = new MoqSteamKeyProvider();
            var factory = new MoqHttpClientFactory();
            var client = new DotaApiClient(provider, factory);

            ulong id = 5183975800;
            var match = await client.GetMatchDetails(id);
            Assert.IsNotNull(match);
        }


        [TestMethod]
        public async Task GetLastestMatches()
        {
            var provider = new MoqSteamKeyProvider();
            var factory = new MoqHttpClientFactory();
            var client = new DotaApiClient(provider, factory);

            var collection = await client.GetLastestMatches();
            Assert.IsTrue(collection.Count > 0);
        }

        [TestMethod]
        public async Task GetMatchesInSequence()
        {
            var provider = new MoqSteamKeyProvider();
            var factory = new MoqHttpClientFactory();
            var client = new DotaApiClient(provider, factory);

            ulong number = 4350046356;
            var collection = await client.GetMatchesInSequence(number);
            Assert.IsTrue(collection.Count > 0);
        }

        [TestMethod]
        public async Task GetMatchHistory()
        {
            var provider = new MoqSteamKeyProvider();
            var factory = new MoqHttpClientFactory();
            var client = new DotaApiClient(provider, factory);

            uint id= 13029812;
            var collection = await client.GetMatchHistory(id);
            Assert.IsTrue(collection.Count > 0);
        }
        

        [TestMethod]
        public async Task GetMatchHistoryFilterByHero()
        {
            var provider = new MoqSteamKeyProvider();
            var factory = new MoqHttpClientFactory();
            var client = new DotaApiClient(provider, factory);

            uint accountId = 13029812;
            int heroId = 1;
            var collection = await client.GetMatchHistory(accountId, heroId);
            Assert.IsTrue(collection.Count > 0);
        }

        [TestMethod]
        public async Task GetTeamInfoByTeamID()
        {
            var provider = new MoqSteamKeyProvider();
            var factory = new MoqHttpClientFactory();
            var client = new DotaApiClient(provider, factory);

            var teamId = 2013239;
            var team = await client.GetTeamInfoByTeamID(teamId);
            Assert.IsNotNull(team);
        }

        [TestMethod]
        public async Task GetPlayerSummary()
        {
            var provider = new MoqSteamKeyProvider();
            var factory = new MoqHttpClientFactory();
            var client = new DotaApiClient(provider, factory);

            ulong steamId = 76561197995231280;
            var player = await client.GetPlayerSummary(steamId);
            Assert.IsNotNull(player);
        }

        [TestMethod]
        public async Task GetPlayersSummary()
        {
            var provider = new MoqSteamKeyProvider();
            var factory = new MoqHttpClientFactory();
            var client = new DotaApiClient(provider, factory);

            var input = new List<ulong>() { 76561197995231280 }; 
            var collection = await client.GetPlayersSummary(input);
            Assert.IsTrue(collection.Count > 0);
        }
    }
}
