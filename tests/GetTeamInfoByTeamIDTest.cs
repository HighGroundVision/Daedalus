using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HGV.Daedalus.Tests
{
	public class GetTeamInfoByTeamIDTest
	{
		private string ApiKey = ConfigurationManager.AppSettings["Steam:ApiKey"];

		[Fact]
		public async Task NotNull()
		{
			using (var client = new DotaApiClient(this.ApiKey))
			{
				var team = await client.GetTeamInfoByTeamID(2013239);

				Assert.NotNull(team);
			}
		}

		[Fact]
		public async Task VerifyTeam()
		{
			using (var client = new DotaApiClient(this.ApiKey))
			{
				var team = await client.GetTeamInfoByTeamID(2013239);

				Assert.NotNull(team);
				Assert.Equal(2013239, team.team_id);
				Assert.Equal("ca", team.country_code);
				Assert.Equal(539633534871532086, team.logo);
				Assert.Equal(539633534871534771, team.logo_sponsor);
				Assert.Equal("Dev5", team.name);
				Assert.Equal("inactive", team.rating);
				Assert.Equal("Dev5", team.tag);
				Assert.Equal("www.abilitydrafter.com", team.url);
			}
		}

		[Fact]
		public async Task Null()
		{
			using (var client = new DotaApiClient(this.ApiKey))
			{
				var team = await client.GetTeamInfoByTeamID(long.MaxValue);

				Assert.Null(team);
			}
		}
	}
}
