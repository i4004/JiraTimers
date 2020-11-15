using System.Collections.Generic;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsTrackingIssuesList
	{
		public IList<IItsTrackingIssue> Items { get; }

		void CreateNewItem();

		void UpdateItem(string id, IItsIssue issue);

		void RemoveItem(string id);
	}
}