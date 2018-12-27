using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreatModeler
{
	public class Component
	{
		public Guid Id { get; set; }
		public Guid ParentId { get; set; }
		public string Name { get; set; }
		public ComponentType ComponentType { get; set; }

	}
}
