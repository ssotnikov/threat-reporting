using System;
using System.Collections.Generic;

namespace SASTReportSource.Objects
{
	public class Issue
	{
		public string key { get; set; }
		public string rule { get; set; }
		public string severity { get; set; }
		public string component { get; set; }
		public string line { get; set; }
		public string status { get; set; }
		public string message { get; set; }
		public string type { get; set; }

	}
}
