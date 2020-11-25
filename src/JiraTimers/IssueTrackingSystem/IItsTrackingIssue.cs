using System;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsTrackingIssue
	{
		public IItsIssue? Issue { get; }

		public DateTime? StartTime { get; set; }

		public TimeSpan ElapsedTime { get; set; }
		public string FormattedElapsedTime { get; }
		public string TextElapsedTime { get; }

		public bool IsTimerRunning { get; }

		void StartTimer();

		void StopTimer();

		void ResetTimer();
	}
}