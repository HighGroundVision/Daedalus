using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HGV.Daedalus.Tests
{
	public class DotaApiTest
	{
		[Fact]
		public void ArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
				using (var client = new DotaApiClient(null))
				{
				}
			});
		}
	}
}
