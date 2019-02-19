using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASTReportSource.Objects
{
	public class IssuesReport
	{
		public int total { get; set; } 
		public List<Issue> issues { get; set; }
	}
}
