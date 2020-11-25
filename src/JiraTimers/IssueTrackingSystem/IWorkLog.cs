using System;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IWorkLog
	{
		string? TimeSpent { get; set; }

		DateTime StartTime { get; set; }
		string FormattedStartTime { get; }

		string? Comment { get; set; }
		WorkLogStrategy Strategy { get; set; }
		string? NewEstimate { get; set; }
	}
}