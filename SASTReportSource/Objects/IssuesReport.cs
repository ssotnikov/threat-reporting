using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonar.Objects
{
	public class IssuesReport
	{
		public int total { get; set; } 
		public Paging paging { get; set; }
		public int effortTotal { get; set; }
		public int debtTotal { get; set; }
		public List<Issue> issues { get; set; }
		public List<Rule> rules { get; set; }
		public List<Component> components { get; set; }
		public List<Language> languages { get; set; }
	}
}
