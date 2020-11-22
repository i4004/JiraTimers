using System;
using Qml.Net;

namespace JiraTimers.IssueTrackingSystem.Impl.Qml
{
	public class WorkLog : IWorkLog
	{
		public string? TimeSpent { get; set; }
		public DateTime StartDate { get; set; }

		public string? Comment { get; set; }

		[NotifySignal]
		public WorkLogStrategy Strategy { get; set; }

		public string? NewEstimate { get; set; }
	}
}