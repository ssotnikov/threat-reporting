using Newtonsoft.Json;

namespace Sonar.Objects
{
	public class RuleReport
	{
		[JsonProperty("rule")]
		public Rule Rule { get; set; }
	}
}
