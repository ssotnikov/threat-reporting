using System.Collections.Generic;

namespace Sonar.Objects
{
	public class DictionariesReport
	{
		public List<Rule> rules { get; set; }
		public List<Component> components { get; set; }
		public List<Language> languages { get; set; }
		public List<Facet> facets { get; set; }
	}
}
