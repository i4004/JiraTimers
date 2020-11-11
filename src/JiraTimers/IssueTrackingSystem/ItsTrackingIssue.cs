using System;
using Qml.Net;

namespace JiraTimers.IssueTrackingSystem
{
	public class ItsTrackingIssue : IItsTrackingIssue
	{
		public ItsTrackingIssue(IItsIssue baseIssue)
		{
			Issue = baseIssue ?? throw new ArgumentNullException(nameof(baseIssue));
		}

		public IItsIssue Issue { get; }

		[NotifySignal]
		public string Time { get; set; }
	}
}