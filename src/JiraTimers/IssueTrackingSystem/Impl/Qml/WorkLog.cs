using System;
using Qml.Net;

namespace JiraTimers.IssueTrackingSystem.Impl.Qml
{
	public class WorkLog : IWorkLog
	{
		private WorkLogStrategy _strategy;

		public string? TimeSpent { get; set; }
		public DateTime StartDate { get; set; }

		public string? Comment { get; set; }

		[NotifySignal]
		public WorkLogStrategy Strategy
		{
			get => _strategy;
			set
			{
				_strategy = value;

				this.ActivateSignal("strategyChanged");
			}
		}

		public string? NewEstimate { get; set; }
	}
}