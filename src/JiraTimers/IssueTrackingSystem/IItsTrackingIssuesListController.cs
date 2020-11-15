using System.Threading.Tasks;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsTrackingIssuesListController
	{
		void CreateNewIssue();

		Task<bool> RefreshIssueInfoAsync(string issueID, string issueKey);

		void RemoveIssue(string issueID);
	}
}