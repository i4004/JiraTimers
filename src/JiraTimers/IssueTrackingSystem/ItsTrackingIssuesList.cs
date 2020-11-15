using System;
using System.Collections.Generic;
using System.Linq;

namespace JiraTimers.IssueTrackingSystem
{
	public class ItsTrackingIssuesList : IItsTrackingIssuesList
	{
		public ItsTrackingIssuesList()
		{
		}

		public IList<IItsTrackingIssue> Items { get; } = new List<IItsTrackingIssue>();

		public void CreateNewItem()
		{
			Items.Add(new ItsTrackingIssue(new ItsIssue
			{
				ID = Guid.NewGuid().ToString()
			}));
		}

		public void UpdateItem(string id, IItsIssue issue)
		{
			if (string.IsNullOrEmpty(id))
				throw new ArgumentException("Value cannot be null or empty.", nameof(id));

			var existingIssue = Items.First(x => x.Issue.ID == id);

			existingIssue.Issue.Key = issue.Key;
			existingIssue.Issue.Summary = issue.Summary;
		}

		public void RemoveItem(string id)
		{
			if (string.IsNullOrEmpty(id))
				throw new ArgumentException("Value cannot be null or empty.", nameof(id));

			Items.Remove(Items.First(x => x.Issue.ID == id));
		}
	}
}