using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMReportSource
{
	public class ThreatModel: IReportModel
	{
		public List<MetaInformation> MetaInformation { get; set; }
		public List<Note> Notes { get; set; }
		public List<Threat> Threats { get; set; }

	}
}
