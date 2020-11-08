using Qml.Net;

namespace JiraTimers.IssueTrackingSystem
{
	public class ItsTrackingIssue : IItsTrackingIssue
	{
		[NotifySignal]
		public string Name { get; set; }
	}
}