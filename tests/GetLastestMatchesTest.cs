using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HGV.Daedalus.Tests
{
	public class GetLastestMatchesTest
    {
		private string ApiKey = ConfigurationManager.AppSettings["Steam:ApiKey"];

        [Fact]
        public async Task NotEmpty()
        {
            using (var client = new DotaApiClient(this.ApiKey))
            {
                var matches = await client.GetLastestMatches();

                Assert.NotEmpty(matches);
            }
        }
       
	}
}
