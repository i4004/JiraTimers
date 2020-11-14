using System;
using System.Collections.Generic;
using System.Linq;

namespace JiraTimers.IssueTrackingSystem
{
	public class ItsTrackingIssuesList : IItsTrackingIssuesList
	{
		public ItsTrackingIssuesList()
		{
			Items.Add(new ItsTrackingIssue(new ItsIssue
			{
				ID = new Guid().ToString(),
				Key = "DEV-125",
				Summary = "fix an error in task"
			})
			{
				Time = "00:01:25"
			});

			Items.Add(new ItsTrackingIssue(new ItsIssue
			{
				ID = new Guid().ToString(),
				Key = "JIRATM-25",
				Summary = "Linux (Ubuntu) installation package setup/development"
			})
			{
				Time = "00:01:25"
			});

			Items.Add(new ItsTrackingIssue(new ItsIssue
			{
				ID = new Guid().ToString(),
				Key = "JIRATM-26",
				Summary = "Windows Chocolatey installation package setup/development"
			})
			{
				Time = "00:01:25"
			});
		}

		public IList<IItsTrackingIssue> Items { get; } = new List<IItsTrackingIssue>();

		public void CreateNewItem()
		{
			Items.Add(new ItsTrackingIssue(new ItsIssue
			{
				ID = new Guid().ToString()
			}));
		}

		public void RemoveItem(string id)
		{
			if (string.IsNullOrEmpty(id))
				throw new ArgumentException("Value cannot be null or empty.", nameof(id));

			Items.Remove(Items.First(x => x.Issue.ID == id));
		}
	}
}