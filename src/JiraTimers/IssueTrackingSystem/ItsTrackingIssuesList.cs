using System.Collections.Generic;

namespace JiraTimers.IssueTrackingSystem
{
	public class ItsTrackingIssuesList : IItsTrackingIssuesList
	{
		public ItsTrackingIssuesList()
		{
			Items.Add(new ItsTrackingIssue { Name = "Issue 1" });
			Items.Add(new ItsTrackingIssue { Name = "Issue 2" });
		}

		public IList<IItsTrackingIssue> Items { get; } = new List<IItsTrackingIssue>();
	}
}