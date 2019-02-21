using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Linq;
using ThreatModeller.Properties;

namespace ThreatModeller
{
	public class ThreatReportProcessor
	{
		private string fileName = string.Empty;

		private static XDocument xdoc;

		private static XNamespace nsArrays = "http://schemas.microsoft.com/2003/10/Serialization/Arrays";

		private static XNamespace nsKnowledgeBase = "http://schemas.datacontract.org/2004/07/ThreatModeling.KnowledgeBase";

		private static XNamespace nsModel = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model";

		private static XNamespace nsAbstracts = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts";

		private static List<Component> components;

		private static List<ComponentProperty> componentProperties;

		private Dictionaries dictionaries;

		public ThreatReportProcessor(string fileName)
		{
			try {
				xdoc = XDocument.Load(fileName);

				components = getComponents();

				componentProperties = components.SelectMany(c => c.Properties).ToList();

				dictionaries = new Dictionaries();
			}
			catch (Exception e) {

				throw e;

			}
			
		}

		public List<Component> GetComponentsByType(string type)
		{

			return components.Where(c => c.GenericTypeId == type).ToList();

		}

		public List<MetaInformation> GetMetaInformation()
		{
			var list = new List<MetaInformation>();

			var xMI = xdoc.Document.Descendants(nsModel + "MetaInformation").FirstOrDefault();

			var mi = new MetaInformation
			{
				Assumptions = xMI.Element(nsModel + "Assumptions").Value,
				Contributors = xMI.Element(nsModel + "Contributors").Value,
				ExternalDependencies = xMI.Element(nsModel + "ExternalDependencies").Value,
				HighLevelSystemDescription = xMI.Element(nsModel + "HighLevelSystemDescription").Value,
				Owner = xMI.Element(nsModel + "Owner").Value,
				Reviewer = xMI.Element(nsModel + "Reviewer").Value,
				ThreatModelName = xMI.Element(nsModel + "ThreatModelName").Value
			};

			list.Add(mi);

			return list;
		}

		public List<Note> GetNotes()
		{

			var list = new List<Note>();

			var xNotes = xdoc.Document.Descendants(nsModel + "Note").ToList();

			foreach (XElement xNote in xNotes)
			{
				var note = new Note
				{
					Id = int.Parse(xNote.Element(nsModel + "Id").Value),

					AddedBy = xNote.Element(nsModel + "AddedBy").Value,

					Date = DateTime.Parse(xNote.Element(nsModel + "Date").Value),

					Message = xNote.Element(nsModel + "Message").Value
				};

				list.Add(note);
			}
			return list;
		}

		private List<Component> getComponents()
		{
			var list = new List<Component>();
			var xComponents = xdoc.Document.Descendants(nsArrays + "KeyValueOfguidanyType").ToList();
			foreach (XElement xComponent in xComponents)
			{
				var key = xComponent.Element(nsArrays + "Key").Value;

				var value = xComponent.Element(nsArrays + "Value");

				var component = new Component
				{

					Key = key,

					GenericTypeId = value.Element(nsAbstracts + "GenericTypeId").Value,

					TypeId = value.Element(nsAbstracts + "TypeId").Value

				};

				var xProperties = value.Descendants(nsArrays + "anyType").ToList();

				component.Properties = new List<ComponentProperty>();

				foreach (XElement xProperty in xProperties)
				{

					var prop = new ComponentProperty
					{
						ComponentId = key,
						DisplayName = xProperty.Element(nsKnowledgeBase + "DisplayName").Value,
						Name = xProperty.Element(nsKnowledgeBase + "Name").Value,
						Value = xProperty.Element(nsKnowledgeBase + "Value").Value
					};

					if (prop.DisplayName == "Name")
					{

						component.Name = prop.Value;

					}

					component.Properties.Add(prop);

				}

				list.Add(component);
			}
			return list;
		}

