using System.Collections.Generic;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsTrackingIssuesList
	{
		public IList<IItsTrackingIssue> Items { get; }

		public void AddItem(IItsTrackingIssue issue);

		IItsTrackingIssue GetIssueByID(string issueID);

		void UpdateItem(string id, IItsIssue issue);

		void RemoveItem(string id);
	}
}