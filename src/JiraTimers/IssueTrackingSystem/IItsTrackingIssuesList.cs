using System.Collections.Generic;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsTrackingIssuesList
	{
		public IList<IItsTrackingIssue> Items { get; }
	}
}