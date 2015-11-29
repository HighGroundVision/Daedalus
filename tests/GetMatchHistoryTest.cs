using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HGV.Daedalus.Tests
{
	public class GetMatchHistoryTest
	{
		private string ApiKey = ConfigurationManager.AppSettings["SteamApiKey"];

		[Fact]
		public async Task NotEmpty_AccountId()
		{
			using (var client = new DotaApi(this.ApiKey))
			{
				var matches = await client.GetMatchHistory(76561197973295540);

				Assert.NotEmpty(matches);
			}
		}

		[Fact]
		public async Task NotEmpty_HeroId()
		{
			using (var client = new DotaApi(this.ApiKey))
			{
				var matches = await client.GetMatchHistory(76561197973295540, 1);

				Assert.NotEmpty(matches);
			}
		}



		[Fact]
		public async Task ArgumentOutOfRangeException_AccountId()
		{
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
			{
				using (var client = new DotaApi(this.ApiKey))
				{
					var matches = await client.GetMatchHistory(0);
				}
			});
			
		}

		[Fact]
		public async Task ArgumentOutOfRangeException_HeroId_Low()
		{
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
			{
				using (var client = new DotaApi(this.ApiKey))
				{
					var matches = await client.GetMatchHistory(76561197973295540, 0);
				}
			});

		}

		[Fact]
		public async Task ArgumentOutOfRangeException_HeroId_High()
		{
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
			{
				using (var client = new DotaApi(this.ApiKey))
				{
					var matches = await client.GetMatchHistory(76561197973295540, 150);
				}
			});

		}
	}
}
