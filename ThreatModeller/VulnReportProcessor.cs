using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ThreatModeller.Objects.VulnReport;

namespace ThreatModeller
{
	public class VulnReportProcessor
	{

		private JObject _report;

		public string FileName { get; set; }

		public VulnReportProcessor()
		{

		}

		public VulnModel GetReport()
		{

			var model = new VulnModel
			{
				Vulns = new List<Vuln>()
			};

			if (!string.IsNullOrEmpty(FileName)) {

				using (StreamReader r = new StreamReader(FileName))
				{
					var jsSource = r.ReadToEnd();

					_report = JObject.Parse(jsSource);
				}

				if (_report != null)
				{
					var dependencies = ((JArray)_report["dependencies"]).ToList();

					foreach (var dep in dependencies)
					{
						var v = new Vuln
						{
							Id = dep["md5"].ToString(),
							FileName = dep["fileName"].ToString()
						};
						model.Vulns.Add(v);
					}
				}
			}

			return model;

		}

	}
}
