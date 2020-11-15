using System.Collections.Generic;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsIssuesStore
	{
		IList<IItsTrackingIssue> Load();

		void Save(IList<IItsTrackingIssue> items);
	}
}