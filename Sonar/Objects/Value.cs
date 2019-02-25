using Newtonsoft.Json;

namespace Sonar.Objects
{
	public class Value
	{
		[JsonProperty("val")]
		public string Val { get; set; }

		[JsonProperty("count")]
		public int count { get; set; }

		public override string ToString()
		{
			return Val;
		}
	}
}