		public List<Threat> GetThreats()
		{

			var list = new List<Threat>();

			var xThreats = xdoc.Document.Descendants(nsArrays + "KeyValueOfstringThreatpc_P0_PhOB").ToList();

			foreach (XElement xThreat in xThreats)
			{
				var key = xThreat.Element(nsArrays + "Key").Value;

				var value = xThreat.Element(nsArrays + "Value");

				var flowGuid = value.Element(nsKnowledgeBase + "FlowGuid").Value;

				var sourceGuid = value.Element(nsKnowledgeBase + "SourceGuid").Value;

				var targetGuid = value.Element(nsKnowledgeBase + "TargetGuid").Value;

				var threat = new Threat
				{
					Id = int.Parse(value.Element(nsKnowledgeBase + "Id").Value),

					Priority = value.Element(nsKnowledgeBase + "Priority").Value,

					PriorityWeight = dictionaries.SeverityWeight.FirstOrDefault(i => i.Key == value.Element(nsKnowledgeBase + "Priority").Value).Value,

					ChangedBy = value.Element(nsKnowledgeBase + "ChangedBy").Value,

					ModifiedAt = DateTime.Parse(value.Element(nsKnowledgeBase + "ModifiedAt").Value),

					FlowGuid = flowGuid,

					FlowName = getComponentPropertyValue(flowGuid, Settings.Default.Name),

					FlowOutOfScope = getComponentPropertyValue(flowGuid, Settings.Default.OutOfScope),

					FlowOutOfScopeReason = getComponentPropertyValue(flowGuid, Settings.Default.OutOfScopeReason),

					SourceGuid = sourceGuid,

					SourceName = getComponentPropertyValue(sourceGuid, Settings.Default.Name),

					SourceOutOfScope = getComponentPropertyValue(sourceGuid, Settings.Default.OutOfScope),

					SourceOutOfScopeReason = getComponentPropertyValue(sourceGuid, Settings.Default.OutOfScopeReason),

					TargetGuid = targetGuid,

					TargetName = getComponentPropertyValue(targetGuid, Settings.Default.Name),

					TargetOutOfScope = getComponentPropertyValue(targetGuid, Settings.Default.OutOfScope),

					TargetOutOfScopeReason = getComponentPropertyValue(targetGuid, Settings.Default.OutOfScopeReason),

					State = value.Element(nsKnowledgeBase + "State").Value == "AutoGenerated" ? "Not Started" : value.Element(nsKnowledgeBase + "State").Value
				};

				threat.InteractionImage = xdoc.Descendants(nsKnowledgeBase + "ImageSource").FirstOrDefault().Value;

				var xProperties = value.Descendants(nsKnowledgeBase + "Properties").ToList();

				foreach (XElement xProperty in xProperties.Elements(nsArrays + "KeyValueOfstringstring"))
				{

					if (xProperty.Element(nsArrays + "Key").Value == "Title")
					{
						threat.Title = xProperty.Element(nsArrays + "Value").Value;
					}
					else if (xProperty.Element(nsArrays + "Key").Value == "UserThreatDescription")
					{
						threat.Description = GetNormalizedString(xProperty.Element(nsArrays + "Value").Value);
					}
					else if (xProperty.Element(nsArrays + "Key").Value == "UserThreatShortDescription")
					{
						threat.ShortDescription = xProperty.Element(nsArrays + "Value").Value;
					}
					else if (xProperty.Element(nsArrays + "Key").Value == "UserThreatCategory")
					{
						threat.Category = xProperty.Element(nsArrays + "Value").Value;

						threat.MitigationStrategy = getMitigationStrategy(threat.Category);
					}
					else if (xProperty.Element(nsArrays + "Key").Value == "InteractionString")
					{
						threat.Interaction = xProperty.Element(nsArrays + "Value").Value;
					}
					else if (xProperty.Element(nsArrays + "Key").Value == "StateInformation")
					{
						threat.Justification = GetNormalizedString(xProperty.Element(nsArrays + "Value").Value);
					}
					else if (xProperty.Element(nsArrays + "Key").Value == "SDLPhase")
					{
						threat.SDLPhase = xProperty.Element(nsArrays + "Value").Value;
					}
					else if (xProperty.Element(nsArrays + "Key").Value == "PossibleMitigations")
					{
						threat.PossibleMitigations = xProperty.Element(nsArrays + "Value").Value;
					}
					else if (TryParseGuid(xProperty.Element(nsArrays + "Key").Value, out Guid key1))
					{

						var customPropName = getCustomPropertyName(xdoc, key1.ToString());

						if (customPropName == "Assets")
						{

							threat.Assets = xProperty.Element(nsArrays + "Value").Value;

						}

						if (customPropName == "Impact")
						{

							threat.Impact = xProperty.Element(nsArrays + "Value").Value;

						}

						if (customPropName == "Attack Vectors")
						{

							threat.AttackVectors = xProperty.Element(nsArrays + "Value").Value;

						}

						if (customPropName == "Likelihood")
						{

							threat.Likelihood = xProperty.Element(nsArrays + "Value").Value;

						}

						if (customPropName == "Actors")
						{

							threat.Actors = xProperty.Element(nsArrays + "Value").Value;

						}

						if (customPropName == "Affected (CIA)")
						{

							threat.Actions = xProperty.Element(nsArrays + "Value").Value;

						}

						if (customPropName == "Issue Reference")
						{

							threat.IssueReference = xProperty.Element(nsArrays + "Value").Value;

						}

						if (customPropName == "Issue Status")
						{

							threat.IssueStatus = xProperty.Element(nsArrays + "Value").Value;

						}

						if (customPropName == "Mitigated Components")
						{

							threat.MitigatedComponents = xProperty.Element(nsArrays + "Value").Value;

						}

					}
				}

				list.Add(threat);

			}

			return list.OrderBy(i => i.Id).ToList();
		}

		public List<Threat> GetThreatsGroupedByMitigatedComponent()
		{
			var threats = GetThreats();
			List<Threat> result = new List<Threat>();
			foreach (Threat threat in threats)
			{
				if (threat.MitigatedComponents != null) {

					string[] components = threat.MitigatedComponents.Split(';', ',', '|');

					foreach (string component in components)
					{
						Threat th = (Threat)threat.Clone();
						th.MitigatedComponents = GetNormalizedString(component);
						result.Add(th);
					}

				}
			}
			return result;
		}


		private string getMitigationStrategy(string category)
		{
			var strideKey = new string(category.Take(1).ToArray());
			return dictionaries.MitigationStartegies.Where(i => i.Key == strideKey).FirstOrDefault().Value;
		}

		private static string GetNormalizedString(string input)
		{
			return input.Replace("\n              ", "\n").TrimStart().TrimEnd();
		}

		private static string getComponentPropertyValue(string guid, string PropertyName)
		{
			var val = string.Empty;

			var nameProperty = componentProperties.Where(p => p.ComponentId == guid && p.DisplayName == PropertyName).FirstOrDefault();

			if (nameProperty != null)
			{

				val = nameProperty.Value;

				if (string.IsNullOrEmpty(val))
				{
					val = componentProperties[0].Value;
				}

				val = val.Trim().Replace("\r", "").Replace("\n", "").Replace(" ", "");
			}

			return val;
		}

		private static string getCustomPropertyName(XDocument xdoc, string guid)
		{
			var name = xdoc.Document.Descendants(nsModel + "ThreatMetaDatum")
				.Where(e => e.Element(nsModel + "Id").Value == guid)
				.Select(e => e.Element(nsModel + "Label").Value)
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
