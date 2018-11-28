using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMReportSource
{
	public class StatisticsModel : IReportModel
	{
		public List<MetaInformation> MetaInformation { get; set; }
		public List<Statistics> Statistics { get; set; }

		public List<Threat> Threats { get; set; }
	}
}
