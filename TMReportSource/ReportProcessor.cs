using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace TMReportSource
{
	public class ReportProcessor
	{
		public static List<Threat> GetReport(string fileName)
		{
			return LoadThreatInstances(fileName);
		}

		private static List<Threat> LoadThreatInstances(string fileName)
		{
			List<Threat> list = new List<Threat>();

			XDocument xdoc = XDocument.Load(fileName);

			XNamespace nsA = "http://schemas.microsoft.com/2003/10/Serialization/Arrays";

			XNamespace nsB = "http://schemas.datacontract.org/2004/07/ThreatModeling.KnowledgeBase";

			var xThreats = xdoc.Document.Descendants(nsA + "KeyValueOfstringThreatpc_P0_PhOB").ToList();
			

			foreach (XElement xThreat in xThreats)
			{
				var key = xThreat.Element(nsA + "Key").Value;

				var value = xThreat.Element(nsA + "Value");

				var xProperties = value.Descendants(nsB + "Properties").ToList();

				foreach (XElement xProperty in xProperties.Elements(nsA + "KeyValueOfstringstring"))
				{
					Threat threat = new Threat
					{
						Id = value.Element(nsB + "Id").Value,

						Priority = value.Element(nsB + "Priority").Value
					};

					if (TryParseGuid(xProperty.Element(nsA + "Key").Value, out Guid key1))
					{
						threat.Key = getPropertyName(xdoc, key1.ToString());
					}
					else
					{
						threat.Key = xProperty.Element(nsA + "Key").Value;

					}

					threat.Value = xProperty.Element(nsA + "Value").Value;

					if (threat.Key == "Title")
					{
						threat.Title = threat.Value;
					}

					list.Add(threat);
				}

				//Threat threat = new Threat
				//{
				//	Key = key,

				//	Id = value.Element(nsB + "Id").Value,

				//	ChangedBy = value.Element(nsB + "ChangedBy").Value,

				//	InteractionKey = value.Element(nsB + "ChangedBy").Value,

				//	ModifiedAt = value.Element(nsB + "ModifiedAt").Value,

				//	Priority = value.Element(nsB + "Priority").Value,

				//	SourceGuid = value.Element(nsB + "SourceGuid").Value,

				//	TargetGuid = value.Element(nsB + "TargetGuid").Value,

				//	Properties = new List<ThreatProperty>()
				//};
			}

			return list;
		}

		private static string getPropertyName(XDocument xdoc, string guid) {
			var name = xdoc.Document.Root.Elements().ToList()[7].Elements().ToList()[4].Elements().ToList()[2].Elements().ToList();

			var d = name.Descendants().First(i => i.Value == guid).Value;

			return d;
		}

		private static bool TryParseGuid(string guidString, out Guid guid)
		{
			if (guidString == null) throw new ArgumentNullException("guidString");
			try
			{
				guid = new Guid(guidString);
				return true;
			}
			catch (FormatException)
			{
				guid = default(Guid);
				return false;
			}
		}
	}
}
