using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HGV.Daedalus.Tests
{
	public class GetLiveLeagueGamesTest
	{
		private string ApiKey = ConfigurationManager.AppSettings["SteamApiKey"];

		[Fact]
		public async Task NotEmpty()
		{
			using (var client = new DotaApi(this.ApiKey))
			{
				var leagues = await client.GetLiveLeagueGames();

				Assert.NotEmpty(leagues);
			}
		}
	}
}
