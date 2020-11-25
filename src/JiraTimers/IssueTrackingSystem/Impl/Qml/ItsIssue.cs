using Qml.Net;

namespace JiraTimers.IssueTrackingSystem.Impl.Qml
{
	public class ItsIssue : IItsIssue
	{
		public string? ID { get; set; }

		[NotifySignal]
		public string? Key { get; set; }

		[NotifySignal]
		public string? Summary { get; set; }

		[NotifySignal]
		public string? Assignee { get; set; }
	}
}