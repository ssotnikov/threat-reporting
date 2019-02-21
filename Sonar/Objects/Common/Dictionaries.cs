using System.Collections.Generic;

namespace Sonar.Objects.Common
{
	internal class Dictionaries
	{
		public List<string> FacetTypes;

		public Dictionaries()
		{

			FacetTypes = new List<string>
			{
				{"severities" },
				{"statuses" },
				{"resolutions"},
				{"authors"},
				{"languages"},
				{"tags"},
				{"types"},
				{"owaspTop10"},
				{"sansTop25"},
				{"cwe"},
				{"createdAt"},
				{"rules"},
				{"assignees"},
				{"projects"}
			};
		}
	}
}
