using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMReportSource.Objects.VulnReport;

namespace TMReportSource
{
	public class VulnReportProcessor
	{

		private string _fileName = string.Empty;

		private JObject _report;

		public VulnReportProcessor(string fileName) {

			_fileName = fileName;

			using (StreamReader r = new StreamReader(_fileName))
			{
				var jsSource = r.ReadToEnd();

				_report = JObject.Parse(jsSource);
			}

		}

		public VulnModel GetReport()
		{

			var model = new VulnModel();

			var list = new List<Vuln>();

			var dependencies = ((JArray)_report["dependencies"]).ToList();

			foreach (var dep in dependencies) {
				var v = new Vuln
				{
					Id = dep["md5"].ToString(),
					FileName = dep["fileName"].ToString()
				};
				list.Add(v);
			}

			model.Vulns = list;

			return model;
		}

	}
}
