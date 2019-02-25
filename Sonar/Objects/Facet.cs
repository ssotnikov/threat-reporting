using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sonar.Objects
{
	public class Facet
	{
		[JsonProperty("property")]
		public string Property { get; set; }

		[JsonProperty("values")]
		public List<Value> Values { get; set; }
	}
}
