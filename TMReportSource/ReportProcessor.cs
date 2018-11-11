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

				Threat threat = new Threat
				{
					Id = value.Element(nsB + "Id").Value,

					Priority = value.Element(nsB + "Priority").Value,

					ChangedBy = value.Element(nsB + "ChangedBy").Value,

					ModifiedAt = value.Element(nsB + "ModifiedAt").Value,

					State = value.Element(nsB + "State").Value,
				};

				var xProperties = value.Descendants(nsB + "Properties").ToList();

				foreach (XElement xProperty in xProperties.Elements(nsA + "KeyValueOfstringstring"))
				{
					
					if (xProperty.Element(nsA + "Key").Value == "Title")
					{
						threat.Title = xProperty.Element(nsA + "Value").Value;
					}
					else if (xProperty.Element(nsA + "Key").Value == "UserThreatDescription")
					{
						threat.Description = xProperty.Element(nsA + "Value").Value;
					}
					else if (xProperty.Element(nsA + "Key").Value == "UserThreatShortDescription")
					{
						threat.ShortDescription = xProperty.Element(nsA + "Value").Value;
					}
					else if (xProperty.Element(nsA + "Key").Value == "UserThreatCategory")
					{
						threat.Category = xProperty.Element(nsA + "Value").Value;
					}
					else if (xProperty.Element(nsA + "Key").Value == "InteractionString")
					{
						threat.Interaction = xProperty.Element(nsA + "Value").Value;
					}
					else if (xProperty.Element(nsA + "Key").Value == "StateInformation")
					{
						threat.Justification = xProperty.Element(nsA + "Value").Value;
					}

					//if (TryParseGuid(xProperty.Element(nsA + "Key").Value, out Guid key1))
					//{
					//TODO: Custom field  threat.Key = getPropertyName(xdoc, key1.ToString());
					//}
					//else
					//{

					//}
				}
				list.Add(threat);
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
