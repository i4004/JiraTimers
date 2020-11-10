using System.Threading.Tasks;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsClient
	{
		Task<string> CheckConnectionAsync();

		Task<IItsIssue> GetIssue(string issueKey);
	}
}