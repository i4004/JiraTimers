using System.Threading.Tasks;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsTrackingIssuesListController
	{
		void CreateNewIssue();

		Task<bool> RefreshIssueInfoAsync(string issueID, string issueKey);

		void RemoveIssue(string issueID);

		void StartIssueTimer(string issueID);

		void StopIssueTimer(string issueID);

		void ResetIssueTimer(string issueID);

		Task<bool> LogWork(string issueID, IWorkLog workLog);
	}
}