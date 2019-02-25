using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sonar.Objects
{
	public class Issue
	{
		[JsonProperty("key")]
		public string Key { get; set; }

		[JsonProperty("rule")]
		public string Rule { get; set; }

		[JsonProperty("severity")]
		public string Severity { get; set; }

		[JsonProperty("component")]
		public string Component { get; set; }

		[JsonProperty("line")]
		public string Line { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

	}
}
