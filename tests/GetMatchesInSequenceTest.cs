using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HGV.Daedalus.Tests
{
	public class GetMatchesInSequenceTest
    {
		private string ApiKey = ConfigurationManager.AppSettings["Steam:ApiKey"];

        [Fact]
        public async Task NotEmpty()
        {
            using (var client = new DotaApiClient(this.ApiKey))
            {
                var matches = await client.GetMatchesInSequence(2977404520);

                Assert.NotEmpty(matches);
            }
        }

        [Fact]
        public async Task ArgumentOutOfRangeException_Number()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                using (var client = new DotaApiClient(this.ApiKey))
                {
                    var matches = await client.GetMatchesInSequence(0);
                }
            });

        }

    }
}
