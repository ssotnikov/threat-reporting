using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace TMReportSource
{
	public class ReportProcessor
	{
		private static XNamespace nsA = "http://schemas.microsoft.com/2003/10/Serialization/Arrays";

		private static XNamespace nsKB = "http://schemas.datacontract.org/2004/07/ThreatModeling.KnowledgeBase";


		public static List<Threat> GetReport(string fileName)
		{
			return LoadThreatInstances(fileName);
		}

		private static List<Threat> LoadThreatInstances(string fileName)
		{
			List<Threat> list = new List<Threat>();

			XDocument xdoc = XDocument.Load(fileName);

			var xThreats = xdoc.Document.Descendants(nsA + "KeyValueOfstringThreatpc_P0_PhOB").ToList();

			foreach (XElement xThreat in xThreats)
			{
				var key = xThreat.Element(nsA + "Key").Value;

				var value = xThreat.Element(nsA + "Value");

				Threat threat = new Threat
				{
					Id = value.Element(nsKB + "Id").Value,

					Priority = value.Element(nsKB + "Priority").Value,

					ChangedBy = value.Element(nsKB + "ChangedBy").Value,

					ModifiedAt = value.Element(nsKB + "ModifiedAt").Value,

					State = value.Element(nsKB + "State").Value,
				};

				var xProperties = value.Descendants(nsKB + "Properties").ToList();

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
					else if (xProperty.Element(nsA + "Key").Value == "SDLPhase")
					{
						threat.SDLPhase = xProperty.Element(nsA + "Value").Value;
					}
					else if (TryParseGuid(xProperty.Element(nsA + "Key").Value, out Guid key1))
					{

						var customPropName = getPropertyName(xdoc, key1.ToString());

						if (customPropName == "Data Asset") {
							threat.DataAsset = xProperty.Element(nsA + "Value").Value;
						}

						if (customPropName == "Actors")
						{
							threat.Actor = xProperty.Element(nsA + "Value").Value;
						}

						if (customPropName == "Issue references") {
							threat.IssueReferences = xProperty.Element(nsA + "Value").Value;
						}
					}
				}
				list.Add(threat);
			}

			return list;
		}

		private static string getPropertyName(XDocument xdoc, string guid)
		{
			XNamespace nsM = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model";
			var name = xdoc.Document.Descendants(nsM + "ThreatMetaDatum")
				.Where(e => e.Element(nsM + "Id").Value == guid)
				.Select(e => e.Element(nsM + "Label").Value)
				.FirstOrDefault();
			return name;
		}

		private static bool TryParseGuid(string guidString, out Guid guid)
		{
			if (guidString == null)
			{
				throw new ArgumentNullException("guidString");
			}

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
