using System.Threading.Tasks;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsClientFactory
	{
		public Task<IItsClient> CreateAsync(string url, string userName, string userPassword);
	}
}