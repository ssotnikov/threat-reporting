using Newtonsoft.Json;

namespace Sonar.Objects
{
	public class Component
	{
		[JsonProperty("organization")]
		public string Organization { get; set; }

		[JsonProperty("key")]
		public string Key { get; set; }

		[JsonProperty("uuid")]
		public string Uuid { get; set; }

		[JsonProperty("enabled")]
		public bool Enabled { get; set; }

		[JsonProperty("qualifier")]
		public string Qualifier { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("longName")]
		public string LongName { get; set; }

		[JsonProperty("path")]
		public string Path { get; set; }
	}
}
