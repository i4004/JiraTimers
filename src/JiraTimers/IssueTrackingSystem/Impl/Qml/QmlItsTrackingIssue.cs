using JiraTimers.Json;
using Newtonsoft.Json;
using Qml.Net;

namespace JiraTimers.IssueTrackingSystem.Impl.Qml
{
	public class QmlItsTrackingIssue : IItsTrackingIssue
	{
		[JsonConverter(typeof(ConcreteConverter<QmlItsIssue>))]
		public IItsIssue Issue { get; set; }

		[NotifySignal]
		public string Time { get; set; }
	}
}