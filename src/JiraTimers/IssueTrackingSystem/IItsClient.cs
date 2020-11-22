using System.Threading.Tasks;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsClient
	{
		public string? LastOperationResult { get; }

		Task<string?> CheckConnectionAsync();

		Task<IItsIssue?> GetIssueAsync(string issueKey);

		Task<bool> LogWork(string issueKey, WorkLog workLog);
	}
}