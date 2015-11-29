using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HGV.Daedalus.Tests
{
	public class GetPlayerSummariesTest
	{
		private string ApiKey = ConfigurationManager.AppSettings["SteamApiKey"];

		[Fact]
		public async Task NotNull()
		{
			using (var client = new DotaApiClient(this.ApiKey))
			{
				var profile = await client.GetPlayerSummaries(76561197973295540);

				Assert.NotNull(profile);
			}
		}


		[Fact]
		public async Task VerifyProfile()
		{
			using (var client = new DotaApiClient(this.ApiKey))
			{
				var profile = await client.GetPlayerSummaries(76561197973295540);

				Assert.NotNull(profile);
				Assert.Equal(76561197973295540, profile.steamid);
				Assert.Equal("RGBKnights", profile.personaname);
				Assert.Equal("http://steamcommunity.com/id/RGBKnights/", profile.profileurl);
				Assert.Equal("https://steamcdn-a.akamaihd.net/steamcommunity/public/images/avatars/74/746e33fac2bc741beffd5cc2b77f13f136e1e00a.jpg", profile.avatar);
			}
		}

		[Fact]
		public async Task Null()
		{
			using (var client = new DotaApiClient(this.ApiKey))
			{
				var profile = await client.GetPlayerSummaries(1234);
				
				Assert.Null(profile);
			}
		}

	}
}
