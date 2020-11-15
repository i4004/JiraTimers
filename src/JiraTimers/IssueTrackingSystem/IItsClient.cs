using System.Threading.Tasks;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsClient
	{
		public bool LastOperationStatus { get; }
		public string LastOperationResult { get; }

		Task<string> CheckConnectionAsync();

		Task<IItsIssue> GetIssueAsync(string issueKey);
	}
}