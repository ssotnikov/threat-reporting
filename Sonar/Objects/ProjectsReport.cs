using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sonar.Objects
{
	public class ProjectsReport
	{
		[JsonProperty("components")]
		public List<Component> Components { get; set; }
	}
}
