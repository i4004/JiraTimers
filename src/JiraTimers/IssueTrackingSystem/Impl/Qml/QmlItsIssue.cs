using Qml.Net;

namespace JiraTimers.IssueTrackingSystem.Impl.Qml
{
	public class QmlItsIssue : IItsIssue
	{
		public string ID { get; set; }

		[NotifySignal]
		public string Key { get; set; }

		[NotifySignal]
		public string Summary { get; set; }
	}
}