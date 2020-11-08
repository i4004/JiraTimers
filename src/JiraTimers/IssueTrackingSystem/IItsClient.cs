using System.Threading.Tasks;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsClient
	{
		Task<string> CheckConnectionAsync();
	}
}