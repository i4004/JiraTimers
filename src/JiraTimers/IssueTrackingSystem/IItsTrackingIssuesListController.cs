using System.Threading.Tasks;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsTrackingIssuesListController
	{
		Task<bool> RefreshIssueInfoAsync(string issueID, string issueKey);
	}
}