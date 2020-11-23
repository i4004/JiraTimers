using System;
using System.Collections.Generic;
using System.Linq;

namespace JiraTimers.IssueTrackingSystem.Impl
{
	public class ItsTrackingIssuesList : IItsTrackingIssuesList
	{
		public IList<IItsTrackingIssue> Items { get; } = new List<IItsTrackingIssue>();

		public void AddItem(IItsTrackingIssue issue) => Items.Add(issue);

		public IItsTrackingIssue GetIssueByID(string issueID) => Items.Single(x => x.Issue?.ID == issueID);

		public void UpdateItem(string id, IItsIssue issue)
		{
			if (string.IsNullOrEmpty(id))
				throw new ArgumentException("Value cannot be null or empty.", nameof(id));

			var existingIssue = Items.First(x => x.Issue?.ID == id);

			if (existingIssue.Issue == null)
				throw new InvalidOperationException("Issue is null");

			existingIssue.Issue.Key = issue.Key;
			existingIssue.Issue.Summary = issue.Summary;
			existingIssue.Issue.Assignee = issue.Assignee;
		}

		public void RemoveItem(string id)
		{
			if (string.IsNullOrEmpty(id))
				throw new ArgumentException("Value cannot be null or empty.", nameof(id));

			Items.Remove(Items.First(x => x.Issue?.ID == id));
		}
	}
}