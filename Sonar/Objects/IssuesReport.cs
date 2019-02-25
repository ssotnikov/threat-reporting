using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sonar.Objects
{
	public class IssuesReport
	{
		[JsonProperty("total")]
		public int Total { get; set; }

		[JsonProperty("paging")]
		public Paging Paging { get; set; }

		[JsonProperty("effortTotal")]
		public int EffortTotal { get; set; }

		[JsonProperty("debtTotal")]
		public int DebtTotal { get; set; }

		[JsonProperty("issues")]
		public List<Issue> Issues { get; set; }

		[JsonProperty("rules")]
		public List<Rule> Rules { get; set; }

		[JsonProperty("components")]
		public List<Component> Components { get; set; }

		[JsonProperty("languages")]
		public List<Language> Languages { get; set; }
	}
}
