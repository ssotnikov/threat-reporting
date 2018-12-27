using System.Collections.Generic;

namespace TMReportSource
{
	public class Dictionaries
	{
		public Dictionary<string, string> MitigationStartegies;

		public Dictionary<string, int> SeverityWeight;

		public Dictionaries() {

			MitigationStartegies = new Dictionary<string, string>
			{
				{ "S", "Authentication" },
				{ "T", "Integrity" },
				{ "R", "Audit (Non-repudiation services)" },
				{ "I", "Confidentiality" },
				{ "D", "Availability" },
				{ "E", "Authorization" }
			};

			SeverityWeight = new Dictionary<string, int>
			{
				{ "High", 0},
				{ "Medium", 1},
				{ "Low", 2}
			};
		}
	}
}
