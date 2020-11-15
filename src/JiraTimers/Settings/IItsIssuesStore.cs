using System.Collections.Generic;
using JiraTimers.IssueTrackingSystem;

namespace JiraTimers.Settings
{
	public interface IItsIssuesStore
	{
		IList<IItsTrackingIssue> Load();

		void Save(IList<IItsTrackingIssue> items);
	}
}