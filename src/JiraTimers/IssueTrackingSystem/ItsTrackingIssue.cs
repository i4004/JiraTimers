using JiraTimers.Json;
using Newtonsoft.Json;
using Qml.Net;

namespace JiraTimers.IssueTrackingSystem
{
	public class ItsTrackingIssue : IItsTrackingIssue
	{
		[JsonConverter(typeof(ConcreteConverter<ItsIssue>))]
		public IItsIssue Issue { get; set; }

		[NotifySignal]
		public string Time { get; set; }
	}
}