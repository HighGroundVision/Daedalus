using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HGV.Daedalus.Tests
{
	public class GetLeagueListingTest
	{
		private string ApiKey = "D929B1E7DFCC5FABB23DE7969F813E5E";

		[Fact]
		public void NotEmpty()
		{
			using (var client = new DotaApi(this.ApiKey))
			{
				var leagues = client.GetLeagueListing().Result;

				Assert.NotEmpty(leagues);
			}
		}

	}
}
