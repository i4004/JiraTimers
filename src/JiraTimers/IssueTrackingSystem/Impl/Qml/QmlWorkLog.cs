using System;
using Qml.Net;

namespace JiraTimers.IssueTrackingSystem.Impl.Qml
{
	public class QmlWorkLog : IWorkLog
	{
		private WorkLogStrategy _strategy;

		private DateTime? _startTime;

		public string? TimeSpent { get; set; }
		public DateTime StartTime
		{
			get => _startTime ?? DateTime.Now;
			set => _startTime = value;
		}

		[NotifySignal]
		public string FormattedStartTime => StartTime.ToString("yyyy-MM-dd HH:mm");

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