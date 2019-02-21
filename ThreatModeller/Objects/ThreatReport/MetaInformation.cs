using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreatModeller
{
	public class MetaInformation
	{
		public string ThreatModelName { get; set; }
		public string Assumptions { get; set; }
		public string Contributors { get; set; }
		public string ExternalDependencies { get; set; }
		public string HighLevelSystemDescription { get; set; }
		public string Owner { get; set; }
		public string Reviewer { get; set; }
	}
}
