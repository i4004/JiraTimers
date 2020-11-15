using System.Collections.Generic;
using JiraTimers.IssueTrackingSystem;

namespace JiraTimers.Settings
{
	public interface IIssuesSettings
	{
		IList<IItsTrackingIssue> Load();

		void Save(IList<IItsTrackingIssue> items);
	}
}