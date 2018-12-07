using System;

namespace TMReportSource
{
	public class Threat
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Priority { get; set; }
		public string Interaction { get; set; }
		public string InteractionImage { get; set; }
		public string State { get; set; }
		public string Category { get; set; }
		public string MitigationStrategy { get; set; }
		public string Actor { get; set; }
		public string Justification { get; set; }
		public string ShortDescription { get; set; }
		public string Description { get; set; }
		public string ChangedBy { get; set; }
		public DateTime ModifiedAt { get; set; }
		public string DataAsset { get; set; }
		public string SDLPhase { get; set; }
		public string IssueReferences { get; set; }
		public string PossibleMitigations { get; set; }
		public string FlowGuid { get; set; }
		public string SourceGuid { get; set; }
		public string TargetGuid { get; set; }
		public string FlowName { get; set; }
		public string SourceName { get; set; }
		public string TargetName { get; set; }
		public string FlowOutOfScope{ get; set; }
		public string SourceOutOfScope { get; set; }
		public string TargetOutOfScope { get; set; }
		public string FlowOutOfScopeReason { get; set; }
		public string SourceOutOfScopeReason { get; set; }
		public string TargetOutOfScopeReason { get; set; }
	}
}
