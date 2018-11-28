using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMReportSource
{
	public interface IReportModel
	{
		List<MetaInformation> MetaInformation { get; set; }
	}
}
