using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMReportSource
{
	public class Component
	{
		public string Key { get; set; }
		public string GenericTypeId { get; set; }
		public string TypeId { get; set; }
		public List<ComponentProperty> Properties { get; set; }

	}
}
