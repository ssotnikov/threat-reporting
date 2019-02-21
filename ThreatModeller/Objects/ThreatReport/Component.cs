using System.Collections.Generic;

namespace ThreatModeller
{
	public class Component
	{
		public string Key { get; set; }
		public string GenericTypeId { get; set; }
		public string TypeId { get; set; }
		public string Name { get; set; }
		public List<ComponentProperty> Properties { get; set; }

	}
}
