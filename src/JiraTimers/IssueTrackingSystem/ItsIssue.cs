using Qml.Net;

namespace JiraTimers.IssueTrackingSystem
{
	public class ItsIssue : IItsIssue
	{
		public string ID { get; set; }

		[NotifySignal]
		public string Key { get; set; }

		[NotifySignal]
		public string Summary { get; set; }
	}
}