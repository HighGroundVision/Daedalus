using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGV.Daedalus.GetMatchHistory
{
	public class Result
	{
		public List<Match> matches { get; set; }

		public int status { get; set; }
		public int num_results { get; set; }
		public int total_results { get; set; }
		public int results_remaining { get; set; }
	}
}
