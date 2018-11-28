using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TMReportSource.Properties;

namespace TMReportSource
{
	public class ReportProcessor
	{
		private string _fileName = string.Empty;

		private static XDocument xdoc;

		private static XNamespace nsArrays = "http://schemas.microsoft.com/2003/10/Serialization/Arrays";

		private static XNamespace nsKnowledgeBase = "http://schemas.datacontract.org/2004/07/ThreatModeling.KnowledgeBase";

		private static XNamespace nsModel = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model";

		private static XNamespace nsAbstracts = "http://schemas.datacontract.org/2004/07/ThreatModeling.Model.Abstracts";

		private static List<Component> _components;

		private static List<ComponentProperty> _componentProperties;

		private Dictionaries _dictionaries;

		public ReportProcessor(string fileName)
		{
			xdoc = XDocument.Load(fileName);

			_components = getComponents();

			_componentProperties = _components.SelectMany(c => c.Properties).ToList();

			_dictionaries = new Dictionaries();

		}

		public ThreatModel GetThreatReport()
		{

			var model = new ThreatModel
			{
				Threats = getThreats(),
				Notes = getNotes(),
				MetaInformation = getMetaInformation()
			};

			return model;
		}

		public StatisticsModel GetStatisticsReport()
		{
			var threats = getThreats();

			var stats = new Statistics
			{
				ThreatStatusNotStarted = threats.Count(th => th.State == "Not Started"),
				ThreatStatusMitigated = threats.Count(th => th.State == "Mitigated"),
				ThreatStatusNeedsInvestigation = threats.Count(th => th.State == "NeedsInvestigation"),
				ThreatStatusNotApplicable = threats.Count(th => th.State == "NotApplicable"),
				SDLPhaseDesign = threats.Count(th => th.SDLPhase == "Design"),
				SDLPhaseImplementation = threats.Count(th => th.SDLPhase == "Implementation"),
				PriorityHigh = threats.Count(th => th.Priority == "High"),
				PriorityMedium = threats.Count(th => th.Priority == "Medium"),
				PriorityLow = threats.Count(th => th.Priority == "Low")
			};

			var model = new StatisticsModel
			{
				MetaInformation = getMetaInformation(),
				Statistics = new List<Statistics>(),
				Threats = getThreats()
			};

			model.Statistics.Add(stats);

			return model;
		}

		private List<MetaInformation> getMetaInformation()
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

		private List<Note> getNotes()
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

					component.Properties.Add(prop);

				}

				list.Add(component);
			}
			return list;
		}

		private List<Threat> getThreats()
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
						threat.Description = xProperty.Element(nsArrays + "Value").Value;
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
						threat.Justification = xProperty.Element(nsArrays + "Value").Value;
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

						if (customPropName == "Data Asset")
						{

							threat.DataAsset = xProperty.Element(nsArrays + "Value").Value;

						}

						if (customPropName == "Actors")
						{

							threat.Actor = xProperty.Element(nsArrays + "Value").Value;

						}

						if (customPropName == "Issue references")
						{

							threat.IssueReferences = xProperty.Element(nsArrays + "Value").Value;

						}
					}
				}

				list.Add(threat);

			}

			return list.OrderBy(i => i.Id).ToList();
		}

		private string getMitigationStrategy(string category)
		{
			var strideKey = new string(category.Take(1).ToArray());
			return _dictionaries.MitigationStartegies.Where(i => i.Key == strideKey).FirstOrDefault().Value;
		}

		private static string getComponentPropertyValue(string guid, string PropertyName)
		{
			var val = string.Empty;

			var nameProperty = _componentProperties.Where(p => p.ComponentId == guid && p.DisplayName == PropertyName).FirstOrDefault();

			val = nameProperty.Value;

			if (string.IsNullOrEmpty(val))
			{
				val = _componentProperties[0].Value;
			}

			return val.Trim().Replace("\r", "").Replace("\n", "").Replace(" ", "");
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
