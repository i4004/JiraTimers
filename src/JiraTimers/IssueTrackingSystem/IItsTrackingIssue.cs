using System;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsTrackingIssue
	{
		public IItsIssue Issue { get; }

		public DateTime TimerStartTime { get; set; }
		public TimeSpan ElapsedTime { get; set; }

		void StartTimer();

		void StopTimer();

		void ResetTimer();
	}
}