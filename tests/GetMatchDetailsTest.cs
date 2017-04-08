using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HGV.Daedalus.Tests
{
	public class GetMatchDetailsTest
	{
		private string ApiKey = ConfigurationManager.AppSettings["Steam:ApiKey"];

		[Fact]
		public async Task NotNull()
		{
			using (var client = new DotaApiClient(this.ApiKey))
			{
				var matchDetails = await client.GetMatchDetails(1962101529);

				Assert.NotNull(matchDetails);
			}
		}

		[Fact]
		public async Task ArgumentOutOfRangeException()
		{
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
			{
				using (var client = new DotaApiClient(this.ApiKey))
				{
					var matchDetails = await client.GetMatchDetails(0);
				}
			});
		}
	}
}
