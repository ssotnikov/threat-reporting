using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMReportSource
{
	public class Statistics
	{
		public int ThreatStatusNotStarted { get; set; }
		public int ThreatStatusNeedsInvestigation { get; set; }
		public int ThreatStatusNotApplicable { get; set; }
		public int ThreatStatusMitigated { get; set; }
		public int PriorityHigh { get; set; }
		public int PriorityMedium { get; set; }
		public int PriorityLow { get; set; }
		public int SDLPhaseDesign { get; set; }
		public int SDLPhaseImplementation { get; set; }
	}
}
