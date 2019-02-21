using System;

namespace Sonar.Objects
{
	public class Rule
	{
		public string key { get; set; }
		public string name { get; set; }
		public string repo { get; set; }
		public DateTime createdAt { get; set; }
		public string htmlDesc { get; set; }
		public string mdDesc { get; set; }
		public string lang { get; set; }
		public string status { get; set; }
		public string langName { get; set; }
		public string severity { get; set; }
		public bool isTemplate { get; set; }
		public string[] tags { get; set; }
		public string[] sysTags { get; set; }
		public string stringdefaultDebtRemFnType { get; set; }
		public string defaultDebtRemFnOffset { get; set; }
		public bool debtOverloaded { get; set; }
		public string debtRemFnType { get; set; }
		public string debtRemFnOffset { get; set; }
		public string defaultRemFnType { get; set; }
		public string defaultRemFnBaseEffort { get; set; }
		public string remFnType { get; set; }
		public string remFnBaseEffort { get; set; }
		public bool remFnOverloaded { get; set; }
		public string scope { get; set; }
		public bool sExternal { get; set; }
		public string type { get; set; }
	}
}
