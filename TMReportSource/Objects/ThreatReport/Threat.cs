using System;

namespace TMReportSource
{
	public class Threat: ICloneable
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Priority { get; set; }
		public int PriorityWeight { get; set; }
		public string Interaction { get; set; }
		public string InteractionImage { get; set; }
		public string State { get; set; }
		public string Category { get; set; }
		public string MitigationStrategy { get; set; }
		public string Actors { get; set; }
		public string Actions { get; set; }
		public string Justification { get; set; }
		public string ShortDescription { get; set; }
		public string Description { get; set; }
		public string ChangedBy { get; set; }
		public DateTime ModifiedAt { get; set; }
		public string Assets { get; set; }
		public string SDLPhase { get; set; }
		public string IssueReference { get; set; }
		public string IssueStatus { get; set; }
		public string PossibleMitigations { get; set; }
		public string FlowGuid { get; set; }
		public string SourceGuid { get; set; }
		public string TargetGuid { get; set; }
		public string FlowName { get; set; }
		public string SourceName { get; set; }
		public string TargetName { get; set; }
		public string FlowOutOfScope { get; set; }
		public string SourceOutOfScope { get; set; }
		public string TargetOutOfScope { get; set; }
		public string FlowOutOfScopeReason { get; set; }
		public string SourceOutOfScopeReason { get; set; }
		public string TargetOutOfScopeReason { get; set; }
		public string Impact { get; set; }
		public string AttackVectors { get; set; }
		public string Likelihood { get; set; }
		public string MitigatedComponents { get; set; }

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
