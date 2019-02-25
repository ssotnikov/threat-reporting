using Newtonsoft.Json;
using System;

namespace Sonar.Objects
{
	public class Rule
	{
		[JsonProperty("key")]
		public string Key { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("repo")]
		public string Repo { get; set; }

		[JsonProperty("createdAt")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("htmlDesc")]
		public string HtmlDesc { get; set; }

		[JsonProperty("mdDesc")]
		public string MdDesc { get; set; }

		[JsonProperty("lang")]
		public string Lang { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("langName")]
		public string LangName { get; set; }

		[JsonProperty("severity")]
		public string Severity { get; set; }

		[JsonProperty("isTemplate")]
		public bool IsTemplate { get; set; }

		[JsonProperty("tags")]
		public string[] Tags { get; set; }

		[JsonProperty("sysTags")]
		public string[] SysTags { get; set; }

		[JsonProperty("stringdefaultDebtRemFnType")]
		public string StringDefaultDebtRemFnType { get; set; }

		[JsonProperty("defaultDebtRemFnOffset")]
		public string DefaultDebtRemFnOffset { get; set; }

		[JsonProperty("debtOverloaded")]
		public bool DebtOverloaded { get; set; }

		[JsonProperty("debtRemFnType")]
		public string DebtRemFnType { get; set; }

		[JsonProperty("debtRemFnOffset")]
		public string DebtRemFnOffset { get; set; }

		[JsonProperty("defaultRemFnType")]
		public string DefaultRemFnType { get; set; }

		[JsonProperty("defaultRemFnBaseEffort")]
		public string DefaultRemFnBaseEffort { get; set; }

		[JsonProperty("remFnType")]
		public string RemFnType { get; set; }

		[JsonProperty("remFnBaseEffort")]
		public string RemFnBaseEffort { get; set; }

		[JsonProperty("remFnOverloaded")]
		public bool RemFnOverloaded { get; set; }

		[JsonProperty("scope")]
		public string Scope { get; set; }

		[JsonProperty("sExternal")]
		public bool SExternal { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
