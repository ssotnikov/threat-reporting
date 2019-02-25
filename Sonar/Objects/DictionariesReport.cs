using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sonar.Objects
{
	public class DictionariesReport
	{
		[JsonProperty("rules")]
		public List<Rule> rules { get; set; }

		[JsonProperty("components")]
		public List<Component> components { get; set; }

		[JsonProperty("languages")]
		public List<Language> languages { get; set; }

		[JsonProperty("facets")]
		public List<Facet> Facets { get; set; }
	}
}
