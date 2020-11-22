using System;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IWorkLog
	{
		string? TimeSpent { get; set; }
		DateTime StartDate { get; set; }
		string? Comment { get; set; }
		WorkLogStrategy Strategy { get; set; }
		string? NewEstimate { get; set; }
	}
}