using System.Collections.Generic;
using JiraTimers.IssueTrackingSystem;

namespace JiraTimers.Settings
{
	public interface IIssuesStore
	{
		IList<IItsTrackingIssue> Load();

		void Save(IList<IItsTrackingIssue> items);
	}
}