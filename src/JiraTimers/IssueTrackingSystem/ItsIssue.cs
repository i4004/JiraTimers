using Qml.Net;

namespace JiraTimers.IssueTrackingSystem
{
	public class ItsIssue : IItsIssue
	{
		[NotifySignal]
		public string Key { get; set; }

		[NotifySignal]
		public string Summary { get; set; }
	}
}