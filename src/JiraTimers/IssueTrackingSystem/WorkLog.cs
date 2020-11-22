using System;

namespace JiraTimers.IssueTrackingSystem
{
	public class WorkLog
	{
		public string? TimeSpent { get; set; }
		public DateTime StartDate { get; set; }

		public string? Comment { get; set; }

		public WorkLogStrategy Strategy { get; set; }

		public string? NewEstimate { get; set; }
	}
}