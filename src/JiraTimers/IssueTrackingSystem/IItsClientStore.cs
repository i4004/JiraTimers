using System.Threading.Tasks;

namespace JiraTimers.IssueTrackingSystem
{
	public interface IItsClientStore
	{
		public bool IsConnected { get; }

		public bool ReadyToConnect();

		public Task<string> TryCreateItsClientAsync();

		public Task<string> TestConnectionAsync(string url, string userName, string userPassword);
	}
}