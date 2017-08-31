using HGV.Daedalus.GetMatchDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGV.Daedalus.GetMatchHistoryBySequenceNum
{
	public class Result
	{
		public List<Match> matches { get; set; }

		public int status { get; set; }
	}
}
