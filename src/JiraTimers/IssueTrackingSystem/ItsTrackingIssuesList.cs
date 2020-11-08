using System.Collections.Generic;

namespace JiraTimers.IssueTrackingSystem
{
	public class ItsTrackingIssuesList : IItsTrackingIssuesList
	{
		public ItsTrackingIssuesList()
		{
			Items.Add(new ItsTrackingIssue { Name = "DEV-125", Time = "00:01:25", Description = "fix an error in task" });
			Items.Add(new ItsTrackingIssue { Name = "JIRATM-25", Time = "00:15:40", Description = "Linux (Ubuntu) installation package setup/development" });
			Items.Add(new ItsTrackingIssue { Name = "JIRATM-26", Time = "02:10:40", Description = "Windows Chocolatey installation package setup/development" });
		}

		public IList<IItsTrackingIssue> Items { get; } = new List<IItsTrackingIssue>();
	}
}