using System.Threading.Tasks;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsClient
	{
		Task<string> CheckConnectionAsync();

		Task<IItsIssue> GetIssueAsync(string issueKey);
	}
}