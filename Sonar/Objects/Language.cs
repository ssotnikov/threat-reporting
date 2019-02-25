using Newtonsoft.Json;

namespace Sonar.Objects
{
	public class Language
	{
		[JsonProperty("key")]
		public string Key { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
