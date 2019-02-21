using Newtonsoft.Json;
using Sonar.Objects;

namespace SASTReportSource.Objects
{
	public class RuleReport
	{
		[JsonProperty("rule")]
		public Rule Rule { get; set; }
	}
}
